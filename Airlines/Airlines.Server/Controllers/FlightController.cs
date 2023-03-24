using Airlines.Domain;
using Airlines.Server.Dto;
using Airlines.Server.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Airlines.Server.Controllers;

/// <summary>
/// Controller for flight table
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class FlightController : ControllerBase
{
    private readonly ILogger<FlightController> _logger;
    private readonly IAirlinesRepository _airlinesRepository;
    private readonly IMapper _mapper;

    public FlightController(ILogger<FlightController> logger, IAirlinesRepository airlinesRepository, IMapper mapper)
    {
        _logger = logger;
        _airlinesRepository = airlinesRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Get metod for flight table
    /// </summary>
    /// <returns>'
    /// Return all flights
    /// </returns>
    [HttpGet]
    public IEnumerable<FlightGetDto> Get()
    {
        _logger.LogInformation("Get flights");
        return _airlinesRepository.Flights.Select(flight => _mapper.Map<FlightGetDto>(flight));
    }

    /// <summary>
    /// Get by id metod for flight table
    /// </summary>
    /// <returns>'
    /// Return flight with specified id
    /// </returns>
    [HttpGet("{id}")]
    public ActionResult<FlightGetDto> Get(int id)
    {
        _logger.LogInformation($"Get flight with id ({id})");
        var flight = _airlinesRepository.Flights.FirstOrDefault(flight => flight.Id == id);
        if (flight == null)
        {
            _logger.LogInformation($"Not found flight with id ({id})");
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
        _logger.LogInformation("Post");
        _airlinesRepository.Flights.Add(_mapper.Map<FlightCLass>(flight));
    }

    /// <summary>
    /// Put method for flight table
    /// </summary>
    /// <param name="id">An id of flight which would be changed </param>
    /// <param name="flightToPut">Flight class instance to insert to table</param>
    /// <returns>Signalization of success of error</returns>
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] FlightPostDto flightToPut)
    {
        _logger.LogInformation("Put flight with id {0}", id);
        var flight = _airlinesRepository.Flights.FirstOrDefault(flight => flight.Id == id);
        if (flight == null)
        {
            _logger.LogInformation("Not found flight with id {0}", id);
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
    public IActionResult Delete(int id)
    {
        _logger.LogInformation($"Put flight with id ({id})");
        var flight = _airlinesRepository.Flights.FirstOrDefault(flight => flight.Id == id);
        if (flight == null)
        {
            _logger.LogInformation($"Not found flight with id ({id})");
            return NotFound();
        }
        else
        {
            _airlinesRepository.Flights.Remove(flight);
            return Ok();
        }
    }
}