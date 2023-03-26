using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Taxi.Domain;
using Taxi.Server.Dto;
using Taxi.Server.Repository;

namespace Taxi.Server.Controllers;


[Route("api/[controller]")]
[ApiController]

public class PassengerController: ControllerBase
{
    private readonly ILogger<PassengerController> _logger;
    
    private readonly ITaxiRepository _taxiRepository;

    private readonly IMapper _mapper;
    
    public PassengerController(ILogger<PassengerController> logger, ITaxiRepository taxiRepository, IMapper mapper)
    {
        _logger = logger;
        _taxiRepository = taxiRepository;
        _mapper = mapper;
    }

    [HttpGet]
    public IEnumerable<PassengerGetDto> Get()
    {
        _logger.LogInformation("Get passenger");
        return _taxiRepository.Passengers.Select(passenger => _mapper.Map<PassengerGetDto>(passenger));
    }

    [HttpGet("{id}")]
    public ActionResult<PassengerGetDto> Get(ulong id)
    {
        var passenger = _taxiRepository.Passengers.FirstOrDefault(passenger => passenger.Id == id);
        if (passenger == null)
        {
            _logger.LogInformation($"Not found passenger with id={id}");
            return NotFound();
        }
        else
        {
            _logger.LogInformation($"Get passenger with id={id}");
            return Ok(_mapper.Map<PassengerGetDto>(passenger));
        }
    }

    [HttpPost]
    public void Post([FromBody] PassengerPostDto passenger)
    {
        _logger.LogInformation($"Post passenger");
        _taxiRepository.Passengers.Add(_mapper.Map<Passenger>(passenger));
    }
    
    [HttpPut("{id}")]

    public IActionResult Put(ulong id, [FromBody] PassengerPostDto passengerToPut)
    {
        var passenger = _taxiRepository.Passengers.FirstOrDefault(passenger => passenger.Id == id);
        if (passenger == null)
        {
            _logger.LogInformation($"Not found passenger with id={id}", id);
            return NotFound();
        }
        else
        {
            _logger.LogInformation($"Put passenger with id={id}", id);
            _mapper.Map(passengerToPut, passenger);
            return Ok();
        }
    }

    [HttpDelete("{id}")]
    
    public IActionResult Delete(ulong id)
    {
        var passenger = _taxiRepository.Passengers.FirstOrDefault(passenger => passenger.Id == id);
        if (passenger == null)
        {
            _logger.LogInformation($"Not found passenger with id={id}");
            return NotFound();
        }
        else
        {
            _logger.LogInformation($"Delete passenger with id={id}");
            _taxiRepository.Passengers.Remove(passenger);
            return Ok();
        }
    }
}