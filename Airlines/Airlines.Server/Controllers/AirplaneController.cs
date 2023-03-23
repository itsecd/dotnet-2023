using Airlines.Domain;
using Airlines.Server.Dto;
using Airlines.Server.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Airlines.Server.Controllers;
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
    [HttpGet]
    public IEnumerable<AirplaneGetDto> Get()
    {
        _logger.LogInformation("Get passengers");
        return _airlinesRepository.Airplanes.Select(airplane => _mapper.Map<AirplaneGetDto>(airplane));
    }

    [HttpGet("{id}")]
    public ActionResult<AirplaneGetDto> Get(int id)
    {
        _logger.LogInformation($"Get passenger with id ({id})");
        var airplane = _airlinesRepository.Airplanes.FirstOrDefault(airplane => airplane.Id == id);
        if (airplane == null)
        {
            _logger.LogInformation($"Not found passenger with id ({id})");
            return NotFound();
        }
        else
        {
            return Ok(_mapper.Map<AirplaneGetDto>(airplane));
        }
    }

    [HttpPost]
    public void Post([FromBody] AirplanePostDto airplane)
    {
        _logger.LogInformation("Post");
        _airlinesRepository.Airplanes.Add(_mapper.Map<AirplaneClass>(airplane));
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] AirplanePostDto airplaneToPut)
    {
        _logger.LogInformation("Put passenger with id {0}", id);
        var airplane = _airlinesRepository.Airplanes.FirstOrDefault(airplane => airplane.Id == id);
        if (airplane == null)
        {
            _logger.LogInformation("Not found passenger with id {0}", id);
            return NotFound();
        }
        else
        {
            _mapper.Map(airplaneToPut, airplane);
            return Ok();
        }
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _logger.LogInformation($"Put passenger with id ({id})");
        var airplane = _airlinesRepository.Airplanes.FirstOrDefault(airplane => airplane.Id == id);
        if (airplane == null)
        {
            _logger.LogInformation($"Not found passenger with id ({id})");
            return NotFound();
        }
        else
        {
            _airlinesRepository.Airplanes.Remove(airplane);
            return Ok();
        }
    }
}
