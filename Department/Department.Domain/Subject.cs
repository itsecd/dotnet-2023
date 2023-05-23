namespace Department.Domain;

/// <summary>
/// Class Subject has the info about all subjects
/// </summary>
public class Subject
{
    public int Id { get; set; }

    /// <summary>
    /// Subject's name
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Subject's semester
    /// </summary>
    public int Semester { get; set; }
}
