namespace Department.Server.Dto;

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
