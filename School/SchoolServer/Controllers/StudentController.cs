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
    ///  Метод получения данных всей коллекции для студентов
    /// </summary>
    /// <returns>Коллекция студентов</returns>
    [HttpGet]
    public IEnumerable<StudentGetDto> Get()
    {
        return _diaryRepository.Students.Select(student => _mapper.Map<StudentGetDto>(student));
    }

    /// <summary>
    /// Метод получения студента по id
    /// </summary>
    /// <param name="id">id студента</param>
    /// <returns>Студент по id</returns>
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
    /// Метод добавления студента с помощью json
    /// </summary>
    /// <param name="student">параметр добавления</param>
    [HttpPost]
    public void Post([FromBody] StudentGetDto student)
    {
        _diaryRepository.Students.Add(_mapper.Map<Student>(student));
    }

    /// <summary>
    /// Метод обновления студента по id 
    /// </summary>
    /// <param name="id">id студента</param>
    /// <param name="student">Объект класса Student</param>
    /// <returns>Обновленное значение по id</returns>
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
    /// Метод удаления студента по id
    /// </summary>
    /// <param name="id">id студента</param>
    /// <returns>Успех или ошибка удаления</returns>
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
