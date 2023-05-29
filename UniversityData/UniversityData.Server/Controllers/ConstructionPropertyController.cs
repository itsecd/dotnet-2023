using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniversityData.Domain;
using UniversityData.Server.Dto;
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
    /// Хранение ContextFactory
    /// </summary>
    private readonly IDbContextFactory<UniversityDataDbContext> _contextFactory;
    /// <summary>
    /// Хранение маппера
    /// </summary>
    private readonly IMapper _mapper;
    public ConstructionPropertyController(ILogger<DepartmentController> logger, IDbContextFactory<UniversityDataDbContext> contextFactory, IMapper mapper)
    {
        _logger = logger;
        _contextFactory = contextFactory;
        _mapper = mapper;
    }
    /// <summary>
    /// GET-запрос на получение всех элементов коллекции
    /// </summary>
    /// <returns>
    /// Коллекция объектов ConstructionProperty
    /// </returns>
    [HttpGet]
    public async Task<IEnumerable<ConstructionPropertyGetDto>> Get()
    {
        await using UniversityDataDbContext ctx = await _contextFactory.CreateDbContextAsync();
        var constructionProperties = await ctx.ConstructionProperties.ToArrayAsync();
        _logger.LogInformation("Get all construction properties");
        return _mapper.Map<IEnumerable<ConstructionPropertyGetDto>>(constructionProperties);
    }
    /// <summary>
    /// GET-запрос на получение элемента в соответствии с ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns>
    /// Объект ConstructionProperty с заданным ID
    /// </returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<ConstructionPropertyGetDto?>> Get(int id)
    {
        await using UniversityDataDbContext ctx = await _contextFactory.CreateDbContextAsync();
        var constructionProperty = ctx.ConstructionProperties.FirstOrDefault(constructionProperty => constructionProperty.Id == id);
        if (constructionProperty == null)
        {
            _logger.LogInformation("Not found construction property with id: {id}", id);
            return NotFound();
        }
        else
        {
            _logger.LogInformation("Get construction property with id: {id}", id);
            return Ok(_mapper.Map<ConstructionPropertyGetDto>(constructionProperty));
        }
    }
    /// <summary>
    /// POST-запрос на добавление нового элемента в коллекцию
    /// </summary>
    /// <param name="constructionProperty"></param>
    [HttpPost]
    [ProducesResponseType(201)]
    public async Task<ActionResult<ConstructionPropertyGetDto>> Post([FromBody] ConstructionPropertyPostDto constructionProperty)
    {
        await using UniversityDataDbContext ctx = await _contextFactory.CreateDbContextAsync();
        var mappedConstructionProperty = _mapper.Map<ConstructionProperty>(constructionProperty);
        ctx.ConstructionProperties.Add(mappedConstructionProperty);
        await ctx.SaveChangesAsync();
        _logger.LogInformation("Add new construction property");
        return CreatedAtAction("POST", _mapper.Map<ConstructionPropertyGetDto>(mappedConstructionProperty));
    }
    /// <summary>
    /// PUT-запрос на замену существующего элемента коллекции
    /// </summary>
    /// <param name="id"></param>
    /// <param name="constructionPropertyToPut"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public async Task<ActionResult<ConstructionPropertyPostDto>> Put(int id, [FromBody] ConstructionPropertyPostDto constructionPropertyToPut)
    {
        await using UniversityDataDbContext ctx = await _contextFactory.CreateDbContextAsync();
        var constructionProperty = ctx.ConstructionProperties.FirstOrDefault(constructionProperty => constructionProperty.Id == id);
        if (constructionProperty == null)
        {
            _logger.LogInformation("Not found construction property with id: {id}", id);
            return NotFound();
        }
        else
        {
            _mapper.Map<ConstructionPropertyPostDto, ConstructionProperty>(constructionPropertyToPut, constructionProperty);
            await ctx.SaveChangesAsync();
            _logger.LogInformation("Update construction property with id: {id}", id);
            return Ok(constructionPropertyToPut);
        }
    }
    /// <summary>
    /// DELETE-запрос на удаление элемента из коллекции
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public async Task<ActionResult<ConstructionPropertyGetDto>> Delete(int id)
    {
        await using UniversityDataDbContext ctx = await _contextFactory.CreateDbContextAsync();
        var constructionProperty = ctx.ConstructionProperties.FirstOrDefault(constructionProperty => constructionProperty.Id == id);
        if (constructionProperty == null)
        {
            _logger.LogInformation("Not found construction property with id: {id}", id);
            return NotFound();
        }
        else
        {
            ctx.ConstructionProperties.Remove(constructionProperty);
            await ctx.SaveChangesAsync();
            _logger.LogInformation("Delete construction property with id: {id}", id);
            return Ok();
        }
    }
}
