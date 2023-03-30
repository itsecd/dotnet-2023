using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PonrfDomain;
using PonrfServer.Dto;

namespace PonrfServer.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BuildingController : ControllerBase
{
    private readonly ILogger<BuildingController> _logger;

    private readonly PonrfRepository _ponrfRepository;

    private readonly IMapper _mapper;

    public BuildingController(ILogger<BuildingController> logger, PonrfRepository ponrfRepository, IMapper mapper)
    {
        _logger = logger;
        _ponrfRepository = ponrfRepository;
        _mapper = mapper;
    }

    [HttpGet]
    public IEnumerable<BuildingDto> Get()
    {
        _logger.LogInformation("Get all buildings");
        return _mapper.Map<IEnumerable<BuildingDto>>(_ponrfRepository.Buildings);
    }

    [HttpGet("{id}")]
    public ActionResult<BuildingDto?> Get(int id)
    {
        var building = _ponrfRepository.Buildings.FirstOrDefault(building => building.Id == id);
        if (building == null)
        {
            _logger.LogInformation($"Not found building with {id}");
            return NotFound();
        }
        else return Ok(_mapper.Map<BuildingDto>(building));
    }

    [HttpPost]
    public void Post([FromBody] string value)
    {
    }

    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
}
