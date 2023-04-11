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
    /// Метод получения "предмета"
    /// </summary>
    [HttpGet]
    public IEnumerable<SubjectGetDto> Get()
    {
        return _diaryRepository.Subjects.Select(subject => _mapper.Map<SubjectGetDto>(subject));
    }

    /// <summary>
    /// Метод получения "предмета" по id
    /// </summary>
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
    /// Post метод для добавления "предмета"
    /// </summary>
    [HttpPost]
    public void Post([FromBody] SubjectGetDto subject)
    {
        _diaryRepository.Subjects.Add(_mapper.Map<Subject>(subject));
    }


    /// <summary>
    /// Метод удаления из класса
    /// </summary>
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
