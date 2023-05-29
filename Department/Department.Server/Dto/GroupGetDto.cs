namespace Department.Server.Dto;

/// <summary>
/// Class GroupGetDto has the info about all groups
/// </summary>
public class GroupGetDto
{
    /// <summary>
    /// Group id
    /// </summary>
    public int Id { get; set; }

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
