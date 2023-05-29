namespace Department.Server.Dto;

/// <summary>
/// Class TeacherSetDto has the info about all teachers
/// </summary>
public class TeacherSetDto
{
    /// <summary>
    /// Teacher's full name
    /// </summary>
    public string FullName { get; set; } = string.Empty;

    /// <summary>
    /// Teacher's academic degree
    /// </summary>
    public string Degree { get; set; } = string.Empty;
}
