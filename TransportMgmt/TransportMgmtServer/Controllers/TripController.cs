using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TransportMgmt.Domain;
using TransportMgmtServer.Dto;

namespace TransportMgmtServer.Controllers;

/// <summary>
/// Controller for trip
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class TripController : ControllerBase
{
    /// <summary>
    /// Used to store factory context
    /// </summary>
    private readonly IDbContextFactory<TransportMgmtContext> _contextFactory;
    /// <summary>
    /// Used to store logger
    /// </summary>
    private readonly ILogger<TripController> _logger;
    /// <summary>
    /// Used to store map's object
    /// </summary>
    private readonly IMapper _mapper;
    /// <summary>
    /// Controller constructor
    /// </summary>
    public TripController(ILogger<TripController> logger, IDbContextFactory<TransportMgmtContext> contextFactory, IMapper mapper)
    {
        _logger = logger;
        _contextFactory = contextFactory;
        _mapper = mapper;
    }
    /// <summary>
    /// Returns a list of all trips
    /// </summary>
    /// <returns> Returns a list of all trips </returns>
    [HttpGet]
    public async Task<IEnumerable<TripGetDto>> Get()
    {
        await using var context = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation("Get trips");
        return _mapper.Map<IEnumerable<TripGetDto>>(context.Trips);
    }
    /// <summary>
    /// Get method that returns trip with a specific id
    /// </summary>
    /// <param name="id"> Trip id </param>
    /// <returns> Transports with required id </returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<TripGetDto>> Get(int id)
    {
        await using var context = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation("Get trip with id= {id}", id);
        var trip = await context.Trips.FirstOrDefaultAsync(trip => trip.Id == id);
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
    /// <param name="trip"> Added trip </param>
    [HttpPost]
    public async Task Post([FromBody] TripPostDto trip)
    {
        await using var context = await _contextFactory.CreateDbContextAsync();
        await context.Trips.AddAsync(_mapper.Map<Trip>(trip));
        _logger.LogInformation("Successfully added");
        await context.SaveChangesAsync();
    }
    /// <summary>
    /// Put method which allows change the data of trip with a specific id
    /// </summary>
    /// <param name="id"> Trip id whose data will change </param>
    /// <param name="tripToPut"> New trip data </param>
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] TripPostDto tripToPut)
    {
        await using var context = await _contextFactory.CreateDbContextAsync();
        var trip = await context.Trips.FirstOrDefaultAsync(trip => trip.Id == id);
        if (trip == null)
        {
            _logger.LogInformation("Not found trip with id= {id} ", id);
            return NotFound();
        }
        else
        {
            _mapper.Map(tripToPut, trip);
            _logger.LogInformation("Successfully updates");
            await context.SaveChangesAsync();
            return Ok();
        }
    }
    /// <summary>
    /// Delete method which allows delete a trip with a specific id
    /// </summary>
    /// <param name="id"> Trip id </param>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await using var context = await _contextFactory.CreateDbContextAsync();
        var trip = await context.Trips.FirstOrDefaultAsync(trip => trip.Id == id);
        if (trip == null)
        {
            _logger.LogInformation("Not found trip with id= {id} ", id);
            return NotFound();
        }
        else
        {
            context.Trips.Remove(trip);
            _logger.LogInformation("Successfully removed");
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
