using Microsoft.AspNetCore.Mvc;
using PonrfDomain;

namespace PonrfServer.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BuildingController : ControllerBase
{
    private readonly ILogger<BuildingController> _logger;

    private readonly PonrfRepository _ponrfRepository;

    public BuildingController(ILogger<BuildingController> logger, PonrfRepository ponrfRepository)
    {
        _logger = logger;
        _ponrfRepository = ponrfRepository;
    }

    [HttpGet]
    public IEnumerable<Building> Get()
    {
        _logger.LogInformation("Get all buildings");
        return _ponrfRepository.Buildings;
    }

    [HttpGet("{id}")]
    public ActionResult<Building?> Get(int id)
    {
        var building = _ponrfRepository.Buildings.FirstOrDefault(building => building.Id == id);
        if (building == null)
        {
            _logger.LogInformation($"Not found building with {id}");
            return NotFound();
        }
        else return Ok(building);
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
