using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using School.Classes;
using SchoolServer.Dto;
using SchoolServer.Repository;

namespace SchoolServer.Controllers;

/// <summary>
/// Контроллер оценок
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class GradeController : ControllerBase
{
    private readonly ILogger<GradeController> _logger;

    private readonly ISchoolRepository _diaryRepository;

    private readonly IMapper _mapper;

    /// <summary>
    /// Конструктор контроллера
    /// </summary>
    public GradeController(ILogger<GradeController> logger, ISchoolRepository diaryRepository, IMapper mapper)
    {
        _logger = logger;
        _diaryRepository = diaryRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Метод получения
    /// </summary>
    [HttpGet]
    public IEnumerable<GradeGetDto> Get()
    {
        return _diaryRepository.Grades.Select(grade => _mapper.Map<GradeGetDto>(grade));
    }

    /// <summary>
    /// Метод получения по id
    /// </summary>
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

    /// <summary>
    /// Метод Post 
    /// </summary>
    [HttpPost]
    public void Post([FromBody] GradeGetDto grade)
    {
        _diaryRepository.Grades.Add(_mapper.Map<Grade>(grade));
    }

    /// <summary>
    /// Метод получения по id
    /// </summary>
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

    /// <summary>
    /// Метод удаления по id
    /// </summary>
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
