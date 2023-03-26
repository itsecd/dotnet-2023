using UniversityData.Domain;
using UniversityData.Server.Dto;
using Microsoft.AspNetCore.Mvc;
using UniversityData.Server.Repository;
using AutoMapper;
namespace UniversityData.Server.Controllers;

/// <summary>
/// Контроллер специальности
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class SpecialtyController : ControllerBase
{
    /// <summary>
    /// Хранение логгера
    /// </summary>
    private readonly ILogger<SpecialtyController> _logger;
    /// <summary>
    /// Хранение репозитория
    /// </summary>
    private readonly IUniversityDataRepository _universityDataRepository;
    /// <summary>
    /// Хранение маппера
    /// </summary>
    private readonly IMapper _mapper;
    public SpecialtyController(ILogger<SpecialtyController> logger, IUniversityDataRepository universityDataRepository, IMapper mapper)
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
    public IEnumerable<Specialty> Get()
    {
        _logger.LogInformation("Get all specialties");
        return _universityDataRepository.Specialties;
    }
    /// <summary>
    /// GET-запрос на получение элемента в соответствии с ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public ActionResult<Specialty?> Get(int id)
    {
        var specialty = _universityDataRepository.Specialties.FirstOrDefault(specialty => specialty.Id == id);
        if (specialty == null)
        {
            _logger.LogInformation("Not found specialty with id: {0}", id);
            return NotFound();
        }
        else
        {
            _logger.LogInformation("Get specialty with id {0}", id);
            return Ok(specialty);
        }
    }
    /// <summary>
    /// POST-запрос на добавление нового элемента в коллекцию
    /// </summary>
    /// <param name="specialty"></param>
    [HttpPost]
    public void Post([FromBody] SpecialtyPostDto specialty)
    {
        _logger.LogInformation("Add new specialty");
        _universityDataRepository.Specialties.Add(_mapper.Map<Specialty>(specialty));
    }
    /// <summary>
    /// PUT-запрос на замену существующего элемента коллекции
    /// </summary>
    /// <param name="id"></param>
    /// <param name="specialtyToPut"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] SpecialtyPostDto specialtyToPut)
    {
        var specialty = _universityDataRepository.Specialties.FirstOrDefault(specialty => specialty.Id == id);
        if (specialty == null)
        {
            _logger.LogInformation($"Not found specialty with id: {id}");
            return NotFound();
        }
        else
        {
            _mapper.Map<SpecialtyPostDto, Specialty>(specialtyToPut, specialty);
            _logger.LogInformation("Update specialty with id: {0}", id);
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
        var specialty = _universityDataRepository.Specialties.FirstOrDefault(specialty => specialty.Id == id);
        if (specialty == null)
        {
            _logger.LogInformation($"Not found specialty with id: {id}");
            return NotFound();
        }
        else
        {
            _universityDataRepository.Specialties.Remove(specialty);
            _logger.LogInformation("Delete specialty with id: {0}", id);
            return Ok();
        }
    }
}
