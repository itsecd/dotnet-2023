using Microsoft.AspNetCore.Mvc;
using SelectionCommittee.Domain;
using SelectionCommittee.Server.Controllers.Faculties.Dto;
using SelectionCommittee.Server.Repository;

namespace SelectionCommittee.Server.Controllers.Faculties;

/// <summary>
/// Выполнение CRUD операций для факультета.
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class FacultyController : Controller
{
    /// <summary>
    /// Репозиторий для сущностей приемной комиссии.
    /// </summary>
    private readonly ISelectionCommitteeRepository _selectionCommitteeRepository;

    /// <summary>
    /// Создание контроллера с помощью указанных параметров.
    /// </summary>
    /// <param name="selectionCommitteeRepository">Репозиторий сущностей приемной комиссии.</param>
    public FacultyController(ISelectionCommitteeRepository selectionCommitteeRepository)
    {
        _selectionCommitteeRepository = selectionCommitteeRepository;
    }

    /// <summary>
    /// Получение списка факультетов.
    /// </summary>
    /// <returns>Список факультетов.</returns>
    [HttpGet]
    public async Task<IEnumerable<FacultyDtoGet>> GetFaculties()
    {
        return (await _selectionCommitteeRepository.GetFaculties())
            .Select(faculty => new FacultyDtoGet
            {
                Id = faculty.Id,
                Name = faculty.Name
            });
    }

    /// <summary>
    /// Получение факультета по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    /// <returns>Факультет.</returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<FacultyDtoGet>> GetFaculty(int id)
    {
        var faculty = await _selectionCommitteeRepository.GetFaculty(id);

        if (faculty == null)
        {
            return NotFound("Факультет с указанным идентификатором не найден!");
        }

        return Ok(new FacultyDtoGet
        {
            Id = faculty.Id,
            Name = faculty.Name
        });
    }

    /// <summary>
    /// Добавление факультета.
    /// </summary>
    /// <param name="faculty">Факультет.</param>
    [HttpPost]
    public async Task<ActionResult<int>> AddFaculty([FromBody] FacultyDtoPostOrPut faculty)
    {
        return Ok(await _selectionCommitteeRepository.AddFaculty(new Faculty
        {
            Name = faculty.Name
        }));
    }

    /// <summary>
    /// Обновление данных факультета.
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    /// <param name="facultyDtoPostOrPut">Содержит новые данные для факультета.</param>
    /// <returns>Результат обновления.</returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateFaculty(int id, [FromBody] FacultyDtoPostOrPut facultyDtoPostOrPut)
    {
        var faculty = await _selectionCommitteeRepository.GetFaculty(id);

        if (faculty == null)
        {
            return NotFound("Факультут с указанным идентификатором не найден!");
        }

        await _selectionCommitteeRepository.UpdateFaculty(id, new Faculty
        {
            Name = facultyDtoPostOrPut.Name
        });

        return Ok();
    }

    /// <summary>
    /// Удаление факультета.
    /// </summary>
    /// <param name="id">Идентификатор</param>
    /// <returns>Результат удаления.</returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteFaculty(int id)
    {
        var faculty = await _selectionCommitteeRepository.GetFaculty(id);

        if (faculty == null)
        {
            return NotFound("Факультет с указанным идентификатором не найден!");
        }

        await _selectionCommitteeRepository.DeleteFaculty(id);

        return Ok();
    }
}
