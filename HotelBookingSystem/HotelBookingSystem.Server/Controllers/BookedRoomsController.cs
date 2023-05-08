using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HotelBookingSystem.Classes;
using HotelBookingSystem.Server.Dto;
using AutoMapper;

namespace HotelBookingSystem.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BookedRoomsController : ControllerBase
{
    private readonly ILogger<BookedRoomsController> _logger;
    private readonly HotelBookingSystemDbContext _context;
    private readonly IMapper _mapper;

    public BookedRoomsController(ILogger<BookedRoomsController> logger, HotelBookingSystemDbContext context, IMapper mapper)
    {
        _logger = logger;
        _context = context;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<BookedRoomsGetDto>>> GetBrooms()
    {
        _logger.LogInformation("GetBrooms");
        if (_context.Brooms == null)
        {
            return NotFound();
        }
        return await _mapper.ProjectTo<BookedRoomsGetDto>(_context.Brooms).ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<BookedRoomsGetDto>> GetBroom(int id)
    {
        _logger.LogInformation("GetBroom");
        if (_context.Brooms == null)
        {
            return NotFound();
        }
        var broom = await _context.Brooms.FindAsync(id);

        if (broom == null)
        {
            return NotFound();
        }

        return _mapper.Map<BookedRoomsGetDto>(broom);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutBroom(int id, BookedRoomsPostDto broom)
    {
        _logger.LogInformation("PutBroom");
        if (_context.Brooms == null)
        {
            return NotFound();
        }
        var temp = await _context.Brooms.FindAsync(id);
        if (temp == null)
        {
            return NotFound();
        }
        _mapper.Map(broom, temp);
        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpPost]
    [ProducesResponseType(201)]
    public async Task<ActionResult<HotelGetDto>> PostBroom(BookedRoomsPostDto broom)
    {
        _logger.LogInformation("PostBroom");
        if (_context.Brooms == null)
        {
            return Problem("Entity set 'HotelBookingSystemDbContext.Brooms'  is null.");
        }
        var temp = _mapper.Map<BookedRooms>(broom);
        _context.Brooms.Add(temp);
        await _context.SaveChangesAsync();
        return CreatedAtAction("PostBookedRoom", new { id = temp.Id }, _mapper.Map<BookedRoomsGetDto>(temp));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBroom(int id)
    {
        _logger.LogInformation("DeleteBroom");
        if (_context.Brooms == null)
        {
            return NotFound();
        }
        var broom = await _context.Brooms.FindAsync(id);
        if (broom == null)
        {
            return NotFound();
        }

        _context.Brooms.Remove(broom);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
