using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using School.Classes;
using SchoolServer.Dto;

namespace SchoolServer.Controllers;

/// <summary>
/// Оценки
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class GradeController : ControllerBase
{
    private readonly SchoolDbContext _context;

    private readonly IMapper _mapper;

    /// <summary>
    /// Конструктор класса GradeController
    /// </summary>
    /// <param name="context"></param>
    /// <param name="mapper"></param>
    public GradeController(SchoolDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    /// <summary>
    /// Получение всех оценок
    /// </summary>
    /// <returns>Список всех оценок</returns>
    [HttpGet(Name = "GetGrades")]
    public async Task<ActionResult<IEnumerable<GradeGetDto>>> GetGrades()
    {
        if (_context.Grades == null)
        {
            return NotFound();
        }
        return await _mapper.ProjectTo<GradeGetDto>(_context.Grades).ToListAsync();
    }

    /// <summary>
    /// Получение оценки по id
    /// </summary>
    /// <param name="id">Идентификатор оценки</param>
    /// <returns>Оценка</returns>
    [HttpGet("{id}", Name = "GetGrade")]
    public async Task<ActionResult<GradeGetDto>> GetGrade(int id)
    {
        if (_context.Grades == null)
        {
            return NotFound();
        }
        var grade = await _context.Grades.FindAsync(id);

        if (grade == null)
        {
            return NotFound();
        }

        return _mapper.Map<GradeGetDto>(grade);
    }

    /// <summary>
    /// Изменение данных об оценке
    /// </summary>
    /// <param name="id">Идентификатор класса</param>
    /// <param name="grade">Изменяемая оценка</param>
    /// <returns>Результат выполнения операции</returns>
    [HttpPut("{id}", Name = "PutGrade")]
    public async Task<IActionResult> PutGrade(int id, GradePostDto grade)
    {
        if (_context.Grades == null)
        {
            return NotFound();
        }

        var gradeToModify = await _context.Grades.FindAsync(id);
        if (gradeToModify == null)
        {
            return NotFound();
        }

        _mapper.Map(grade, gradeToModify);

        await _context.SaveChangesAsync();

        return Ok();
    }

    /// <summary>
    /// Добавление новой оценки
    /// </summary>
    /// <param name="grade">оценка</param>
    /// <returns>Созданная оценка</returns>
    [HttpPost(Name = "PostGrade")]
    public async Task<ActionResult<int>> PostGrade(GradePostDto grade)
    {
        if (_context.Grades == null)
        {
            return Problem("Entity set 'DiaryDomainDbContext.Grades'  is null.");
        }
        var mappedGrade = _mapper.Map<Grade>(grade);

        _context.Grades.Add(mappedGrade);
        await _context.SaveChangesAsync();

        return Ok(mappedGrade.Id);
    }

    /// <summary>
    /// Удаление оценки
    /// </summary>
    /// <param name="id">Идентификатор удаляемой оценки</param>
    /// <returns>Результат выполнения операции</returns>
    [HttpDelete("{id}", Name = "DeleteGrade")]
    public async Task<IActionResult> DeleteGrade(int id)
    {
        if (_context.Grades == null)
        {
            return NotFound();
        }
        var grade = await _context.Grades.FindAsync(id);
        if (grade == null)
        {
            return NotFound();
        }

        _context.Grades.Remove(grade);
        await _context.SaveChangesAsync();

        return Ok();
    }
}
