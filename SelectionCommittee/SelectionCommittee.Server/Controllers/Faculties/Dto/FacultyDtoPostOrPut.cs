namespace SelectionCommittee.Server.Controllers.Faculties.Dto;

/// <summary>
/// Dto для Post и Put операций сущности факультета.
/// </summary>
public class FacultyDtoPostOrPut
{
    /// <summary>
    /// Идентификатор.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Название.
    /// </summary>
    public string Name { get; set; }
}
