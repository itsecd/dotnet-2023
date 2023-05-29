using Department.Domain;
using Department.Server.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Department.Server.Controllers;

/// <summary>
/// Analytics controller for requests
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class AnalyticsController : ControllerBase
{
    private readonly DepartmentDbContext _context;

    private readonly ILogger<AnalyticsController> _logger;

    public AnalyticsController(DepartmentDbContext context, ILogger<AnalyticsController> logger)
    {
        _context = context;
        _logger = logger;
    }

    /// <summary>
    /// 1st request: give info about all teachers on given course
    /// </summary>
    /// <returns> List of teachers on course </returns>
    [HttpGet("courseTeachers")]
    public async Task<ActionResult<ICollection<TeacherGetDto>>> GetCourseTeachers(string courseName)
    {
        _logger.LogInformation("Get info about teachers on course");

        var request = await
             (from teacher in _context.Teachers
              join course in _context.Courses on teacher.FullName equals course.TeachersName
              where course.SubjectName == courseName
              orderby teacher.FullName
              select teacher).ToListAsync();
        return Ok(request);
    }

    /// <summary>
    /// 2nd request: give info about all teachers whose curriculum includes a course project
    /// </summary>
    /// <returns> List of teachers </returns>
    [HttpGet("courseProjectTeachers")]
    public async Task<ActionResult<ICollection<TeacherGetDto>>> GetCourseProjectTeachers()
    {
        _logger.LogInformation("Give info about all teachers whose curriculum includes a course project");

        var request = await
            (from teacher in _context.Teachers
             join course in _context.Courses on teacher.FullName equals course.TeachersName
             where course.CourseType == "Course project"
             select teacher).ToListAsync();

        if (request.Count == 0)
        {
            _logger.LogInformation("Teachers not found");
            return NotFound();
        }
        else
        {
            return Ok(request);
        }
    }

    /// <summary>
    /// 3rd request: give info about all subjects for given group
    /// </summary>
    /// <returns>List of subjects</returns>
    [HttpGet("groupSubjects")]
    public async Task<ActionResult<ICollection<SubjectGetDto>>> GetGroupSubjects(int groupNumber)
    {
        _logger.LogInformation("Give info about all subjects for given group");

        var request = await
            (from subject in _context.Subjects
             join course in _context.Courses on subject.Name equals course.SubjectName
             where course.GroupId == groupNumber
             select subject).ToListAsync();

        if (request.Count == 0)
        {
            _logger.LogInformation("Subjects not found");
            return NotFound();
        }
        else
        {
            return Ok(request);
        }
    }

    /// <summary>
    /// 4th request: summary information about the department (amount of teachers, amount of groups, amount of students, etc.)
    /// </summary>
    /// <returns>Department info</returns>
    [HttpGet("departmentSummary")]
    public async Task<ActionResult> GetDepartmentInfo()
    {
        _logger.LogInformation("Give info about department");

        var teacherInfo = await
            (from teacher in _context.Teachers
             group teacher by teacher.Degree into teacherGroup
             select new
             {
                 type = teacherGroup.Key,
                 counter = teacherGroup.Count()
             }).ToListAsync();

        var courseInfo = await
            (from course in _context.Courses
             group course by course.CourseType into courseGroup
             select new
             {
                 type = courseGroup.Key,
                 counter = courseGroup.Count()
             }).ToListAsync();

        var listGroups = await
            (from studentGroup in _context.Groups
             select studentGroup).ToListAsync();
        var totalGroups = listGroups.Count;

        var listStudents = await
            (from studentGroup in _context.Groups
             select studentGroup.StudentAmount).ToListAsync();
        var totalStudents = listStudents.Sum();

        return Ok(new
        {
            teacherInfo,
            courseInfo,
            totalGroups,
            totalStudents
        });
    }

    /// <summary>
    /// 5th request: give info about most busy teacher
    /// </summary>
    /// <returns>Teachers info</returns>
    [HttpGet("mostBusyTeachers")]
    public async Task<ActionResult> TestMostBusy()
    {
        _logger.LogInformation("Get info about most busy teachers");

        var totalHours = await
            (from courses in _context.Courses
             orderby courses.TeachersName
             group courses by courses.TeachersName into teachersGroup
             select new
             {
                 name = teachersGroup.Key,
                 totalTime = teachersGroup.Sum(x => x.SemesterHours)
             }).ToListAsync();

        var result = (from hoursCounter in totalHours orderby hoursCounter.totalTime descending select hoursCounter).Take(3).ToList();
        return Ok(result);
    }

    /// <summary>
    /// 6th request: give info about subjects taught by different teachers
    /// </summary>
    /// <returns>List of subjects</returns>
    [HttpGet("differentTeacherSubjects")]
    public async Task<ActionResult> GetTimeValues()
    {
        _logger.LogInformation("Get info about subjects taught by different teachers");

        var teachersCounter = await
            (from courses in _context.Courses
             group courses.TeachersName by courses.SubjectName into courseGroup
             select new
             {
                 subjectName = courseGroup.Key,
                 teachers = courseGroup.Distinct().Count()
             }).ToListAsync();

        var resultSubjects = new List<string>();
        foreach (var subject in teachersCounter)
        {
            if (subject.teachers > 1)
            {
                resultSubjects.Add(subject.subjectName);
            }
        }

        if (resultSubjects.Count == 0)
        {
            _logger.LogInformation("Subjects not found");
            return NotFound();
        }

        return Ok(resultSubjects);
    }
}