using AutoMapper;
using Microsoft.AspNetCore.Mvc;
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
    /// Хранение репозитория
    /// </summary>
    private readonly IUniversityDataRepository _universityDataRepository;
    /// <summary>
    /// Хранение маппера
    /// </summary>
    private readonly IMapper _mapper;
    public DepartmentController(ILogger<DepartmentController> logger, IUniversityDataRepository universityDataRepository, IMapper mapper)
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
    public IEnumerable<Department> Get()
    {
        _logger.LogInformation("Get all departments");
        return _universityDataRepository.Departments;
    }
    /// <summary>
    /// GET-запрос на получение элемента в соответствии с ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public ActionResult<Department?> Get(int id)
    {
        var department = _universityDataRepository.Departments.FirstOrDefault(department => department.Id == id);
        if (department == null)
        {
            _logger.LogInformation("Not found department with id: {0}", id);
            return NotFound();
        }
        else
        {
            _logger.LogInformation("Get department with id: {0}", id);
            return Ok(department);
        }
    }
    /// <summary>
    /// POST-запрос на добавление нового элемента в коллекцию
    /// </summary>
    /// <param name="department"></param>
    [HttpPost]
    public void Post([FromBody] DepartmentPostDto department)
    {
        _logger.LogInformation("Add new department");
        _universityDataRepository.Departments.Add(_mapper.Map<Department>(department));
    }
    /// <summary>
    /// PUT-запрос на замену существующего элемента коллекции
    /// </summary>
    /// <param name="id"></param>
    /// <param name="departmentToPut"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] DepartmentPostDto departmentToPut)
    {
        var department = _universityDataRepository.Departments.FirstOrDefault(department => department.Id == id);
        if (department == null)
        {
            _logger.LogInformation("Not found department with id: {0}", id);
            return NotFound();
        }
        else
        {
            _mapper.Map<DepartmentPostDto, Department>(departmentToPut, department);
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
    public IActionResult Delete(int id)
    {
        var department = _universityDataRepository.Departments.FirstOrDefault(department => department.Id == id);
        if (department == null)
        {
            _logger.LogInformation("Not found department with id: {0}", id);
            return NotFound();
        }
        else
        {
            _universityDataRepository.Departments.Remove(department);
            _logger.LogInformation("Delete departments with id: {0}", id);
            return Ok();
        }
    }
}
