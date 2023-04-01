using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NonResidentialFund.Server.Dto;
using NonResidentialFund.Server.Repository;

namespace NonResidentialFund.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RequestsController : ControllerBase
{
    private readonly ILogger<RequestsController> _logger;
    private readonly INonResidentialFundRepository _requestsRepository;
    private readonly IMapper _mapper;

    public RequestsController(ILogger<RequestsController> logger, INonResidentialFundRepository requestsRepository, IMapper mapper)
    {
        _logger = logger;
        _requestsRepository = requestsRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Returns information about all customers
    /// </summary>
    /// <returns>List of buyers</returns>
    [HttpGet("GetAllCustomers")]
    public IEnumerable<BuyerGetDto> GetAllCustomers()
    {
        _logger.LogInformation("Get all buyers");
        return _mapper.Map<IEnumerable<BuyerGetDto>>(_requestsRepository.Buyers);
    }

    /// <summary>
    /// Output information on auctions in which all auctioned buildings were not sold
    /// </summary>
    /// <returns></returns>
    [HttpGet("GetAuctionsNotAllLotsSold")]
    public IEnumerable<AuctionGetDto> GetAuctionsNotAllLotsSold()
    {
        _logger.LogInformation("Get information on auctions in which all auctioned buildings were not sold");
        var result = (from auction in _requestsRepository.Auctions
                      join countBoughtInAuction in (
                            from privatized in _requestsRepository.Privatized
                            group privatized by privatized.AuctionId into privGroup
                            select new
                            {
                                privGroup.First().AuctionId,
                                countBought = privGroup.Count()
                            })
                            on auction.AuctionId equals countBoughtInAuction.AuctionId
                      where countBoughtInAuction.countBought != auction.Buildings.Count
                      select auction).ToList();
        return _mapper.Map<IEnumerable<AuctionGetDto>>(result);
    }

    /// <summary>
    /// Output the information about the buyers who received the nonresidential fund for a certain the district of the city, and the total amount of privatized fund of the district. Arrange by full name
    /// </summary>
    /// <param name="id">District id</param>
    /// <returns>List of buyers</returns>
    [HttpGet("GetBuyersInSpecifiedDistrict/{id}")]
    public IEnumerable<BuyerGetDto> GetBuyersInSpecifiedDistrict(int id)
    {
        var result = (from buyer in _requestsRepository.Buyers
                      join privatized in _requestsRepository.Privatized on buyer.BuyerId equals privatized.BuyerId
                      join building in _requestsRepository.Buildings on privatized.RegistrationNumber equals building.RegistrationNumber
                      join districtCountSold in (
                            from building in _requestsRepository.Buildings
                            join privatized in _requestsRepository.Privatized on building.RegistrationNumber equals privatized.RegistrationNumber
                            group new { privatized, building } by building.DistrictId into privGroupByDistrict
                            select new
                            {
                                privGroupByDistrict.First().building.DistrictId,
                                CountSold = privGroupByDistrict.Count()
                            }
                      ).ToList() on building.DistrictId equals districtCountSold.DistrictId
                      where building.DistrictId == id
                      orderby buyer.LastName, buyer.FirstName
                      select buyer).ToList();
        return _mapper.Map<IEnumerable<BuyerGetDto>>(result);
    }

    /// <summary>
    /// Find the addresses of all buyers participating in the auction of the specified date (Date format: 2022-03-21)
    /// </summary>
    /// <returns></returns>
    [HttpGet("GetAddressesOfAuctionParticipantsInSpecifiedDate/{date:DateTime}")]
    public IEnumerable<BuyerAddressDto> AddressesOfAuctionParticipantsInSpecifiedDate(DateTime date)
    {
        var result = (from auction in _requestsRepository.Auctions
                      from participant in auction.Buyers
                      join buyer in _requestsRepository.Buyers on participant.BuyerId equals buyer.BuyerId
                      where auction.Date == date
                      select buyer).ToList();

        return _mapper.Map<IEnumerable<BuyerAddressDto>>(result);
    }

    /// <summary>
    /// Returns the top 5 buyers who spent the most money
    /// </summary>
    /// <returns>List of buyers ids and their expenses </returns>
    [HttpGet("GetTopBuyersByExpenses")]
    public IEnumerable<BuyerExpensesDto> GetTopBuyersByExpenses()
    {
        var result = (from privatized in _requestsRepository.Privatized
                      join buyer in _requestsRepository.Buyers on privatized.BuyerId equals buyer.BuyerId
                      group privatized by privatized.BuyerId into privGRoup
                      orderby privGRoup.Sum(privatized => privatized.EndPrice) descending
                      select new BuyerExpensesDto()
                      {
                          BuyerId = privGRoup.First().BuyerId,
                          Expenses = privGRoup.Sum(privatized => privatized.EndPrice)
                      }).Take(5).ToList();
        return result;
    }

    /// <summary>
    /// Returns the data on the auctions that brought the most profit
    /// </summary>
    /// <returns></returns>
    [HttpGet("GetAuctionsWithHighestIncome")]
    public IEnumerable<AuctionIncomeDto> GetAuctionsWithHighestIncome()
    {
        var result = (from privatized in _requestsRepository.Privatized
                      join auction in _requestsRepository.Auctions on privatized.AuctionId equals auction.AuctionId
                      group privatized by privatized.AuctionId into privGRoup
                      orderby privGRoup.Sum(privatized => privatized.EndPrice - privatized.StartPrice) descending
                      select new AuctionIncomeDto
                      {
                          AuctionId = privGRoup.First().AuctionId,
                          Income = privGRoup.Sum(privatized => privatized.EndPrice - privatized.StartPrice)
                      }).ToList();
        return result;
    }
}