using Microsoft.AspNetCore.Mvc;
using SelectionCommittee.Server.Controllers.Faculties.Dto;
using SelectionCommittee.Server.Repository;

namespace SelectionCommittee.Server.Controllers.Faculties;

///
/// Выполнение CRUD операций для факультета.
///
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
    public IEnumerable<FacultyDtoGet> GetFaculties() 
    {
        return _selectionCommitteeRepository.Faculties.Select(x => new FacultyDtoGet
        {
            Id = x.Id,
            Name = x.Name,
            //Specializations = x.Specializations
        });
    }

    /// <summary>
    /// Получение факультета по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    /// <returns>Факультет.</returns>
    [HttpGet("{id}")]
    public ActionResult<FacultyDtoGet> GetFaculty(int id)
    {
        var faculty = _selectionCommitteeRepository.Faculties.FirstOrDefault(e => e.Id == id);

        if (faculty == null)
        {
            return NotFound();
        }

        return Ok(new FacultyDtoGet
        {
            Id = faculty.Id,
            Name = faculty.Name,
            //Specializations = faculty.Specializations
        });
    }

    /// <summary>
    /// Добавление факультета.
    /// </summary>
    /// <param name="faculty">Факультет.</param>
    [HttpPost]
    public void AddFaculty([FromBody] FacultyDtoPostOrPut faculty) 
    {
        //_selectionCommitteeRepository.Faculties.Add(new Domain.Faculty
        //{
        //    Id = faculty.Id,
        //    Name = faculty.Name,
        //});
    }

    /// <summary>
    /// Обновление данных факультета.
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    /// <param name="facultyDtoPostOrPut">Содержит новые данные для факультета.</param>
    /// <returns>Результат обновления.</returns>
    [HttpPut("{id}")]
    public IActionResult UpdateFaculty(int id, [FromBody] FacultyDtoPostOrPut facultyDtoPostOrPut) 
    {
        var faculty = _selectionCommitteeRepository.Faculties.FirstOrDefault(e => e.Id == id);

        if (faculty == null)
        {
            return NotFound();
        }

        faculty.Name = facultyDtoPostOrPut.Name;

        return Ok();
    }

    /// <summary>
    /// Удаление факультета.
    /// </summary>
    /// <param name="id">Идентификатор</param>
    /// <returns>Результат удаления.</returns>
    [HttpDelete("{id}")]
    public IActionResult DeleteFaculty(int id)
    {
        var faculty = _selectionCommitteeRepository.Faculties.FirstOrDefault(examResult => examResult.Id == id);

        if (faculty == null)
        {
            return NotFound();
        }

        _selectionCommitteeRepository.Faculties.Remove(faculty);

        return Ok();
    }
}
