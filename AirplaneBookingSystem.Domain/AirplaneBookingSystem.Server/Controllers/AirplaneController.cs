using AirplaneBookingSystem.Domain;
using AirplaneBookingSystem.Server.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace AirplaneBookingSystem.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AirplaneController : ControllerBase
{
    private readonly ILogger<AirplaneController> _logger;
    private readonly IAirplaneBookingSystemRepository _airplaneRepository;
    private readonly IMapper _mapper;
    public AirplaneController(ILogger<AirplaneController> logger, IAirplaneBookingSystemRepository airplaneRepository, IMapper mapper)
    {
        _logger = logger;
        _airplaneRepository = airplaneRepository;
        _mapper = mapper;
    }
    [HttpGet]
    public IEnumerable<Airplane> Get()
    {
        _logger.LogInformation("Get airplanes");
        return _airplaneRepository.Airplanes;
    }

    [HttpGet("{id}")]
    public ActionResult<Airplane> Get(int id)
    {
        _logger.LogInformation($"Get airplane with id {id}");
        var  airplane = _airplaneRepository.Airplanes.FirstOrDefault(airplane => airplane.Id == id);
        if (airplane == null)
        {
            _logger.LogInformation($"Not found airplane with id {id}");
            return NotFound();
        }
        else
        {
            return Ok(airplane);
        }
    }
}