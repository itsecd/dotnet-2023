using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PonrfDomain;
using PonrfServer.Dto;

namespace PonrfServer.Controllers;

/// <summary>
/// Analytics controller for requests
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class AnalyticsController : ControllerBase
{
    private readonly IDbContextFactory<PonrfContext> _contextFactory;

    private readonly IMapper _mapper;

    /// <summary>
    /// Constructor for AnalyticsController
    /// </summary>
    /// <param name="contextFactory"></param>
    /// <param name="mapper"></param>
    public AnalyticsController(IDbContextFactory<PonrfContext> contextFactory, IMapper mapper)
    {
        _contextFactory = contextFactory;
        _mapper = mapper;
    }


    /// <summary>
    /// Get infomation about all customers
    /// </summary>
    /// <returns>CustomerGetDto</returns>
    [HttpGet("view_all_customers")]
    public async Task<ActionResult<CustomerGetDto>> ViewAllCustomers()
    {
        await using var context = await _contextFactory.CreateDbContextAsync();
        var request = await (from customer in context.Customers
                             select _mapper.Map<CustomerGetDto>(customer)).ToListAsync();
        return Ok(request);
    }

    /// <summary>
    /// Get infomation about auctions without full sales
    /// </summary>
    /// <returns>AuctionGetDto</returns>
    [HttpGet("auctions_without_full_sales")]
    public async Task<ActionResult<AuctionGetDto>> AuctionsWithoutFullSales()
    {
        await using var context = await _contextFactory.CreateDbContextAsync();
        var request = await (from auction in context.Auctions
                             join privatizedBuilding in context.PrivatizedBuildings
                             on auction.Id equals privatizedBuilding.AuctionId
                             where privatizedBuilding.CustomerId == null
                             select _mapper.Map<AuctionGetDto>(auction)).ToListAsync();
        return Ok(request);
    }

    /// <summary>
    /// Get information about customers and total amount of privatized buildings in district
    /// </summary>
    /// <param name="district">District for search</param>
    /// <returns>Customers and total amount of privatized buildings in district</returns>
    [HttpGet("customers_and_total_amount_in_district/{district}")]
    public async Task<IActionResult> CustomersAndTotalAmountInDistrict(string district)
    {
        await using var context = await _contextFactory.CreateDbContextAsync();
        var customers = await (from building in context.Buildings
                               where building.District == district
                               join privatizedBuilding in context.PrivatizedBuildings
                               on building.Id equals privatizedBuilding.BuildingId
                               from customer in context.Customers
                               where customer.Id == privatizedBuilding.CustomerId
                               orderby customer.Fio
                               select _mapper.Map<CustomerGetDto>(customer)).ToListAsync();
        var totalAmount = await (from privatizedBuilding in context.PrivatizedBuildings
                                 join customer in context.Customers
                                 on privatizedBuilding.CustomerId equals customer.Id
                                 join building in context.Buildings
                                 on privatizedBuilding.BuildingId equals building.Id
                                 where building.District == district
                                 select privatizedBuilding.SecondCost).SumAsync();
        var result = new { customers, totalAmount };
        return Ok(result);
    }

    /// <summary>
    /// Get addresses of auction participants
    /// </summary>
    /// <param name="date">Date of the auction</param>
    /// <returns>Addresses of auction participants</returns>
    [HttpGet("addresses_of_auction_participants")]
    public async Task<IActionResult> AddressesOfAuctionParticipants(DateTime date)
    {
        await using var context = await _contextFactory.CreateDbContextAsync();
        var request = await (from customer in context.Customers
                             join privatizedBuilding in context.PrivatizedBuildings
                             on customer.Id equals privatizedBuilding.CustomerId
                             join auction in context.Auctions
                             on privatizedBuilding.AuctionId equals auction.Id
                             where auction.Date == date
                             select customer.Address).ToListAsync();
        return Ok(request);
    }

    /// <summary>
    /// Get top 5 customers who spent the most amount of money
    /// </summary>
    /// <returns>Top-5 customers</returns>
    [HttpGet("top_five_customers")]
    public async Task<IActionResult> TopFiveCustomers()
    {
        await using var context = await _contextFactory.CreateDbContextAsync();
        var request = await (from customer in context.Customers
                             join privatizedBuilding in context.PrivatizedBuildings
                             on customer.Id equals privatizedBuilding.CustomerId
                             group privatizedBuilding by new { privatizedBuilding.Customer!.Fio } into privBuild
                             select new
                             {
                                 privBuild.Key.Fio,
                                 Total = privBuild.Sum(lot => lot.SecondCost)
                             }).OrderByDescending(lot => lot.Total).Take(5).ToListAsync();
        return Ok(request);
    }

    /// <summary>
    /// Get infomation about most profitable auctions
    /// </summary>
    /// <returns>Top-2 auctions</returns>
    [HttpGet("most_profitable_auctions")]
    public async Task<IActionResult> MostProfitableAuctions()
    {
        await using var context = await _contextFactory.CreateDbContextAsync();
        var request = await (from auction in context.Auctions
                             join privatizedBuilding in context.PrivatizedBuildings
                             on auction.Id equals privatizedBuilding.AuctionId
                             where privatizedBuilding.SecondCost > 0
                             group privatizedBuilding by new { privatizedBuilding.Auction!.Organizer } into privBuild
                             select new
                             {
                                 privBuild.Key.Organizer,
                                 Profit = privBuild.Sum(lot => lot.SecondCost - lot.FirstCost)
                             }).OrderByDescending(lot => lot.Profit).Take(2).ToListAsync();
        return Ok(request);
    }
}
