using AutoMapper;
using SchoolServer.Dto;
using SchoolServer.Repository;
//using DotnetDiary.DiaryDomain;
using School.Classes;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SchoolServer.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StudentController : ControllerBase
{
    private readonly ILogger<StudentController> _logger;

    private readonly ISchoolRepository _diaryRepository;

    private readonly IMapper _mapper;

    public StudentController(ILogger<StudentController> logger, ISchoolRepository diaryRepository, IMapper mapper)
    {   
        _logger = logger;
        _diaryRepository = diaryRepository;
        _mapper = mapper;
    }

    // GET: api/<StudentController>
    [HttpGet]
    public IEnumerable<StudentGetDto> Get()
    {
        return _diaryRepository.Students.Select(student => _mapper.Map<StudentGetDto>(student));
    }

    // GET api/<StudentController>/5
    [HttpGet("{id}")]
    public ActionResult<StudentGetDto> Get(int id)
    {
        var diaryStudent = _diaryRepository.Students.FirstOrDefault(subject => subject.Id == id);
        if (diaryStudent == null)
        {
            _logger.LogInformation("Not Found class with id = {id}", id);
            return NotFound();
        }
        else
        {
            return Ok(_mapper.Map<StudentGetDto>(diaryStudent));
        }
    }

    // POST api/<StudentController>
    [HttpPost]
    public void Post([FromBody] StudentGetDto student)
    {
        _diaryRepository.Students.Add(_mapper.Map<Student>(student));
    }

    // PUT api/<StudentController>/5
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] StudentGetDto student)
    {
        var diaryStudent = _diaryRepository.Students.FirstOrDefault(stud => stud.Id == id);
        if (diaryStudent == null)
        {
            _logger.LogInformation("Not Found class with id = {id}", id);
            return NotFound();
        }
        else
        {
            _mapper.Map(student, diaryStudent);
            return Ok();
        }
    }

    // DELETE api/<StudentController>/5
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var diaryStudent = _diaryRepository.Students.FirstOrDefault(subject => subject.Id == id);
        if (diaryStudent == null)
        {
            _logger.LogInformation("Not Found class with id = {id}", id);
            return NotFound();
        }
        else
        {
            _diaryRepository.Students.Remove(diaryStudent);
            return Ok();
        }
    }

}
