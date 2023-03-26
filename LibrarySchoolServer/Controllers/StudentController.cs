using AutoMapper;
using LibrarySchool;
using LibrarySchoolServer.Dto;
using Microsoft.AspNetCore.Mvc;

namespace LibrarySchoolServer.Controllers;
/// <summary>
/// Controler for class Student. Defined methods: Post, Put, Get, Delete
/// </summary>

[Route("api/[controller]")]
[ApiController]
public class StudentController : Controller
{
    private readonly ILogger<ClassTypeController> _logger;
    private readonly ILibrarySchoolRepository _librarySchoolRepository;
    private readonly IMapper _mapper;

    /// <summary>
    /// Constructor class StudentController
    /// </summary>
    /// <param name="logger"></param>
    /// <param name="librarySchoolRepository"></param>
    /// <param name="mapper"></param>
    public StudentController(ILogger<ClassTypeController> logger, ILibrarySchoolRepository librarySchoolRepository, IMapper mapper)
    {
        _logger = logger;
        _mapper = mapper;
        _librarySchoolRepository = librarySchoolRepository;
    }
    /// <summary>
    /// Get list student
    /// </summary>
    /// <returns>
    /// Return: list student type StudentGetDto
    /// </returns>
    [HttpGet]
    public IEnumerable<StudentGetDto> Get()
    {
        _logger.LogInformation("Get list students");
        return _librarySchoolRepository.Students.Select(student => _mapper.Map<StudentGetDto>(student));
    }
    /// <summary>
    /// Get student with certain id
    /// </summary>
    /// <param name="id"></param>
    /// <returns>
    /// Return: Ation result Ok if student exist, NotFound() if not exist
    /// </returns>
    [HttpGet("{id}")]
    public ActionResult<StudentGetDto> Get(int id)
    {
        var foundStudent = _librarySchoolRepository.Students.FirstOrDefault(student => student.StudentId == id);
        if (foundStudent == null)
        {
            _logger.LogInformation("Not found student {id}", id);
            return NotFound();
        }
        return Ok(_mapper.Map<StudentGetDto>(foundStudent));
    }

    /// <summary>
    /// Add new student to respository
    /// </summary>
    /// <param name="studentDtoToPost"></param>
    [HttpPost]
    public void Post([FromBody] StudentPostDto studentDtoToPost)
    {
        _librarySchoolRepository.Students.Add(_mapper.Map<Student>(studentDtoToPost));
    }

    /// <summary>
    /// Change information of student with certain Id
    /// </summary>
    /// <param name="id"></param>
    /// <param name="fixedStudent"></param>
    /// <returns>
    /// Return: IActionResult NotFound if not exist or Ok if exist
    /// </returns>
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] StudentPostDto fixedStudent)
    {
        var studentToFix = _librarySchoolRepository.Students.FirstOrDefault(student => student.StudentId == id);
        if (studentToFix == null)
        {
            _logger.LogInformation("Not found student {id}", id);
            return NotFound();
        }
        _mapper.Map(fixedStudent, studentToFix);
        return Ok();
    }

    /// <summary>
    /// Delete a student with certain Id 
    /// </summary>
    /// <param name="id"></param>
    /// <returns>
    /// Return: IActionResult NotFound if not exist or Ok if student deleted
    /// </returns>

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var studentToDelete = _librarySchoolRepository.Students.FirstOrDefault(student => student.StudentId == id);
        if (studentToDelete == null)
        {
            _logger.LogInformation("Not found student {id}", id);
            return NotFound();
        }
        _librarySchoolRepository.Students.Remove(studentToDelete);
        return Ok();
    }
}
