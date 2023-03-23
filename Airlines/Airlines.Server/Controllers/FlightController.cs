using Airlines.Domain;
using Airlines.Server.Dto;
using Airlines.Server.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Airlines.Server.Controllers;
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
    [HttpGet]
    public IEnumerable<FlightGetDto> Get()
    {
        _logger.LogInformation("Get flights");
        return _airlinesRepository.Flights.Select(flight => _mapper.Map<FlightGetDto>(flight));
    }

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

    [HttpPost]
    public void Post([FromBody] FlightPostDto flight)
    {
        _logger.LogInformation("Post");
        _airlinesRepository.Flights.Add(_mapper.Map<FlightCLass>(flight));
    }

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

    // DELETE api/<PassengerController>/5
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
