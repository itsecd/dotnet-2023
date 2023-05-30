using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using School.Classes;
using SchoolServer.Dto;

namespace SchoolServer.Controllers;

/// <summary>
/// Контроллер "предмета"
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class SubjectController : ControllerBase
{
    private readonly SchoolDbContext _context;

    private readonly IMapper _mapper;

    /// <summary>
    /// Конструктор SubjectController
    /// </summary>
    /// <param name="context"></param>
    /// <param name="mapper"></param>
    public SubjectController(SchoolDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    /// <summary>
    /// Получение всех предметов
    /// </summary>
    /// <returns>Список всех предметов</returns>
    [HttpGet(Name = "GetSubjects")]
    public async Task<ActionResult<IEnumerable<SubjectGetDto>>> GetSubjects()
    {
        if (_context.Subjects == null)
        {
            return NotFound();
        }
        return await _mapper.ProjectTo<SubjectGetDto>(_context.Subjects).ToListAsync();
    }

    /// <summary>
    /// Получение предмета по id
    /// </summary>
    /// <param name="id">Идентификатор предмета</param>
    /// <returns>Школьный предмет</returns>
    [HttpGet("{id}", Name = "GetSubject")]
    public async Task<ActionResult<SubjectGetDto>> GetSubject(int id)
    {
        if (_context.Subjects == null)
        {
            return NotFound();
        }
        var subject = await _context.Subjects.FindAsync(id);

        if (subject == null)
        {
            return NotFound();
        }

        return _mapper.Map<SubjectGetDto>(subject);
    }

    /// <summary>
    /// Изменение данных о школьном предмете
    /// </summary>
    /// <param name="id">Идентификатор предмета</param>
    /// <param name="subject">Изменяемый предмет</param>
    /// <returns>Результат выполнения операции</returns>
    [HttpPut("{id}", Name = "PutSubject")]
    public async Task<IActionResult> PutSubject(int id, SubjectPostDto subject)
    {
        if (_context.Subjects == null)
        {
            return NotFound();
        }

        var subjectToModify = await _context.Subjects.FindAsync(id);
        if (subjectToModify == null)
        {
            return NotFound();
        }

        _mapper.Map(subject, subjectToModify);

        await _context.SaveChangesAsync();

        return Ok();
    }

    /// <summary>
    /// Добавление нового предмета
    /// </summary>
    /// <param name="subject">предмет</param>
    /// <returns>Созданный предмет</returns>
    [HttpPost(Name = "PostSubject")]
    public async Task<ActionResult<int>> PostSubject(SubjectPostDto subject)
    {
        if (_context.Subjects == null)
        {
            return Problem("Entity set 'DiaryDomainDbContext.Subjects'  is null.");
        }
        var mappedSubject = _mapper.Map<Subject>(subject);

        _context.Subjects.Add(mappedSubject);
        await _context.SaveChangesAsync();

        return Ok(mappedSubject.Id);
    }

    /// <summary>
    /// Удаление предмета
    /// </summary>
    /// <param name="id">Идентификатор удаляемого предмета</param>
    /// <returns>Результат выполнения операции</returns>
    [HttpDelete("{id}", Name = "DeleteSubject")]
    public async Task<IActionResult> DeleteSubject(int id)
    {
        if (_context.Subjects == null)
        {
            return NotFound();
        }
        var subject = await _context.Subjects.FindAsync(id);
        if (subject == null)
        {
            return NotFound();
        }

        _context.Subjects.Remove(subject);
        await _context.SaveChangesAsync();

        return Ok();
    }
}
