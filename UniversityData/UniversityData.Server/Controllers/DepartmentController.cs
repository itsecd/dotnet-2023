using UniversityData.Domain;
using UniversityData.Server.Dto;
using Microsoft.AspNetCore.Mvc;
namespace UniversityData.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DepartmentController : ControllerBase
{
    private readonly ILogger<DepartmentController> _logger;
    private readonly UniversityDataRepository _universityDataRepository;
    public DepartmentController(ILogger<DepartmentController> logger, UniversityDataRepository universityDataRepository)
    {
        _logger = logger;
        _universityDataRepository = universityDataRepository;
    }

    [HttpGet]
    public IEnumerable<Department> Get()
    {
        _logger.LogInformation("Get all departments");
        return _universityDataRepository.Departments;
    }

    [HttpGet("{id}")]
    public ActionResult<Department?> Get(int id)
    {
        var department = _universityDataRepository.Departments.FirstOrDefault(department => department.Id == id);
        if (department == null)
        {
            _logger.LogInformation($"Not found department with id: {id}");
            return NotFound();
        }
        else
        {
            _logger.LogInformation($"Get department with id: {id}");
            return Ok(department);
        }
    }

    [HttpPost]
    public void Post([FromBody] DepartmentPostDto department)
    {
        _universityDataRepository.Departments.Add(new Department()
        {
            Name = department.Name,
            SupervisorNumber = department.SupervisorNumber,
            UniversityId = department.UniversityId
        });
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] DepartmentPostDto departmentToPut)
    {
        var department = _universityDataRepository.Departments.FirstOrDefault(department => department.Id == id);
        if (department == null)
        {
            _logger.LogInformation($"Not found department with id: {id}");
            return NotFound();
        }
        else
        {
            department.Name = departmentToPut.Name;
            department.SupervisorNumber = departmentToPut.SupervisorNumber;
            department.UniversityId = departmentToPut.UniversityId;
            return Ok();
        }
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var department = _universityDataRepository.Departments.FirstOrDefault(department => department.Id == id);
        if (department == null)
        {
            _logger.LogInformation($"Not found department with id: {id}");
            return NotFound();
        }
        else
        {
            _universityDataRepository.Departments.Remove(department);
            return Ok();
        }
    }
}
