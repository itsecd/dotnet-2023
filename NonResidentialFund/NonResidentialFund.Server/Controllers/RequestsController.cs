using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NonResidentialFund.Model;
using NonResidentialFund.Server.Dto;

namespace NonResidentialFund.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RequestsController : ControllerBase
{
    private readonly IDbContextFactory<NonResidentialFundContext> _contextFactory;
    private readonly ILogger<RequestsController> _logger;
    private readonly IMapper _mapper;

    public RequestsController(IDbContextFactory<NonResidentialFundContext> contextFactory, ILogger<RequestsController> logger, IMapper mapper)
    {
        _contextFactory = contextFactory;
        _logger = logger;
        _mapper = mapper;
    }

    /// <summary>
    /// Returns information about all customers
    /// </summary>
    /// <returns>List of buyers</returns>
    [HttpGet("GetAllCustomers")]
    public async Task<IEnumerable<BuyerGetDto>> GetAllCustomers()
    {
        _logger.LogInformation("Get all buyers");
        using var ctx = await _contextFactory.CreateDbContextAsync();
        return _mapper.Map<IEnumerable<BuyerGetDto>>(ctx.Buyers);
    }

    /// <summary>
    /// Output information on auctions in which all auctioned buildings were not sold
    /// </summary>
    /// <returns></returns>
    [HttpGet("GetAuctionsNotAllLotsSold")]
    public async Task<IEnumerable<AuctionGetDto>> GetAuctionsNotAllLotsSold()
    {
        _logger.LogInformation("Get information on auctions in which all auctioned buildings were not sold");
        using var ctx = await _contextFactory.CreateDbContextAsync();

        var result = await (from auction in ctx.Auctions
                            join countBoughtInAuction in (
                                  from privatized in ctx.Privatized
                                  group privatized by privatized.AuctionId into privGroup
                                  select new
                                  {
                                      privGroup.First().AuctionId,
                                      countBought = privGroup.Count()
                                  })
                                  on auction.AuctionId equals countBoughtInAuction.AuctionId
                            where countBoughtInAuction.countBought != auction.Buildings.Count
                            select auction).ToListAsync();

        return _mapper.Map<IEnumerable<AuctionGetDto>>(result);
    }

    /// <summary>
    /// Output the information about the buyers who received the nonresidential fund for a certain the district of the city, and the total amount of privatized fund of the district. Arrange by full name
    /// </summary>
    /// <param name="id">District id</param>
    /// <returns>List of buyers</returns>
    [HttpGet("GetBuyersInSpecifiedDistrict/{id}")]
    public async Task<IEnumerable<BuyerGetDto>> GetBuyersInSpecifiedDistrict(int id)
    {
        using var ctx = await _contextFactory.CreateDbContextAsync();
        var result = await (from buyer in ctx.Buyers
                            join privatized in ctx.Privatized on buyer.BuyerId equals privatized.BuyerId
                            join building in ctx.Buildings on privatized.RegistrationNumber equals building.RegistrationNumber
                            join districtCountSold in (
                                  from building in ctx.Buildings
                                  join privatized in ctx.Privatized on building.RegistrationNumber equals privatized.RegistrationNumber
                                  group new { privatized, building } by building.DistrictId into privGroupByDistrict
                                  select new
                                  {
                                      privGroupByDistrict.First().building.DistrictId,
                                      CountSold = privGroupByDistrict.Count()
                                  }
                            ) on building.DistrictId equals districtCountSold.DistrictId
                            where building.DistrictId == id
                            orderby buyer.LastName, buyer.FirstName
                            select buyer).ToListAsync();
        return _mapper.Map<IEnumerable<BuyerGetDto>>(result);
    }

    /// <summary>
    /// Find the addresses of all buyers participating in the auction of the specified date (Date format: 2022-03-21)
    /// </summary>
    /// <returns></returns>
    [HttpGet("GetAddressesOfAuctionParticipantsInSpecifiedDate/{date:DateTime}")]
    public async Task<IEnumerable<BuyerAddressDto>> AddressesOfAuctionParticipantsInSpecifiedDate(DateTime date)
    {
        using var ctx = await _contextFactory.CreateDbContextAsync();
        var result = from auction in ctx.Auctions
                     from participant in auction.Buyers
                     join buyer in ctx.Buyers on participant.BuyerId equals buyer.BuyerId
                     where auction.Date == date
                     select buyer;

        return _mapper.Map<IEnumerable<BuyerAddressDto>>(result);
    }

    /// <summary>
    /// Returns the top 5 buyers who spent the most money
    /// </summary>
    /// <returns>List of buyers ids and their expenses </returns>
    [HttpGet("GetTopBuyersByExpenses")]
    public async Task<IEnumerable<BuyerExpensesDto>> GetTopBuyersByExpenses()
    {
        using var ctx = await _contextFactory.CreateDbContextAsync();
        var result = await (from privatized in ctx.Privatized
                            join buyer in ctx.Buyers on privatized.BuyerId equals buyer.BuyerId
                            group privatized by privatized.BuyerId into privGRoup
                            orderby privGRoup.Sum(privatized => privatized.EndPrice) descending
                            select new BuyerExpensesDto()
                            {
                                BuyerId = privGRoup.First().BuyerId,
                                Expenses = privGRoup.Sum(privatized => privatized.EndPrice)
                            }).Take(5).ToListAsync();
        return result;
    }

    /// <summary>
    /// Returns the data on the auctions that brought the most profit
    /// </summary>
    /// <returns></returns>
    [HttpGet("GetAuctionsWithHighestIncome")]
    public async Task<IEnumerable<AuctionIncomeDto>> GetAuctionsWithHighestIncome()
    {
        using var ctx = await _contextFactory.CreateDbContextAsync();
        var result = await (from privatized in ctx.Privatized
                            join auction in ctx.Auctions on privatized.AuctionId equals auction.AuctionId
                            group privatized by privatized.AuctionId into privGRoup
                            orderby privGRoup.Sum(privatized => privatized.EndPrice - privatized.StartPrice) descending
                            select new AuctionIncomeDto
                            {
                                AuctionId = privGRoup.First().AuctionId,
                                Income = privGRoup.Sum(privatized => privatized.EndPrice - privatized.StartPrice)
                            }).ToListAsync();
        return result;
    }
}