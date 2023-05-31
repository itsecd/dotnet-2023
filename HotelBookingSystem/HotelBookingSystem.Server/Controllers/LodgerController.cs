using AutoMapper;
using HotelBookingSystem.Model;
using HotelBookingSystem.Server.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotelBookingSystem.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LodgerController : ControllerBase
{
    private readonly ILogger<LodgerController> _logger;
    private readonly HotelBookingSystemDbContext _context;
    private readonly IMapper _mapper;

    public LodgerController(ILogger<LodgerController> logger, HotelBookingSystemDbContext context, IMapper mapper)
    {
        _logger = logger;
        _context = context;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(200)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<IEnumerable<LodgerGetDto>>> GetLodgers()
    {
        _logger.LogInformation("GetLodgers");
        if (_context.Lodgers == null)
        {
            return NotFound();
        }
        return await _mapper.ProjectTo<LodgerGetDto>(_context.Lodgers).ToListAsync();
    }

    [HttpGet("{id}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<LodgerGetDto>> GetLodger(int id)
    {
        _logger.LogInformation("GetLodger");
        if (_context.Lodgers == null)
        {
            return NotFound();
        }
        var lodger = await _context.Lodgers.FindAsync(id);

        if (lodger == null)
        {
            return NotFound();
        }

        return _mapper.Map<LodgerGetDto>(lodger);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> PutLodger(int id, LodgerPostDto lodger)
    {
        _logger.LogInformation("PutLodger");
        if (_context.Lodgers == null)
        {
            return NotFound();
        }
        var temp = await _context.Lodgers.FindAsync(id);
        if (temp == null)
        {
            return NotFound();
        }
        _mapper.Map(lodger, temp);
        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<ActionResult<LodgerGetDto>> PostLodger(LodgerPostDto lodger)
    {
        _logger.LogInformation("PostLodger");
        if (_context.Lodgers == null)
        {
            return Problem("Entity set 'HotelBookingSystemDbContext.Lodgers'  is null.");
        }
        var temp = _mapper.Map<Lodger>(lodger);
        _context.Lodgers.Add(temp);
        await _context.SaveChangesAsync();
        return CreatedAtAction("PostLodger", new { id = temp.Id }, _mapper.Map<LodgerGetDto>(temp));
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteLodger(int id)
    {
        _logger.LogInformation("DeleteLodger");
        if (_context.Lodgers == null)
        {
            return NotFound();
        }
        var lodger = await _context.Lodgers.FindAsync(id);
        if (lodger == null)
        {
            return NotFound();
        }

        _context.Lodgers.Remove(lodger);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
