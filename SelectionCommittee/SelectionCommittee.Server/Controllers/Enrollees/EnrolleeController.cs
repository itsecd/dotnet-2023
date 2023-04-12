using Microsoft.AspNetCore.Mvc;
using SelectionCommittee.Server.Controllers.Enrollees.Dto;
using SelectionCommittee.Server.Repository;

namespace SelectionCommittee.Server.Controllers.Enrollees;

///
/// Выполнение CRUD операций для абитуриента.
///
[Route("api/[controller]")]
[ApiController]
public class EnrolleeController : Controller
{
    /// <summary>
    /// Репозиторий для сущностей приемной комиссии.
    /// </summary>
    private readonly ISelectionCommitteeRepository _selectionCommitteeRepository;

    /// <summary>
    /// Создание контроллера с помощью указанных параметров.
    /// </summary>
    /// <param name="selectionCommitteeRepository">Репозиторий сущностей приемной комиссии.</param>
    public EnrolleeController(ISelectionCommitteeRepository selectionCommitteeRepository)
    {
        _selectionCommitteeRepository = selectionCommitteeRepository;
    }

    /// <summary>
    /// Получение списка абитуриентов.
    /// </summary>
    /// <returns>Список абитуриентов.</returns>
    [HttpGet]
    public IEnumerable<EnrolleeDtoGet> GetEnrollees() 
    {
        return _selectionCommitteeRepository.Enrollees.Select(x => new EnrolleeDtoGet
        {
            Id = x.Id,
            FirstName= x.FirstName,
            LastName= x.LastName,
            Patronymic = x.Patronymic,
            Age = x.Age,
            BirthDate= x.BirthDate,
            Country= x.Country,
            City= x.City,
            ExamResults= x.ExamResults,
            Specializations= x.Specializations
        });
    }

    /// <summary>
    /// Получение абитуриента по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    /// <returns>Абитуриента.</returns>
    [HttpGet("{id}")]
    public ActionResult<EnrolleeDtoGet> GetEnrollee(int id)
    {
        var enrollee = _selectionCommitteeRepository.Enrollees.FirstOrDefault(e => e.Id == id);

        if (enrollee == null) 
        {
            return NotFound();
        }

        return Ok(new EnrolleeDtoGet
        {
            FirstName = enrollee.FirstName,
            LastName = enrollee.LastName,
            Patronymic = enrollee.Patronymic,
            Age = enrollee.Age,
            BirthDate = enrollee.BirthDate,
            Country = enrollee.Country,
            City = enrollee.City,
            ExamResults = enrollee.ExamResults,
            Specializations = enrollee.Specializations
        });
    }

    /// <summary>
    /// Добавление абитуриента.
    /// </summary>
    /// <param name="enrollee">Абитуриент.</param>
    [HttpPost]
    public void AddEnrollee([FromBody] EnrolleeDtoPostOrPut enrollee)
    {
        _selectionCommitteeRepository.Enrollees.Add(new Domain.Enrollee
        {
            Id = enrollee.Id,
            FirstName = enrollee.FirstName,
            LastName = enrollee.LastName,
            Patronymic = enrollee.Patronymic,
            Age = enrollee.Age,
            BirthDate = enrollee.BirthDate,
            Country = enrollee.Country,
            City = enrollee.City
        });
    }

    /// <summary>
    /// Обновление данных абитуриента.
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    /// <param name="enrolleeDtoPostOrPut">Содержит новые данные для абитуриента</param>
    /// <returns>Результат обновления.</returns>
    [HttpPut("{id}")]
    public IActionResult UpdateEnrollee(int id, [FromBody] EnrolleeDtoPostOrPut enrolleeDtoPostOrPut)
    {
        var enrollee = _selectionCommitteeRepository.Enrollees.FirstOrDefault(e => e.Id == id);

        if (enrollee == null) 
        {
            return NotFound();
        }

        enrollee.FirstName = enrolleeDtoPostOrPut.FirstName;
        enrollee.LastName = enrolleeDtoPostOrPut.LastName;
        enrollee.Patronymic = enrolleeDtoPostOrPut.Patronymic;
        enrollee.Age = enrolleeDtoPostOrPut.Age;
        enrollee.BirthDate = enrolleeDtoPostOrPut.BirthDate;
        enrollee.Country = enrolleeDtoPostOrPut.Country;
        enrollee.City = enrolleeDtoPostOrPut.City;

        return Ok();
    }

    /// <summary>
    /// Удаление абитуриента.
    /// </summary>
    /// <param name="id">Идентификатор</param>
    /// <returns>Результат удаления.</returns>
    [HttpDelete("{id}")]
    public IActionResult DeleteEnrollee(int id) 
    {
        var enrollee = _selectionCommitteeRepository.Enrollees.FirstOrDefault(enrollee => enrollee.Id == id);

        if (enrollee == null)
        {
            return NotFound();
        }

        _selectionCommitteeRepository.Enrollees.Remove(enrollee);

        return Ok();
    }
}
