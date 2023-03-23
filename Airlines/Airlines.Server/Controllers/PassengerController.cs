using Airlines.Domain;
using Airlines.Server.Dto;
using Airlines.Server.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Airlines.Server.Controllers;
[Route("api/[controller]")]
[ApiController]
public class PassengerController : ControllerBase
{
    private readonly ILogger<PassengerController> _logger;
    private readonly IAirlinesRepository _airlinesRepository;
    private readonly IMapper _mapper;

    public PassengerController(ILogger<PassengerController> logger, IAirlinesRepository airlinesRepository, IMapper mapper)
    {
        _logger = logger;
        _airlinesRepository = airlinesRepository;
        _mapper = mapper;
    }
    [HttpGet]
    public IEnumerable<PassengerGetDto> Get()
    {
        _logger.LogInformation("Get passengers");
        return _airlinesRepository.Passengers.Select(passenger => _mapper.Map<PassengerGetDto>(passenger));
    }

    [HttpGet("{id}")]
    public ActionResult<PassengerGetDto> Get(int id)
    {
        _logger.LogInformation($"Get passenger with id ({id})");
        var passenger = _airlinesRepository.Passengers.FirstOrDefault(passenger => passenger.Id == id);
        if (passenger == null)
        {
            _logger.LogInformation($"Not found passenger with id ({id})");
            return NotFound();
        }
        else
        {
            return Ok(_mapper.Map<PassengerGetDto>(passenger));
        }
    }

    [HttpPost]
    public void Post([FromBody] PassengerPostDto passenger)
    {
        _logger.LogInformation("Post");
        _airlinesRepository.Passengers.Add(_mapper.Map<PassengerClass>(passenger));
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] PassengerPostDto passengerToPut)
    {
        _logger.LogInformation("Put passenger with id {0}", id);
        var passenger = _airlinesRepository.Passengers.FirstOrDefault(passenger => passenger.Id == id);
        if (passenger == null)
        {
            _logger.LogInformation("Not found passenger with id {0}", id);
            return NotFound();
        }
        else
        {
            _mapper.Map(passengerToPut, passenger);
            return Ok();
        }
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _logger.LogInformation($"Put passenger with id ({id})");
        var passenger = _airlinesRepository.Passengers.FirstOrDefault(passenger => passenger.Id == id);
        if (passenger == null)
        {
            _logger.LogInformation($"Not found passenger with id ({id})");
            return NotFound();
        }
        else
        {
            _airlinesRepository.Passengers.Remove(passenger);
            return Ok();
        }
    }
}
