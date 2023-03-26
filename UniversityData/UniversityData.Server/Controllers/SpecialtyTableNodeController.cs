using UniversityData.Domain;
using UniversityData.Server.Dto;
using Microsoft.AspNetCore.Mvc;
using UniversityData.Server.Repository;
using AutoMapper;
namespace UniversityData.Server.Controllers;

/// <summary>
/// Контроллер связи университетов со специальностями
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class SpecialtyTableNodeController : ControllerBase
{
    /// <summary>
    /// Хранение логгера
    /// </summary>
    private readonly ILogger<SpecialtyTableNodeController> _logger;
    /// <summary>
    /// Хранение репозитория
    /// </summary>
    private readonly IUniversityDataRepository _universityDataRepository;
    /// <summary>
    /// Хранение маппера
    /// </summary>
    private readonly IMapper _mapper;
    public SpecialtyTableNodeController(ILogger<SpecialtyTableNodeController> logger, IUniversityDataRepository universityDataRepository, IMapper mapper)
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
    public IEnumerable<SpecialtyTableNodeGetDto> Get()
    {
        _logger.LogInformation("Get all specialtyTableNodes");
        return _universityDataRepository.SpecialtyTableNodes.Select(specialtyTableNode => _mapper.Map<SpecialtyTableNodeGetDto>(specialtyTableNode));
    }
    /// <summary>
    /// GET-запрос на получение элемента в соответствии с ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public ActionResult<SpecialtyTableNodeGetDto?> Get(int id)
    {
        var specialtyTableNode = _universityDataRepository.SpecialtyTableNodes.FirstOrDefault(specialtyTableNode => specialtyTableNode.Id == id);
        if (specialtyTableNode == null)
        {
            _logger.LogInformation("Not found specialtyTableNode with id: {0}", id);
            return NotFound();
        }
        else
        {
            _logger.LogInformation("Get specialtyTableNode with id {0}", id);
            return Ok(_mapper.Map<SpecialtyTableNodeGetDto>(specialtyTableNode));
        }
    }
    /// <summary>
    /// POST-запрос на добавление нового элемента в коллекцию
    /// </summary>
    /// <param name="specialtyTableNode"></param>
    [HttpPost]
    public void Post([FromBody] SpecialtyTableNodePostDto specialtyTableNode)
    {
        _logger.LogInformation("Add new specialtyTableNode");
        _universityDataRepository.SpecialtyTableNodes.Add(_mapper.Map<SpecialtyTableNode>(specialtyTableNode));
    }
    /// <summary>
    /// PUT-запрос на замену существующего элемента коллекции
    /// </summary>
    /// <param name="id"></param>
    /// <param name="specialtyTableNodeToPut"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] SpecialtyTableNodePostDto specialtyTableNodeToPut)
    {
        var specialtyTableNode = _universityDataRepository.SpecialtyTableNodes.FirstOrDefault(specialtyTableNode => specialtyTableNode.Id == id);
        if (specialtyTableNode == null)
        {
            _logger.LogInformation($"Not found specialtyTableNode with id: {id}");
            return NotFound();
        }
        else
        {
            _mapper.Map<SpecialtyTableNodePostDto, SpecialtyTableNode>(specialtyTableNodeToPut, specialtyTableNode);
            _logger.LogInformation("Update specialtyTableNode with id: {0}", id);
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
        var specialtyTableNode = _universityDataRepository.SpecialtyTableNodes.FirstOrDefault(specialtyTableNode => specialtyTableNode.Id == id);
        if (specialtyTableNode == null)
        {
            _logger.LogInformation($"Not found specialtyTableNode with id: {id}");
            return NotFound();
        }
        else
        {
            _universityDataRepository.SpecialtyTableNodes.Remove(specialtyTableNode);
            _logger.LogInformation("Delete specialtyTableNode with id: {0}", id);
            return Ok();
        }
    }
}