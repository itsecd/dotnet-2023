using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniversityData.Domain;
using UniversityData.Server.Dto;
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
        _contextFactory = contextFactory;
        _mapper = mapper;
    }

    /// <summary>
    /// GET-запрос на получение всех элементов коллекции
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<IEnumerable<RectorGetDto>> Get()
    {
        await using UniversityDataDbContext ctx = await _contextFactory.CreateDbContextAsync();
        var rectors = await ctx.Rectors.ToArrayAsync();
        _logger.LogInformation("Get all rectors");
        return _mapper.Map<IEnumerable<RectorGetDto>>(rectors);
    }
    /// <summary>
    /// GET-запрос на получение элемента в соответствии с ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<RectorGetDto?>> Get(int id)
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
            return Ok(_mapper.Map<RectorGetDto>(rector));
        }
    }
    /// <summary>
    /// POST-запрос на добавление нового элемента в коллекцию
    /// </summary>
    /// <param name="rector"></param>
    [HttpPost]
    [ProducesResponseType(201)]
    public async Task<ActionResult<RectorGetDto>> Post([FromBody] RectorPostDto rector)
    {
        await using UniversityDataDbContext ctx = await _contextFactory.CreateDbContextAsync();
        var mappedRector= _mapper.Map<Rector>(rector);
        ctx.Rectors.Add(mappedRector);
        await ctx.SaveChangesAsync();
        _logger.LogInformation("Add new construction property");
        return CreatedAtAction("POST", _mapper.Map<RectorGetDto>(mappedRector));
    }
    /// <summary>
    /// PUT-запрос на замену существующего элемента коллекции
    /// </summary>
    /// <param name="id"></param>
    /// <param name="rectorToPut"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public async Task<ActionResult<RectorPostDto>> Put(int id, [FromBody] RectorPostDto rectorToPut)
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
            await ctx.SaveChangesAsync();
            _logger.LogInformation("Update rector with id: {0}", id);
            return Ok(rectorToPut);
        }
    }
    /// <summary>
    /// DELETE-запрос на удаление элемента из коллекции
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public async Task<ActionResult<RectorGetDto>> Delete(int id)
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
            await ctx.SaveChangesAsync();
            _logger.LogInformation("Delete rector with id: {0}", id);
            return Ok();
        }
    }
}
