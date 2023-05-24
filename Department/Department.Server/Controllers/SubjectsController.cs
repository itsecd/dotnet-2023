using AutoMapper;
using Department.Domain;
using Department.Server.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Department.Server.Controllers;

/// <summary>
/// Subjects
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class SubjectsController : ControllerBase
{
    private readonly DepartmentDbContext _context;

    private readonly IMapper _mapper;

    private readonly ILogger<SubjectsController> _logger;

    public SubjectsController(DepartmentDbContext context, IMapper mapper, ILogger<SubjectsController> logger)
    {
        _context = context;
        _mapper = mapper;
        _logger = logger;
    }

    /// <summary>
    /// View all subjects
    /// </summary>
    /// <returns>Subjects list</returns>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<SubjectGetDto>>> GetSubjects()
    {
      if (_context.Subjects == null)
      {
          return NotFound();
      }
        _logger.LogInformation("Get subjects list");
        return await _mapper.ProjectTo<SubjectGetDto>(_context.Subjects).ToListAsync();
    }

    /// <summary>
    /// View subject by id
    /// </summary>
    /// <param name="id">Subject id</param>
    /// <returns>Subject</returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<SubjectGetDto>> GetSubject(int id)
    {
        _logger.LogInformation("Get the subject by id");
        if (_context.Subjects == null)
        {
          return NotFound();
        }
        var subject = await _context.Subjects.FindAsync(id);

        if (subject == null)
        {
            _logger.LogInformation("Subject not found");
            return NotFound();
        }

        return _mapper.Map<SubjectGetDto>(subject); ;
    }

    /// <summary>
    /// Change subject info
    /// </summary>
    /// <param name="id">Subject id</param>
    /// <param name="bike">Changing subject</param>
    /// <returns>Action result</returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> PutSubject(int id, SubjectSetDto subject)
    {
        if (_context.Subjects == null)
        {
            return NotFound();
        }

        var subjectToModify = await _context.Subjects.FindAsync(id);
        if (subjectToModify == null)
        {
            _logger.LogInformation("Bike not found");
            return NotFound();
        }

        _mapper.Map(subject, subjectToModify);

        _logger.LogInformation("Successfully updated");

        await _context.SaveChangesAsync();

        return NoContent();
    }

    /// <summary>
    /// Adding new subject
    /// </summary>
    /// <param name="subject">Subject</param>
    /// <returns>Added subject</returns>
    [HttpPost]
    [ProducesResponseType(201)]
    public async Task<ActionResult<SubjectGetDto>> PostSubject(SubjectSetDto subject)
    {
      if (_context.Subjects == null)
      {
          return Problem("Entity set 'DepartmentDbContext.Subjects'  is null.");
      }
        var mappedSubject = _mapper.Map<Subject>(subject);

        _context.Subjects.Add(mappedSubject);

        _logger.LogInformation("Successfully added");

        await _context.SaveChangesAsync();

        return CreatedAtAction("PostSubject", new { id = mappedSubject.Id }, _mapper.Map<SubjectGetDto>(mappedSubject));
    }

    /// <summary>
    /// Deleting a subject
    /// </summary>
    /// <param name="id">Deleted subject id</param>
    /// <returns>Action result</returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteSubject(int id)
    {
        if (_context.Subjects == null)
        {
            return NotFound();
        }
        var subject = await _context.Subjects.FindAsync(id);
        if (subject == null)
        {
            _logger.LogInformation("Subject not found");
            return NotFound();
        }

        _context.Subjects.Remove(subject);

        _logger.LogInformation("Successfully deleted");

        await _context.SaveChangesAsync();

        return NoContent();
    }
}
