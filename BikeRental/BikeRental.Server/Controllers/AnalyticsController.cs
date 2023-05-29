using AutoMapper;
using BikeRental.Domain;
using BikeRental.Server.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BikeRental.Server.Controllers;

/// <summary>
/// Analytics controller for requests
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class AnalyticsController : ControllerBase
{
    private readonly BikeRentalDbContext _context;

    private readonly IMapper _mapper;

    private readonly ILogger<AnalyticsController> _logger;

    public AnalyticsController(BikeRentalDbContext context, IMapper mapper, ILogger<AnalyticsController> logger)
    {
        _context = context;
        _mapper = mapper;
        _logger = logger;
    }

    /// <summary>
    /// 1st request - give info about all sport bikes
    /// </summary>
    /// <returns> List of sport bikes </returns>
    [HttpGet("sportBikes")]
    public async Task<ActionResult<ICollection<BikeGetDto>>> GetSportBikes()
    {
        _logger.LogInformation("Get info about sport bikes");
        if (_context.Bikes == null)
        {
            return NotFound();
        }

        var request = await
            (from bike in _context.Bikes
             where bike.TypeId == 3
             select _mapper.Map<Bike, BikeGetDto>(bike)).ToListAsync();

        if (request.Count == 0)
        {
            _logger.LogInformation("Sport bikes not found");
            return NotFound();
        }
        else
        {
            return Ok(request);
        }
    }

    /// <summary>
    /// 2nd request - give ordered by client's name info about all clients who have rented mountain bikes
    /// </summary>
    /// <returns> Ordered by name list of clients who rented mountain bikes </returns>
    [HttpGet("mountaiBikesClients")]
    public async Task<ActionResult<ICollection<ClientGetDto>>> GetMountainBikesClients()
    {
        _logger.LogInformation("Give info about clients who rented mountain bikes");
        if (_context.RentRecords == null || _context.Bikes == null)
        {
            return NotFound();
        }

        var rentList = await
            (from client in _context.Clients
             join record in _context.RentRecords on client.Id equals record.ClientId
             join bike in _context.Bikes on record.BikeId equals bike.Id
             where bike.TypeId == 1
             select _mapper.Map<Client, ClientGetDto>(client)).Distinct().ToListAsync();

        var request =
            (from req in rentList
             orderby req.FullName
             select req).ToList();

        if (request.Count == 0)
        {
            _logger.LogInformation("Clients not found");
            return NotFound();
        }
        else
        {
            return Ok(request);
        }
    }

    /// <summary>
    /// 3rd request - give total rent time for each bike type
    /// </summary>
    /// <returns>Total rent time for each type in minutes</returns>
    [HttpGet("totalRentTime")]
    public async Task<ActionResult> GetRentTime()
    {
        _logger.LogInformation("Get total rent time for each bike type");
        if (_context.RentRecords == null || _context.Bikes == null)
        {
            return NotFound();
        }

        var request = await
            (from record in _context.RentRecords
             join bike in _context.Bikes on record.BikeId equals bike.Id
             join type in _context.BikeTypes on bike.TypeId equals type.Id
             select new
             {
                 bike.TypeId,
                 type.TypeName,
                 record.RentEndTime,
                 record.RentStartTime
             }).ToListAsync();

        var rentTime =
            (from res in request
             group res by new { res.TypeName, res.TypeId } into totalTime
             select new
             {
                 totalTime.Key.TypeId,
                 totalTime.Key.TypeName,
                 TotalRentTime = totalTime.Sum(time => (time.RentEndTime - time.RentStartTime).TotalMinutes)
             }).ToList();

        if (rentTime.Count == 0)
        {
            _logger.LogInformation("Time not found");
            return NotFound();
        }
        else
        {
            return Ok(rentTime);
        }
    }

    /// <summary>
    /// 4th request - give info about clients who have rented bikes the most
    /// </summary>
    /// <returns>Clients who rented bikes the most</returns>
    [HttpGet("maxRentsClients")]
    public async Task<ActionResult<ClientGetDto>> GetClientsInfo()
    {
        _logger.LogInformation("Give info about clients who rented bikes the most");
        if (_context.RentRecords == null)
        {
            return NotFound();
        }

        var request = await
            (from record in _context.RentRecords
             join client in _context.Clients on record.ClientId equals client.Id
             group record by record.ClientId into clientGroup
             orderby clientGroup.Count() descending
             select clientGroup.First().Client).ToListAsync();

        return _mapper.Map<ClientGetDto>(request[0]);
    }

    /// <summary>
    /// 5th request - give info about 5 most rented bikes
    /// </summary>
    /// <returns>Top 5 most rented bikes</returns>
    [HttpGet("topFiveBikes")]
    public async Task<ActionResult<ICollection<BikeGetDto>>> GetTopFiveBikes()
    {
        _logger.LogInformation("Give info about 5 most rented bikes");
        if (_context.RentRecords == null)
        {
            return NotFound();
        }

        var request = await
            (from record in _context.RentRecords
             join bike in _context.Bikes on record.BikeId equals bike.Id
             group record by record.BikeId into bikeRents
             orderby bikeRents.Count() descending
             select _mapper.Map<Bike, BikeGetDto>(bikeRents.First().Bike)).Take(5).ToListAsync();

        return Ok(request);
    }

    /// <summary>
    /// 6th request - give info about min, max and average rent time
    /// </summary>
    /// <returns>Min, max and average rent time</returns>
    [HttpGet("rentTime")]
    public async Task<ActionResult> GetTimeValues()
    {
        _logger.LogInformation("Get min, max and avg time of rent");
        if (_context.RentRecords == null)
        {
            return NotFound();
        }

        var time = await
            (from record in _context.RentRecords
             select new
             {
                 record.RentStartTime,
                 record.RentEndTime
             }).ToListAsync();

        var minTime = time.Min(time => (time.RentEndTime - time.RentStartTime).TotalMinutes);
        var avgTime = time.Average(time => (time.RentEndTime - time.RentStartTime).TotalMinutes);
        var maxTime = time.Max(time => (time.RentEndTime - time.RentStartTime).TotalMinutes);

        var request = new List<double>() { minTime, avgTime, maxTime };

        return Ok(request);
    }
}
