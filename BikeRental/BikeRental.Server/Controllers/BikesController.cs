using AutoMapper;
using BikeRental.Domain;
using BikeRental.Server.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BikeRental.Server.Controllers;

/// <summary>
/// Bikes
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class BikesController : ControllerBase
{
    private readonly BikeRentalDbContext _context;

    private readonly IMapper _mapper;

    private readonly ILogger<BikesController> _logger;

    public BikesController(BikeRentalDbContext context, IMapper mapper, ILogger<BikesController> logger)
    {
        _context = context;
        _mapper = mapper;
        _logger = logger;
    }

    /// <summary>
    /// View all bikes
    /// </summary>
    /// <returns>Bikes list</returns>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<BikeGetDto>>> GetBikes()
    {
        if (_context.Bikes == null)
        {
            return NotFound();
        }
        _logger.LogInformation("Get bikes list");
        return await _mapper.ProjectTo<BikeGetDto>(_context.Bikes).ToListAsync();
    }

    /// <summary>
    /// View bike by id
    /// </summary>
    /// <param name="id">Bike id</param>
    /// <returns>Bike</returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<BikeGetDto>> GetBike(int id)
    {
        _logger.LogInformation("Get the bike by id");
        if (_context.Bikes == null)
        {
            return NotFound();
        }
        var bike = await _context.Bikes.FindAsync(id);

        if (bike == null)
        {
            _logger.LogInformation("Bike not found");
            return NotFound();
        }

        return _mapper.Map<BikeGetDto>(bike);
    }

    /// <summary>
    /// Change bike info
    /// </summary>
    /// <param name="id">Bike id</param>
    /// <param name="bike">Changing bike</param>
    /// <returns>Action result</returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> PutBike(int id, BikeSetDto bike)
    {
        if (_context.Bikes == null)
        {
            return NotFound();
        }
        var bikeToModify = await _context.Bikes.FindAsync(id);
        if (bikeToModify == null)
        {
            _logger.LogInformation("Bike not found");
            return NotFound();
        }

        _mapper.Map(bike, bikeToModify);

        _logger.LogInformation("Successfully updated");

        await _context.SaveChangesAsync();

        return NoContent();
    }

    /// <summary>
    /// Adding new bike
    /// </summary>
    /// <param name="bike">Bike</param>
    /// <returns>Added bike</returns>
    [HttpPost]
    [ProducesResponseType(201)]
    public async Task<ActionResult<BikeGetDto>> PostBike(BikeSetDto bike)
    {
        if (_context.Bikes == null)
        {
            return Problem("Entity set 'BikeRentalDbContext.Bikes'  is null.");
        }
        var mappedBike = _mapper.Map<Bike>(bike);

        _context.Bikes.Add(mappedBike);

        _logger.LogInformation("Successfully added");

        await _context.SaveChangesAsync();

        return CreatedAtAction("PostBike", new { id = mappedBike.Id }, _mapper.Map<BikeGetDto>(mappedBike));
    }

    /// <summary>
    /// Deleting a bike
    /// </summary>
    /// <param name="id">Deleted bike id</param>
    /// <returns>Action result</returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBike(int id)
    {
        if (_context.Bikes == null)
        {
            return NotFound();
        }
        var bike = await _context.Bikes.FindAsync(id);
        if (bike == null)
        {
            _logger.LogInformation("Bike not found");
            return NotFound();
        }

        _context.Bikes.Remove(bike);

        _logger.LogInformation("Successfully deleted");

        await _context.SaveChangesAsync();

        return NoContent();
    }
}
