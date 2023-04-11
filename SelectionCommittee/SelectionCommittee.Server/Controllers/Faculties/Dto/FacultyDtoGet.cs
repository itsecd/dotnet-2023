using SelectionCommittee.Domain;

namespace SelectionCommittee.Server.Controllers.Faculties.Dto;

/// <summary>
/// Dto для Get операций сущности факультета.
/// </summary>
public class FacultyDtoGet
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
