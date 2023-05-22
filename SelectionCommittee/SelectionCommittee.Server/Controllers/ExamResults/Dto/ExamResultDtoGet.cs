namespace SelectionCommittee.Server.Controllers.ExamResults.Dto;

/// <summary>
/// Dto для Get операций сущности результатов экзамена.
/// </summary>
public class ExamResultDtoGet
{
    /// <summary>
    /// Идентификатор.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Название предмета.
    /// </summary>
    public string SubjectName { get; set; }

    /// <summary>
    /// Количество баллов.
    /// </summary>
    public int Points { get; set; }

    /// <summary>
    /// Идентификатор абитуриента.
    /// </summary>
    public int EnrolleeId { get; set; }
}
