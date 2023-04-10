using AutoMapper;
using SchoolServer.Dto;
using SchoolServer.Repository;

using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;


namespace SchoolServer.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RequestsController : ControllerBase
{
    private readonly ILogger<GradeController> _logger;

    private readonly ISchoolRepository _diaryRepository;

    private readonly IMapper _mapper;

    public RequestsController(ILogger<GradeController> logger, ISchoolRepository diaryRepository, IMapper mapper)
    {
        _logger = logger;
        _diaryRepository = diaryRepository;
        _mapper = mapper;
    }


    /// <summary>
    /// Output information about all items. Checking for the number of items
    /// </summary>
    /// <returns></returns>
    [HttpGet("GetAllSubject")]
    public IEnumerable<GradeGetDto> GetAllSubject()
    {
        return _diaryRepository.Grades.Select(grade => _mapper.Map<GradeGetDto>(grade));
    }

    /// <summary>
    /// Display information about all students in the specified class, sort by name.
    /// </summary>
    /// <param name="ClassId">Class id</param>
    /// <returns></returns>
    [HttpGet("GetAllStudentByClassId/{ClassId}")]
    public IEnumerable<StudentGetDto> GetAllStudentByClassId(int ClassId)
    {
        var needStudents = (from student in _diaryRepository.Students
                            where student.Class != null && student.Class.Id.Equals(ClassId)
                            orderby student.LastName, student.FirstName, student.Patronymic
                            select student).ToList();
        return _mapper.Map<IEnumerable<StudentGetDto>>(needStudents);
    }

    /// <summary>
    /// Output information about all students who received grades on the specified day.
    /// </summary>
    /// <param name="date">Day of receiving grade</param>
    /// <returns></returns>
    [HttpGet("StudentsGetsGradesByDay/{date:DateTime}")]
    public IEnumerable<StudentGetDto> StudentsGetsGradesByDay(DateTime date)
    {
        var infoStudent = (from grade in _diaryRepository.Grades
                           where grade.Date == date
                           select grade.Student).ToList();
        return _mapper.Map<IEnumerable<StudentGetDto>>(infoStudent);
    }

    /// <summary>
    /// Bring out the top 5 students by average score
    /// </summary>
    /// <param name="date"></param>
    /// <returns></returns>
    [HttpGet("Top5StudentsAvrMark")]
    public IEnumerable<StudentGetDto> Top5StudentsAvrMark()
    {
        var topFive = (from grade in _diaryRepository.Grades
                       group grade by grade.Student into g
                       select new
                       {
                           Student = g.Key,
                           Marks = g.Average(s => s.Mark)
                       }).OrderByDescending(s => s.Marks).ThenBy(s => s.Student.FirstName).Take(5).ToList();

        var students = topFive.Select(x => x.Student).ToList();

        return _mapper.Map<IEnumerable<StudentGetDto>>(students);
    }

    /// <summary>
    /// Output students with the maximum average score for the specified period
    /// </summary>
    /// <returns></returns>
    [HttpGet("MaxAvrGradeStudentsByPeriod")]
    public ActionResult<IEnumerable<StudentGetDto>> MaxAvrGradeStudentsByPeriod(DateTime first, DateTime second)
    {
        if (first > second)
        {
            return StatusCode(412);
        }

        var averageMarks =
            (from grade in _diaryRepository.Grades
             where grade.Date >= first && grade.Date <= second
             group grade by grade.Student into g
             select new
             {
                 Student = g.Key,
                 Marks = g.Average(s => s.Mark)
             }).ToList();

        if (averageMarks.Count == 0)
            return NotFound();

        var maxMark = averageMarks.Max(x => x.Marks);
        var students = averageMarks.Where(x => x.Marks.Equals(maxMark)).Select(s => s.Student).ToList();

        return Ok(_mapper.Map<IEnumerable<StudentGetDto>>(students));
    }

    /// <summary>
    /// Output information about the minimum, average and maximum score for each subject
    /// </summary>
    /// <returns></returns>
    [HttpGet("StatisticSubjects")]
    public dynamic MinMaxAvrGradeBySubject()
    {
        return (from grade in _diaryRepository.Grades
                group grade by grade.Subject into g
                select new
                {
                    Min = g.Min(s => s.Mark),
                    Max = g.Max(s => s.Mark),
                    Average = g.Average(s => s.Mark)
                }).ToList();
    }
}
