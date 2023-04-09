using AutoMapper;
using Library.Domain;
using Library.Server.Dto;
using Library.Server.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Library.Server.Controllers;
/// <summary>
/// Department controller
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class DepartmentController : ControllerBase
{
    /// <summary>
    /// Used to store logger
    /// </summary>
    private readonly ILogger<DepartmentController> _logger;
    /// <summary>
    /// Used to store repository
    /// </summary>
    private readonly ILibraryRepository _librariesRepository;
    /// <summary>
    /// Used to store map's object
    /// </summary>
    private readonly IMapper _mapper;
    /// <summary>
    /// Reader controller's constructor
    /// </summary>
    /// <param name="logger"></param>
    /// <param name="librariesRepository"></param>
    /// <param name="mapper"></param>
    public DepartmentController(ILogger<DepartmentController> logger, ILibraryRepository librariesRepository, IMapper mapper)
    {
        _logger = logger;
        _librariesRepository = librariesRepository;
        _mapper = mapper;
    }
    /// <summary>
    /// Return list of all departments
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public IEnumerable<DepartmentGetDto> Get()
    {
        return _librariesRepository.Departments.Select(department => _mapper.Map<DepartmentGetDto>(department)); ;
    }
    /// <summary>
    /// Return info about department by id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public ActionResult<DepartmentGetDto> Get(int id)
    {
        var department = _librariesRepository.Departments.FirstOrDefault(department => department.Id == id);
        if (department == null)
        {
            _logger.LogInformation("Not found department: {id}", id);
            return NotFound();
        }
        else
        {
            return Ok(_mapper.Map<DepartmentGetDto>(department));
        }
    }
    /// <summary>
    /// Add a new department
    /// </summary>
    /// <param name="department"></param>
    [HttpPost]
    public void Post([FromBody] DepartmentPostDto department)
    {
        _librariesRepository.Departments.Add(_mapper.Map<Department>(department));
        _logger.LogInformation("Added");
    }
    /// <summary>
    /// Сhange info of selected department
    /// </summary>
    /// <param name="id"></param>
    /// <param name="departmentToPut"></param>
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] DepartmentPostDto departmentToPut)
    {
        var department = _librariesRepository.Departments.FirstOrDefault(department => department.Id == id);
        if (department == null)
        {
            _logger.LogInformation("Not found department: {id}", id);
            return NotFound();
        }
        else
        {
            _mapper.Map(departmentToPut, department);
            return Ok();
        }
    }
    /// <summary>
    /// Delete department by id
    /// </summary>
    /// <param name="id"></param>
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var department = _librariesRepository.Departments.FirstOrDefault(department => department.Id == id);
        if (department == null)
        {
            _logger.LogInformation("Not found department: {id}", id);
            return NotFound();
        }
        else
        {
            _librariesRepository.Departments.Remove(department);
            return Ok();
        }
    }
}