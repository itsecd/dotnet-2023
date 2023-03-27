using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Taxi.Domain;
using Taxi.Server.Dto;
using Taxi.Server.Repository;

namespace Taxi.Server.Controllers;

/// <summary>
///     Controller for ride table
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class RideController : ControllerBase
{
    private readonly ILogger<RideController> _logger;

    private readonly IMapper _mapper;

    private readonly ITaxiRepository _taxiRepository;

    public RideController(ILogger<RideController> logger, ITaxiRepository taxiRepository, IMapper mapper)
    {
        _logger = logger;
        _taxiRepository = taxiRepository;
        _mapper = mapper;
    }

    /// <summary>
    ///     Get method which returns all rides
    /// </summary>
    /// <returns>
    ///     List of ride
    /// </returns>
    [HttpGet]
    public IEnumerable<Ride> Get()
    {
        _logger.LogInformation("Get rides");
        return _taxiRepository.Rides;
    }

    /// <summary>
    ///     Get method which returns ride by id
    /// </summary>
    /// <param name="id"> Identifier of ride</param>
    /// <returns>
    ///     Ride with the required id
    /// </returns>
    [HttpGet("{id}")]
    public ActionResult<Ride> Get(ulong id)
    {
        Ride? ride = _taxiRepository.Rides.FirstOrDefault(ride => ride.Id == id);
        if (ride == null)
        {
            _logger.LogInformation("Not found ride with id={id}", id);
            return NotFound();
        }

        _logger.LogInformation("Get ride with id={id}", id);
        return Ok(ride);
    }

    /// <summary>
    ///     Post method which add new ride in ride table
    /// </summary>
    /// <param name="ride"> New ride for addition</param>
    /// >
    [HttpPost]
    public void Post([FromBody] RidePostDto ride)
    {
        _logger.LogInformation("Post ride");
        _taxiRepository.Rides.Add(_mapper.Map<Ride>(ride));
    }

    /// <summary>
    ///     Put method which allows change the data of the desired ride by id
    /// </summary>
    /// <param name="id"> Identifier of ride</param>
    /// <param name="rideToPut"> New ride data</param>
    /// <returns>
    ///     Signalization of success or error
    /// </returns>
    [HttpPut("{id}")]
    public IActionResult Put(ulong id, [FromBody] RidePostDto rideToPut)
    {
        Ride? ride = _taxiRepository.Rides.FirstOrDefault(ride => ride.Id == id);
        if (ride == null)
        {
            _logger.LogInformation("Not found ride with id={id}", id);
            return NotFound();
        }

        _logger.LogInformation("Put ride with id={id}", id);
        _mapper.Map(rideToPut, ride);
        return Ok();
    }

    /// <summary>
    ///     Delete - method for deleting a ride by the desired identifier
    /// </summary>
    /// <param name="id"> Identifier of ride </param>
    /// <returns>
    ///     Signalization of success or error
    /// </returns>
    [HttpDelete("{id}")]
    public IActionResult Delete(ulong id)
    {
        Ride? ride = _taxiRepository.Rides.FirstOrDefault(ride => ride.Id == id);
        if (ride == null)
        {
            _logger.LogInformation("Not found ride with id={id}", id);
            return NotFound();
        }

        _logger.LogInformation("Delete ride with id={id}", id);
        _taxiRepository.Rides.Remove(ride);
        return Ok();
    }
}