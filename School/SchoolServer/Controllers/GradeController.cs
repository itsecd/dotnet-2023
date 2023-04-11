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
    /// Метод получения данных всей коллекции для оценок
    /// </summary>
    /// <returns>Коллекция оценок учеников</returns>
    [HttpGet]
    public IEnumerable<GradeGetDto> Get()
    {
        return _diaryRepository.Grades.Select(grade => _mapper.Map<GradeGetDto>(grade));
    }

    /// <summary>
    /// Метод получения оценок по id
    /// </summary>
    /// <param name="id">id объекта(оценки)</param>
    /// <returns>Оценку и параметры согласно id</returns>
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
    /// Метод добавления элементов в коллекцию с помощью json
    /// </summary>
    /// <param name="grade">Параметр добавления</param>
    [HttpPost]
    public void Post([FromBody] GradeGetDto grade)
    {
        _diaryRepository.Grades.Add(_mapper.Map<Grade>(grade));
    }

    /// <summary>
    /// Метод обновления данных по id
    /// </summary>
    /// <param name="id">Параметр по которому происходит изменение</param>
    /// <param name="grade">Параметр изменения</param>
    /// <returns>Обновленные данные по id</returns>
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
    /// Метод удаления данных по id
    /// </summary>
    /// <returns>Успех или ошибка удаления</returns>
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
