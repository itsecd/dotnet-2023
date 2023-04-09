using AirplaneBookingSystem.Domain;
using AirplaneBookingSystem.Server.Dto;
using AirplaneBookingSystem.Server.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace AirplaneBookingSystem.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FlightController : ControllerBase
{
    private readonly ILogger<AirplaneController> _logger;
    private readonly IAirplaneBookingSystemRepository _flightRepository;
    private readonly IMapper _mapper;
   public FlightController(ILogger<AirplaneController> logger, IAirplaneBookingSystemRepository flightRepository, IMapper mapper)
    {
        _logger = logger;
        _flightRepository = flightRepository;
        _mapper = mapper;
    }
    [HttpGet]
    public IEnumerable<FlightGetDto> Get()
    {
        _logger.LogInformation("Get flight");
        return _flightRepository.Flights.Select(flight => _mapper.Map<FlightGetDto>(flight));
    }

    [HttpGet("{id}")]
    public ActionResult<FlightGetDto> Get(int id)
    {
        _logger.LogInformation("Get flight with id {id}", id);
        var flight = _flightRepository.Flights.FirstOrDefault(flight => flight.Id == id);
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
    [HttpPost]
    public void Post([FromBody] FlightPostDto flight)
    {
        _flightRepository.Flights.Add(_mapper.Map<Flight>(flight));
    }
    [HttpPut("{id}")]
    public ActionResult Put(int id, [FromBody] FlightPostDto flightToPut)
    {
        _logger.LogInformation("Put flight with id {id}", id);
        var flight = _flightRepository.Flights.FirstOrDefault(flight => flight.Id == id);
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
    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        _logger.LogInformation("Delete flight with id {id}", id);
        var flight = _flightRepository.Flights.FirstOrDefault(flight => flight.Id == id);
        if (flight == null)
        {
            _logger.LogInformation("Not found flight with id {id}", id);
            return NotFound();
        }
        else
        {
            _flightRepository.Flights.Remove(flight);
            return Ok();
        }
    }
}