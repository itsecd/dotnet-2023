using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UniversityData.Domain;
using UniversityData.Server.Dto;
using UniversityData.Server.Repository;
namespace UniversityData.Server.Controllers;

/// <summary>
/// Контроллер ректора
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class RectorController : ControllerBase
{
    /// <summary>
    /// Хранение логгера
    /// </summary>
    private readonly ILogger<RectorController> _logger;
    /// <summary>
    /// Хранение репозитория
    /// </summary>
    private readonly IUniversityDataRepository _universityDataRepository;
    /// <summary>
    /// Хранение маппера
    /// </summary>
    private readonly IMapper _mapper;
    public RectorController(ILogger<RectorController> logger, IUniversityDataRepository universityDataRepository, IMapper mapper)
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
    public IEnumerable<Rector> Get()
    {
        _logger.LogInformation("Get all rectors");
        return _universityDataRepository.Rectors;
    }
    /// <summary>
    /// GET-запрос на получение элемента в соответствии с ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public ActionResult<Rector?> Get(int id)
    {
        var rector = _universityDataRepository.Rectors.FirstOrDefault(rector => rector.Id == id);
        if (rector == null)
        {
            _logger.LogInformation("Not found rector with id: {0}", id);
            return NotFound();
        }
        else
        {
            _logger.LogInformation("Get rector with id {0}", id);
            return Ok(rector);
        }
    }
    /// <summary>
    /// POST-запрос на добавление нового элемента в коллекцию
    /// </summary>
    /// <param name="rector"></param>
    [HttpPost]
    public void Post([FromBody] RectorPostDto rector)
    {
        _logger.LogInformation("Add new rector");
        _universityDataRepository.Rectors.Add(_mapper.Map<Rector>(rector));
    }
    /// <summary>
    /// PUT-запрос на замену существующего элемента коллекции
    /// </summary>
    /// <param name="id"></param>
    /// <param name="rectorToPut"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] RectorPostDto rectorToPut)
    {
        var rector = _universityDataRepository.Rectors.FirstOrDefault(rector => rector.Id == id);
        if (rector == null)
        {
            _logger.LogInformation($"Not found rector with id: {id}");
            return NotFound();
        }
        else
        {
            _mapper.Map<RectorPostDto, Rector>(rectorToPut, rector);
            _logger.LogInformation("Update rector with id: {0}", id);
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
        var rector = _universityDataRepository.Rectors.FirstOrDefault(rector => rector.Id == id);
        if (rector == null)
        {
            _logger.LogInformation("Not found rector with id: {0}", id);
            return NotFound();
        }
        else
        {
            _universityDataRepository.Rectors.Remove(rector);
            _logger.LogInformation("Delete rector with id: {0}", id);
            return Ok();
        }
    }
}
