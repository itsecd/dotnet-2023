using AutoMapper;
using HotelBookingSystem.Classes;
using HotelBookingSystem.Server.Dto;
using HotelBookingSystem.Server.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace HotelBookingSystem.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LodgerController : ControllerBase
{
    private readonly ILogger<LodgerController> _logger;

    private readonly IHotelBookingSystemRepository _repos;

    private readonly IMapper _mapper;

    public LodgerController(ILogger<LodgerController> logger, IHotelBookingSystemRepository repos, IMapper mapper)
    {
        _logger = logger;
        _repos = repos;
        _mapper = mapper;
    }

    [HttpGet]
    public IEnumerable<LodgerGetDto> Get()
    {
        _logger.LogInformation("Get ListOfLodgers");
        return _repos.ListOfLodgers.Select(lodger => _mapper.Map<LodgerGetDto>(lodger));
    }

    [HttpGet("{id}")]
    public ActionResult<LodgerGetDto> Get(int id) 
    {
        _logger.LogInformation($"Get Lodger {id}");
        var tmp = _repos.ListOfLodgers.FirstOrDefault(x => x.Id == id);
        if (tmp != null) 
        {
            _logger.LogInformation("Success");
            return Ok(_mapper.Map<LodgerGetDto>(tmp));
        }
        else
        {
            _logger.LogInformation("Failure: Not found");
            return NotFound();
        }
    }

    [HttpPost]
    public IActionResult Post([FromBody] LodgerPostDto lodger) 
    {
        _logger.LogInformation("Post Lodger");
        _repos.ListOfLodgers.Add(_mapper.Map<Lodger>(lodger));
        return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] LodgerPostDto lodger) 
    {
        _logger.LogInformation($"Put Lodger {id}");
        var tmp = _repos.ListOfLodgers.FirstOrDefault(x => x.Id == id);
        if (tmp != null)
        {
            _logger.LogInformation("Success");
            _mapper.Map(lodger, tmp);
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
        _logger.LogInformation($"Delete Lodger {id}");
        var tmp = _repos.ListOfLodgers.FirstOrDefault(x => x.Id == id);
        if (tmp != null)
        {
            _repos.ListOfLodgers.Remove(tmp);
            return Ok();
        }
        else
        {
            _logger.LogInformation("Failure: Not found");
            return NotFound();
        }
    }
}
