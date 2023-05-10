using Microsoft.AspNetCore.Mvc;
using SelectionCommittee.Domain;
using SelectionCommittee.Server.Controllers.Specializations.Dto;
using SelectionCommittee.Server.Repository;

namespace SelectionCommittee.Server.Controllers.Specializations;

/// <summary>
/// Выполнение CRUD операций для специальности.
/// </summary>
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
    public async Task<IEnumerable<SpecializationDtoGet>> GetSpecializations()
    {
        return (await _selectionCommitteeRepository.GetSpecializations())
            .Select(specialization => new SpecializationDtoGet
            {
                Id = specialization.Id,
                Priority = specialization.Priority,
                Name = specialization.Name,
                FacultyId = specialization.FacultyId
            });
    }

    /// <summary>
    /// Получение специальности по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    /// <returns>Факультет.</returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<SpecializationDtoGet>> GetSpecialization(int id)
    {
        var specialization = await _selectionCommitteeRepository.GetSpecialization(id);

        if (specialization == null)
        {
            return NotFound("Специальность с указанным идентификатором не найдена!");
        }

        return Ok(new SpecializationDtoGet
        {
            Id = specialization.Id,
            Priority = specialization.Priority,
            Name = specialization.Name,
            FacultyId = specialization.FacultyId
        });
    }

    /// <summary>
    /// Добавление специальности.
    /// </summary>
    /// <param name="specialization">Специальность.</param>
    [HttpPost]
    public async Task<ActionResult<int>> AddSpecialization([FromBody] SpecializationDtoPostOrPut specialization)
    {
        if (await _selectionCommitteeRepository.GetFaculty(specialization.FacultyId) == null)
        {
            return BadRequest("Факультет с указанным идентификатором не найден!");
        }

        return Ok(await _selectionCommitteeRepository.AddSpecialization(new Specialization
        {
            Priority = specialization.Priority,
            Name = specialization.Name,
            FacultyId = specialization.FacultyId,
        }));
    }

    /// <summary>
    /// Обновление данных специальности.
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    /// <param name="specializationDtoPostOrPut">Содержит новые данные для специальности.</param>
    /// <returns>Результат обновления.</returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateSpecialization(int id, [FromBody] SpecializationDtoPostOrPut specializationDtoPostOrPut)
    {
        var specialization = await _selectionCommitteeRepository.GetSpecialization(id);

        if (specialization == null)
        {
            return NotFound("Специальность с указанным идентификатором не найдена!");
        }

        if (await _selectionCommitteeRepository.GetFaculty(specializationDtoPostOrPut.FacultyId) == null)
        {
            return BadRequest("Факультет с указанным идентификатором не найден!");
        }

        await _selectionCommitteeRepository.UpdateSpecialization(id, new Specialization
        {
            Priority = specializationDtoPostOrPut.Priority,
            Name = specializationDtoPostOrPut.Name,
            FacultyId = specializationDtoPostOrPut.FacultyId
        });

        return Ok();
    }

    /// <summary>
    /// Удаление специальности.
    /// </summary>
    /// <param name="id">Идентификатор</param>
    /// <returns>Результат удаления.</returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteSpecialization(int id)
    {
        var specialization = await _selectionCommitteeRepository.GetSpecialization(id);

        if (specialization == null)
        {
            return NotFound("Специальность с указанным идентификатором не найдена!");
        }

        await _selectionCommitteeRepository.DeleteSpecialization(id);

        return Ok();
    }
}
