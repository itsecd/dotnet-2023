using UniversityData.Domain;
using UniversityData.Server.Dto;
using Microsoft.AspNetCore.Mvc;
using UniversityData.Server.Repository;
using AutoMapper;
namespace UniversityData.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FacultyController : ControllerBase
{
    private readonly ILogger<FacultyController> _logger;
    private readonly IUniversityDataRepository _universityDataRepository;
    private readonly IMapper _mapper;
    public FacultyController(ILogger<FacultyController> logger, IUniversityDataRepository universityDataRepository, IMapper mapper)
    {
        _logger = logger;
        _universityDataRepository = universityDataRepository;
        _mapper = mapper;
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
        _universityDataRepository.Faculties.Add(_mapper.Map<Faculty>(faculty));
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] FacultyPostDto facultyToPut)
    {
        var faculty = _universityDataRepository.Faculties.FirstOrDefault(faculty => faculty.Id == id);
        if (faculty == null)
        {
            _logger.LogInformation($"Not found faculty with id: {id}");
            return NotFound();
        }
        else
        {
            _mapper.Map<FacultyPostDto, Faculty>(facultyToPut, faculty);
            return Ok();
        }
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var faculty = _universityDataRepository.Faculties.FirstOrDefault(faculty => faculty.Id == id);
        if (faculty == null)
        {
            _logger.LogInformation($"Not found faculty with id: {id}");
            return NotFound();
        }
        else
        {
            _universityDataRepository.Faculties.Remove(faculty);
            return Ok();
        }
    }
}
