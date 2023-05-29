namespace Department.Server.Dto;

/// <summary>
/// Class GroupSetDto has the info about all groups
/// </summary>
public class GroupSetDto
{
    /// <summary>
    /// Group number
    /// </summary>
    public int GroupNumber { get; set; }

    /// <summary>
    /// Amount of students
    /// </summary>
    public int StudentAmount { get; set; }

    /// <summary>
    /// Type of education (full-time education, evening education, extramural studies)
    /// </summary>
    public string EducationType { get; set; } = string.Empty;
}
