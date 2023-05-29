using AutoMapper;
using Department.Domain;
using Department.Server.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Department.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CoursesController : ControllerBase
{
    private readonly DepartmentDbContext _context;

    private readonly IMapper _mapper;

    private readonly ILogger<CoursesController> _logger;

    public CoursesController(DepartmentDbContext context, IMapper mapper, ILogger<CoursesController> logger)
    {
        _context = context;
        _mapper = mapper;
        _logger = logger;
    }

    /// <summary>
    /// View all courses
    /// </summary>
    /// <returns>Courses list</returns>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<CourseGetDto>>> GetCourses()
    {
        _logger.LogInformation("Get courses list");
        return await _mapper.ProjectTo<CourseGetDto>(_context.Courses).ToListAsync();
    }

    /// <summary>
    /// View course by id
    /// </summary>
    /// <param name="id">Course id</param>
    /// <returns>Course</returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<CourseGetDto>> GetCourse(int id)
    {
        _logger.LogInformation("Get the course by id");

        var course = await _context.Courses.FindAsync(id);

        if (course == null)
        {
            _logger.LogInformation("Course not found");
            return NotFound();
        }

        return _mapper.Map<CourseGetDto>(course);
    }

    /// <summary>
    /// Change course info
    /// </summary>
    /// <param name="id">Course id</param>
    /// <param name="course">Changing course</param>
    /// <returns>Action result</returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> PutCourse(int id, CourseSetDto course)
    {
        var courseToModify = await _context.Courses.FindAsync(id);
        if (courseToModify == null)
        {
            _logger.LogInformation("Course not found");
            return NotFound();
        }

        _mapper.Map(course, courseToModify);

        _logger.LogInformation("Successfully updated");

        await _context.SaveChangesAsync();

        return NoContent();
    }

    /// <summary>
    /// Adding new course
    /// </summary>
    /// <param name="course">Course</param>
    /// <returns>Added course</returns>
    [HttpPost]
    [ProducesResponseType(201)]
    public async Task<ActionResult<CourseGetDto>> PostCourse(CourseSetDto course)
    {
        var mappedCourse = _mapper.Map<Course>(course);

        _context.Courses.Add(mappedCourse);

        _logger.LogInformation("Successfully added");

        await _context.SaveChangesAsync();

        return CreatedAtAction("PostCourse", new { id = mappedCourse.Id }, _mapper.Map<CourseGetDto>(mappedCourse));
    }

    /// <summary>
    /// Deleting a course
    /// </summary>
    /// <param name="id">Deleted course id</param>
    /// <returns>Action result</returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCourse(int id)
    {
        var course = await _context.Courses.FindAsync(id);
        if (course == null)
        {
            _logger.LogInformation("Course not found");
            return NotFound();
        }

        _context.Courses.Remove(course);

        _logger.LogInformation("Successfully deleted");

        await _context.SaveChangesAsync();

        return NoContent();
    }
}
