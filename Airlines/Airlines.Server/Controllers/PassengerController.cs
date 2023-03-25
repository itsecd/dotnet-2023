using Airlines.Domain;
using Airlines.Server.Dto;
using Airlines.Server.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Airlines.Server.Controllers;

/// <summary>
/// Controller for passenger table
/// </summary>
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

    /// <summary>
    /// Get method for passenger table
    /// </summary>
    /// <returns>
    /// Return all passengers
    /// </returns>
    [HttpGet]
    public IEnumerable<PassengerGetDto> Get()
    {
        _logger.LogInformation("Get passengers");
        return _airlinesRepository.Passengers.Select(passenger => _mapper.Map<PassengerGetDto>(passenger));
    }

    /// <summary>
    /// Get by id method for passenger table
    /// </summary>
    /// <returns>
    /// Return passenger with specified id
    /// </returns>
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


    /// <summary>
    /// Post method for passenger table
    /// </summary>
    /// <param name="passenger"> Passenger class instance to insert to table</param>
    [HttpPost]
    public void Post([FromBody] PassengerPostDto passenger)
    {
        _logger.LogInformation("Post");
        _airlinesRepository.Passengers.Add(_mapper.Map<PassengerClass>(passenger));
    }

    /// <summary>
    /// Put method for passenger table
    /// </summary>
    /// <param name="id">An id of passenger which would be changed </param>
    /// <param name="passengerToPut">Passenger class instance to insert to table</param>
    /// <returns>Signalization of success of error</returns>
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

    /// <summary>
    /// Delete method 
    /// </summary>
    /// <param name="id">An id of passenger which would be deleted</param>
    /// <returns>Signalization of success of error</returns>
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