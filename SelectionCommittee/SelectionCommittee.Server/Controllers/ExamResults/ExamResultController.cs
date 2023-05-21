using Microsoft.AspNetCore.Mvc;
using SelectionCommittee.Domain;
using SelectionCommittee.Server.Controllers.ExamResults.Dto;
using SelectionCommittee.Server.Repository;

namespace SelectionCommittee.Server.Controllers.ExamResults;

/// <summary>
/// Выполнение CRUD операций для результатов экзамена.
/// </summary>
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
    [HttpGet(Name = "GetExamResults")]
    public async Task<IEnumerable<ExamResultDtoGet>> GetExamResults()
    {
        return (await _selectionCommitteeRepository.GetExamResults())
            .Select(examResult => new ExamResultDtoGet
            {
                Id = examResult.Id,
                SubjectName = examResult.SubjectName,
                Points = examResult.Points,
                EnrolleeId = examResult.EnrolleeId
            });
    }

    /// <summary>
    /// Получение результата экзамена по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    /// <returns>Результат экзамена.</returns>
    [HttpGet("{id}", Name = "GetExamResult")]
    public async Task<ActionResult<ExamResultDtoGet>> GetExamResult(int id)
    {
        var examResult = await _selectionCommitteeRepository.GetExamResult(id);

        if (examResult == null)
        {
            return NotFound("Результат экзамена с указанным идентификатором не найден!");
        }

        return Ok(new ExamResultDtoGet
        {
            Id = examResult.Id,
            SubjectName = examResult.SubjectName,
            Points = examResult.Points,
            EnrolleeId = examResult.EnrolleeId
        });
    }

    /// <summary>
    /// Добавление результата экзамена.
    /// </summary>
    /// <param name="examResult">Абитуриент.</param>
    [HttpPost(Name = "AddExamResult")]
    public async Task<ActionResult<int>> AddExamResult([FromBody] ExamResultDtoPostOrPut examResult)
    {
        if (await _selectionCommitteeRepository.GetEnrollee(examResult.EnrolleeId) == null)
        {
            return BadRequest("Абитуриент с указанным идентификатором не найден!");
        }

        return Ok(await _selectionCommitteeRepository.AddExamResult(new ExamResult
        {
            SubjectName = examResult.SubjectName,
            Points = examResult.Points,
            EnrolleeId = examResult.EnrolleeId
        }));
    }

    /// <summary>
    /// Обновление данных результата экзамена.
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    /// <param name="examResultDtoPostOrPut">Содержит новые данные для результата экзамена</param>
    /// <returns>Результат обновления.</returns>
    [HttpPut("{id}", Name = "UpdateExamResult")]
    public async Task<IActionResult> UpdateExamResult(int id, [FromBody] ExamResultDtoPostOrPut examResultDtoPostOrPut)
    {
        if (await _selectionCommitteeRepository.GetExamResult(id) == null)
        {
            return NotFound("Результат экзамена с указанным идентификатором не найден!");
        }

        if (await _selectionCommitteeRepository.GetEnrollee(examResultDtoPostOrPut.EnrolleeId) == null)
        {
            return BadRequest("Абитуриент с указанным идентификатором не найден!");
        }

        await _selectionCommitteeRepository.UpdateExamResult(id, new ExamResult
        {
            SubjectName = examResultDtoPostOrPut.SubjectName,
            Points = examResultDtoPostOrPut.Points,
            EnrolleeId = examResultDtoPostOrPut.EnrolleeId
        });

        return Ok();
    }

    /// <summary>
    /// Удаление результата экзамена.
    /// </summary>
    /// <param name="id">Идентификатор</param>
    /// <returns>Результат удаления.</returns>
    [HttpDelete("{id}", Name = "DeleteExamResult")]
    public async Task<IActionResult> DeleteExamResult(int id)
    {
        var examResult = await _selectionCommitteeRepository.GetExamResult(id);

        if (examResult == null)
        {
            return NotFound("Результат экзамена с указанным идентификатором не найден!");
        }

        await _selectionCommitteeRepository.DeleteExamResult(id);

        return Ok();
    }
}
