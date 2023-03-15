namespace SelectionCommittee.Domain;

/// <summary>
/// Специальность.
/// </summary>
public class Specialization
{
    /// <summary>
    /// Идентификатор.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Приоритет.
    /// </summary>
    public int Priority { get; set; }

    /// <summary>
    /// Название.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Идентификатор факультета.
    /// </summary>
    public int FacultyId { get; set; }

    /// <summary>
    /// Факультет.
    /// </summary>
    public Faculty? Faculty { get; set; }

    /// <summary>
    /// Абитуриенты.
    /// </summary>
    public List<Enrollee>? Enrollees { get; set; }
}
