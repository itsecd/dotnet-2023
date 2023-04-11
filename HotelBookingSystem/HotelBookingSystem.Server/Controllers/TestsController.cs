using AutoMapper;
using HotelBookingSystem.Classes;
using HotelBookingSystem.Server.Dto;
using HotelBookingSystem.Server.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelBookingSystem.Server.Controllers;
[ApiController]
[Route("api/[controller]")]
public class TestsController : ControllerBase
{
    private readonly ILogger<TestsController> _logger;

    private readonly IHotelBookingSystemRepository _repos;

    private readonly IMapper _mapper;

    public TestsController(ILogger<TestsController> logger, IHotelBookingSystemRepository repos, IMapper mapper)
    {
        _logger = logger;
        _repos = repos;
        _mapper = mapper;
    }

    /// <summary>
    /// Task 1 - Display information about all hotels.
    /// </summary>
    [HttpGet("Task 1")]
    public IEnumerable<HotelGetDto> InfoHotels()
    {
        _logger.LogInformation("Test 1");
        return _repos.ListOfHotels.Select(hotel => _mapper.Map<HotelGetDto>(hotel));
    }

    /// <summary>
    /// Task 2 - Display information about all clients 
    /// staying at the specified hotel, arrange by full name.
    /// </summary>
    [HttpGet("Task 2")]
    public IEnumerable<LodgerGetDto> InfoClientsInHotels()
    {
        _logger.LogInformation("Test 2");
        var brooms = _repos.ListOfBookedRooms;
        var result = (from broom in brooms
                      where broom.BookedRoom.Placement.Name == "Worst Hotel"
                      select broom.Client).Select(lodger => _mapper.Map<LodgerGetDto>(lodger)).ToList();
        return result;
    }

    /// <summary>
    /// Task 3 - Display information about the top 5 
    /// hotels with the largest number of bookings.
    /// </summary>
    [HttpGet("Task 3")]
    public IEnumerable<HotelGetDto> Top5MostBooked()
    {
        _logger.LogInformation("Test 3");
        var brooms = _repos.ListOfBookedRooms;
        var result = brooms.GroupBy(x => x.BookedRoom.Placement)
            .OrderByDescending(g => g.Count())
            .Select(y => y.Key)
            .Take(5)
            .Select(hotel => _mapper.Map<HotelGetDto>(hotel))
            .ToList();
        return result;
    }

    /// <summary>
    /// Task 4 - Display information about available 
    /// rooms in all hotels of the selected city.
    /// </summary>
    [HttpGet("Task 4")]
    public IEnumerable<RoomGetDto> AvailableRooms()
    {
        var rooms = _repos.ListOfRooms;
        var brooms = _repos.ListOfBookedRooms;
        var tmp = (from broom in brooms
                   select broom.BookedRoom).ToList();
        var result = (from room in rooms
                      where !tmp.Contains(room)
                      select room)
                      .Select(room => _mapper.Map<RoomGetDto>(room))
                      .ToList();
        return result;
    }

    /// <summary>
    /// Task 5 - Display information about customers 
    /// who have rented rooms for the largest number of days.
    /// </summary>
    [HttpGet("Task 5")]
    public IEnumerable<LodgerGetDto> ClientsWithMostDays()
    {
        var brooms = _repos.ListOfBookedRooms;
        var result = (from broom in brooms
                      orderby (broom.BookingTerm - broom.EntryDate).Days descending
                      select broom.Client)
                      .Select(lodger => _mapper.Map<LodgerGetDto>(lodger)).ToList();
        return result;
    }

    /// <summary>
    /// Task 6 - Display information about the minimum 
    /// and maximum room cost in each hotel.
    /// </summary>
    [HttpGet("Task 6")]
    public IActionResult MinMaxCost()
    {
        var brooms = _repos.ListOfBookedRooms;
        var min = (from broom in brooms
                   orderby broom.BookedRoom.Cost
                   group broom by broom.BookedRoom.Placement into minres
                   select minres.First().BookedRoom.Cost).ToList();

        var max = (from broom in brooms
                   orderby broom.BookedRoom.Cost descending
                   group broom by broom.BookedRoom.Placement into maxres
                   select maxres.First().BookedRoom.Cost).ToList();
        return Ok(new {min, max});
    }
}

