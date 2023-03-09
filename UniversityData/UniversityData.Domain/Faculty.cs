namespace UniversityData.Domain;
/// <summary>
/// Информация о факультете 
/// </summary>
public class Faculty
{
    /// <summary>
    /// ID
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// Название факультета
    /// </summary>
    public string FaculityName { get; set; } = string.Empty;
    /// <summary>
    /// Количетсво сотрудников факультета
    /// </summary>
    public int FaculityWorkersCount { get; set; }
    /// <summary>
    /// Количество студентов факультета
    /// </summary>
    public int FaculityStudentsCount { get; set; }
    /// <summary>
    /// <summary>
    /// Ссылка на обратную связь
    /// </summary>
    public University? University { get; set; }
}
