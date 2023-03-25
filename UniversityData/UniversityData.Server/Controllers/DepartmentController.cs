using UniversityData.Domain;
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
    public void Post([FromBody] string value)
    {
    }

    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
}
