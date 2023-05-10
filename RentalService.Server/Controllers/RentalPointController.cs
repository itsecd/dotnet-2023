using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentalService.Domain;
using RentalService.Server.Dto;

namespace RentalService.Server.Controllers;

/// <summary>
///     Controller for rental point table
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class RentalPointController : ControllerBase
{
    private readonly RentalServiceDbContext _context;
    private readonly IMapper _mapper;

    public RentalPointController(RentalServiceDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    /// <summary>
    ///     Get method which returns all rental points
    /// </summary>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<RentalPointGetDto>>> Get()
    {
        if (_context.RentalPoints == null)
        {
            return NotFound();
        }

        return await _mapper.ProjectTo<RentalPointGetDto>(_context.RentalPoints).ToListAsync();
    }

    /// <summary>
    ///     Get method which returns rental point by id
    /// </summary>
    [HttpGet("{id}")]
    public async Task<ActionResult<RentalPointGetDto>> Get(ulong id)
    {
        if (_context.RentalPoints == null)
        {
            return NotFound();
        }

        RentalPoint? rentalPoint = await _context.RentalPoints.FindAsync(id);

        if (rentalPoint == null)
        {
            return NotFound();
        }

        return Ok(_mapper.Map<RentalPointGetDto>(rentalPoint));
    }

    /// <summary>
    ///     Post method which add new rental point
    /// </summary>
    [HttpPost]
    public async Task<ActionResult<RentalPointGetDto>> Post([FromBody] RentalPointPostDto rentalPoint)
    {
        if (_context.RentalPoints == null)
        {
            return Problem("Entity set 'DataBaseContext.RentalPoints'  is null.");
        }

        RentalPoint? mappedRentalPoint = _mapper.Map<RentalPoint>(rentalPoint);

        _context.RentalPoints.Add(mappedRentalPoint);
        await _context.SaveChangesAsync();

        return CreatedAtAction("Post", new { id = mappedRentalPoint.Id },
            _mapper.Map<RentalPointGetDto>(mappedRentalPoint));
    }

    /// <summary>
    ///     Put method for changing data in the rental point table
    /// </summary>
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(ulong id, [FromBody] RentalPointPostDto rentalPointToPut)
    {
        if (_context.RentalPoints == null)
        {
            return NotFound();
        }

        RentalPoint? rentalPointToModify = await _context.RentalPoints.FindAsync(id);

        if (rentalPointToModify == null)
        {
            return NotFound();
        }

        _mapper.Map(rentalPointToPut, rentalPointToModify);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    /// <summary>
    ///     Delete method for deleting a rental point
    /// </summary>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(ulong id)
    {
        if (_context.RentalPoints == null)
        {
            return NotFound();
        }

        RentalPoint? rentalPoint = await _context.RentalPoints.FindAsync(id);
        if (rentalPoint == null)
        {
            return NotFound();
        }

        _context.RentalPoints.Remove(rentalPoint);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}