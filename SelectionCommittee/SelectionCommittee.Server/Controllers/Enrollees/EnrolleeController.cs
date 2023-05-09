using Microsoft.AspNetCore.Mvc;
using SelectionCommittee.Domain;
using SelectionCommittee.Server.Controllers.Enrollees.Dto;
using SelectionCommittee.Server.Repository;

namespace SelectionCommittee.Server.Controllers.Enrollees;

/// <summary>
/// Выполнение CRUD операций для абитуриента.
/// </summary>
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
    public async Task<IEnumerable<EnrolleeDtoGet>> GetEnrollees()
    {
        return (await _selectionCommitteeRepository.GetEnrollees()).Select(enrollee => new EnrolleeDtoGet
        {
            Id = enrollee.Id,
            FirstName = enrollee.FirstName,
            LastName = enrollee.LastName,
            Patronymic = enrollee.Patronymic,
            Age = enrollee.Age,
            BirthDate = enrollee.BirthDate,
            Country = enrollee.Country,
            City = enrollee.City,
            SpecializationId = enrollee.SpecializationId
        });
    }

    /// <summary>
    /// Получение абитуриента по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    /// <returns>Абитуриента.</returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<EnrolleeDtoGet>> GetEnrollee(int id)
    {
        var enrollee = await _selectionCommitteeRepository.GetEnrollee(id);

        if (enrollee == null)
        {
            return NotFound("Абитуриент с указанным идентификатором не найден!");
        }

        return Ok(new EnrolleeDtoGet
        {
            Id = enrollee.Id,
            FirstName = enrollee.FirstName,
            LastName = enrollee.LastName,
            Patronymic = enrollee.Patronymic,
            Age = enrollee.Age,
            BirthDate = enrollee.BirthDate,
            Country = enrollee.Country,
            City = enrollee.City,
            SpecializationId = enrollee.SpecializationId
        });
    }

    /// <summary>
    /// Добавление абитуриента.
    /// </summary>
    /// <param name="enrollee">Абитуриент.</param>
    [HttpPost]
    public async Task<ActionResult<int>> AddEnrollee([FromBody] EnrolleeDtoPostOrPut enrollee)
    {
        if (await _selectionCommitteeRepository.GetSpecialization(enrollee.SpecializationId) == null)
        {
            return BadRequest("Специальность с указанным идентифиатором не найдена!");
        }

        return Ok(await _selectionCommitteeRepository.AddEnrollee(new Enrollee
        {
            FirstName = enrollee.FirstName,
            LastName = enrollee.LastName,
            Patronymic = enrollee.Patronymic,
            Age = enrollee.Age,
            BirthDate = enrollee.BirthDate,
            Country = enrollee.Country,
            City = enrollee.City,
            SpecializationId = enrollee.SpecializationId
        }));
    }

    /// <summary>
    /// Обновление данных абитуриента.
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    /// <param name="enrolleeDtoPostOrPut">Содержит новые данные для абитуриента</param>
    /// <returns>Результат обновления.</returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateEnrollee(int id, [FromBody] EnrolleeDtoPostOrPut enrolleeDtoPostOrPut)
    {
        if (await _selectionCommitteeRepository.GetEnrollee(id) == null)
        {
            return NotFound("Абитуриент с указанным идентификатором не найден!");
        }

        if (await _selectionCommitteeRepository.GetSpecialization(enrolleeDtoPostOrPut.SpecializationId) == null)
        {
            return BadRequest("Специальность с указанным идентифиатором не найдена!");
        }

        await _selectionCommitteeRepository.UpdateEnrollee(id, new Enrollee
        {
            FirstName = enrolleeDtoPostOrPut.FirstName,
            LastName = enrolleeDtoPostOrPut.LastName,
            Patronymic = enrolleeDtoPostOrPut.Patronymic,
            Age = enrolleeDtoPostOrPut.Age,
            BirthDate = enrolleeDtoPostOrPut.BirthDate,
            Country = enrolleeDtoPostOrPut.Country,
            City = enrolleeDtoPostOrPut.City,
            SpecializationId = enrolleeDtoPostOrPut.SpecializationId
        });

        return Ok();
    }

    /// <summary>
    /// Удаление абитуриента.
    /// </summary>
    /// <param name="id">Идентификатор</param>
    /// <returns>Результат удаления.</returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteEnrollee(int id)
    {
        var enrollee = await _selectionCommitteeRepository.GetEnrollee(id);

        if (enrollee == null)
        {
            return NotFound("Абитуриент с указанным идентификатором не найден!");
        }

        await _selectionCommitteeRepository.DeleteEnrollee(id);

        return Ok();
    }
}
