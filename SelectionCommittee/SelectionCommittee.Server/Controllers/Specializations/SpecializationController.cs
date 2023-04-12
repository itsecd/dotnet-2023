using Microsoft.AspNetCore.Mvc;
using SelectionCommittee.Server.Controllers.Specializations.Dto;
using SelectionCommittee.Server.Repository;

namespace SelectionCommittee.Server.Controllers.Specializations;

///
/// Выполнение CRUD операций для специализации.
///
[Route("api/[controller]")]
[ApiController]
public class SpecializationController : Controller
{
    /// <summary>
    /// Репозиторий для сущностей приемной комиссии.
    /// </summary>
    private readonly ISelectionCommitteeRepository _selectionCommitteeRepository;

    /// <summary>
    /// Создание контроллера с помощью указанных параметров.
    /// </summary>
    /// <param name="selectionCommitteeRepository">Репозиторий сущностей приемной комиссии.</param>
    public SpecializationController(ISelectionCommitteeRepository selectionCommitteeRepository)
    {
        _selectionCommitteeRepository = selectionCommitteeRepository;
    }

    /// <summary>
    /// Получение списка специальностей.
    /// </summary>
    /// <returns>Список специальностей.</returns>
    [HttpGet]
    public IEnumerable<SpecializationDtoGet> GetSpecializations() 
    {
        return _selectionCommitteeRepository.Specializations.Select(x => new SpecializationDtoGet
        {
            Id = x.Id,
            Priority= x.Priority,
            Name = x.Name,
            Faculty = x.Faculty,
            Enrollees = x.Enrollees,
        });
    }

    /// <summary>
    /// Получение специальности по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    /// <returns>Факультет.</returns>
    [HttpGet("{id}")]
    public ActionResult<SpecializationDtoGet> GetSpecialization(int id)
    {
        var specialization = _selectionCommitteeRepository.Specializations.FirstOrDefault(e => e.Id == id);

        if (specialization == null)
        {
            return NotFound();
        }

        return Ok(new SpecializationDtoGet
        {
            Id = specialization.Id,
            Priority = specialization.Priority,
            Name = specialization.Name,
            Faculty = specialization.Faculty,
            Enrollees = specialization.Enrollees,
        });
    }

    /// <summary>
    /// Добавление специальности.
    /// </summary>
    /// <param name="specialization">Специальность.</param>
    [HttpPost]
    public void AddSpecialization([FromBody] SpecializationDtoPostOrPut specialization)
    {
        _selectionCommitteeRepository.Specializations.Add(new Domain.Specialization
        {
            Id = specialization.Id,
            Priority = specialization.Priority,
            Name = specialization.Name,
            FacultyId = specialization.FacultyId,
        });
    }

    /// <summary>
    /// Обновление данных специальности.
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    /// <param name="specializationDtoPostOrPut">Содержит новые данные для специальности.</param>
    /// <returns>Результат обновления.</returns>
    [HttpPut("{id}")] 
    public IActionResult UpdateSpecialization(int id, [FromBody] SpecializationDtoPostOrPut specializationDtoPostOrPut)
    {
        var specialization = _selectionCommitteeRepository.Specializations.FirstOrDefault(e => e.Id == id);

        if (specialization == null)
        {
            return NotFound();
        }

        specialization.Priority = specializationDtoPostOrPut.Priority;
        specialization.Name = specializationDtoPostOrPut.Name;
        specialization.FacultyId = specializationDtoPostOrPut.FacultyId;

        return Ok();
    }

    /// <summary>
    /// Удаление специальности.
    /// </summary>
    /// <param name="id">Идентификатор</param>
    /// <returns>Результат удаления.</returns>
    [HttpDelete("{id}")]
    public IActionResult DeleteSpecialization(int id)
    {
        var specialization = _selectionCommitteeRepository.Specializations.FirstOrDefault(specialization => specialization.Id == id);

        if (specialization == null)
        {
            return NotFound();
        }

        _selectionCommitteeRepository.Specializations.Remove(specialization);

        return Ok();
    }
}
