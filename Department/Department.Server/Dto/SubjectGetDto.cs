namespace Department.Server.Dto;

public class SubjectGetDto
{
    /// <summary>
    /// Subject's id
    /// </summary>
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
