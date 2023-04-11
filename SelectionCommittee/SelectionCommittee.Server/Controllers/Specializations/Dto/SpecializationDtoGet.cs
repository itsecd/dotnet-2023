using SelectionCommittee.Domain;

namespace SelectionCommittee.Server.Controllers.Specializations.Dto;

/// <summary>
/// Dto для Get операций сущности специальности.
/// </summary>
public class SpecializationDtoGet
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
    /// Факультет.
    /// </summary>
    public Faculty? Faculty { get; set; }

    /// <summary>
    /// Абитуриенты.
    /// </summary>
    public List<Enrollee>? Enrollees { get; set; }
}
