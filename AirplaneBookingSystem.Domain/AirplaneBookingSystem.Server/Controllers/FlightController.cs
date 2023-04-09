using AirplaneBookingSystem.Domain;
using AirplaneBookingSystem.Server.Dto;
using AirplaneBookingSystem.Server.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AirplaneBookingSystem.Server.Controllers;
/// <summary>
/// Controller for flight table
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class FlightController : ControllerBase
{
    private readonly ILogger<AirplaneController> _logger;
    private readonly IAirplaneBookingSystemRepository _airplaneBookingSystemRepository;
    private readonly IMapper _mapper;
    public FlightController(ILogger<AirplaneController> logger, IAirplaneBookingSystemRepository airplaneBookingSystemRepository, IMapper mapper)
    {
        _logger = logger;
        _airplaneBookingSystemRepository = airplaneBookingSystemRepository;
        _mapper = mapper;
    }
    /// <summary>
    /// Get method for flight table
    /// </summary>
    /// <returns>
    /// Return all flights
    /// </returns>
    [HttpGet]
    public IEnumerable<FlightGetDto> Get()
    {
        _logger.LogInformation("Get flight");
        return _airplaneBookingSystemRepository.Flights.Select(flight => _mapper.Map<FlightGetDto>(flight));
    }
    /// <summary>
    /// Get by id method for flight table
    /// </summary>
    /// <returns>
    /// Return flight with specified id
    /// </returns>
    [HttpGet("{id}")]
    public ActionResult<FlightGetDto> Get(int id)
    {
        _logger.LogInformation("Get flight with id {id}", id);
        var flight = _airplaneBookingSystemRepository.Flights.FirstOrDefault(flight => flight.Id == id);
        if (flight == null)
        {
            _logger.LogInformation("Not found flight with id {id}", id);
            return NotFound();
        }
        else
        {
            return Ok(_mapper.Map<FlightGetDto>(flight));
        }
    }
    /// <summary>
    /// Post method for flight table
    /// </summary>
    /// <param name="flight"> Flight class instance to insert to table</param>
    [HttpPost]
    public void Post([FromBody] FlightPostDto flight)
    {
        _airplaneBookingSystemRepository.Flights.Add(_mapper.Map<Flight>(flight));
    }
    /// <summary>
    /// Put method for flight table
    /// </summary>
    /// <param name="id">An id of flight which would be changed </param>
    /// <param name="flightToPut">Flight class instance to insert to table</param>
    /// <returns>Signalization of success of error</returns>
    [HttpPut("{id}")]
    public ActionResult Put(int id, [FromBody] FlightPostDto flightToPut)
    {
        _logger.LogInformation("Put flight with id {id}", id);
        var flight = _airplaneBookingSystemRepository.Flights.FirstOrDefault(flight => flight.Id == id);
        if (flight == null)
        {
            _logger.LogInformation("Not found flight with id {id}", id);
            return NotFound();
        }
        else
        {
            _mapper.Map(flightToPut, flight);
            return Ok();
        }
    }
    /// <summary>
    /// Delete method 
    /// </summary>
    /// <param name="id">An id of flight which would be deleted</param>
    /// <returns>Signalization of success of error</returns>
    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        _logger.LogInformation("Delete flight with id {id}", id);
        var flight = _airplaneBookingSystemRepository.Flights.FirstOrDefault(flight => flight.Id == id);
        if (flight == null)
        {
            _logger.LogInformation("Not found flight with id {id}", id);
            return NotFound();
        }
        else
        {
            _airplaneBookingSystemRepository.Flights.Remove(flight);
            return Ok();
        }
    }
}