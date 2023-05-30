using AutoMapper;
using HotelBookingSystem.Classes;
using HotelBookingSystem.Server.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotelBookingSystem.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RoomController : ControllerBase
{
    private readonly ILogger<RoomController> _logger;
    private readonly HotelBookingSystemDbContext _context;
    private readonly IMapper _mapper;

    public RoomController(ILogger<RoomController> logger, HotelBookingSystemDbContext context, IMapper mapper)
    {
        _logger = logger;
        _context = context;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<IEnumerable<RoomGetDto>>> GetRooms()
    {
        _logger.LogInformation("GetRooms");
        if (_context.Rooms == null)
        {
            return NotFound();
        }
        return await _mapper.ProjectTo<RoomGetDto>(_context.Rooms).ToListAsync();
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<RoomGetDto>> GetRoom(int id)
    {
        _logger.LogInformation("GetRoom");
        if (_context.Rooms == null)
        {
            return NotFound();
        }
        var room = await _context.Rooms.FindAsync(id);

        if (room == null)
        {
            return NotFound();
        }

        return _mapper.Map<RoomGetDto>(room);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> PutRoom(int id, RoomPostDto room)
    {
        _logger.LogInformation("PutRoom");
        if (_context.Rooms == null)
        {
            return NotFound();
        }
        var temp = await _context.Rooms.FindAsync(id);
        if (temp == null)
        {
            return NotFound();
        }
        _mapper.Map(room, temp);
        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<ActionResult<RoomGetDto>> PostRoom(RoomPostDto room)
    {
        _logger.LogInformation("PostRoom");
        if (_context.Rooms == null)
        {
            return Problem("Entity set 'HotelBookingSystemDbContext.Rooms'  is null.");
        }
        var temp = _mapper.Map<Room>(room);
        _context.Rooms.Add(temp);
        await _context.SaveChangesAsync();
        return CreatedAtAction("PostRoom", new { id = temp.Id }, _mapper.Map<RoomGetDto>(temp));
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteRoom(int id)
    {
        _logger.LogInformation("DeleteRoom");
        if (_context.Rooms == null)
        {
            return NotFound();
        }
        var room = await _context.Rooms.FindAsync(id);
        if (room == null)
        {
            return NotFound();
        }

        _context.Rooms.Remove(room);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
