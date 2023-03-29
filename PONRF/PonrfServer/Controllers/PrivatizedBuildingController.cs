using Microsoft.AspNetCore.Mvc;
using PonrfDomain;

namespace PonrfServer.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PrivatizedBuildingController : ControllerBase
{
    private readonly ILogger<PrivatizedBuildingController> _logger;

    private readonly PonrfRepository _ponrfRepository;

    public PrivatizedBuildingController(ILogger<PrivatizedBuildingController> logger, PonrfRepository ponrfRepository)
    {
        _logger = logger;
        _ponrfRepository = ponrfRepository;
    }


    [HttpGet]
    public IEnumerable<PrivatizedBuilding> Get()
    {
        _logger.LogInformation("Get all privatized buildings");
        return _ponrfRepository.PrivatizedBuildings;
    }

    [HttpGet("{id}")]
    public ActionResult<PrivatizedBuilding?> Get(int id)
    {
        var privatizedBuilding = _ponrfRepository.PrivatizedBuildings.FirstOrDefault(privatizedBuilding => privatizedBuilding.Id == id);
        if (privatizedBuilding == null)
        {
            _logger.LogInformation($"Not found privatized building with {id}");
            return NotFound();
        }
        else return Ok(privatizedBuilding);
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
