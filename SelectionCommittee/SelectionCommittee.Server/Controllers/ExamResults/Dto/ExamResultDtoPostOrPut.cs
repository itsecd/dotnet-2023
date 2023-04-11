using SelectionCommittee.Domain;

namespace SelectionCommittee.Server.Controllers.ExamResults.Dto;

/// <summary>
/// Dto для Post и Put операций сущности результатов экзамена.
/// </summary>
public class ExamResultDtoPostOrPut
{
    /// <summary>
    /// Идентификатор.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Название предмета.
    /// </summary>
    public string SubjectName { get; set; } = string.Empty;

    /// <summary>
    /// Количество баллов.
    /// </summary>
    public int Points { get; set; }

    /// <summary>
    /// Идентификатор абитуриента.
    /// </summary>
    public int EnrolleeId { get; set; }
}
