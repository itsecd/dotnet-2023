using Library.Domain;
using Library.Server.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Library.Server.Controllers;
/// <summary>
/// TypeDepartment controller
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class TypeDepartmentController : ControllerBase
{
    /// <summary>
    /// Used to store logger
    /// </summary>
    private readonly ILogger<TypeDepartmentController> _logger;
    /// <summary>
    /// Used to store repository
    /// </summary>
    private readonly ILibraryRepository _librariesRepository;
    /// <summary>
    /// TypeDepartment controller's constructor
    /// </summary>
    /// <param name="logger"></param>
    /// <param name="librariesRepository"></param>
    public TypeDepartmentController(ILogger<TypeDepartmentController> logger, ILibraryRepository librariesRepository)
    {
        _logger = logger;
        _librariesRepository = librariesRepository;
    }
    /// <summary>
    /// Return list of all types of departments
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public IEnumerable<TypeDepartment> Get()
    {
        return _librariesRepository.DepartmentTypes;
    }
    /// <summary>
    /// Return info about type by id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public ActionResult<TypeDepartment> Get(int id)
    {
        var departmentType = _librariesRepository.DepartmentTypes.FirstOrDefault(type => type.Id == id);
        if (departmentType == null)
        {
            _logger.LogInformation("Not found department type: {id}", id);
            return NotFound();
        }
        else
        {
            return Ok(departmentType);
        }
    }
}
