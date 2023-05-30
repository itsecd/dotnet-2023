using AutoMapper;
using SchoolServer.Dto;
using Microsoft.AspNetCore.Mvc;
using School.Classes;
using Microsoft.EntityFrameworkCore;

namespace SchoolServer.Controllers;

/// <summary>
/// Задания по варианту
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class RequestsController : ControllerBase
{
    private readonly SchoolDbContext _context;

    private readonly IMapper _mapper;

    /// <summary>
    /// Конструктор класса RequestController
    /// </summary>
    /// <param name="context"></param>
    /// <param name="mapper"></param>
    public RequestsController(SchoolDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }


    /// <summary>
    /// Выведите информацию обо всех элементах. Проверьте количество элементов
    /// </summary>
    /// <returns>Список предметов</returns>
    [HttpGet("GetAllSubject", Name = "GetAllSubjects")]
    public async Task<ActionResult<IEnumerable<SubjectGetDto>>> GetAllSubject()
    {
        if (_context.Subjects == null)
        {
            return NotFound();
        }
        return await _mapper.ProjectTo<SubjectGetDto>(_context.Subjects).ToListAsync();
    }

    /// <summary>
    /// Отобразить информацию обо всех учащихся в указанном классе, отсортировать по имени.
    /// </summary>
    /// <param name="classId">Идентификатор класса</param>
    /// <returns></returns>
    [HttpGet("GetAllStudentByClassId/{classId}", Name = "GetAllStudentByClassId")]
    public async Task<ActionResult<IEnumerable<StudentGetDto>>> GetAllStudentByClassId(int classId)
    {
        if (_context.Students == null)
        {
            return NotFound();
        }
        var allStudents = await _context.Students.ToListAsync();

        var needStudents = (from student in allStudents
                            where student.ClassId.Equals(classId)
                            orderby student.LastName, student.FirstName, student.Patronymic
                            select student).ToList();

        var needStudentsDto = needStudents.Select(_mapper.Map<Student, StudentGetDto>);

        return Ok(needStudentsDto);

    }


    /// <summary>
    /// Выведите информацию обо всех учащихся, получивших оценки в указанный день.
    /// </summary>
    /// <param name="date">День выставления оценки</param>
    /// <returns>Список студентов</returns>
    [HttpGet("StudentsGetsGradesByDay/{date:DateTime}", Name = "StudentsGetsGradesByDay")]
    public async Task<ActionResult<IEnumerable<StudentGetDto>>> StudentsGetsGradesByDay(DateTime date)
    {
        if (_context.Grades == null || _context.Students == null)
        {
            return NotFound();
        }
        var allGrades = await _context.Grades.ToListAsync();

        var infoStudent = (from grade in allGrades
                           where grade.Date == date
                           select grade.StudentId).ToList();
        var allStudents = await _context.Students.ToListAsync();

        var needStudents = allStudents.Where(x => infoStudent.Contains(x.Id)).ToList().Select(_mapper.Map<Student, StudentGetDto>);

        return Ok(needStudents);
    }


    /// <summary>
    /// Выделите 5 лучших студентов по среднему баллу
    /// </summary>
    /// <returns>Результат операции</returns>
    [HttpGet("Top5StudentsAvrMark", Name = "Top5StudentsAvrMark")]
    public async Task<ActionResult<IEnumerable<StudentGetDto>>> Top5StudentsAvrMark()
    {
        if (_context.Grades == null || _context.Students == null)
        {
            return NotFound();
        }
        var allGrades = await _context.Grades.ToListAsync();


        var topFive = (from grade in allGrades
                       group grade by grade.StudentId into g
                       select new
                       {
                           StudentId = g.Key,
                           Marks = g.Average(s => s.Mark)
                       }).OrderByDescending(s => s.Marks).Take(5).ToList();

        var allStudents = await _context.Students.ToListAsync();

        var needStudents = allStudents.IntersectBy(topFive.Select(x => x.StudentId), o => o.Id).ToList().Select(_mapper.Map<Student, StudentGetDto>); //Where(x => infoStudent.Contains(x.Id)).ToList().Select(_mapper.Map<Student, StudentGetDto>);

        return Ok(needStudents);
    }

    /// <summary>
    /// Вывод студентов с максимальным средним баллом за указанный период
    /// </summary>
    /// <returns></returns>
    [HttpGet("MaxAvrGradeStudentsByPeriod", Name = "MaxAvrGradeStudentsByPeriod")]
    public async Task<ActionResult<IEnumerable<StudentGetDto>>> MaxAvrGradeStudentsByPeriod(DateTime first, DateTime second)
    {
        if (first > second)
        {
            return StatusCode(412);
        }

        if (_context.Grades == null || _context.Students == null)
        {
            return NotFound();
        }
        var allGrades = await _context.Grades.ToListAsync();

        var averageMarks =
            (from grade in allGrades
             where grade.Date >= first && grade.Date <= second
             group grade by grade.StudentId into g
             select new
             {
                 StudentId = g.Key,
                 Marks = g.Average(s => s.Mark)
             }).ToList();

        if (averageMarks.Count == 0)
            return NotFound();

        var maxMark = averageMarks.Max(x => x.Marks);
        var studentsId = averageMarks.Where(x => x.Marks.Equals(maxMark)).Select(s => s.StudentId);

        var allStudents = await _context.Students.ToListAsync();

        var needStudents = allStudents.Where(x => studentsId.Contains(x.Id)).ToList().Select(_mapper.Map<Student, StudentGetDto>);

        return Ok(needStudents);
    }


    /// <summary>
    /// Выведите информацию о минимальном, среднем и максимальном балле по каждому предмету
    /// </summary>
    /// <returns></returns>
    [HttpGet("StatisticSubjects", Name = "MinMaxAvrGradeBySubject")]
    public async Task<dynamic> MinMaxAvrGradeBySubject()
    {
        if (_context.Grades == null)
        {
            return NotFound();
        }
        var allGrades = await _context.Grades.ToListAsync();

        return (from grade in allGrades
                group grade by grade.SubjectId into g
                select new
                {
                    Id = g.Select(x => x.SubjectId).FirstOrDefault(),
                    Min = g.Min(s => s.Mark),
                    Max = g.Max(s => s.Mark),
                    Average = g.Average(s => s.Mark)
                });
    }
}

