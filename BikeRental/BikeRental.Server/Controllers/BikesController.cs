using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BikeRental.Domain;
using AutoMapper;
using BikeRental.Server.Dto;

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

    public BikesController(BikeRentalDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
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
      if (_context.Bikes == null)
      {
          return NotFound();
      }
        var bike = await _context.Bikes.FindAsync(id);

        if (bike == null)
        {
            return NotFound();
        }

        return _mapper.Map<BikeGetDto>(bike);
    }

    /// <summary>
    /// Change bike info
    /// </summary>
    /// <param name="id">Bike id</param>
    /// <param name="bike">Cnanging bike</param>
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
            return NotFound();
        }

        _mapper.Map(bike, bikeToModify);

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
            return NotFound();
        }

        _context.Bikes.Remove(bike);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
