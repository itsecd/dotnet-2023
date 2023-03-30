using AutoMapper;
using LibrarySchool;
using LibrarySchoolServer.Dto;
using Microsoft.AspNetCore.Mvc;

namespace LibrarySchoolServer.Controllers;

/// <summary>
/// Controller for class ClassType. Define method: Get
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class ClassTypeController : Controller
{
    private readonly ILogger<ClassTypeController> _logger;
    private readonly ILibrarySchoolRepository _librarySchoolRepository;
    private readonly IMapper _mapper;

    /// <summary>
    /// Constructor controller ClassTypeController
    /// </summary>
    /// <param name="logger"></param>
    /// <param name="librarySchoolRepository"></param>
    /// <param name="mapper"></param>
    public ClassTypeController(ILogger<ClassTypeController> logger, ILibrarySchoolRepository librarySchoolRepository, IMapper mapper)
    {
        _logger = logger;
        _mapper = mapper;
        _librarySchoolRepository = librarySchoolRepository;
    }

    /// <summary>
    /// Get list Class
    /// </summary>
    /// <returns>
    /// Return: list class type ClassTypeGetDto
    /// </returns>
    [HttpGet]
    public IEnumerable<ClassTypeGetDto> Get()
    {
        _logger.LogInformation("Get list classes");
        return _librarySchoolRepository.ClassTypes.Select(classType => _mapper.Map<ClassTypeGetDto>(classType));
    }

    /// <summary>
    /// Get class by certain Id
    /// </summary>
    /// <param name="id"></param>
    /// <returns>
    /// Class with certain Id
    /// </returns>
    [HttpGet("{id}")]
    public ActionResult<ClassTypeGetDto> Get(int id)
    {
        var foundClassType = _librarySchoolRepository.ClassTypes.FirstOrDefault(classType => classType.ClassId == id);
        if (foundClassType == null)
        {
            _logger.LogInformation("Not found class-type {id}", id);
            return NotFound();
        }
        return Ok(_mapper.Map<ClassTypeGetDto>(foundClassType));
    }

    /// <summary>
    /// Create new class
    /// </summary>
    /// <param name="classTypeToPost"></param>
    /// <returns>
    /// Class with certain Id
    /// </returns>
    [HttpPost]
    public void Post(ClassTypePostDto classTypeToPost)
    {
        _librarySchoolRepository.AddClass(_mapper.Map<ClassType>(classTypeToPost));
    }

    /// <summary>
    ///  Change information of class by Id
    /// </summary>
    /// <param name="id"></param>
    /// <param name="fixedClass"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] ClassTypePostDto fixedClass)
    {
        var foundClassType = _librarySchoolRepository.ClassTypes.FirstOrDefault(classType => classType.ClassId == id);
        if (foundClassType == null)
        {
            _logger.LogInformation("Not found class-type {id}", id);
            return NotFound();
        }
        _librarySchoolRepository.ChangeClass(id, _mapper.Map<ClassType>(fixedClass));
        return Ok();
    }

    /// <summary>
    /// Delete class by Id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var foundClassType = _librarySchoolRepository.ClassTypes.FirstOrDefault(classType => classType.ClassId == id);
        if (foundClassType == null)
        {
            _logger.LogInformation("Not found class-type {id}", id);
            return NotFound();
        }
        _librarySchoolRepository.DeleteClass(id);
        return Ok();
    }
}
