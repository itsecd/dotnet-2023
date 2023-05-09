namespace SelectionCommittee.Server.Controllers.ExamResults.Dto;

/// <summary>
/// Dto для Post и Put операций сущности результатов экзамена.
/// </summary>
public class ExamResultDtoPostOrPut
{
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
