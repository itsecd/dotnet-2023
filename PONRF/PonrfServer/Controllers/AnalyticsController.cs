using AutoMapper;
using Microsoft.AspNetCore.Mvc;
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

    private readonly IPonrfRepository _ponrfRepository;

    private readonly IMapper _mapper;

    /// <summary>
    /// Constructor for AnalyticsController
    /// </summary>
    /// <param name="logger"></param>
    /// <param name="ponrfRepository"></param>
    /// <param name="mapper"></param>
    public AnalyticsController(ILogger<AuctionController> logger, IPonrfRepository ponrfRepository, IMapper mapper)
    {
        _logger = logger;
        _ponrfRepository = ponrfRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Get infomation about all customers
    /// </summary>
    /// <returns>CustomerGetDto</returns>
    [HttpGet("view_all_customers")]
    public ActionResult<CustomerGetDto> ViewAllCustomers()
    {
        var request = (from customer in _ponrfRepository.Customers
                       select _mapper.Map<CustomerGetDto>(customer)).ToList();
        return Ok(request);
    }

    /// <summary>
    /// Get infomation about auctions without full sales
    /// </summary>
    /// <returns>AuctionGetDto</returns>
    [HttpGet("auctions_without_full_sales")]
    public ActionResult<AuctionGetDto> AuctionsWithoutFullSales()
    {
        var request = (from auction in _ponrfRepository.Auctions
                       join privatizedBuilding in _ponrfRepository.PrivatizedBuildings on auction.Id equals privatizedBuilding.Auction?.Id
                       join building in _ponrfRepository.Buildings on privatizedBuilding.Building?.RegistNum equals building.RegistNum
                       where privatizedBuilding.Customer?.Passport == null
                       select _mapper.Map<AuctionGetDto>(auction)).ToList();
        return Ok(request);
    }

    /// <summary>
    /// Get information about customers and total amount of privatized buildings in district
    /// </summary>
    /// <returns></returns>
    [HttpGet("customers_and_total_amount_in_district")]
    public IActionResult CustomersAndTotalAmountInDistrict()
    {
        var customers = (from customer in _ponrfRepository.Customers
                         join privatizedBuilding in _ponrfRepository.PrivatizedBuildings on customer.Passport equals privatizedBuilding.Customer?.Passport
                         join building in _ponrfRepository.Buildings on privatizedBuilding.Building?.RegistNum equals building.RegistNum
                         where building.District == "Кировский"
                         orderby customer.Fio
                         select _mapper.Map<CustomerGetDto>(customer)).ToList();
        var totalAmount = (from privatizedBuilding in _ponrfRepository.PrivatizedBuildings
                           join customer in _ponrfRepository.Customers on privatizedBuilding.Customer?.Passport equals customer.Passport
                           join building in _ponrfRepository.Buildings on privatizedBuilding.Building?.RegistNum equals building.RegistNum
                           where building.District == "Кировский"
                           select privatizedBuilding.SecondCost).Sum();
        var result = new { customers, totalAmount };
        return Ok(result);
    }

    /// <summary>
    /// Get addresses of auction participants
    /// </summary>
    /// <returns></returns>
    [HttpGet("addresses_of_auction_participants")]
    public IActionResult AddressesOfAuctionParticipants()
    {
        var date = DateTime.Parse("2023-02-02");
        var request = (from customer in _ponrfRepository.Customers
                       join privatizedBuilding in _ponrfRepository.PrivatizedBuildings on customer.Passport equals privatizedBuilding.Customer?.Passport
                       join auction in _ponrfRepository.Auctions on privatizedBuilding.Auction?.Id equals auction.Id
                       where auction.Date == date
                       select customer.Address).ToList();
        return Ok(request);
    }

    /// <summary>
    /// Get top 5 customers who spent the most amount of money
    /// </summary>
    /// <returns></returns>
    [HttpGet("top_five_customers")]
    public IActionResult TopFiveCustomers()
    {
        var request = (from customer in _ponrfRepository.Customers
                       join privatizedBuilding in _ponrfRepository.PrivatizedBuildings on customer.Passport equals privatizedBuilding.Customer?.Passport
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
    /// <returns></returns>
    [HttpGet("most_profitable_auctions")]
    public IActionResult MostProfitableAuctions()
    {
        var request = (from auction in _ponrfRepository.Auctions
                       join privatizedBuilding in _ponrfRepository.PrivatizedBuildings on auction.Id equals privatizedBuilding.Auction?.Id
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
