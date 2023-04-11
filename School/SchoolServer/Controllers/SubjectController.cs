using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using School.Classes;
using SchoolServer.Dto;
using SchoolServer.Repository;

namespace SchoolServer.Controllers;

/// <summary>
/// Контроллер "предмета"
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class SubjectController : ControllerBase
{
    private readonly ILogger<SubjectController> _logger;

    private readonly ISchoolRepository _diaryRepository;

    private readonly IMapper _mapper;

    /// <summary>
    /// Конструктор контроллера
    /// </summary>
    public SubjectController(ILogger<SubjectController> logger, ISchoolRepository diaryRepository, IMapper mapper)
    {
        _logger = logger;
        _diaryRepository = diaryRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Метод получения данных всей коллекции для предметов
    /// </summary>
    /// <returns>Коллекция предметов</returns>
    [HttpGet]
    public IEnumerable<SubjectGetDto> Get()
    {
        return _diaryRepository.Subjects.Select(subject => _mapper.Map<SubjectGetDto>(subject));
    }

    /// <summary>
    ///  Метод получения предметов по id
    /// </summary>
    /// <param name="id">id предмета</param>
    /// <returns>Предмет согласно id</returns>
    [HttpGet("{id}")]
    public ActionResult<SubjectGetDto> Get(int id)
    {
        var diarySubject = _diaryRepository.Subjects.FirstOrDefault(subject => subject.Id == id);
        if (diarySubject == null)
        {
            _logger.LogInformation("Not Found class with id = {id}", id);
            return NotFound();
        }
        else
        {
            return Ok(_mapper.Map<SubjectGetDto>(diarySubject));
        }
    }

    /// <summary>
    /// Метод добавления предмета с помощью json
    /// </summary>
    /// <param name="subject">Параметр добавления элемента</param>
    [HttpPost]
    public void Post([FromBody] SubjectGetDto subject)
    {
        _diaryRepository.Subjects.Add(_mapper.Map<Subject>(subject));
    }


    /// <summary>
    /// Метод удаления предмета по id
    /// </summary>
    /// <param name="id">id для удаления предмета</param>
    /// <returns>Успех или ошибка удаления</returns>
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var diarySubject = _diaryRepository.Subjects.FirstOrDefault(subject => subject.Id == id);
        if (diarySubject == null)
        {
            _logger.LogInformation("Not Found class with id = {id}", id);
            return NotFound();
        }
        else
        {
            _diaryRepository.Subjects.Remove(diarySubject);
            return Ok();
        }
    }
}
