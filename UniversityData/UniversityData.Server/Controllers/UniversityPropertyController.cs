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
public class UniversityPropertyController : ControllerBase
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
    public UniversityPropertyController(ILogger<FacultyController> logger, IUniversityDataRepository universityDataRepository, IMapper mapper)
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
    public IEnumerable<UniversityProperty> Get()
    {
        _logger.LogInformation("Get all university properties");
        return _universityDataRepository.UniversityProperties;
    }
    /// <summary>
    /// GET-запрос на получение элемента в соответствии с ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public ActionResult<UniversityProperty?> Get(int id)
    {
        var universityProperty = _universityDataRepository.UniversityProperties.FirstOrDefault(universityProperty => universityProperty.Id == id);
        if (universityProperty == null)
        {
            _logger.LogInformation("Not found university property with id: {0}", id);
            return NotFound();
        }
        else
        {
            _logger.LogInformation("Get university property with id {0}", id);
            return Ok(universityProperty);
        }
    }
    /// <summary>
    /// POST-запрос на добавление нового элемента в коллекцию
    /// </summary>
    /// <param name="universityProperty"></param>
    [HttpPost]
    public void Post([FromBody] UniversityPropertyDto universityProperty)
    {
        _logger.LogInformation("Add new university property");
        _universityDataRepository.Faculties.Add(_mapper.Map<Faculty>(universityProperty));
    }
    /// <summary>
    /// PUT-запрос на замену существующего элемента коллекции
    /// </summary>
    /// <param name="id"></param>
    /// <param name="universityPropertyToPut"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] UniversityPropertyDto universityPropertyToPut)
    {
        var universityProperty = _universityDataRepository.UniversityProperties.FirstOrDefault(universityProperty => universityProperty.Id == id);
        if (universityProperty == null)
        {
            _logger.LogInformation("Not found university property with id: {0}", id);
            return NotFound();
        }
        else
        {
            _mapper.Map<UniversityPropertyDto, UniversityProperty>(universityPropertyToPut, universityProperty);
            _logger.LogInformation("Update university property with id: {0}", id);
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
        var universityProperty = _universityDataRepository.UniversityProperties.FirstOrDefault(universityProperty => universityProperty.Id == id);
        if (universityProperty == null)
        {
            _logger.LogInformation("Not found university property with id: {0}", id);
            return NotFound();
        }
        else
        {
            _universityDataRepository.UniversityProperties.Remove(universityProperty);
            _logger.LogInformation("Delete university property with id: {0}", id);
            return Ok();
        }
    }
}
