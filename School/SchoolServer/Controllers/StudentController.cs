using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using School.Classes;
using SchoolServer.Dto;
using SchoolServer.Repository;

namespace SchoolServer.Controllers;

/// <summary>
/// Контроллер студента
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class StudentController : ControllerBase
{
    private readonly ILogger<StudentController> _logger;

    private readonly ISchoolRepository _diaryRepository;

    private readonly IMapper _mapper;

    /// <summary>
    /// Конструктор контроллера
    /// </summary>
    public StudentController(ILogger<StudentController> logger, ISchoolRepository diaryRepository, IMapper mapper)
    {   
        _logger = logger;
        _diaryRepository = diaryRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Метод Get для студента
    /// </summary>
    [HttpGet]
    public IEnumerable<StudentGetDto> Get()
    {
        return _diaryRepository.Students.Select(student => _mapper.Map<StudentGetDto>(student));
    }

    /// <summary>
    /// Метод Get для контроллера
    /// </summary>
    [HttpGet("{id}")]
    public ActionResult<StudentGetDto> Get(int id)
    {
        var diaryStudent = _diaryRepository.Students.FirstOrDefault(subject => subject.Id == id);
        if (diaryStudent == null)
        {
            _logger.LogInformation("Not Found class with id = {id}", id);
            return NotFound();
        }
        else
        {
            return Ok(_mapper.Map<StudentGetDto>(diaryStudent));
        }
    }

    /// <summary>
    /// Метод Post для контроллера
    /// </summary>
    [HttpPost]
    public void Post([FromBody] StudentGetDto student)
    {
        _diaryRepository.Students.Add(_mapper.Map<Student>(student));
    }

    /// <summary>
    /// метод Put для коетроллера
    /// </summary>
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] StudentGetDto student)
    {
        var diaryStudent = _diaryRepository.Students.FirstOrDefault(stud => stud.Id == id);
        if (diaryStudent == null)
        {
            _logger.LogInformation("Not Found class with id = {id}", id);
            return NotFound();
        }
        else
        {
            _mapper.Map(student, diaryStudent);
            return Ok();
        }
    }

    /// <summary>
    /// Метод удаления студента
    /// </summary>
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var diaryStudent = _diaryRepository.Students.FirstOrDefault(subject => subject.Id == id);
        if (diaryStudent == null)
        {
            _logger.LogInformation("Not Found class with id = {id}", id);
            return NotFound();
        }
        else
        {
            _diaryRepository.Students.Remove(diaryStudent);
            return Ok();
        }
    }

}
