namespace Department.Server.Dto;

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
