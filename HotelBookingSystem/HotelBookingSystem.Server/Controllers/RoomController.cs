using AutoMapper;
using HotelBookingSystem.Classes;
using HotelBookingSystem.Server.Dto;
using HotelBookingSystem.Server.Repository;
using Microsoft.AspNetCore.Mvc;

namespace HotelBookingSystem.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RoomController : ControllerBase
{
    private readonly ILogger<RoomController> _logger;

    private readonly IHotelBookingSystemRepository _repos;

    private readonly IMapper _mapper;

    public RoomController(ILogger<RoomController> logger, IHotelBookingSystemRepository repos, IMapper mapper)
    {
        _logger = logger;
        _repos = repos;
        _mapper = mapper;
    }

    [HttpGet]
    public IEnumerable<RoomGetDto> Get()
    {
        _logger.LogInformation("Get ListOfRooms");
        return _repos.ListOfRooms.Select(room => _mapper.Map<RoomGetDto>(room));
    }

    [HttpGet("{id}")]
    public ActionResult<RoomGetDto> Get(int id) 
    {
        _logger.LogInformation($"Get Room {id}");
        var tmp = _repos.ListOfRooms.FirstOrDefault(x => x.Id == id);
        if (tmp != null) 
        {
            _logger.LogInformation("Success");
            return Ok(_mapper.Map<RoomGetDto>(tmp));
        }
        else
        {
            _logger.LogInformation("Failure: Not found");
            return NotFound();
        }
    }

    [HttpPost]
    public IActionResult Post([FromBody] RoomPostDto room) 
    {
        _logger.LogInformation("Post Room");
        _repos.ListOfRooms.Add(_mapper.Map<Room>(room));
        return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] RoomPostDto room) 
    {
        _logger.LogInformation($"Put Room {id}");
        var tmp = _repos.ListOfRooms.FirstOrDefault(x => x.Id == id);
        if (tmp != null)
        {
            _logger.LogInformation("Success");
            _mapper.Map(room, tmp);
            return Ok();
        }
        else
        {
            _logger.LogInformation("Failure: Not found");
            return NotFound();
        }
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id) 
    {
        _logger.LogInformation($"Delete Room {id}");
        var tmp = _repos.ListOfRooms.FirstOrDefault(x => x.Id == id);
        if (tmp != null)
        {
            _repos.ListOfRooms.Remove(tmp);
            return Ok();
        }
        else
        {
            _logger.LogInformation("Failure: Not found");
            return NotFound();
        }
    }
}
