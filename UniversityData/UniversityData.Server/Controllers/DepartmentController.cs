using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniversityData.Domain;
using UniversityData.Server.Dto;
using UniversityData.Server.Repository;
namespace UniversityData.Server.Controllers;

/// <summary>
/// Контроллер кафедры
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class DepartmentController : ControllerBase
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
    public DepartmentController(ILogger<DepartmentController> logger, IDbContextFactory<UniversityDataDbContext> contextFactory, IMapper mapper)
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
    public async Task<IEnumerable<DepartmentGetDto>> Get()
    {
        await using UniversityDataDbContext ctx = await _contextFactory.CreateDbContextAsync();
        var departments = await ctx.Departments.ToArrayAsync();
        _logger.LogInformation("Get all departments");
        return _mapper.Map<IEnumerable<DepartmentGetDto>>(departments);
    }
    /// <summary>
    /// GET-запрос на получение элемента в соответствии с ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<DepartmentGetDto?>> Get(int id)
    {
        await using UniversityDataDbContext ctx = await _contextFactory.CreateDbContextAsync();
        var department = ctx.Departments.FirstOrDefault(department => department.Id == id);
        if (department == null)
        {
            _logger.LogInformation("Not found department with id: {0}", id);
            return NotFound();
        }
        else
        {
            _logger.LogInformation("Get department with id: {0}", id);
            return Ok(_mapper.Map<DepartmentGetDto>(department));
        }
    }
    /// <summary>
    /// POST-запрос на добавление нового элемента в коллекцию
    /// </summary>
    /// <param name="department"></param>
    [HttpPost]
    public async Task<ActionResult> Post([FromBody] DepartmentPostDto department)
    {
        await using UniversityDataDbContext ctx = await _contextFactory.CreateDbContextAsync();
        ctx.Departments.Add(_mapper.Map<Department>(department));
        ctx.SaveChanges();
        _logger.LogInformation("Add new department");
        return Ok();
       
    }
    /// <summary>
    /// PUT-запрос на замену существующего элемента коллекции
    /// </summary>
    /// <param name="id"></param>
    /// <param name="departmentToPut"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] DepartmentPostDto departmentToPut)
    {
        await using UniversityDataDbContext ctx = await _contextFactory.CreateDbContextAsync();
        var department = ctx.Departments.FirstOrDefault(department => department.Id == id);
        if (department == null)
        {
            _logger.LogInformation("Not found department with id: {0}", id);
            return NotFound();
        }
        else
        {
            _mapper.Map<DepartmentPostDto, Department>(departmentToPut, department);
            ctx.SaveChanges();
            _logger.LogInformation("Update department with id: {0}", id);
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
        var department = ctx.Departments.FirstOrDefault(department => department.Id == id);
        if (department == null)
        {
            _logger.LogInformation("Not found department with id: {0}", id);
            return NotFound();
        }
        else
        {
            ctx.Departments.Remove(department);
            ctx.SaveChanges();
            _logger.LogInformation("Delete departments with id: {0}", id);
            return Ok();
        }
    }
}
