using AutoMapper;
using HotelBookingSystem.Classes;
using HotelBookingSystem.Server.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotelBookingSystem.Server.Controllers;
[ApiController]
[Route("api/[controller]")]
public class AnalyticsController : ControllerBase
{
    private readonly ILogger<AnalyticsController> _logger;

    private readonly HotelBookingSystemDbContext _context;

    private readonly IMapper _mapper;

    public AnalyticsController(ILogger<AnalyticsController> logger, HotelBookingSystemDbContext context, IMapper mapper)
    {
        _logger = logger;
        _context = context;
        _mapper = mapper;
    }

    /// <summary>
    /// Task 1 - Display information about all hotels.
    /// </summary>
    [HttpGet("InfoHotels")]
    public async Task<ActionResult<IEnumerable<HotelGetDto>>> InfoHotels()
    {
        _logger.LogInformation("InfoHotels");
        if (_context.Hotels == null)
        {
            return NotFound();
        }
        return await _mapper.ProjectTo<HotelGetDto>(_context.Hotels).ToListAsync();
    }

    /// <summary>
    /// Task 2 - Display information about all clients 
    /// staying at the specified hotel, arrange by full name.
    /// </summary>
    [HttpGet("InfoClientsInHotels")]
    public async Task<ActionResult<IEnumerable<LodgerGetDto>>> InfoClientsInHotels(string name)
    {
        _logger.LogInformation("InfoClientsInHotels");
        if (_context.Brooms == null)
        {
            return NotFound();
        }
        var brooms = _context.Brooms;
        var result = await (from broom in brooms
                            where broom.BookedRoom.Placement.Name == name
                            select broom.Client).Select(lodger => _mapper.Map<LodgerGetDto>(lodger)).ToListAsync();
        return result;
    }

    /// <summary>
    /// Task 3 - Display information about the top 5 
    /// hotels with the largest number of bookings.
    /// </summary>
    [HttpGet("Top5MostBooked")]
    public async Task<ActionResult<IEnumerable<HotelGetDto>>> Top5MostBooked()
    {
        _logger.LogInformation("Top5MostBooked");
        if (_context.Brooms == null)
        {
            return NotFound();
        }
        var brooms = _context.Brooms;
        var result = await brooms.GroupBy(x => x.BookedRoom.Placement)
            .OrderByDescending(g => g.Count())
            .Select(y => y.Key)
            .Take(5)
            .Select(hotel => _mapper.Map<HotelGetDto>(hotel))
            .ToListAsync();
        return result;
    }

    /// <summary>
    /// Task 4 - Display information about available 
    /// rooms in all hotels of the selected city.
    /// </summary>
    [HttpGet("AvailableRooms")]
    public async Task<ActionResult<IEnumerable<RoomGetDto>>> AvailableRooms(string city)
    {
        _logger.LogInformation("AvailableRooms");
        if (_context.Brooms == null || _context.Rooms == null)
        {
            return NotFound();
        }
        var rooms = _context.Rooms;
        var brooms = _context.Brooms;
        var tmp = (from broom in brooms
                   select broom.BookedRoom).ToList();
        var result = await (from room in rooms
                            where !tmp.Contains(room) && room.Placement.City == city
                            select room)
                      .Select(room => _mapper.Map<RoomGetDto>(room))
                      .ToListAsync();
        return result;
    }

    /// <summary>
    /// Task 5 - Display information about customers 
    /// who have rented rooms for the largest number of days.
    /// </summary>
    [HttpGet("ClientsWithMostDays")]
    public async Task<ActionResult<IEnumerable<LodgerGetDto>>> ClientsWithMostDays()
    {
        _logger.LogInformation("ClientsWithMostDays");
        if (_context.Brooms == null)
        {
            return NotFound();
        }
        var brooms = _context.Brooms;
        var result = await (from broom in brooms
                            orderby (broom.BookingTerm - broom.EntryDate) descending
                            select broom.Client)
                      .Select(lodger => _mapper.Map<LodgerGetDto>(lodger)).ToListAsync();
        return result;
    }

    /// <summary>
    /// Task 6 - Display information about the minimum 
    /// and maximum room cost in each hotel.
    /// </summary>
    [HttpGet("MinMaxCost")]
    public async Task<ActionResult> MinMaxCost()
    {
        _logger.LogInformation("MinMaxCost");
        if (_context.Rooms == null)
        {
            return NotFound();
        }
        var rooms = _context.Rooms;
        var result = await rooms.GroupBy(b => b.Placement)
        .Select(g => new
        {
            hotel = g.First().Placement.Name,
            min = g.Min(b => b.Cost),
            avg = g.Average(b => b.Cost),
            max = g.Max(b => b.Cost),
        }).ToListAsync();
        return Ok(result);
    }
}

