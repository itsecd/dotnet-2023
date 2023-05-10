using AutoMapper;
using SchoolServer.Dto;
using SchoolServer.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using School.Classes;

namespace SchoolServer.Controllers;

/// <summary>
/// Классы
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class ClassController : ControllerBase
{
    private readonly SchoolDbContext _context;

    private readonly IMapper _mapper;

    /// <summary>
    /// Конструктор ClassController
    /// </summary>
    /// <param name="context"></param>
    /// <param name="mapper"></param>
    public ClassController(SchoolDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    /// <summary>
    /// Получение всех классов
    /// </summary>
    /// <returns>Список всех классов</returns>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ClassGetDto>>> GetClasses()
    {
        if (_context.Classes == null)
        {
            return NotFound();
        }
        return await _mapper.ProjectTo<ClassGetDto>(_context.Classes).ToListAsync();
    }

    /// <summary>
    /// Получение класса по id
    /// </summary>
    /// <param name="id">Идентификатор класса</param>
    /// <returns>Класс</returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<ClassGetDto>> GetClass(int id)
    {
        if (_context.Classes == null)
        {
            return NotFound();
        }
        var @class = await _context.Classes.FindAsync(id);

        if (@class == null)
        {
            return NotFound();
        }

        return _mapper.Map<ClassGetDto>(@class);
    }
    /// <summary>
    /// Изменение данных о классе
    /// </summary>
    /// <param name="id">Идентификатор класса</param>
    /// <param name="class">Изменяемый класс</param>
    /// <returns>Результат выполнения операции</returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> PutClass(int id, ClassPostDto @class)
    {
        if (_context.Classes == null)
        {
            return NotFound();
        }

        var classToModify = await _context.Classes.FindAsync(id);
        if (classToModify == null)
        {
            return NotFound();
        }

        _mapper.Map(@class, classToModify);

        await _context.SaveChangesAsync();

        return NoContent();
    }

    /// <summary>
    /// Добавление нового класса
    /// </summary>
    /// <param name="class">класс</param>
    /// <returns>Созданный класс</returns>
    [HttpPost]
    public async Task<ActionResult<ClassGetDto>> PostClass(ClassPostDto @class)
    {
        if (_context.Classes == null)
        {
            return Problem("Entity set 'SchoolDbContext.Class'  is null.");
        }
        var mappedClass = _mapper.Map<Class>(@class);

        _context.Classes.Add(mappedClass);
        await _context.SaveChangesAsync();

        return CreatedAtAction("PostClass", new { id = mappedClass.Id }, _mapper.Map<ClassGetDto>(mappedClass));
    }

    /// <summary>
    /// Удаление класса
    /// </summary>
    /// <param name="id">Идентификатор удаляемого класса</param>
    /// <returns>Результат выполнения операции</returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteClass(int id)
    {
        if (_context.Classes == null)
        {
            return NotFound();
        }
        var @class = await _context.Classes.FindAsync(id);
        if (@class == null)
        {
            return NotFound();
        }

        _context.Classes.Remove(@class);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}

