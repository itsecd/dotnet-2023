using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Taxi.Domain;
using Taxi.Server.Dto;
using Taxi.Server.Repository;

namespace Taxi.Server.Controllers;

/// <summary>
///     Controller for passenger table
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class PassengerController : ControllerBase
{
    private readonly ILogger<PassengerController> _logger;
    private readonly IMapper _mapper;
    private readonly ITaxiRepository _taxiRepository;

    public PassengerController(ILogger<PassengerController> logger, ITaxiRepository taxiRepository, IMapper mapper)
    {
        _logger = logger;
        _taxiRepository = taxiRepository;
        _mapper = mapper;
    }

    /// <summary>
    ///     Get method which returns all passengers
    /// </summary>
    /// <returns>
    ///     List of passenger
    /// </returns>
    [HttpGet]
    public IEnumerable<PassengerGetDto> Get()
    {
        _logger.LogInformation("Get passenger");
        return _taxiRepository.Passengers.Select(passenger => _mapper.Map<PassengerGetDto>(passenger));
    }

    /// <summary>
    ///     Get method which returns passenger by id
    /// </summary>
    /// <param name="id"> Identifier of passenger</param>
    /// <returns>
    ///     Passenger with the required id
    /// </returns>
    [HttpGet("{id}")]
    public ActionResult<PassengerGetDto> Get(ulong id)
    {
        Passenger? passenger = _taxiRepository.Passengers.FirstOrDefault(passenger => passenger.Id == id);
        if (passenger == null)
        {
            _logger.LogInformation("Not found passenger with id={id}", id);
            return NotFound();
        }

        _logger.LogInformation("Get passenger with id={id}", id);
        return Ok(_mapper.Map<PassengerGetDto>(passenger));
    }

    /// <summary>
    ///     Post method which add new passenger in passenger table
    /// </summary>
    /// <param name="passenger"> New passenger for addition</param>
    /// >
    [HttpPost]
    public void Post([FromBody] PassengerPostDto passenger)
    {
        _logger.LogInformation("Post passenger");
        _taxiRepository.Passengers.Add(_mapper.Map<Passenger>(passenger));
    }

    /// <summary>
    ///     Put method which allows change the data of the desired passenger by id
    /// </summary>
    /// <param name="id"> Identifier of passenger</param>
    /// <param name="passengerToPut"> New passenger data</param>
    /// <returns>
    ///     Signalization of success or error
    /// </returns>
    [HttpPut("{id}")]
    public IActionResult Put(ulong id, [FromBody] PassengerPostDto passengerToPut)
    {
        Passenger? passenger = _taxiRepository.Passengers.FirstOrDefault(passenger => passenger.Id == id);
        if (passenger == null)
        {
            _logger.LogInformation("Not found passenger with id={id}", id);
            return NotFound();
        }

        _logger.LogInformation("Put passenger with id={id}", id);
        _mapper.Map(passengerToPut, passenger);
        return Ok();
    }

    /// <summary>
    ///     Delete - method for deleting a passenger by the desired identifier
    /// </summary>
    /// <param name="id"> Identifier of passenger </param>
    /// <returns>
    ///     Signalization of success or error
    /// </returns>
    [HttpDelete("{id}")]
    public IActionResult Delete(ulong id)
    {
        Passenger? passenger = _taxiRepository.Passengers.FirstOrDefault(passenger => passenger.Id == id);
        if (passenger == null)
        {
            _logger.LogInformation("Not found passenger with id={id}", id);
            return NotFound();
        }

        _logger.LogInformation("Delete passenger with id={id}", id);
        _taxiRepository.Passengers.Remove(passenger);
        return Ok();
    }
}