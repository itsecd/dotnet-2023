using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TransportMgmt.Domain;
using TransportMgmtServer.Dto;

namespace TransportMgmtServer.Controllers;

/// <summary>
/// Controller for request
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class RequestController : ControllerBase
{
    /// <summary>
    /// Used to store factory context
    /// </summary>
    private readonly IDbContextFactory<TransportMgmtContext> _contextFactory;
    /// <summary>
    /// Used to store logger
    /// </summary>
    private readonly ILogger<RequestController> _logger;
    /// <summary>
    /// Used to store map's object
    /// </summary>
    private readonly IMapper _mapper;
    /// <summary>
    /// Controller constructor
    /// </summary>
    public RequestController(IDbContextFactory<TransportMgmtContext> contextFactory, ILogger<RequestController> logger, IMapper mapper)
    {
        _contextFactory = contextFactory;
        _logger = logger;
        _mapper = mapper;
    }
    /// <summary>
    /// First request - display all information about a specific transport
    /// </summary>
    /// <returns> List of all information about a specific transport </returns>
    [HttpGet("info_about_transport")]
    public async Task<IActionResult> Get(string modelName)
    {
        await using var context = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation("Get info about transport");
        var request = await (from transports in context.Transports
                             where transports.Model.ModelName == modelName
                             select _mapper.Map<Transport, TransportGetDto>(transports)).ToListAsync();
        if (request.Count == 0)
        {
            _logger.LogInformation("Not found transport: {modelName}", modelName);
            return NotFound();
        }
        else
        {
            return Ok(request);
        }
    }
    /// <summary>
    /// Second request - display all drivers who have made trips for a given period, sort by full name
    /// </summary>
    /// <returns> List of drivers who have made trips for a given period, sort by full name </returns>
    [HttpGet("GetAllDriversWithSpecificDate")]
    public async Task<IActionResult> GetAllDriversWithSpecificDate(DateTime firstDateTime, DateTime secondDateTime)
    {
        await using var context = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation("Get info about drivers who have made trips for a given period");
        var request = await (from trip in context.Trips
                             join driver in context.Drivers on trip.DriverId equals driver.Id
                             where trip.Date > firstDateTime && trip.Date < secondDateTime
                             orderby driver.LastName, driver.FirstName, driver.MiddleName
                             select _mapper.Map<Driver, DriverGetDto>(driver)).ToListAsync();
        if (request.Count == 0)
        {
            _logger.LogInformation("Not found drivers");
            return NotFound();
        }
        else
        {
            return Ok(request);
        }
    }
    /// <summary>
    /// Third request - display the total travel time for each transport type and model.
    /// </summary>
    /// <returns> List of total travel time for each transport type and model </returns>
    [HttpGet("TotalTravelTimeAllTransport")]
    public async Task<ActionResult> TotalTravelTimeAllTransport()
    {
        await using var context = _contextFactory.CreateDbContext();
        _logger.LogInformation("Get info about the total travel time for each transport type and model");
        var request = await (from transport in context.Transports
                             join model in context.Models on transport.ModelId equals model.Id
                             join transportType in context.TransportTypes on transport.TypeId equals transportType.Id
                             join trip in context.Trips on transport.Id equals trip.TransportId
                             select new
                             {
                                 model.ModelName,
                                 transportType.TypeName,
                                 trip.TimeOn,
                                 trip.TimeOff
                             }).ToListAsync();
        var tripTime = (from res in request
                        group res by new { res.ModelName, res.TypeName } into TotalTime
                        select new
                        {
                            TotalTime.Key.ModelName,
                            TotalTime.Key.TypeName,
                            TotalTimeTrips = TotalTime.Sum(TimeTrip => (TimeTrip.TimeOff - TimeTrip.TimeOn).TotalHours)
                        }
                        ).ToList();

        if (tripTime.Count == 0)
        {
            _logger.LogInformation("Not found drivers");
            return NotFound();
        }

        return Ok(tripTime);

    }
    /// <summary>
    /// Fourth request - Display the top 5 drivers by the number of trips completed.
    /// </summary>
    /// <returns> List of top 5 drivers by the number of trips completed </returns>
    [HttpGet("DriversTopFive")]
    public async Task<IEnumerable<DriverGetDto>> DriversTopFive()
    {
        await using var context = await _contextFactory.CreateDbContextAsync();
        var request = await (from trip in context.Trips
                             join driver in context.Drivers on trip.DriverId equals driver.Id
                             group trip by trip.DriverId into res
                             orderby res.Count() descending
                             select res.First().Driver).Take(5).ToListAsync();

        return _mapper.Map<IEnumerable<DriverGetDto>>(request);
    }
    /// <summary>
    /// Fifth request - Display information about the number of trips, average time and maximum travel time for each driver.
    /// </summary>
    /// <returns> List of information about the number of trips, average time and maximum travel time for each driver </returns>
    [HttpGet("GetInfoAboutDriverTrips")]
    public async Task<ActionResult> GetInfoAboutDriverTrips()
    {
        await using var context = await _contextFactory.CreateDbContextAsync();
        var request = await (from trip in context.Trips
                             join driver in context.Drivers on trip.DriverId equals driver.Id
                             select new
                             {
                                 driver.FirstName,
                                 driver.LastName,
                                 driver.MiddleName,
                                 trip.TimeOn,
                                 trip.TimeOff
                             }).ToListAsync();
        var result = (from driverTripInfo in request
                      group driverTripInfo by new { driverTripInfo.LastName, driverTripInfo.FirstName, driverTripInfo.MiddleName }
                      into res
                      select new
                      {
                          res.Key.LastName,
                          res.Key.FirstName,
                          res.Key.MiddleName,
                          NumberOfTrips = res.Count(),
                          AvgTravelTime = res.Average(trip => (trip.TimeOff - trip.TimeOn).TotalHours),
                          MaxTravelTime = res.Max(trip => (trip.TimeOff - trip.TimeOn).TotalHours)
                      }).ToList();
        if (result.Count == 0)
        {
            _logger.LogInformation("Not found drivers");
            return NotFound();
        }

        return Ok(result);
    }
    /// <summary>
    /// Sixth request - Display information about the transports that made the maximum number of trips for the specified period.
    /// </summary>
    /// <returns> List of information about the transports that made the maximum number of trips for the specified period </returns>
    [HttpGet("TransportInfoWithMaxCountForSpecificDate")]
    public async Task<IActionResult> TransportInfoWithMaxCountForSpecificDate(DateTime firstDateTime, DateTime secondDateTime)
    {
        await using var context = await _contextFactory.CreateDbContextAsync();
        var numOfTrips = await (from trip in context.Trips
                                group trip by trip.TransportId into res
                                where res.First().Date > firstDateTime && res.First().Date < secondDateTime
                                select new
                                {
                                    tansportId = res.First().TransportId,
                                    tripsAmount = res.Count()
                                }).ToListAsync();
        var request = (from trip in numOfTrips
                       join transport in context.Transports on trip.tansportId equals transport.Id
                       where (trip.tripsAmount == numOfTrips.Max(trip => trip.tripsAmount))
                       select _mapper.Map<TransportGetDto>(transport)).ToList();
        if (request.Count == 0)
        {
            _logger.LogInformation("Not found trips from {firstDateTime} to {secondDateTime}", firstDateTime, secondDateTime);
            return NotFound();
        }
        else
        {
            return Ok(request);
        }
    }

}
