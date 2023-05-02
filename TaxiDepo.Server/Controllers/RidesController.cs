using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaxiDepo.Model;
using TaxiDepo.Server.Dto;

namespace TaxiDepo.Server.Controllers;

/// <summary>
/// RidesController class 
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class RidesController : ControllerBase
{
    /// <summary>
    /// TaxiDepoDbContext class object
    /// </summary>
    private readonly TaxiDepoDbContext _context;

    /// <summary>
    /// Mapper for RidesController class
    /// </summary>
    private readonly IMapper _mapper;

    /// <summary>
    /// Logger for RidesController class
    /// </summary>
    private readonly ILogger<RidesController> _logger;

    /// <summary>
    /// Constructor with params of RidesController class 
    /// </summary>
    /// <param name="context">TaxiDepoDbContext class object</param>
    /// <param name="mapper">IMapper object</param>
    /// <param name="logger">ILogger object</param>
    public RidesController(TaxiDepoDbContext context, IMapper mapper, ILogger<RidesController> logger)
    {
        _context = context;
        _mapper = mapper;
        _logger = logger;
    }

    /// <summary>
    /// Get all rides from collection
    /// </summary>
    /// <returns>RideDto object</returns>
    [HttpGet("GetAllRides")]
    public async Task<ActionResult<IEnumerable<RideDto>>> GetRides()
    {
        if (_context.Rides == null)
        {
            _logger.LogInformation("Not found a rides");
            return NotFound();
        }

        _logger.LogInformation("Get all rides from collection");
        return await _mapper.ProjectTo<RideDto>(_context.Rides).ToListAsync();
    }

    /// <summary>
    /// Get ride by id from collection
    /// </summary>
    /// <param name="id">Needed ride id</param>
    /// <returns>RideDto object</returns>
    [HttpGet("GetRideBy{id}")]
    public async Task<ActionResult<RideDto>> GetRide(int id)
    {
        if (_context.Rides == null)
        {
            _logger.LogInformation("Not found a rides");
            return NotFound();
        }

        _logger.LogInformation("Get ride by id from collection");
        var ride = await _context.Rides.FindAsync(id);
        if (ride == null)
        {
            _logger.LogInformation("Not found a ride by id");
            return NotFound();
        }

        return _mapper.Map<RideDto>(ride);
    }

    /// <summary>
    /// Put ride from collection
    /// </summary>
    /// <param name="id">Needed id to put</param>
    /// <param name="ride">Ride to put</param>
    /// <returns>No content</returns>
    [HttpPut("PutRideBy{id}")]
    public async Task<IActionResult> PutRide(int id, RideDto ride)
    {
        if (_context.Rides == null)
        {
            _logger.LogInformation("Not found a rides");
            return NotFound();
        }

        _logger.LogInformation("Put a ride by id from collection");
        var rideToModify = await _context.Rides.FindAsync(id);
        if (rideToModify == null)
        {
            _logger.LogInformation("Not found a ride by id");
            return NotFound();
        }

        _mapper.Map(ride, rideToModify);
        await _context.SaveChangesAsync();
        return NoContent();
    }

    /// <summary>
    /// Post ride to collection
    /// </summary>
    /// <param name="ride">Ride to post</param>
    /// <returns>Created action</returns>
    [HttpPost("PostRide")]
    [ProducesResponseType(201)]
    public async Task<ActionResult<RideDto>> PostRide(RideDto ride)
    {
        if (_context.Rides == null)
        {
            return Problem("Entity set 'TaxiDepoDbContext.Rides'  is null.");
        }

        _logger.LogInformation("Posting ride to collection");
        var mappedRide = _mapper.Map<Ride>(ride);
        _context.Rides.Add(mappedRide);
        await _context.SaveChangesAsync();
        return CreatedAtAction("PostRide", new { id = mappedRide.Id }, _mapper.Map<RideDto>(mappedRide));
    }

    /// <summary>
    /// Delete ride from collection
    /// </summary>
    /// <param name="id">Needed id to delete</param>
    /// <returns>No content</returns>
    [HttpDelete("DeleteRideBy{id}")]
    public async Task<IActionResult> DeleteRide(int id)
    {
        if (_context.Rides == null)
        {
            _logger.LogInformation("Not found a rides");
            return NotFound();
        }

        _logger.LogInformation("Deletion ride from collection");
        var ride = await _context.Rides.FindAsync(id);
        if (ride == null)
        {
            _logger.LogInformation("Not found a ride by id");
            return NotFound();
        }

        _context.Rides.Remove(ride);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}