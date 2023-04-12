using AirLine.Domain;
using Airline.Server.Dto;
using Airline.Server.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;


namespace Airline.Server.Controllers;
/// <summary>
/// Passenger table controller
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class PassengerController : ControllerBase
{
    private readonly ILogger<PassengerController> _logger;
    private readonly IAirlineRepository _airlineRepository;
    private readonly IMapper _mapper;

    public PassengerController(ILogger<PassengerController> logger, IAirlineRepository airlineRepository, IMapper mapper)
    {
        _logger = logger;
        _airlineRepository = airlineRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Get table passengers
    /// </summary>
    /// <returns>
    /// Return all passengers
    /// </returns>
    [HttpGet]
    public IEnumerable<PassengerGetDto> Get()
    {
        _logger.LogInformation("Get passengers");
        return _airlineRepository.Passengers.Select(passenger => _mapper.Map<PassengerGetDto>(passenger));
    }

    /// <summary>
    /// Get passenger by id
    /// </summary>
    /// <param name="id">Passenger id</param>
    /// <returns>
    /// Return passenger with specified id
    /// </returns>
    [HttpGet("{id}")]
    public ActionResult<PassengerGetDto> Get(int id)
    {
        _logger.LogInformation($"Get passenger: id ({id})");
        var passenger = _airlineRepository.Passengers.FirstOrDefault(passenger => passenger.Id == id);
        if (passenger == null)
        {
            _logger.LogInformation($"Not found passenger: id ({id})");
            return NotFound();
        }
        else
        {
            return Ok(_mapper.Map<PassengerGetDto>(passenger));
        }
    }


    /// <summary>
    /// Post passenger
    /// </summary>
    /// <param name="passenger"> Passenger class for insert in table</param>
    [HttpPost]
    public void Post([FromBody] PassengerPostDto passenger)
    {
        _logger.LogInformation("Post");
        _airlineRepository.Passengers.Add(_mapper.Map<Passenger>(passenger));
    }

    /// <summary>
    /// Put passenger
    /// </summary>
    /// <param name="id">Passenger id for be changed</param>
    /// <param name="passengerToPut">Passenger class for insert in table</param>
    /// <returns>Signalization of success of error</returns>
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] PassengerPostDto passengerToPut)
    {
        _logger.LogInformation("Put passenger: id {0}", id);
        var passenger = _airlineRepository.Passengers.FirstOrDefault(passenger => passenger.Id == id);
        if (passenger == null)
        {
            _logger.LogInformation("Not found passenger: id {0}", id);
            return NotFound();
        }
        else
        {
            _mapper.Map(passengerToPut, passenger);
            return Ok();
        }
    }

    /// <summary>
    /// Delete passenger 
    /// </summary>
    /// <param name="id">Passenger id for deleting</param>
    /// <returns>Triggered of success and error</returns>
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _logger.LogInformation($"Put passenger: id ({id})");
        var passenger = _airlineRepository.Passengers.FirstOrDefault(passenger => passenger.Id == id);
        if (passenger == null)
        {
            _logger.LogInformation($"Not found passenger: id ({id})");
            return NotFound();
        }
        else
        {
            _airlineRepository.Passengers.Remove(passenger);
            return Ok();
        }
    }
}
