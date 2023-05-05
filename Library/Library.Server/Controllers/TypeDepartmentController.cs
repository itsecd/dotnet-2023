using AutoMapper;
using Library.Server.Dto;
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
    /// Used to store map's object
    /// </summary>
    private readonly IMapper _mapper;
    /// <summary>
    /// TypeDepartment controller's constructor
    /// </summary>
    /// <param name="logger"></param>
    /// <param name="librariesRepository"></param>
    /// <param name="mapper"></param>
    public TypeDepartmentController(ILogger<TypeDepartmentController> logger, ILibraryRepository librariesRepository, IMapper mapper)
    {
        _logger = logger;
        _librariesRepository = librariesRepository;
        _mapper = mapper;
    }
    /// <summary>
    /// Return list of all types of departments
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public IEnumerable<TypeDepartmentGetDto> Get()
    {
        return _librariesRepository.DepartmentTypes.Select(type => _mapper.Map<TypeDepartmentGetDto>(type));
    }
    /// <summary>
    /// Return info about type by id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public ActionResult<TypeDepartmentGetDto> Get(int id)
    {
        var departmentType = _librariesRepository.DepartmentTypes.FirstOrDefault(type => type.Id == id);
        if (departmentType == null)
        {
            _logger.LogInformation("Not found department type: {id}", id);
            return NotFound();
        }
        else
        {
            return Ok(_mapper.Map<TypeDepartmentGetDto>(departmentType));
        }
    }
}