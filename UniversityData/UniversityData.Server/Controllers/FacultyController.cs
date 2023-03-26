using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UniversityData.Domain;
using UniversityData.Server.Dto;
using UniversityData.Server.Repository;
namespace UniversityData.Server.Controllers;

/// <summary>
/// Контроллер факультета
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class FacultyController : ControllerBase
{
    /// <summary>
    /// Хранение логгера
    /// </summary>
    private readonly ILogger<FacultyController> _logger;
    /// <summary>
    /// Хранение репозитория
    /// </summary>
    private readonly IUniversityDataRepository _universityDataRepository;
    /// <summary>
    /// Хранение маппера
    /// </summary>
    private readonly IMapper _mapper;
    public FacultyController(ILogger<FacultyController> logger, IUniversityDataRepository universityDataRepository, IMapper mapper)
    {
        _logger = logger;
        _universityDataRepository = universityDataRepository;
        _mapper = mapper;
    }
    /// <summary>
    /// GET-запрос на получение всех элементов коллекции
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public IEnumerable<Faculty> Get()
    {
        _logger.LogInformation("Get all faculties");
        return _universityDataRepository.Faculties;
    }
    /// <summary>
    /// GET-запрос на получение элемента в соответствии с ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public ActionResult<Faculty?> Get(int id)
    {
        var faculty = _universityDataRepository.Faculties.FirstOrDefault(faculty => faculty.Id == id);
        if (faculty == null)
        {
            _logger.LogInformation("Not found faculty with id: {0}", id);
            return NotFound();
        }
        else
        {
            _logger.LogInformation("Get faculty with id {0}", id);
            return Ok(faculty);
        }
    }
    /// <summary>
    /// POST-запрос на добавление нового элемента в коллекцию
    /// </summary>
    /// <param name="faculty"></param>
    [HttpPost]
    public void Post([FromBody] FacultyPostDto faculty)
    {
        _logger.LogInformation("Add new faculty");
        _universityDataRepository.Faculties.Add(_mapper.Map<Faculty>(faculty));
    }
    /// <summary>
    /// PUT-запрос на замену существующего элемента коллекции
    /// </summary>
    /// <param name="id"></param>
    /// <param name="facultyToPut"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] FacultyPostDto facultyToPut)
    {
        var faculty = _universityDataRepository.Faculties.FirstOrDefault(faculty => faculty.Id == id);
        if (faculty == null)
        {
            _logger.LogInformation("Not found faculty with id: {0}", id);
            return NotFound();
        }
        else
        {
            _mapper.Map<FacultyPostDto, Faculty>(facultyToPut, faculty);
            _logger.LogInformation("Update faculty with id: {0}", id);
            return Ok();
        }
    }
    /// <summary>
    /// DELETE-запрос на удаление элемента из коллекции
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var faculty = _universityDataRepository.Faculties.FirstOrDefault(faculty => faculty.Id == id);
        if (faculty == null)
        {
            _logger.LogInformation("Not found faculty with id: {0}", id);
            return NotFound();
        }
        else
        {
            _universityDataRepository.Faculties.Remove(faculty);
            _logger.LogInformation("Delete faculty with id: {0}", id);
            return Ok();
        }
    }
}
