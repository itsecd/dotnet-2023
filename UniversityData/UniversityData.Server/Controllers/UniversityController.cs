using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniversityData.Domain;
using UniversityData.Server.Dto;
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
    /// Хранение ContextFactory
    /// </summary>
    private readonly IDbContextFactory<UniversityDataDbContext> _contextFactory;
    /// <summary>
    /// Хранение маппера
    /// </summary>
    private readonly IMapper _mapper;
    public UniversityController(ILogger<UniversityController> logger, IDbContextFactory<UniversityDataDbContext> contextFactory, IMapper mapper)
    {
        _logger = logger;
        _contextFactory = contextFactory;
        _mapper = mapper;
    }

    /// <summary>
    /// GET-запрос на получение всех элементов коллекции
    /// </summary>
    /// <returns>
    /// Коллекция объектов University
    /// </returns>
    [HttpGet]
    public async Task<IEnumerable<UniversityGetDto>> Get()
    {
        await using UniversityDataDbContext ctx = await _contextFactory.CreateDbContextAsync();
        var universities = await ctx.Universities.ToArrayAsync();
        _logger.LogInformation("Get all universities");
        return _mapper.Map<IEnumerable<UniversityGetDto>>(universities);
    }
    /// <summary>
    /// GET-запрос на получение элемента в соответствии с ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns>
    /// Объект University с заданным ID
    /// </returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<UniversityGetDto?>> Get(int id)
    {
        await using UniversityDataDbContext ctx = await _contextFactory.CreateDbContextAsync();
        var university = ctx.Universities.FirstOrDefault(university => university.Id == id);
        if (university == null)
        {
            _logger.LogInformation("Not found university with id: {id}", id);
            return NotFound();
        }
        else
        {
            _logger.LogInformation("Get university with id {id}", id);
            return Ok(_mapper.Map<UniversityGetDto>(university));
        }
    }
    /// <summary>
    /// POST-запрос на добавление нового элемента в коллекцию
    /// </summary>
    /// <param name="university"></param>
    [HttpPost]
    [ProducesResponseType(201)]
    public async Task<ActionResult<UniversityGetDto>> Post([FromBody] UniversityPostDto university)
    {
        await using UniversityDataDbContext ctx = await _contextFactory.CreateDbContextAsync();
        var mappedUniversity = _mapper.Map<University>(university);
        ctx.Universities.Add(mappedUniversity);
        await ctx.SaveChangesAsync();
        _logger.LogInformation("Add new university");
        return CreatedAtAction("POST", _mapper.Map<UniversityGetDto>(mappedUniversity));
    }
    /// <summary>
    /// PUT-запрос на замену существующего элемента коллекции
    /// </summary>
    /// <param name="id"></param>
    /// <param name="universityToPut"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public async Task<ActionResult<UniversityPostDto>> Put(int id, [FromBody] UniversityPostDto universityToPut)
    {
        await using UniversityDataDbContext ctx = await _contextFactory.CreateDbContextAsync();
        var university = ctx.Universities.FirstOrDefault(university => university.Id == id);
        if (university == null)
        {
            _logger.LogInformation("Not found university with id: {id}", id);
            return NotFound();
        }
        else
        {
            _mapper.Map<UniversityPostDto, University>(universityToPut, university);
            await ctx.SaveChangesAsync();
            _logger.LogInformation("Update university with id: {id}", id);
            return Ok(universityToPut);
        }
    }
    /// <summary>
    /// DELETE-запрос на удаление элемента из коллекции
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public async Task<ActionResult<UniversityGetDto>> Delete(int id)
    {
        await using UniversityDataDbContext ctx = await _contextFactory.CreateDbContextAsync();
        var university = ctx.Universities.FirstOrDefault(university => university.Id == id);
        if (university == null)
        {
            _logger.LogInformation("Not found university with id: {id}", id);
            return NotFound();
        }
        else
        {
            ctx.Universities.Remove(university);
            await ctx.SaveChangesAsync();
            _logger.LogInformation("Delete university with id: {id}", id);
            return Ok();
        }
    }
}