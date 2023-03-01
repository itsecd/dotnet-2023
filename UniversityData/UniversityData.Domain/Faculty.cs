

namespace UniversityData.Domain;
/// <summary>
/// Информация о факультете 
/// </summary>
public class Faculty
{
    /// <summary>
    /// Название факультета
    /// </summary>
    public string? FaculityName { get; set; }
    /// <summary>
    /// Количетсво сотрудников факультета
    /// </summary>
    public int FaculityWorkersCount { get; set; }
    /// <summary>
    /// Количество студентов факультета
    /// </summary>
    public int FaculityStudentsCount { get; set; }

    public Faculty(string? faculityName, int faculityWorkersCount, int faculityStudentsCount)
    {
        FaculityName = faculityName;
        FaculityWorkersCount = faculityWorkersCount;
        FaculityStudentsCount = faculityStudentsCount;
    }
}
