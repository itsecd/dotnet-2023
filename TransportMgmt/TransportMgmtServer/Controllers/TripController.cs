using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TransportMgmt.Domain;
using TransportMgmtServer.Dto;
using TransportMgmtServer.Repository;

namespace TransportMgmtServer.Controllers;

/// <summary>
/// Controller for trip
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class TripController : ControllerBase
{
    /// <summary>
    /// Used to store logger
    /// </summary>
    private readonly ILogger<TripController> _logger;
    /// <summary>
    /// Used to store repository
    /// </summary>
    private readonly ITransportMgmtRepository _transportRepository;
    /// <summary>
    /// Used to store map's object
    /// </summary>
    private readonly IMapper _mapper;
    /// <summary>
    /// Controller constructor
    /// </summary>
    public TripController(ILogger<TripController> logger, ITransportMgmtRepository transportRepository, IMapper mapper)
    {
        _logger = logger;
        _transportRepository = transportRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Returns a list of all trips
    /// </summary>
    /// <returns> Returns a list of all transports </returns>
    [HttpGet]

    public IEnumerable<TripGetDto> Get()
    {
        _logger.LogInformation("Get trips");
        return _transportRepository.Trips.Select(trip => _mapper.Map<TripGetDto>(trip));
    }

    /// <summary>
    /// Get method that returns trip with a specific id
    /// </summary>
    /// <param name="id"> Transports id </param>
    /// <returns> Transports with required id </returns>
    [HttpGet("{id}")]

    public ActionResult<TripGetDto> Get(int id)
    {
        _logger.LogInformation("Get trip with id= {id}", id);
        var trip = _transportRepository.Trips.FirstOrDefault(trip => trip.Id == id);
        if (trip == null)
        {
            _logger.LogInformation("Not found trip with id= {id} ", id);
            return NotFound();
        }
        else return Ok(_mapper.Map<TripGetDto>(trip));
    }

    /// <summary>
    /// Post method that adding a new trip
    /// </summary>
    /// <param name="trip"></param>
    [HttpPost]

    public void Post([FromBody] TripPostDto trip)
    {
        _transportRepository.Trips.Add(_mapper.Map<Trip>(trip));
        _logger.LogInformation("Successfully added");
    }

    /// <summary>
    /// Put method which allows change the data of trip with a specific id
    /// </summary>
    /// <param name="id"></param>
    /// <param name="tripToPut"></param>
    /// <returns></returns>
    [HttpPut("{id}")]

    public IActionResult Put(int id, [FromBody] TripPostDto tripToPut)
    {
        var trip = _transportRepository.Trips.FirstOrDefault(trip => trip.Id == id);
        if (trip == null)
        {
            _logger.LogInformation("Not found trip with id= {id} ", id);
            return NotFound();
        }
        else
        {
            _mapper.Map(tripToPut, trip);
            _logger.LogInformation("Successfully updates");
            return Ok();
        }
    }

    /// <summary>
    /// Delete method which allows delete a trip with a specific id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]

    public IActionResult Delete(int id)
    {
        var trip = _transportRepository.Trips.FirstOrDefault(trip => trip.Id == id);
        if (trip == null)
        {
            _logger.LogInformation("Not found trip with id= {id} ", id);
            return NotFound();
        }
        else
        {
            _transportRepository.Trips.Remove(trip);
            _logger.LogInformation("Successfully removed");
            return Ok();
        }
    }
}
