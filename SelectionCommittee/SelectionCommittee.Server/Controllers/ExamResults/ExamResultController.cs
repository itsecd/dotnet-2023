using Microsoft.AspNetCore.Mvc;
using SelectionCommittee.Server.Controllers.ExamResults.Dto;
using SelectionCommittee.Server.Repository;

namespace SelectionCommittee.Server.Controllers.ExamResults;

///
/// Выполнение CRUD операций для результатов экзамена.
///
[Route("api/[controller]")]
[ApiController]
public class ExamResultController : Controller
{
    /// <summary>
    /// Репозиторий для сущностей приемной комиссии.
    /// </summary>
    private readonly ISelectionCommitteeRepository _selectionCommitteeRepository;

    /// <summary>
    /// Создание контроллера с помощью указанных параметров.
    /// </summary>
    /// <param name="selectionCommitteeRepository">Репозиторий сущностей приемной комиссии.</param>
    public ExamResultController(ISelectionCommitteeRepository selectionCommitteeRepository)
    {
        _selectionCommitteeRepository = selectionCommitteeRepository;
    }

    /// <summary>
    /// Получение списка результатов экзамена.
    /// </summary>
    /// <returns>Список результатов экзамена.</returns>
    [HttpGet]
    public IEnumerable<ExamResultDtoGet> GetExamResults() 
    {
        return _selectionCommitteeRepository.ExamResults.Select(x => new ExamResultDtoGet
        {
            Id = x.Id,
            SubjectName = x.SubjectName,
            Points= x.Points,
            //Enrollee = x.Enrollee,
        });
    }

    /// <summary>
    /// Получение результата экзамена по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    /// <returns>Результат экзамена.</returns>
    [HttpGet("{id}")]
    public ActionResult<ExamResultDtoGet> GetExamResult(int id)
    {
        var examResult = _selectionCommitteeRepository.ExamResults.FirstOrDefault(e => e.Id == id);

        if (examResult == null)
        {
            return NotFound();
        }

        return Ok(new ExamResultDtoGet
        {
            Id = examResult.Id,
            SubjectName = examResult.SubjectName,
            Points = examResult.Points,
           // Enrollee = examResult.Enrollee,
        });
    }

    /// <summary>
    /// Добавление результата экзамена.
    /// </summary>
    /// <param name="examResult">Абитуриент.</param>
    [HttpPost]
    public void AddExamResult([FromBody] ExamResultDtoPostOrPut examResult)
    {
        //_selectionCommitteeRepository.ExamResults.Add(new Domain.ExamResult
        //{
        //    Id = examResult.Id,
        //    SubjectName = examResult.SubjectName,
        //    Points = examResult.Points,
        //    EnrolleeId = examResult.EnrolleeId,
        //});
    }

    /// <summary>
    /// Обновление данных результата экзамена.
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    /// <param name="examResultDtoPostOrPut">Содержит новые данные для результата экзамена</param>
    /// <returns>Результат обновления.</returns>
    [HttpPut("{id}")]
    public IActionResult UpdateExamResult(int id, [FromBody] ExamResultDtoPostOrPut examResultDtoPostOrPut)
    {
        var examResult = _selectionCommitteeRepository.ExamResults.FirstOrDefault(e => e.Id == id);

        if (examResult == null)
        {
            return NotFound();
        }

        examResult.SubjectName = examResultDtoPostOrPut.SubjectName;
        examResult.Points = examResultDtoPostOrPut.Points;
        examResult.EnrolleeId = examResultDtoPostOrPut.EnrolleeId;

        return Ok();
    }

    /// <summary>
    /// Удаление результата экзамена.
    /// </summary>
    /// <param name="id">Идентификатор</param>
    /// <returns>Результат удаления.</returns>
    [HttpDelete("{id}")]
    public IActionResult DeleteExamResult(int id)
    {
        var examResult = _selectionCommitteeRepository.ExamResults.FirstOrDefault(examResult => examResult.Id == id);

        if (examResult == null)
        {
            return NotFound();
        }

        _selectionCommitteeRepository.ExamResults.Remove(examResult);

        return Ok();
    }
}
