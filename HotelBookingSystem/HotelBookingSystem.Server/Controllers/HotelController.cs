using AutoMapper;
using HotelBookingSystem.Classes;
using HotelBookingSystem.Server.Dto;
using HotelBookingSystem.Server.Repository;
using Microsoft.AspNetCore.Mvc;

namespace HotelBookingSystem.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HotelController : ControllerBase
{
    private readonly ILogger<HotelController> _logger;

    private readonly IHotelBookingSystemRepository _repos;

    private readonly IMapper _mapper;

    public HotelController(ILogger<HotelController> logger, IHotelBookingSystemRepository repos, IMapper mapper)
    {
        _logger = logger;
        _repos = repos;
        _mapper = mapper;
    }

    [HttpGet]
    public IEnumerable<HotelGetDto> Get()
    {
        _logger.LogInformation("Get ListOfHotels");
        return _repos.ListOfHotels.Select(hotel => _mapper.Map<HotelGetDto>(hotel));
    }

    [HttpGet("{id}")]
    public ActionResult<HotelGetDto> Get(int id) 
    {
        _logger.LogInformation($"Get Hotel {id}");
        var tmp = _repos.ListOfHotels.FirstOrDefault(x => x.Id == id);
        if (tmp != null) 
        {
            _logger.LogInformation("Success");
            return Ok(_mapper.Map<HotelGetDto>(tmp));
        }
        else
        {
            _logger.LogInformation("Failure: Not found");
            return NotFound();
        }
    }

    [HttpPost]
    public IActionResult Post([FromBody] HotelPostDto hotel) 
    {
        _logger.LogInformation("Post Hotel");
        _repos.ListOfHotels.Add(_mapper.Map<Hotel>(hotel));
        return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] HotelPostDto hotel) 
    {
        _logger.LogInformation($"Put Hotel {id}");
        var tmp = _repos.ListOfHotels.FirstOrDefault(x => x.Id == id);
        if (tmp != null)
        {
            _logger.LogInformation("Success");
            _mapper.Map(hotel, tmp);
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
        _logger.LogInformation($"Delete Hotel {id}");
        var tmp = _repos.ListOfHotels.FirstOrDefault(x => x.Id == id);
        if (tmp != null)
        {
            _repos.ListOfHotels.Remove(tmp);
            return Ok();
        }
        else
        {
            _logger.LogInformation("Failure: Not found");
            return NotFound();
        }
    }
}
