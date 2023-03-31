using AutoMapper;
using LibrarySchool;
using LibrarySchoolServer.Dto;
using Microsoft.AspNetCore.Mvc;

namespace LibrarySchoolServer.Controllers.Querry;
/// <summary>
/// Controller define method querry in variant
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class QueryController : Controller
{

    private readonly ILogger<QueryController> _logger;
    private readonly ILibrarySchoolRepository _librarySchoolRepository;
    private readonly IMapper _mapper;

    /// <summary>
    /// Constructor class StudentController
    /// </summary>
    /// <param name="logger"></param>
    /// <param name="librarySchoolRepository"></param>
    /// <param name="mapper"></param>
    public QueryController(ILogger<QueryController> logger, ILibrarySchoolRepository librarySchoolRepository, IMapper mapper)
    {
        _logger = logger;
        _mapper = mapper;
        _librarySchoolRepository = librarySchoolRepository;
    }
    /// <summary>
    /// Display information about all students in the specified class, sort by full name.
    /// </summary>
    /// <returns>
    /// Return: list student
    /// </returns>
    [HttpGet("StudentInClass/{idClass}")]
    public ActionResult<IEnumerable<StudentGetDto>> GetListStudent(int idClass)
    {
        _logger.LogInformation("Get list student");
        var foundClass = _librarySchoolRepository.ClassTypes.FirstOrDefault(classType => classType.ClassId == idClass);
        if (foundClass == null)
        {
            _logger.LogInformation("Not found class {id}", idClass);
            return NotFound();
        }
        var listStudent = foundClass!.Students.OrderBy(student => student.StudentName).ToList();
        return Ok(listStudent!.Select(x => _mapper.Map<StudentGetDto>(x)));
    }


    /// <summary>
    /// Display information about all students who received grades on the specified day.
    /// </summary>
    /// <returns>
    /// Return: list student
    /// </returns>
    [HttpGet("ListStudentInDay/{day}")]
    public ActionResult<IEnumerable<Student>> GetListStudent(DateTime day)
    {
        var listStudent = _librarySchoolRepository.Students
                            .Select(student =>
                            new Student
                            {
                                ClassId = student.ClassId,
                                StudentId = student.StudentId,
                                StudentName = student.StudentName,
                                DateOfBirth = student.DateOfBirth,
                                Passport = student.Passport,
                                Marks = student.Marks.Where(mark => mark.TimeReceive.Date == day.Date).ToList()
                            }).ToList()
                            .Where(student => student.Marks.Count > 0);

        if (listStudent != null)
        {
            return Ok(listStudent);
        }
        return NotFound();
    }

    /// <summary>
    /// Display information about all subjects
    /// </summary>
    /// <returns>
    /// Return: list subject
    /// </returns>
    [HttpGet("InformationAllsubject")]
    public IEnumerable<Subject> GetListSubject()
    {
        _logger.LogInformation("Get list subject");
        return _librarySchoolRepository.Subjects;
    }

    /// <summary>
    /// Display information about the maximum, minimum, average mark for subject by Id 
    /// </summary>
    /// <param name="idSubject"></param>
    /// <returns></returns>
    [HttpGet("CountMaxMinAverage/{idSubject}")]
    public ActionResult<IEnumerable<MaxMinAverageMarkDto>> Get(int idSubject)
    {
        var foundSubject = _librarySchoolRepository.Marks.Where(mark => mark.SubjectId == idSubject);
        if (!foundSubject.Any())
        {
            _logger.LogInformation("Not found subject {id}", idSubject);
            return NotFound();
        }
        var markInSubject = foundSubject.Select(mark => mark.MarkValue);
        if (!markInSubject.Any())
        {
            return Ok(new MaxMinAverageMarkDto { Max = 0, Min = 0, Average = 0 });
        }
        return Ok(new MaxMinAverageMarkDto
        {
            Max = markInSubject.Max(),
            Min = markInSubject.Min(),
            Average = markInSubject.Average()
        });
    }
    /// <summary>
    /// Display the top 5 students by GPA in period
    /// </summary>
    /// <returns>
    /// Return: list student
    /// </returns>
    [HttpGet("Top5InPeriod")]
    public ActionResult<IEnumerable<StudentGetAverageDto>> GetListStudent([FromQuery]DateTime beginPeriod, [FromQuery]DateTime endPeriod)
    {
        var listStudentInPeriod = _librarySchoolRepository.Students
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
            return NotFound();
        }
        var topInPeriod = listStudentInPeriod.Select(student =>
                                      new StudentGetAverageDto
                                      {
                                          ClassId = student.ClassId,
                                          StudentId = student.StudentId,
                                          StudentName = student.StudentName,
                                          DateOfBirth = student.DateOfBirth,
                                          Passport = student.Passport,
                                          AverageMark = _librarySchoolRepository.AverageMark(student)
                                      });
        if (!topInPeriod.Any()) { return NotFound(); }
        return Ok(topInPeriod.OrderByDescending(x=> x.AverageMark).Take(5));
    }
    /// <summary>
    /// Display the top 5 students by GPA.
    /// </summary>
    /// <returns>
    /// Return: list student
    /// </returns>
    [HttpGet("ListTop5Student")]
    public ActionResult<IEnumerable<StudentGetAverageDto>> GetListStudent()
    {
        var listStudent = _librarySchoolRepository.Students
                            .Select(student =>
                            new StudentGetAverageDto
                            {
                                ClassId = student.ClassId,
                                StudentId = student.StudentId,
                                StudentName = student.StudentName,
                                DateOfBirth = student.DateOfBirth,
                                Passport = student.Passport,
                                AverageMark = _librarySchoolRepository.AverageMark(student)
                            })
                            .OrderByDescending(student => student.AverageMark).ToList()
                            .Take(5);
        if (listStudent != null)
        {
            return Ok(listStudent);
        }
        return NotFound();
    }
}
