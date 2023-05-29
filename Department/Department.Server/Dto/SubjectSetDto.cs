namespace Department.Server.Dto;

/// <summary>
/// Class SubjectSetDto has the info about all subjects
/// </summary>
public class SubjectSetDto
{
    /// <summary>
    /// Subject's name
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Subject's semester
    /// </summary>
    public int Semester { get; set; }
}
