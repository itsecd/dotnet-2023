using AutoMapper;
using SchoolServer.Dto;
using SchoolServer.Repository;
using Microsoft.AspNetCore.Mvc;
using School.Classes;

namespace SchoolServer.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GradeController : ControllerBase
{
    private readonly ILogger<GradeController> _logger;

    private readonly ISchoolRepository _diaryRepository;

    private readonly IMapper _mapper;

    public GradeController(ILogger<GradeController> logger, ISchoolRepository diaryRepository, IMapper mapper)
    {
        _logger = logger;
        _diaryRepository = diaryRepository;
        _mapper = mapper;
    }

    // GET: api/<GradeController>
    [HttpGet]
    public IEnumerable<GradeGetDto> Get()
    {
        return _diaryRepository.Grades.Select(grade => _mapper.Map<GradeGetDto>(grade));
    }

    // GET api/<GradeController>/5
    [HttpGet("{id}")]
    public ActionResult<GradeGetDto> Get(int id)
    {
        var diaryGrade = _diaryRepository.Grades.FirstOrDefault(grade => grade.Id == id);
        if (diaryGrade == null)
        {
            _logger.LogInformation("Not Found class with id = {id}", id);
            return NotFound();
        }
        else
        {
            return Ok(_mapper.Map<GradeGetDto>(diaryGrade));
        }
    }

    // POST api/<GradeController>
    [HttpPost]
    public void Post([FromBody] GradeGetDto grade)
    {
        _diaryRepository.Grades.Add(_mapper.Map<Grade>(grade));
    }

    // PUT api/<GradeController>/5
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] GradeGetDto grade)
    {
        var diaryGrade = _diaryRepository.Grades.FirstOrDefault(grade => grade.Id == id);
        if (diaryGrade == null)
        {
            _logger.LogInformation("Not Found class with id = {id}", id);
            return NotFound();
        }
        else
        {
            _mapper.Map(grade, diaryGrade);
            return Ok();
        }
    }

    // DELETE api/<GradeController>/5
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var diaryGrade = _diaryRepository.Grades.FirstOrDefault(grade => grade.Id == id);
        if (diaryGrade == null)
        {
            _logger.LogInformation("Not Found class with id = {id}", id);
            return NotFound();
        }
        else
        {
            _diaryRepository.Grades.Remove(diaryGrade);
            return Ok();
        }
    }
}
