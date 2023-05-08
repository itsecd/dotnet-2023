namespace UniversityData.Server.Dto;
/// <summary>
/// Информация о факультете
/// </summary>
public class FacultyPostDto
{
    /// <summary>
    /// Название факультета
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// Количество сотрудников факультета
    /// </summary>
    public int WorkersCount { get; set; }
    /// <summary>
    /// Количество студентов факультета
    /// </summary>
    public int StudentsCount { get; set; }
    /// <summary>
    /// ID университета
    /// </summary>
    public int UniversityId { get; set; }
}
