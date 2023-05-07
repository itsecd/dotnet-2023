using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
    /// Хранение ContextFactory
    /// </summary>
    private readonly IDbContextFactory<UniversityDataDbContext> _contextFactory;
    /// <summary>
    /// Хранение маппера
    /// </summary>
    private readonly IMapper _mapper;
    public RectorController(ILogger<RectorController> logger, IDbContextFactory<UniversityDataDbContext> contextFactory, IMapper mapper)
    {
        _logger = logger;
        _contextFactory =  contextFactory;
        _mapper = mapper;
    }

    /// <summary>
    /// GET-запрос на получение всех элементов коллекции
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<IEnumerable<Rector>> Get()
    {
        await using UniversityDataDbContext ctx = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation("Get all rectors");
        return ctx.Rectors;
    }
    /// <summary>
    /// GET-запрос на получение элемента в соответствии с ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<Rector?>> Get(int id)
    {
        await using UniversityDataDbContext ctx = await _contextFactory.CreateDbContextAsync();
        var rector = ctx.Rectors.FirstOrDefault(rector => rector.Id == id);
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
    public async Task<ActionResult>Post([FromBody] RectorPostDto rector)
    {
        await using UniversityDataDbContext ctx = await _contextFactory.CreateDbContextAsync();
        ctx.Rectors.Add(_mapper.Map<Rector>(rector));
        ctx.SaveChanges();
        _logger.LogInformation("Add new rector");
        return Ok();
        
    }
    /// <summary>
    /// PUT-запрос на замену существующего элемента коллекции
    /// </summary>
    /// <param name="id"></param>
    /// <param name="rectorToPut"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] RectorPostDto rectorToPut)
    {
        await using UniversityDataDbContext ctx = await _contextFactory.CreateDbContextAsync();
        var rector = ctx.Rectors.FirstOrDefault(rector => rector.Id == id);
        if (rector == null)
        {
            _logger.LogInformation($"Not found rector with id: {id}");
            return NotFound();
        }
        else
        {
            _mapper.Map<RectorPostDto, Rector>(rectorToPut, rector);
            ctx.SaveChanges();
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
    public async Task<IActionResult> Delete(int id)
    {
        await using UniversityDataDbContext ctx = await _contextFactory.CreateDbContextAsync();
        var rector = ctx.Rectors.FirstOrDefault(rector => rector.Id == id);
        if (rector == null)
        {
            _logger.LogInformation("Not found rector with id: {0}", id);
            return NotFound();
        }
        else
        {
            ctx.Rectors.Remove(rector);
            ctx.SaveChanges();
            _logger.LogInformation("Delete rector with id: {0}", id);
            return Ok();
        }
    }
}
