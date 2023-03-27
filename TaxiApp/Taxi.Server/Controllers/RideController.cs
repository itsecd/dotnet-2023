using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Taxi.Domain;
using Taxi.Server.Dto;
using Taxi.Server.Repository;

namespace Taxi.Server.Controllers;


[Route("api/[controller]")]
[ApiController]

public class RideController: ControllerBase
{
    private readonly ILogger<RideController> _logger;
    
    private readonly ITaxiRepository _taxiRepository;

    private readonly IMapper _mapper;
    
    public RideController(ILogger<RideController> logger, ITaxiRepository taxiRepository, IMapper mapper)
    {
        _logger = logger;
        _taxiRepository = taxiRepository;
        _mapper = mapper;
    }

    [HttpGet]
    public IEnumerable<Ride> Get()
    {
        _logger.LogInformation("Get rides");
        return _taxiRepository.Rides;
    }

    [HttpGet("{id}")]
    public ActionResult<Ride> Get(ulong id)
    {
        var ride = _taxiRepository.Rides.FirstOrDefault(ride => ride.Id == id);
        if (ride == null)
        {
            _logger.LogInformation($"Not found ride with id={id}");
            return NotFound();
        }
        else
        {
            _logger.LogInformation($"Get ride with id={id}");
            return Ok(ride);
        }
    }

    [HttpPost]
    public void Post([FromBody] RidePostDto ride)
    {
        _logger.LogInformation($"Post ride");
        _taxiRepository.Rides.Add(_mapper.Map<Ride>(ride));
    }
    
    [HttpPut("{id}")]

    public IActionResult Put(ulong id, [FromBody] RidePostDto rideToPut)
    {
        var ride = _taxiRepository.Rides.FirstOrDefault(ride => ride.Id == id);
        if (ride == null)
        {
            _logger.LogInformation($"Not found ride with id={id}", id);
            return NotFound();
        }
        else
        {
            _logger.LogInformation($"Put ride with id={id}", id);
            _mapper.Map(rideToPut, ride);
            return Ok();
        }
    }

    [HttpDelete("{id}")]
    
    public IActionResult Delete(ulong id)
    {
        var ride = _taxiRepository.Rides.FirstOrDefault(ride => ride.Id == id);
        if (ride == null)
        {
            _logger.LogInformation($"Not found ride with id={id}");
            return NotFound();
        }
        else
        {
            _logger.LogInformation($"Delete ride with id={id}");
            _taxiRepository.Rides.Remove(ride);
            return Ok();
        }
    }
}