using UniversityData.Domain;
using Microsoft.AspNetCore.Mvc;
namespace UniversityData.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RectorController : ControllerBase
{
    private readonly ILogger<RectorController> _logger;
    private readonly UniversityDataRepository _universityDataRepository;
    public RectorController(ILogger<RectorController> logger, UniversityDataRepository universityDataRepository)
    {
        _logger = logger;
        _universityDataRepository = universityDataRepository;
    }

    [HttpGet]
    public IEnumerable<Rector> Get()
    {
        _logger.LogInformation("Get all departments");
        return _universityDataRepository.Rectors;
    }

    [HttpGet("{id}")]
    public ActionResult<Rector?> Get(int id)
    {
        var rector = _universityDataRepository.Rectors.FirstOrDefault(rector => rector.Id == id);
        if (rector == null)
        {
            _logger.LogInformation($"Not found rector with id: {id}");
            return NotFound();
        }
        else
        {
            _logger.LogInformation($"Get rector with id {id}");
            return Ok(rector);
        }  
    }

    [HttpPost]
    public void Post([FromBody] Rector rector)
    {
        _universityDataRepository.Rectors.Add(rector);
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
