namespace Department.Domain;

/// <summary>
/// Class Teacher has the info about all teachers
/// </summary>
public class Teacher
{
    public int Id { get; set;  }
    /// <summary>
    /// Teacher's full name
    /// </summary>
    public string FullName { get; set; } = string.Empty;

    /// <summary>
    /// Teacher's academic degree
    /// </summary>
    public string Degree { get; set; } = string.Empty;
}
