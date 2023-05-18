namespace Department.Domain;

/// <summary>
/// Class Group has the info about all groups
/// </summary>
public class Group
{
    /// <summary>
    /// Group number
    /// </summary>
    public uint GroupNumber { get; set; }

    /// <summary>
    /// Amount of students
    /// </summary>
    public uint StudentAmount { get; set; }

    /// <summary>
    /// Type of education (full-time education, evening education, extramural studies)
    /// </summary>
    public string EducationType { get; set; } = string.Empty;
}
