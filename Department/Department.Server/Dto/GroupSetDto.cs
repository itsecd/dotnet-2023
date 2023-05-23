namespace Department.Server.Dto;

public class GroupSetDto
{
    /// <summary>
    /// Amount of students
    /// </summary>
    public int StudentAmount { get; set; }

    /// <summary>
    /// Type of education (full-time education, evening education, extramural studies)
    /// </summary>
    public string EducationType { get; set; } = string.Empty;
}
