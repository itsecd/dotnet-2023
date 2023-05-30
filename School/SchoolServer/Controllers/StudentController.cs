using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using School.Classes;
using SchoolServer.Dto;
using Microsoft.EntityFrameworkCore;

namespace SchoolServer.Controllers;

/// <summary>
/// Студенты
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class StudentController : ControllerBase
{
    private readonly SchoolDbContext _context;

    private readonly IMapper _mapper;

    /// <summary>
    /// Конструктор класса StudentsController
    /// </summary>
    /// <param name="context"></param>
    /// <param name="mapper"></param>
    public StudentController(SchoolDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    /// <summary>
    /// Получение всех студентов
    /// </summary>
    /// <returns>Список всех студентов</returns>
    [HttpGet(Name = "GetStudents")]
    public async Task<ActionResult<IEnumerable<StudentGetDto>>> GetStudents()
    {
        if (_context.Students == null)
        {
            return NotFound();
        }
        return await _mapper.ProjectTo<StudentGetDto>(_context.Students).ToListAsync();
    }

    /// <summary>
    /// Получение студента по id
    /// </summary>
    /// <param name="id">Идентификатор студента</param>
    /// <returns>Студент</returns>
    [HttpGet("{id}", Name = "GetStudent")]
    public async Task<ActionResult<StudentGetDto>> GetStudent(int id)
    {
        if (_context.Students == null)
        {
            return NotFound();
        }
        var student = await _context.Students.FindAsync(id);

        if (student == null)
        {
            return NotFound();
        }

        return _mapper.Map<StudentGetDto>(student);
    }

    /// <summary>
    /// Изменение данных выбранного студента
    /// </summary>
    /// <param name="id">Идентификатор студента</param>
    /// <param name="student">Студент, данные которого нужно изменить</param>
    /// <returns>Результат выполнения операции</returns>
    [HttpPut("{id}", Name = "PutStudent")]
    public async Task<IActionResult> PutStudent(int id, StudentPostDto student)
    {
        if (_context.Students == null)
        {
            return NotFound();
        }

        var studentToModify = await _context.Students.FindAsync(id);
        if (studentToModify == null)
        {
            return NotFound();
        }

        _mapper.Map(student, studentToModify);

        await _context.SaveChangesAsync();

        return Ok();
    }

    /// <summary>
    /// Добавление нового студента
    /// </summary>
    /// <param name="student">студент</param>
    /// <returns>Добавленный студент</returns>
    [HttpPost(Name = "PostStudent")]
    public async Task<ActionResult<int>> PostStudent(StudentPostDto student)
    {
        if (_context.Students == null)
        {
            return Problem("Entity set 'DiaryDomainDbContext.Students'  is null.");
        }

        var mappedStudent = _mapper.Map<Student>(student);

        _context.Students.Add(mappedStudent);
        await _context.SaveChangesAsync();

        return Ok(mappedStudent.Id);
    }

    /// <summary>
    /// Удаление студента
    /// </summary>
    /// <param name="id">Идентификатор студента </param>
    /// <returns>Результат выполнения операции</returns>
    [HttpDelete("{id}", Name = "DeleteStudent")]
    public async Task<IActionResult> DeleteStudent(int id)
    {
        if (_context.Students == null)
        {
            return NotFound();
        }
        var student = await _context.Students.FindAsync(id);
        if (student == null)
        {
            return NotFound();
        }

        _context.Students.Remove(student);
        await _context.SaveChangesAsync();

        return Ok();
    }

}
