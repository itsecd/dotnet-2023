using AirLine.Domain;
using Airline.Server.Dto;
using Airline.Server.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Airlines.Server.Controllers;

/// <summary>
/// Flight table controller
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class FlightController : ControllerBase
{
    private readonly ILogger<FlightController> _logger;
    private readonly IAirlineRepository _airlineRepository;
    private readonly IMapper _mapper;

    public FlightController(ILogger<FlightController> logger, IAirlineRepository airlineRepository, IMapper mapper)
    {
        _logger = logger;
        _airlineRepository = airlineRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Get table flight
    /// </summary>
    /// <returns>
    /// Return all flights
    /// </returns>
    [HttpGet]
    public IEnumerable<FlightGetDto> Get()
    {
        _logger.LogInformation("Get flights");
        return _airlineRepository.Flights.Select(flight => _mapper.Map<FlightGetDto>(flight));
    }

    /// <summary>
    /// Get flight by id
    /// </summary>
    /// <returns>
    /// Return flight with specified id
    /// </returns>
    [HttpGet("{id}")]
    public ActionResult<FlightGetDto> Get(int id)
    {
        _logger.LogInformation($"Get flight: id ({id})");
        var flight = _airlineRepository.Flights.FirstOrDefault(flight => flight.Id == id);
        if (flight == null)
        {
            _logger.LogInformation($"Not found flight: id ({id})");
            return NotFound();
        }
        else
        {
            return Ok(_mapper.Map<FlightGetDto>(flight));
        }
    }

    /// <summary>
    /// Post flight
    /// </summary>
    /// <param name="flight"> Flight class for insert in table</param>
    [HttpPost]
    public void Post([FromBody] FlightPostDto flight)
    {
        _logger.LogInformation("Post");
        _airlineRepository.Flights.Add(_mapper.Map<Flight>(flight));
    }

    /// <summary>
    /// Put flight
    /// </summary>
    /// <param name="id">Flight id for be changed</param>
    /// <param name="flightToPut">Flight class for insert in table</param>
    /// <returns>Triggered of success and error</returns>
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] FlightPostDto flightToPut)
    {
        _logger.LogInformation("Put flight: id {0}", id);
        var flight = _airlineRepository.Flights.FirstOrDefault(flight => flight.Id == id);
        if (flight == null)
        {
            _logger.LogInformation("Not found flight: id {0}", id);
            return NotFound();
        }
        else
        {
            _mapper.Map(flightToPut, flight);
            return Ok();
        }
    }

    /// <summary>
    /// Delete flight 
    /// </summary>
    /// <param name="id">Flight id for deleting</param>
    /// <returns>Triggered of success and error</returns>
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _logger.LogInformation($"Put flight: id ({id})");
        var flight = _airlineRepository.Flights.FirstOrDefault(flight => flight.Id == id);
        if (flight == null)
        {
            _logger.LogInformation($"Not found flight: id ({id})");
            return NotFound();
        }
        else
        {
            _airlineRepository.Flights.Remove(flight);
            return Ok();
        }
    }
}