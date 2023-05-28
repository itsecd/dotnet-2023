using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniversityData.Domain;
using UniversityData.Server.Dto;
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
    /// Хранение ContextFactory
    /// </summary>
    private readonly IDbContextFactory<UniversityDataDbContext> _contextFactory;
    /// <summary>
    /// Хранение маппера
    /// </summary>
    private readonly IMapper _mapper;
    public SpecialtyTableNodeController(ILogger<SpecialtyTableNodeController> logger, IDbContextFactory<UniversityDataDbContext> contextFactory, IMapper mapper)
    {
        _logger = logger;
        _contextFactory = contextFactory;
        _mapper = mapper;
    }

    /// <summary>
    /// GET-запрос на получение всех элементов коллекции
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<IEnumerable<SpecialtyTableNodeGetDto>> Get()
    {
        await using UniversityDataDbContext ctx = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation("Get all specialtyTableNodes");
        return ctx.SpecialtyTableNodes.Select(specialtyTableNode => _mapper.Map<SpecialtyTableNodeGetDto>(specialtyTableNode));
    }
    /// <summary>
    /// GET-запрос на получение элемента в соответствии с ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<SpecialtyTableNodeGetDto?>> Get(int id)
    {
        await using UniversityDataDbContext ctx = await _contextFactory.CreateDbContextAsync();
        var specialtyTableNode = ctx.SpecialtyTableNodes.FirstOrDefault(specialtyTableNode => specialtyTableNode.Id == id);
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
    [ProducesResponseType(201)]
    public async Task<ActionResult<SpecialtyTableNodeGetDto>> Post([FromBody] SpecialtyTableNodePostDto specialtyTableNode)
    {
        await using UniversityDataDbContext ctx = await _contextFactory.CreateDbContextAsync();
        var mappedSpecilatyTableNode = _mapper.Map<SpecialtyTableNode>(specialtyTableNode);
        ctx.SpecialtyTableNodes.Add(mappedSpecilatyTableNode);
        await ctx.SaveChangesAsync();
        _logger.LogInformation("Add new specialty table node");
        return Ok(_mapper.Map<SpecialtyTableNodeGetDto>(mappedSpecilatyTableNode));
    }
    /// <summary>
    /// PUT-запрос на замену существующего элемента коллекции
    /// </summary>
    /// <param name="id"></param>
    /// <param name="specialtyTableNodeToPut"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public async Task<ActionResult<SpecialtyTableNodePostDto>> Put(int id, [FromBody] SpecialtyTableNodePostDto specialtyTableNodeToPut)
    {
        await using UniversityDataDbContext ctx = await _contextFactory.CreateDbContextAsync();
        var specialtyTableNode = ctx.SpecialtyTableNodes.FirstOrDefault(specialtyTableNode => specialtyTableNode.Id == id);
        if (specialtyTableNode == null)
        {
            _logger.LogInformation($"Not found specialtyTableNode with id: {id}");
            return NotFound();
        }
        else
        {
            _mapper.Map<SpecialtyTableNodePostDto, SpecialtyTableNode>(specialtyTableNodeToPut, specialtyTableNode);
            await ctx.SaveChangesAsync();
            _logger.LogInformation("Update specialtyTableNode with id: {0}", id);
            return Ok(specialtyTableNodeToPut);
        }
    }
    /// <summary>
    /// DELETE-запрос на удаление элемента из коллекции
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public async Task<ActionResult<SpecialtyTableNodeGetDto>> Delete(int id)
    {
        await using UniversityDataDbContext ctx = await _contextFactory.CreateDbContextAsync();
        var specialtyTableNode = ctx.SpecialtyTableNodes.FirstOrDefault(specialtyTableNode => specialtyTableNode.Id == id);
        if (specialtyTableNode == null)
        {
            _logger.LogInformation($"Not found specialtyTableNode with id: {id}");
            return NotFound();
        }
        else
        {
            ctx.SpecialtyTableNodes.Remove(specialtyTableNode);
            await ctx.SaveChangesAsync();
            _logger.LogInformation("Delete specialtyTableNode with id: {0}", id);
            return Ok();
        }
    }
}