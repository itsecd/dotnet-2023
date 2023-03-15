namespace SelectionCommittee.Domain;

/// <summary>
/// Факультет.
/// </summary>
public class Faculty
{
    /// <summary>
    /// Идентификатор.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Название.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Список специальностей.
    /// </summary>
    public List<Specialization>? Specializations { get; set; }
}
