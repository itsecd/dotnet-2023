using AutoMapper;
using Department.Domain;
using Department.Server.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Department.Server.Controllers;

/// <summary>
/// Teachers
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class TeachersController : ControllerBase
{
    private readonly DepartmentDbContext _context;

    private readonly IMapper _mapper;

    private readonly ILogger<TeachersController> _logger;

    public TeachersController(DepartmentDbContext context, IMapper mapper, ILogger<TeachersController> logger)
    {
        _context = context;
        _mapper = mapper;
        _logger = logger;
    }

    /// <summary>
    /// View all teachers
    /// </summary>
    /// <returns>Teachers list</returns>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TeacherGetDto>>> GetTeachers()
    {
        if (_context.Teachers == null)
        {
            return NotFound();
        }
        _logger.LogInformation("Get teachers list");
        return await _mapper.ProjectTo<TeacherGetDto>(_context.Teachers).ToListAsync();
    }

    /// <summary>
    /// View teacher by id
    /// </summary>
    /// <param name="id">Teacher id</param>
    /// <returns>Teacher</returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<TeacherGetDto>> GetTeacher(int id)
    {
        _logger.LogInformation("Get teacher by id");
        if (_context.Teachers == null)
        {
            return NotFound();
        }
        var teacher = await _context.Teachers.FindAsync(id);

        if (teacher == null)
        {
            _logger.LogInformation("Teacher not found");
            return NotFound();
        }

        return _mapper.Map<TeacherGetDto>(teacher);
    }

    /// <summary>
    /// Change teacher info
    /// </summary>
    /// <param name="id">Teacher id</param>
    /// <param name="teacher">Changing teacher</param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> PutTeacher(int id, TeacherSetDto teacher)
    {
        if (_context.Teachers == null)
        {
            return NotFound();
        }
        var teacherToModify = await _context.Teachers.FindAsync(id);
        if (teacherToModify == null)
        {
            _logger.LogInformation("Teacher not found");
            return NotFound();
        }

        _mapper.Map(teacher, teacherToModify);

        _logger.LogInformation("Successfully updated");

        await _context.SaveChangesAsync();

        return NoContent();
    }

    /// <summary>
    /// Adding new teacher
    /// </summary>
    /// <param name="teacher">Teacher</param>
    /// <returns>Added teacher</returns>
    [HttpPost]
    [ProducesResponseType(201)]
    public async Task<ActionResult<TeacherGetDto>> PostTeacher(TeacherSetDto teacher)
    {
        if (_context.Teachers == null)
        {
            return Problem("Entity set 'DepartmentDbContext.Teachers'  is null.");
        }
        var mappedTeacher = _mapper.Map<Teacher>(teacher);

        _context.Teachers.Add(mappedTeacher);

        _logger.LogInformation("Successfully added");

        await _context.SaveChangesAsync();

        return CreatedAtAction("PostTeacher", new { id = mappedTeacher.Id }, _mapper.Map<TeacherGetDto>(mappedTeacher));
    }

    /// <summary>
    /// Deleting a teacher
    /// </summary>
    /// <param name="id">Deleted teacher id</param>
    /// <returns>Action result</returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTeacher(int id)
    {
        if (_context.Teachers == null)
        {
            return NotFound();
        }
        var teacher = await _context.Teachers.FindAsync(id);
        if (teacher == null)
        {
            _logger.LogInformation("Teacher not found");
            return NotFound();
        }

        _context.Teachers.Remove(teacher);

        _logger.LogInformation("Successfully deleted");

        await _context.SaveChangesAsync();

        return NoContent();
    }
}
