using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TransportMgmt.Domain;
using TransportMgmtServer.Dto;
using TransportMgmtServer.Repository;

namespace TransportMgmtServer.Controllers;

/// <summary>
/// Controller for request
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class RequestController : ControllerBase
{
    /// <summary>
    /// Used to store logger
    /// </summary>
    private readonly ILogger<RequestController> _logger;
    /// <summary>
    /// Used to store repository
    /// </summary>
    private readonly ITransportMgmtRepository _transportRepository;
    /// <summary>
    /// Used to store map's object
    /// </summary>
    private readonly IMapper _mapper;
    /// <summary>
    /// Controller constructor
    /// </summary>
    public RequestController(ILogger<RequestController> logger, ITransportMgmtRepository transportRepository, IMapper mapper)
    {
        _logger = logger;
        _transportRepository = transportRepository;
        _mapper = mapper;
    }
    /// <summary>
    /// First request - display all information about a specific transport
    /// </summary>
    /// <returns> List of all information about a specific transport </returns>
    [HttpGet("info_about_transport")]
    public IActionResult Get(string modelName)
    {
        _logger.LogInformation("Get info about transport");
        var request = (from transports in _transportRepository.Transports
                       where transports.Model.ModelName == modelName
                       select _mapper.Map<Transport, TransportGetDto>(transports)).ToList();
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
    public IActionResult GetAllDriversWithSpecificDate(DateTime firstDateTime, DateTime secondDateTime)
    {
        _logger.LogInformation("Get info about drivers who have made trips for a given period");
        var request = (from trip in _transportRepository.Trips
                       join driver in _transportRepository.Drivers on trip.Driver.Id equals driver.Id
                       where trip.Date > firstDateTime && trip.Date < secondDateTime
                       orderby driver.LastName, driver.FirstName, driver.MiddleName
                       select _mapper.Map<Driver, DriverGetDto>(driver)).ToList();
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
    public IEnumerable<TransportTotalTravelTimeDto> TotalTravelTimeAllTransport()
    {
        _logger.LogInformation("Get info about the total travel time for each transport type and model");
        var request = (from trip in _transportRepository.Trips
                       join transport in _transportRepository.Transports on trip.Transport.Id equals transport.Id
                       group trip by new { transport.Type, transport.Model } into res
                       orderby res.Sum(trip => (trip.TimeOff - trip.TimeOn).TotalHours) descending
                       select new TransportTotalTravelTimeDto
                       {
                           Id = res.First().Transport.Id,
                           StateNumber = res.First().Transport.StateNumber,
                           TypeName = res.First().Transport.Type.TypeName,
                           ModelName = res.First().Transport.Model.ModelName,
                           TotalTravelTime = res.Sum(trip => (trip.TimeOff - trip.TimeOn).TotalHours)
                       }
             ).ToList();
        return _mapper.Map<IEnumerable<TransportTotalTravelTimeDto>>(request);
    }
    /// <summary>
    /// Fourth request - Display the top 5 drivers by the number of trips completed.
    /// </summary>
    /// <returns> List of top 5 drivers by the number of trips completed </returns>
    [HttpGet("DriversTopFive")]
    public IEnumerable<DriverGetDto> DriversTopFive()
    {
        var request = (from trip in _transportRepository.Trips
                       join driver in _transportRepository.Drivers on trip.Driver.Id equals driver.Id
                       group trip by trip.Driver.Id into res
                       orderby res.Count() descending
                       select res.First().Driver).Take(5).ToList();
        return _mapper.Map<IEnumerable<DriverGetDto>>(request);
    }
    /// <summary>
    /// Fifth request - Display information about the number of trips, average time and maximum travel time for each driver.
    /// </summary>
    /// <returns> List of information about the number of trips, average time and maximum travel time for each driver </returns>
    [HttpGet("GetInfoAboutDriverTrips")]
    public IEnumerable<DriverPropertiesRouteDto> GetInfoAboutDriverTrips()
    {
        var result = (from trip in _transportRepository.Trips
                      join driver in _transportRepository.Drivers on trip.Driver.Id equals driver.Id
                      group trip by trip.Driver.Id into res
                      select new DriverPropertiesRouteDto
                      {
                          FirstName = res.First().Driver.FirstName,
                          LastName = res.First().Driver.LastName,
                          MiddleName = res.First().Driver.MiddleName,
                          TripsAmount = res.Count(),
                          AvgTime = res.Average(trip => (trip.TimeOff - trip.TimeOn).TotalHours),
                          MaxTime = res.Max(trip => (trip.TimeOff - trip.TimeOn).TotalHours)
                      });
        return _mapper.Map<IEnumerable<DriverPropertiesRouteDto>>(result);
    }
    /// <summary>
    /// Sixth request - Display information about the transports that made the maximum number of trips for the specified period.
    /// </summary>
    /// <returns> List of information about the transports that made the maximum number of trips for the specified period </returns>
    [HttpGet("TransportInfoWithMaxCountForSpecificDate")]
    public IActionResult TransportInfoWithMaxCountForSpecificDate(DateTime firstDateTime, DateTime secondDateTime)
    {
        var numOfTrips = (from trip in _transportRepository.Trips
                          group trip by trip.Transport.Id into res
                          where res.First().Date > firstDateTime && res.First().Date < secondDateTime
                          select new
                          {
                              tansportId = res.First().Transport.Id,
                              tripsAmount = res.Count()
                          }).ToList();
        var request = (from trip in numOfTrips
                       join transport in _transportRepository.Transports on trip.tansportId equals transport.Id
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
