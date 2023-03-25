using UniversityData.Domain;
using Microsoft.AspNetCore.Mvc;
namespace UniversityData.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SpecialtyController : ControllerBase
{
    private readonly ILogger<SpecialtyController> _logger;
    private readonly UniversityDataRepository _universityDataRepository;
    public SpecialtyController(ILogger<SpecialtyController> logger, UniversityDataRepository universityDataRepository)
    {
        _logger = logger;
        _universityDataRepository = universityDataRepository;
    }

    [HttpGet]
    public IEnumerable<Specialty> Get()
    {
        _logger.LogInformation("Get all departments");
        return _universityDataRepository.Specialties;
    }

    [HttpGet("{id}")]
    public ActionResult<Specialty?> Get(int id)
    {
        var specialty = _universityDataRepository.Specialties.FirstOrDefault(specialty => specialty.Id == id);
        if (specialty == null)
        {
            _logger.LogInformation($"Not found specialty with id: {id}");
            return NotFound();
        }
        else
        {
            _logger.LogInformation($"Get specialty with id {id}");
            return Ok(specialty);
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
