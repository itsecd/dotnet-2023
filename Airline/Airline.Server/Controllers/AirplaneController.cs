using AirLine.Domain;
using Airline.Server.Dto;
using Airline.Server.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Airlines.Server.Controllers;

/// <summary>
/// Airplane controller
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class AirplaneController : ControllerBase
{
    private readonly ILogger<AirplaneController> _logger;
    private readonly IAirlineRepository _airlineRepository;
    private readonly IMapper _mapper;

    public AirplaneController(ILogger<AirplaneController> logger, IAirlineRepository airlineRepository, IMapper mapper)
    {
        _logger = logger;
        _airlineRepository = airlineRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Get airplane table
    /// </summary>
    /// <returns>
    /// Return all airplanes
    /// </returns>
    [HttpGet]
    public IEnumerable<AirplaneGetDto> Get()
    {
        _logger.LogInformation("Get airplaes");
        return _airlineRepository.Airplanes.Select(airplane => _mapper.Map<AirplaneGetDto>(airplane));
    }

    /// <summary>
    /// Get airplane by id
    /// </summary>
    /// <returns>
    /// Return airplane with specified id
    /// </returns>
    [HttpGet("{id}")]
    public ActionResult<AirplaneGetDto> Get(int id)
    {
        _logger.LogInformation($"Get airplane: id ({id})");
        var airplane = _airlineRepository.Airplanes.FirstOrDefault(airplane => airplane.Id == id);
        if (airplane == null)
        {
            _logger.LogInformation($"Not found airplane: id ({id})");
            return NotFound();
        }
        else
        {
            return Ok(_mapper.Map<AirplaneGetDto>(airplane));
        }
    }

    /// <summary>
    /// Post airplane
    /// </summary>
    /// <param name="airplane"> Airplane class for insert in table</param>
    [HttpPost]
    public void Post([FromBody] AirplanePostDto airplane)
    {
        _logger.LogInformation("Post airplane");
        _airlineRepository.Airplanes.Add(_mapper.Map<Airplane>(airplane));
    }

    /// <summary>
    /// Put airplane
    /// </summary>
    /// <param name="id">Airplane id for be changed</param>
    /// <param name="airplaneToPut">Airplane class for insert in table</param>
    /// <returns>Triggered of success and error</returns>
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] AirplanePostDto airplaneToPut)
    {
        _logger.LogInformation("Put airplane: id {0}", id);
        var airplane = _airlineRepository.Airplanes.FirstOrDefault(airplane => airplane.Id == id);
        if (airplane == null)
        {
            _logger.LogInformation("Not found airplane: id {0}", id);
            return NotFound();
        }
        else
        {
            _mapper.Map(airplaneToPut, airplane);
            return Ok();
        }
    }

    /// <summary>
    /// Delete airplane 
    /// </summary>
    /// <param name="id">Airplane id for deleting</param>
    /// <returns>Triggered of success and error</returns>
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _logger.LogInformation($"Put airplane: id ({id})");
        var airplane = _airlineRepository.Airplanes.FirstOrDefault(airplane => airplane.Id == id);
        if (airplane == null)
        {
            _logger.LogInformation($"Not found airplane: id ({id})");
            return NotFound();
        }
        else
        {
            _airlineRepository.Airplanes.Remove(airplane);
            return Ok();
        }
    }
}