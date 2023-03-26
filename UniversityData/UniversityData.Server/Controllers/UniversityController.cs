using UniversityData.Domain;
using Microsoft.AspNetCore.Mvc;
using UniversityData.Server.Dto;
using UniversityData.Server.Repository;
using AutoMapper;
namespace UniversityData.Server.Controllers;

/// <summary>
/// Контроллер университета
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class UniversityController : ControllerBase
{
    /// <summary>
    /// Хранение логгера
    /// </summary>
    private readonly ILogger<UniversityController> _logger;
    /// <summary>
    /// Хранение репозитория
    /// </summary>
    private readonly IUniversityDataRepository _universityDataRepository;
    /// <summary>
    /// Хранение маппера
    /// </summary>
    private readonly IMapper _mapper;
    public UniversityController(ILogger<UniversityController> logger, IUniversityDataRepository universityDataRepository, IMapper mapper)
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
    public IEnumerable<UniversityGetDto> Get()
    {
        _logger.LogInformation("Get all universities");
        return _universityDataRepository.Universities.Select(university => _mapper.Map<UniversityGetDto>(university));
    }
    /// <summary>
    /// GET-запрос на получение элемента в соответствии с ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public ActionResult<UniversityGetDto?> Get(int id)
    {
        var university = _universityDataRepository.Universities.FirstOrDefault(university => university.Id == id);
        if (university == null)
        {
            _logger.LogInformation("Not found university with id: {0}", id);
            return NotFound();
        }
        else
        {
            _logger.LogInformation("Get university with id {0}", id);
            return Ok(_mapper.Map<UniversityGetDto>(university));
        }
    }
    /// <summary>
    /// POST-запрос на добавление нового элемента в коллекцию
    /// </summary>
    /// <param name="university"></param>
    [HttpPost]
    public void Post([FromBody] UniversityPostDto university)
    {
        _logger.LogInformation("Add new university");
        _universityDataRepository.Universities.Add(_mapper.Map<University>(university));
    }
    /// <summary>
    /// PUT-запрос на замену существующего элемента коллекции
    /// </summary>
    /// <param name="id"></param>
    /// <param name="universityToPut"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] UniversityPostDto universityToPut)
    {
        var university = _universityDataRepository.Universities.FirstOrDefault(university => university.Id == id);
        if (university == null)
        {
            _logger.LogInformation("Not found university with id: {0}", id);
            return NotFound();
        }
        else
        {
            _mapper.Map<UniversityPostDto, University>(universityToPut, university);
            _logger.LogInformation("Update university with id: {0}", id);
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
        var university = _universityDataRepository.Universities.FirstOrDefault(university => university.Id == id);
        if (university == null)
        {
            _logger.LogInformation("Not found university with id: {0}", id);
            return NotFound();
        }
        else
        {
           _universityDataRepository.Universities.Remove(university);
            _logger.LogInformation("Delete university with id: {0}", id);
            return Ok();
        }
    }
}