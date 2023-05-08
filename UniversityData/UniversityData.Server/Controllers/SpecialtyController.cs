using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniversityData.Domain;
using UniversityData.Server.Dto;
using UniversityData.Server.Repository;
namespace UniversityData.Server.Controllers;

/// <summary>
/// Контроллер специальности
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class SpecialtyController : ControllerBase
{
    /// <summary>
    /// Хранение логгера
    /// </summary>
    private readonly ILogger<SpecialtyController> _logger;
    /// <summary>
    /// Хранение ContextFactory
    /// </summary>
    private readonly IDbContextFactory<UniversityDataDbContext> _contextFactory;
    /// <summary>
    /// Хранение маппера
    /// </summary>
    private readonly IMapper _mapper;
    public SpecialtyController(ILogger<SpecialtyController> logger, IDbContextFactory<UniversityDataDbContext> contextFactory, IMapper mapper)
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
    public async Task<IEnumerable<SpecialtyGetDto>> Get()
    {
        await using UniversityDataDbContext ctx = await _contextFactory.CreateDbContextAsync();
        var specialties = await ctx.Specialties.ToArrayAsync();
        _logger.LogInformation("Get all specialties");
        return _mapper.Map<IEnumerable<SpecialtyGetDto>>(specialties);
    }
    /// <summary>
    /// GET-запрос на получение элемента в соответствии с ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<SpecialtyGetDto?>> Get(int id)
    {
        await using UniversityDataDbContext ctx = await _contextFactory.CreateDbContextAsync();
        var specialty = ctx.Specialties.FirstOrDefault(specialty => specialty.Id == id);
        if (specialty == null)
        {
            _logger.LogInformation("Not found specialty with id: {0}", id);
            return NotFound();
        }
        else
        {
            _logger.LogInformation("Get specialty with id {0}", id);
            return Ok(_mapper.Map<SpecialtyGetDto>(specialty));
        }
    }
    /// <summary>
    /// POST-запрос на добавление нового элемента в коллекцию
    /// </summary>
    /// <param name="specialty"></param>
    [HttpPost]
    public async Task<ActionResult>Post([FromBody] SpecialtyPostDto specialty)
    {
        await using UniversityDataDbContext ctx = await _contextFactory.CreateDbContextAsync();
        ctx.Specialties.Add(_mapper.Map<Specialty>(specialty));
        ctx.SaveChanges();
        _logger.LogInformation("Add new specialty");
        return Ok();
        
    }
    /// <summary>
    /// PUT-запрос на замену существующего элемента коллекции
    /// </summary>
    /// <param name="id"></param>
    /// <param name="specialtyToPut"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] SpecialtyPostDto specialtyToPut)
    {
        await using UniversityDataDbContext ctx = await _contextFactory.CreateDbContextAsync();
        var specialty = ctx.Specialties.FirstOrDefault(specialty => specialty.Id == id);
        if (specialty == null)
        {
            _logger.LogInformation($"Not found specialty with id: {id}");
            return NotFound();
        }
        else
        {
            _mapper.Map<SpecialtyPostDto, Specialty>(specialtyToPut, specialty);
            ctx.SaveChanges();
            _logger.LogInformation("Update specialty with id: {0}", id);
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
        var specialty = ctx.Specialties.FirstOrDefault(specialty => specialty.Id == id);
        if (specialty == null)
        {
            _logger.LogInformation($"Not found specialty with id: {id}");
            return NotFound();
        }
        else
        {
            ctx.Specialties.Remove(specialty);
            ctx.SaveChanges();
            _logger.LogInformation("Delete specialty with id: {0}", id);
            return Ok();
        }
    }
}
