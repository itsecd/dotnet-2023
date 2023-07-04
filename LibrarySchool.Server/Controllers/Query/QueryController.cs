using AutoMapper;
using LibrarySchool;
using LibrarySchool.Domain;
using LibrarySchool.Server.Dto;
using LibrarySchool.Server.Exceptions;
using LibrarySchoolServer.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibrarySchoolServer.Controllers.Querry;
/// <summary>
/// Controller define method querry in variant
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class QueryController : Controller
{

    private readonly ILogger<QueryController> _logger;
    private readonly IDbContextFactory<LibrarySchoolContext> _dbContextFactory;
    private readonly IMapper _mapper;

    /// <summary>
    /// Contructor for controller querry
    /// </summary>
    /// <param name="logger"></param>
    /// <param name="dbContextFactory"></param>
    /// <param name="mapper"></param>
    public QueryController(ILogger<QueryController> logger, IDbContextFactory<LibrarySchoolContext> dbContextFactory, IMapper mapper)
    {
        _logger = logger;
        _mapper = mapper;
        _dbContextFactory = dbContextFactory;
    }
    /// <summary>
    /// Display information about all students in the specified class, sort by full name.
    /// </summary>
    /// <returns>
    /// Return: list student
    /// </returns>
    [HttpGet("StudentInClass/{classId}")]
    public async Task<ActionResult<IEnumerable<StudentGetDto>>> GetListStudentInClass(int classId)
    {
        _logger.LogInformation("Get list student by id class");
        var ctx = await _dbContextFactory.CreateDbContextAsync();
        var foundClassType = await ctx.ClassTypes.Include(classType => classType.Students)
                                           .FirstOrDefaultAsync(classType => classType.ClassId == classId);
        if (foundClassType == null)
            throw new NotFoundException($"Not found class {classId}");
        return Ok(_mapper.Map<IEnumerable<StudentGetDto>>(foundClassType.Students.OrderBy(student => student.StudentName)));
    }

    /// <summary>
    /// Display information about all subjects
    /// </summary>
    /// <returns>
    /// Return: list subject
    /// </returns>
    [HttpGet("InformationAllsubject")]
    public async Task<IEnumerable<SubjectGetDto>> GetListSubject()
    {
        _logger.LogInformation("Get list subject");
        var ctx = await _dbContextFactory.CreateDbContextAsync();
        return _mapper.Map<List<SubjectGetDto>>(ctx.Subjects);
    }

    /// <summary>
    /// Display information about the maximum, minimum, average mark for subject by Id 
    /// </summary>
    /// <param name="idSubject"></param>
    /// <returns></returns>
    [HttpGet("CountMaxMinAverage/{idSubject}")]
    public async Task<ActionResult<MaxMinAverageMarkDto>> Get(int idSubject)
    {
        _logger.LogInformation("Display information about the maximum, minimum, average mark by Id");
        var ctx = await _dbContextFactory.CreateDbContextAsync();
        var foundSubject = await ctx.Subjects.Include(subject => subject.Marks)
                                             .FirstOrDefaultAsync(subject => subject.SubjectId == idSubject);
        if (foundSubject == null)
        {
            _logger.LogInformation("Not found subject id: {id}", idSubject);
            throw new NotFoundException($"Not found subject id: {idSubject}");
        }
        var markInSubject = foundSubject.Marks.Select(mark => mark.MarkValue);
        if (!markInSubject.Any())
        {
            return Ok(new MaxMinAverageMarkDto(0, 0, 0));
        }
        return Ok(new MaxMinAverageMarkDto(markInSubject.Max(), markInSubject.Min(), markInSubject.Average()));
    }
    /// <summary>
    /// Display the top 5 students by GPA in period
    /// </summary>
    /// <returns>
    /// Return: list student
    /// </returns>
    [HttpGet("Top5InPeriod")]
    public async Task<ActionResult<IEnumerable<StudentGetAverageDto>>> GetListStudent([FromQuery] DateTime beginPeriod, [FromQuery] DateTime endPeriod)
    {
        _logger.LogInformation("Get top 5 students by GPA in period");
        var ctx = await _dbContextFactory.CreateDbContextAsync();
        var listStudentInPeriod = ctx.Students
                            .Select(student =>
                            new Student
                            {
                                ClassId = student.ClassId,
                                StudentId = student.StudentId,
                                StudentName = student.StudentName,
                                DateOfBirth = student.DateOfBirth,
                                Passport = student.Passport,
                                Marks = student.Marks.Where(mark => (mark.TimeReceive > beginPeriod) && (mark.TimeReceive < endPeriod)).ToList()
                            }).ToList();

        if (!listStudentInPeriod.Any())
        {
            throw new NotFoundException("List student empty");
        }
        var topInPeriod = listStudentInPeriod.Select(student =>
                                      new StudentGetAverageDto
                                      (
                                          student.StudentId,
                                          student.Passport,
                                          student.StudentName,
                                          student.DateOfBirth,
                                          student.ClassId,
                                          student.Marks.Any()? student.Marks.Average(mark => mark.MarkValue): 0
                                      ));
        if (!topInPeriod.Any()) 
        { throw new NotFoundException("List student empty"); }
        return Ok(topInPeriod.OrderByDescending(x => x.AverageMark).Take(5));
    }
    /// <summary>
    /// Display the top 5 students by GPA.
    /// </summary>
    /// <returns>
    /// Return: list student
    /// </returns>
    [HttpGet("ListTop5Student")]
    public async Task<ActionResult<IEnumerable<StudentGetAverageDto>>> GetListStudent()
    {
        _logger.LogInformation("Display information about the maximum, minimum, average mark by Id");
        var ctx = await _dbContextFactory.CreateDbContextAsync();
        var listStudent = ctx.Students
                            .Include(student => student.Marks)
                            .Select(student =>
                                    new StudentGetAverageDto
                                      (
                                          student.StudentId,
                                          student.Passport,
                                          student.StudentName,
                                          student.DateOfBirth,
                                          student.ClassId,
                                          student.Marks.Any() ? student.Marks.Average(mark => mark.MarkValue) : 0
                                      ))
                            .ToList()
                            .OrderByDescending(student => student.AverageMark)
                            .Take(5);

        if (listStudent != null)
        {
            return Ok(listStudent);
        }
        throw new NotFoundException("List student empty");
    }

    /// <summary>
    /// Display information about all students who received grades on the specified day.
    /// </summary>
    /// <returns>
    /// Return: list student
    /// </returns>
    [HttpGet("ListStudentInDay/{day}")]
    public async Task<ActionResult<IEnumerable<StudentGetInDayDto>>> GetListStudent(DateTime day)
    {
        _logger.LogInformation("Get list student by time receive mark");
        var ctx = await _dbContextFactory.CreateDbContextAsync();
        
        var studentReceiveInDay = ctx.Marks.Include(mark => mark.Student)
                                           .Include(mark => mark.Subject)
                                           .Where(mark => mark.TimeReceive == day)
                                           .Select(mark =>
                                            new StudentGetInDayDto
                                            (
                                                mark.StudentId,
                                                mark.Student.StudentName,
                                                mark.SubjectId,
                                                mark.Subject.SubjectName,
                                                mark.MarkValue
                                            ))
                                           .ToList();;
        return Ok(studentReceiveInDay);
    }

}
