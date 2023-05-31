using AutoMapper;
using HotelBookingSystem.Model;
using HotelBookingSystem.Server.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotelBookingSystem.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class HotelController : ControllerBase
{
    private readonly ILogger<HotelController> _logger;
    private readonly HotelBookingSystemDbContext _context;
    private readonly IMapper _mapper;

    public HotelController(ILogger<HotelController> logger, HotelBookingSystemDbContext context, IMapper mapper)
    {
        _logger = logger;
        _context = context;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<IEnumerable<HotelGetDto>>> GetHotels()
    {
        _logger.LogInformation("GetHotels");
        if (_context.Hotels == null)
        {
            return NotFound();
        }
        return await _mapper.ProjectTo<HotelGetDto>(_context.Hotels).ToListAsync();
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<HotelGetDto>> GetHotel(int id)
    {
        _logger.LogInformation("GetHotel");
        if (_context.Hotels == null)
        {
            return NotFound();
        }
        var hotel = await _context.Hotels.FindAsync(id);

        if (hotel == null)
        {
            return NotFound();
        }

        return _mapper.Map<HotelGetDto>(hotel);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> PutHotel(int id, HotelPostDto hotel)
    {
        _logger.LogInformation("PutHotel");
        if (_context.Hotels == null)
        {
            return NotFound();
        }
        var temp = await _context.Hotels.FindAsync(id);
        if (temp == null)
        {
            return NotFound();
        }
        _mapper.Map(hotel, temp);
        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<ActionResult<HotelGetDto>> PostHotel(HotelPostDto hotel)
    {
        _logger.LogInformation("PostHotel");
        if (_context.Hotels == null)
        {
            return Problem("Entity set 'HotelBookingSystemDbContext.Hotels'  is null.");
        }
        var temp = _mapper.Map<Hotel>(hotel);
        _context.Hotels.Add(temp);
        await _context.SaveChangesAsync();
        return CreatedAtAction("PostHotel", new { id = temp.Id }, _mapper.Map<HotelGetDto>(temp));
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteHotel(int id)
    {
        _logger.LogInformation("DeleteHotel");
        if (_context.Hotels == null)
        {
            return NotFound();
        }
        var hotel = await _context.Hotels.FindAsync(id);
        if (hotel == null)
        {
            return NotFound();
        }

        _context.Hotels.Remove(hotel);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
