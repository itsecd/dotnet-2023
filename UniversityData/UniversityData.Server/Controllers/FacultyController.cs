using UniversityData.Domain;
using UniversityData.Server.Dto;
using Microsoft.AspNetCore.Mvc;
namespace UniversityData.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FacultyController : ControllerBase
{
    private readonly ILogger<FacultyController> _logger;
    private readonly UniversityDataRepository _universityDataRepository;
    public FacultyController(ILogger<FacultyController> logger, UniversityDataRepository universityDataRepository)
    {
        _logger = logger;
        _universityDataRepository = universityDataRepository;
    }

    [HttpGet]
    public IEnumerable<Faculty> Get()
    {
        _logger.LogInformation("Get all departments");
        return _universityDataRepository.Faculties;
    }

    [HttpGet("{id}")]
    public ActionResult<Faculty?> Get(int id)
    {
        var faculty = _universityDataRepository.Faculties.FirstOrDefault(faculty => faculty.Id == id);
        if (faculty == null)
        {
            _logger.LogInformation($"Not found faculty with id: {id}");
            return NotFound();
        }
        else
        {
            _logger.LogInformation($"Get faculty with id {id}");
            return Ok(faculty);
        }
    }

    [HttpPost]
    public void Post([FromBody] FacultyPostDto faculty)
    {
        _universityDataRepository.Faculties.Add(new Faculty()
        {
            Name = faculty.Name,
            StudentsCount = faculty.StudentsCount,
            WorkersCount = faculty.WorkersCount,
            UniversityId = faculty.UniversityId
        });
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
