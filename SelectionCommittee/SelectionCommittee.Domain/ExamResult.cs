namespace SelectionCommittee.Domain;

/// <summary>
/// Результаты экзаменов.
/// </summary>
public class ExamResult
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

    /// <summary>
    /// Абитуриент.
    /// </summary>
    public Enrollee? Enrollee { get; set; }
}