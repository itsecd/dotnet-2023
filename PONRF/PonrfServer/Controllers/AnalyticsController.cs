using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore;
using PonrfDomain;
using PonrfServer.Dto;
using PonrfServer.Repository;

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
        await using var context = _contextFactory.CreateDbContext();
        var request = (from customer in context.Customers
                       select _mapper.Map<CustomerGetDto>(customer)).ToList();
        return Ok(request);
    }

    /// <summary>
    /// Get infomation about auctions without full sales
    /// </summary>
    /// <returns>AuctionGetDto</returns>
    [HttpGet("auctions_without_full_sales")]
    public async Task<ActionResult<AuctionGetDto>> AuctionsWithoutFullSales()
    {
        await using var context = _contextFactory.CreateDbContext();
        var request = (from auction in context.Auctions
                       join privatizedBuilding in context.PrivatizedBuildings on auction.Id equals privatizedBuilding.Auction?.Id
                       join building in context.Buildings on privatizedBuilding.Building?.RegistNum equals building.RegistNum
                       where privatizedBuilding.Customer?.Passport == null
                       select _mapper.Map<AuctionGetDto>(auction)).ToList();
        return Ok(request);
    }

    /// <summary>
    /// Get information about customers and total amount of privatized buildings in district
    /// </summary>
    /// <returns>Customers and total amount of privatized buildings in district</returns>
    [HttpGet("customers_and_total_amount_in_district")]
    public IActionResult CustomersAndTotalAmountInDistrict()
    {
        using var context = _contextFactory.CreateDbContext();
        var customers = (from customer in context.Customers
                         join privatizedBuilding in context.PrivatizedBuildings on customer.Passport equals privatizedBuilding.Customer?.Passport
                         join building in context.Buildings on privatizedBuilding.Building?.RegistNum equals building.RegistNum
                         where building.District == "Кировский"
                         orderby customer.Fio
                         select _mapper.Map<CustomerGetDto>(customer)).ToList();
        var totalAmount = (from privatizedBuilding in context.PrivatizedBuildings
                           join customer in context.Customers on privatizedBuilding.Customer?.Passport equals customer.Passport
                           join building in context.Buildings on privatizedBuilding.Building?.RegistNum equals building.RegistNum
                           where building.District == "Кировский"
                           select privatizedBuilding.SecondCost).Sum();
        var result = new { customers, totalAmount };
        return Ok(result);
    }

    /// <summary>
    /// Get addresses of auction participants
    /// </summary>
    /// <returns>Addresses of auction participants</returns>
    [HttpGet("addresses_of_auction_participants")]
    public IActionResult AddressesOfAuctionParticipants()
    {
        using var context = _contextFactory.CreateDbContext();
        var date = DateTime.Parse("2023-02-02");
        var request = (from customer in context.Customers
                       join privatizedBuilding in context.PrivatizedBuildings on customer.Passport equals privatizedBuilding.Customer?.Passport
                       join auction in context.Auctions on privatizedBuilding.Auction?.Id equals auction.Id
                       where auction.Date == date
                       select customer.Address).ToList();
        return Ok(request);
    }

    /// <summary>
    /// Get top 5 customers who spent the most amount of money
    /// </summary>
    /// <returns>Top-5 customers</returns>
    [HttpGet("top_five_customers")]
    public IActionResult TopFiveCustomers()
    {
        using var context = _contextFactory.CreateDbContext();
        var request = (from customer in context.Customers
                       join privatizedBuilding in context.PrivatizedBuildings on customer.Passport equals privatizedBuilding.Customer?.Passport
                       group privatizedBuilding by new { privatizedBuilding.Customer?.Fio } into privBuild
                       select new
                       {
                           privBuild.Key.Fio,
                           Total = privBuild.Sum(lot => lot.SecondCost)
                       }).OrderByDescending(lot => lot.Total).Take(5).ToList();
        return Ok(request);
    }

    /// <summary>
    /// Get infomation about most profitable auctions
    /// </summary>
    /// <returns>Auction</returns>
    [HttpGet("most_profitable_auctions")]
    public IActionResult MostProfitableAuctions()
    {
        using var context = _contextFactory.CreateDbContext();
        var request = (from auction in context.Auctions
                       join privatizedBuilding in context.PrivatizedBuildings on auction.Id equals privatizedBuilding.Auction?.Id
                       where privatizedBuilding.SecondCost != int.MinValue
                       group privatizedBuilding by new { privatizedBuilding.Auction?.Organizer } into privBuild
                       select new
                       {
                           privBuild.Key.Organizer,
                           Profit = privBuild.Sum(lot => lot.SecondCost - lot.FirstCost)
                       }).OrderByDescending(lot => lot.Profit).Take(2).ToList();
        return Ok(request);
    }
}
