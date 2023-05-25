namespace Department.Server.Dto;

public class TeacherGetDto
{
    /// <summary>
    /// Teacher's id
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Teacher's full name
    /// </summary>
    public string FullName { get; set; } = string.Empty;

    /// <summary>
    /// Teacher's academic degree
    /// </summary>
    public string Degree { get; set; } = string.Empty;
}
