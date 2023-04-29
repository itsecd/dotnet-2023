using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UniversityData.Domain;
using UniversityData.Server.Dto;
using UniversityData.Server.Repository;
namespace UniversityData.Server.Controllers;

/// <summary>
/// Контроллер собственности зданий университета
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class ConstructionPropertyController : ControllerBase
{
    /// <summary>
    /// Хранение логгера
    /// </summary>
    private readonly ILogger<DepartmentController> _logger;
    /// <summary>
    /// Хранение репозитория
    /// </summary>
    private readonly IUniversityDataRepository _universityDataRepository;
    /// <summary>
    /// Хранение маппера
    /// </summary>
    private readonly IMapper _mapper;
    public ConstructionPropertyController(ILogger<DepartmentController> logger, IUniversityDataRepository universityDataRepository, IMapper mapper)
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
    public IEnumerable<ConstructionProperty> Get()
    {
        _logger.LogInformation("Get all construction properties");
        return _universityDataRepository.ConstructionProperties;
    }
    /// <summary>
    /// GET-запрос на получение элемента в соответствии с ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public ActionResult<ConstructionProperty?> Get(int id)
    {
        var constructionProperty = _universityDataRepository.ConstructionProperties.FirstOrDefault(constructionProperty => constructionProperty.Id == id);
        if (constructionProperty == null)
        {
            _logger.LogInformation("Not found construction property with id: {0}", id);
            return NotFound();
        }
        else
        {
            _logger.LogInformation("Get construction property with id: {0}", id);
            return Ok(constructionProperty);
        }
    }
    /// <summary>
    /// POST-запрос на добавление нового элемента в коллекцию
    /// </summary>
    /// <param name="constructionProperty"></param>
    [HttpPost]
    public void Post([FromBody] ConstructionPropertyDto constructionProperty)
    {
        _logger.LogInformation("Add new construction property");
        _universityDataRepository.ConstructionProperties.Add(_mapper.Map<ConstructionProperty>(constructionProperty));
    }
    /// <summary>
    /// PUT-запрос на замену существующего элемента коллекции
    /// </summary>
    /// <param name="id"></param>
    /// <param name="constructionPropertyToPut"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] ConstructionPropertyDto constructionPropertyToPut)
    {
        var constructionProperty = _universityDataRepository.ConstructionProperties.FirstOrDefault(constructionProperty => constructionProperty.Id == id);
        if (constructionProperty == null)
        {
            _logger.LogInformation("Not found construction property with id: {0}", id);
            return NotFound();
        }
        else
        {
            _mapper.Map<ConstructionPropertyDto, ConstructionProperty>(constructionPropertyToPut, constructionProperty);
            _logger.LogInformation("Update construction property with id: {0}", id);
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
        var constructionProperty = _universityDataRepository.ConstructionProperties.FirstOrDefault(constructionProperty => constructionProperty.Id == id);
        if (constructionProperty == null)
        {
            _logger.LogInformation("Not found construction property with id: {0}", id);
            return NotFound();
        }
        else
        {
            _universityDataRepository.ConstructionProperties.Remove(constructionProperty);
            _logger.LogInformation("Delete construction property with id: {0}", id);
            return Ok();
        }
    }
}
