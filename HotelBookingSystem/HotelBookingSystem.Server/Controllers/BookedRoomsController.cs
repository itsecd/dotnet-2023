using AutoMapper;
using HotelBookingSystem.Classes;
using HotelBookingSystem.Server.Dto;
using HotelBookingSystem.Server.Repository;
using Microsoft.AspNetCore.Mvc;

namespace HotelBookingSystem.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BookedRoomsController : ControllerBase
{
    private readonly ILogger<BookedRoomsController> _logger;

    private readonly IHotelBookingSystemRepository _repos;

    private readonly IMapper _mapper;

    public BookedRoomsController(ILogger<BookedRoomsController> logger, IHotelBookingSystemRepository repos, IMapper mapper)
    {
        _logger = logger;
        _repos = repos;
        _mapper = mapper;
    }

    [HttpGet]
    public IEnumerable<BookedRoomsGetDto> Get()
    {
        _logger.LogInformation("Get ListOfBookedRooms");
        return _repos.ListOfBookedRooms.Select(broom => _mapper.Map<BookedRoomsGetDto>(broom));
    }

    [HttpGet("{id}")]
    public ActionResult<BookedRoomsGetDto> Get(int id) 
    {
        _logger.LogInformation($"Get BookedRooms {id}");
        var tmp = _repos.ListOfBookedRooms.FirstOrDefault(x => x.Id == id);
        if (tmp != null) 
        {
            _logger.LogInformation("Success");
            return Ok(_mapper.Map<BookedRoomsGetDto>(tmp));
        }
        else
        {
            _logger.LogInformation("Failure: Not found");
            return NotFound();
        }
    }

    [HttpPost]
    public IActionResult Post([FromBody] BookedRoomsPostDto broom) 
    {
        _logger.LogInformation("Post BookedRooms");
        _repos.ListOfBookedRooms.Add(_mapper.Map<BookedRooms>(broom));
        return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] BookedRoomsPostDto broom) 
    {
        _logger.LogInformation($"Put BookedRooms {id}");
        var tmp = _repos.ListOfBookedRooms.FirstOrDefault(x => x.Id == id);
        if (tmp != null)
        {
            _logger.LogInformation("Success");
            _mapper.Map<BookedRoomsPostDto, BookedRooms>(broom, tmp);
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
        _logger.LogInformation($"Delete BookedRooms {id}");
        var tmp = _repos.ListOfBookedRooms.FirstOrDefault(x => x.Id == id);
        if (tmp != null)
        {
            _repos.ListOfBookedRooms.Remove(tmp);
            return Ok();
        }
        else
        {
            _logger.LogInformation("Failure: Not found");
            return NotFound();
        }
    }
}
