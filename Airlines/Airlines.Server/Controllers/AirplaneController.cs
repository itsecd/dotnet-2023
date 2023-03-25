using Airlines.Domain;
using Airlines.Server.Dto;
using Airlines.Server.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Airlines.Server.Controllers;

/// <summary>
/// Controller for airplane table
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class AirplaneController : ControllerBase
{
    private readonly ILogger<AirplaneController> _logger;
    private readonly IAirlinesRepository _airlinesRepository;
    private readonly IMapper _mapper;

    public AirplaneController(ILogger<AirplaneController> logger, IAirlinesRepository airlinesRepository, IMapper mapper)
    {
        _logger = logger;
        _airlinesRepository = airlinesRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Get method for airplane table
    /// </summary>
    /// <returns>
    /// Return all airplanes
    /// </returns>
    [HttpGet]
    public IEnumerable<AirplaneGetDto> Get()
    {
        _logger.LogInformation("Get airplaes");
        return _airlinesRepository.Airplanes.Select(airplane => _mapper.Map<AirplaneGetDto>(airplane));
    }

    /// <summary>
    /// Get by id method for airplane table
    /// </summary>
    /// <returns>
    /// Return airplane with specified id
    /// </returns>
    [HttpGet("{id}")]
    public ActionResult<AirplaneGetDto> Get(int id)
    {
        _logger.LogInformation($"Get airplane with id ({id})");
        var airplane = _airlinesRepository.Airplanes.FirstOrDefault(airplane => airplane.Id == id);
        if (airplane == null)
        {
            _logger.LogInformation($"Not found airplane with id ({id})");
            return NotFound();
        }
        else
        {
            return Ok(_mapper.Map<AirplaneGetDto>(airplane));
        }
    }

    /// <summary>
    /// Post method for airplane table
    /// </summary>
    /// <param name="airplane"> Airplane class instance to insert to table</param>
    [HttpPost]
    public void Post([FromBody] AirplanePostDto airplane)
    {
        _logger.LogInformation("Post airplane");
        _airlinesRepository.Airplanes.Add(_mapper.Map<AirplaneClass>(airplane));
    }

    /// <summary>
    /// Put method for airplane table
    /// </summary>
    /// <param name="id">An id of airplane which would be changed </param>
    /// <param name="airplaneToPut">Airplane class instance to insert to table</param>
    /// <returns>Signalization of success of error</returns>
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] AirplanePostDto airplaneToPut)
    {
        _logger.LogInformation("Put airplane with id {0}", id);
        var airplane = _airlinesRepository.Airplanes.FirstOrDefault(airplane => airplane.Id == id);
        if (airplane == null)
        {
            _logger.LogInformation("Not found airplane with id {0}", id);
            return NotFound();
        }
        else
        {
            _mapper.Map(airplaneToPut, airplane);
            return Ok();
        }
    }

    /// <summary>
    /// Delete method 
    /// </summary>
    /// <param name="id">An id of airplane which would be deleted</param>
    /// <returns>Signalization of success of error</returns>
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _logger.LogInformation($"Put airplane with id ({id})");
        var airplane = _airlinesRepository.Airplanes.FirstOrDefault(airplane => airplane.Id == id);
        if (airplane == null)
        {
            _logger.LogInformation($"Not found airplane with id ({id})");
            return NotFound();
        }
        else
        {
            _airlinesRepository.Airplanes.Remove(airplane);
            return Ok();
        }
    }
}