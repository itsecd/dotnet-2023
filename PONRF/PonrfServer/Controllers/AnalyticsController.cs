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
    private readonly ILogger<AuctionController> _logger;

    private readonly IDbContextFactory<PonrfContext> _contextFactory;

    private readonly IMapper _mapper;

    /// <summary>
    /// Constructor for AnalyticsController
    /// </summary>
    /// <param name="logger"></param>
    /// <param name="contextFactory"></param>
    /// <param name="mapper"></param>
    public AnalyticsController(ILogger<AuctionController> logger, IDbContextFactory<PonrfContext> contextFactory, IMapper mapper)
    {
        _logger = logger;
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

    ///// <summary>
    ///// Get infomation about auctions without full sales
    ///// </summary>
    ///// <returns>AuctionGetDto</returns>
    //[HttpGet("auctions_without_full_sales")]
    //public async Task<ActionResult<AuctionGetDto>> AuctionsWithoutFullSales()
    //{
    //    await using var context = await _contextFactory.CreateDbContextAsync();
    //    var request = await (from auction in context.Auctions.Include(auction => auction.Id)
    //                         join privatizedBuilding in context.PrivatizedBuildings.Include(privatizedBuilding => privatizedBuilding)
    //                         on auction.Id equals privatizedBuilding.Auction.Id
    //                         join building in context.Buildings.Include(building => building.Id)
    //                         on privatizedBuilding.Building.RegistNum equals building.RegistNum
    //                         where privatizedBuilding.Customer.Passport == null
    //                         select _mapper.Map<AuctionGetDto>(auction)).ToListAsync();
    //    return Ok(request);
    //}

    ///// <summary>
    ///// Get information about customers and total amount of privatized buildings in district
    ///// </summary>
    ///// <param name="district">District for search</param>
    ///// <returns>Customers and total amount of privatized buildings in district</returns>
    //[HttpGet("customers_and_total_amount_in_district/{district}")]
    //public async Task<IActionResult> CustomersAndTotalAmountInDistrict(string district)
    //{
    //    await using var context = await _contextFactory.CreateDbContextAsync();
    //    var customers = await (from privatizedBuilding in context.PrivatizedBuildings.Include(privatizedBuilding => privatizedBuilding.Id)
    //                           where privatizedBuilding.Building.District == district
    //                           from customer in context.Customers.Include(customer => customer.Id)
    //                           where customer.Passport == privatizedBuilding.Customer.Passport
    //                           orderby customer.Fio
    //                           select _mapper.Map<CustomerGetDto>(customer)).ToListAsync();
    //    var totalAmount = await (from privatizedBuilding in context.PrivatizedBuildings.Include(privatizedBuilding => privatizedBuilding)
    //                             from customer in context.Customers.Include(customer => customer.Id)
    //                             where customer.Passport == privatizedBuilding.Customer.Passport
    //                             join building in context.Buildings.Include(building => building.Id) on privatizedBuilding.Building.RegistNum equals building.RegistNum
    //                             where building.District == district
    //                             select privatizedBuilding.SecondCost).SumAsync();
    //    var result = new { customers, totalAmount };
    //    return Ok(result);
    //}

    ///// <summary>
    ///// Get addresses of auction participants
    ///// </summary>
    ///// <returns>Addresses of auction participants</returns>
    //[HttpGet("addresses_of_auction_participants")]
    //public async Task<IActionResult> AddressesOfAuctionParticipants()
    //{
    //    await using var context = await _contextFactory.CreateDbContextAsync();
    //    var date = DateTime.Parse("2023-02-02");
    //    var request = await (from customer in context.Customers
    //                         join privatizedBuilding in context.PrivatizedBuildings on customer.Passport equals privatizedBuilding.Customer?.Passport
    //                         join auction in context.Auctions on privatizedBuilding.Auction?.Id equals auction.Id
    //                         where auction.Date == date
    //                         select customer.Address).ToListAsync();
    //    return Ok(request);
    //}

    ///// <summary>
    ///// Get top 5 customers who spent the most amount of money
    ///// </summary>
    ///// <returns>Top-5 customers</returns>
    //[HttpGet("top_five_customers")]
    //public async Task<IActionResult> TopFiveCustomers()
    //{
    //    await using var context = await _contextFactory.CreateDbContextAsync();
    //    var request = await (from customer in context.Customers
    //                         join privatizedBuilding in context.PrivatizedBuildings on customer.Passport equals privatizedBuilding.Customer?.Passport
    //                         group privatizedBuilding by new { privatizedBuilding.Customer?.Fio } into privBuild
    //                         select new
    //                         {
    //                             privBuild.Key.Fio,
    //                             Total = privBuild.Sum(lot => lot.SecondCost)
    //                         }).OrderByDescending(lot => lot.Total).Take(5).ToListAsync();
    //    return Ok(request);
    //}

    ///// <summary>
    ///// Get infomation about most profitable auctions
    ///// </summary>
    ///// <returns>Auction</returns>
    //[HttpGet("most_profitable_auctions")]
    //public async Task<IActionResult> MostProfitableAuctions()
    //{
    //    await using var context = await _contextFactory.CreateDbContextAsync();
    //    var request = await (from auction in context.Auctions.Include(auction => auction.Id)
    //                         join privatizedBuilding in context.PrivatizedBuildings.Include(privatizedBuilding => privatizedBuilding.Id)
    //                         on auction.Id == privatizedBuilding.Auction.Id
    //                         where privatizedBuilding.SecondCost != int.MinValue
    //                         group privatizedBuilding by new { privatizedBuilding.Auction.Organizer } into privBuild
    //                         select new
    //                         {
    //                             privBuild.Key.Organizer,
    //                             Profit = privBuild.Sum(lot => lot.SecondCost - lot.FirstCost)
    //                         }).OrderByDescending(lot => lot.Profit).Take(2).ToListAsync();
    //    return Ok(request);
    //}
}
