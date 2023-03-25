using UniversityData.Domain;
using Microsoft.AspNetCore.Mvc;
namespace UniversityData.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UniversityController : ControllerBase
{
    private readonly ILogger<UniversityController> _logger;
    private readonly UniversityDataRepository _universityDataRepository;
    public UniversityController(ILogger<UniversityController> logger, UniversityDataRepository universityDataRepository)
    {
        _logger = logger;
        _universityDataRepository = universityDataRepository;
    }

    [HttpGet]
    public IEnumerable<University> Get()
    {
        _logger.LogInformation("Get all departments");
        return _universityDataRepository.Universities;
    }

    [HttpGet("{id}")]
    public ActionResult<University?> Get(int id)
    {
        var university = _universityDataRepository.Universities.FirstOrDefault(university => university.Id == id);
        if (university == null)
        {
            _logger.LogInformation($"Not found university with id: {id}");
            return NotFound();
        }
        else
        {
            _logger.LogInformation($"Get university with id {id}");
            return Ok(university);
        }
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