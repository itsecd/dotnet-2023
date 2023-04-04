using AutoMapper;
using BicycleRentals.Server.Respostory;
using Microsoft.AspNetCore.Mvc;

namespace BicycleRentals.Server.ControllersModels;
[Route("api/[controller]")]
[ApiController]
public class RequestsController : ControllerBase
{
    private readonly ILogger<BicycleTypeController> _logger;

    private readonly IBicycleRentalRespostory _bicycleRespostory;

    private readonly IMapper _mapper;
    public RequestsController(ILogger<BicycleTypeController> logger, IBicycleRentalRespostory respostory, IMapper mapper)
    {
        _logger = logger;
        _bicycleRespostory = respostory;
        _mapper = mapper;
    }

    [HttpGet("GetSportBicycles")]
    public IActionResult GetSportBicycles()
    {
        var sportBicycles = _bicycleRespostory.FixTypes[2].Bicycles;
        return Ok(sportBicycles);
    }

    [HttpGet("GetCustomersWhoRentedMountainBikes")]
    public IActionResult GetCustomersWhoRentedMountainBikes()
    {
        var mountainBikes = _bicycleRespostory.FixTypes[0].Bicycles;
        var customerNames = (from c in _bicycleRespostory.FixCustomers
                             join r in _bicycleRespostory.FixRentals on c.Id equals r.CustomerId
                             join b in mountainBikes on r.SerialNumber equals b.SerialNumber
                             orderby c.FullName ascending
                             select c.FullName)
                            .ToList();
        return Ok(customerNames);
    }

    [HttpGet("GetTotalRentalTimePerBicycleType")]
    public IActionResult GetTotalRentalTimePerBicycleType()
    {
        var totalRentalTime = (from r in _bicycleRespostory.FixRentals
                               join b in _bicycleRespostory.FixBicycles on r.SerialNumber equals b.SerialNumber
                               group r by b.TypeId into g
                               select new
                               {
                                   TypeId = g.Key,
                                   TotalTime = g.Sum(br => br.RentalDurationHours)
                               }).ToList();
        return Ok(totalRentalTime);
    }

    [HttpGet("GetCustomersWithMostRentalsReturnsCorrectCount")]
    public IActionResult GetCustomersWithMostRentals()
    {
        var customerRentalCounts = _bicycleRespostory.FixRentals.GroupBy(br => br.CustomerId)
                                             .Select(g => new { CustomerId = g.Key, RentalCount = g.Count() })
                                             .OrderByDescending(c => c.RentalCount);
        var mostRentedCustomers = from c in _bicycleRespostory.FixCustomers
                                  where c.Id == customerRentalCounts.First().CustomerId
                                  select c.FullName;
        return Ok(mostRentedCustomers);
    }

    [HttpGet("Top5MostRentedBikes")]
    public IActionResult Top5MostRentedBikes()
    {
        var top5Bikes = _bicycleRespostory.FixRentals
           .GroupBy(r => r.SerialNumber)
           .OrderByDescending(g => g.Count())
           .Take(5)
           .Select(g => g.Key)
           .ToList();
        return Ok(top5Bikes);
    }

    [HttpGet("MinMaxAvgRentalTime")]
    public IActionResult MinMaxAvgRentalTime()
    {
        var rentalTimes = (from r in _bicycleRespostory.FixRentals
                           join b in _bicycleRespostory.FixBicycles on r.SerialNumber equals b.SerialNumber
                           group r by b.TypeId into g
                           select new
                           {
                               TypeId = g.Key,
                               minRentalTime = g.Min(br => br.RentalDurationHours),
                               maxRentalTime = g.Max(br => br.RentalDurationHours),
                               avgRentalTime = g.Average(br => br.RentalDurationHours)
                           }).ToList();
        return Ok(rentalTimes);
    }
}
