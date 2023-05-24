namespace Department.Server.Dto;

public class CourseGetDto
{
    /// <summary>
    /// Course id
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Subject
    /// </summary>
    public string SubjectName { get; set; } = string.Empty;

    /// <summary>
    /// Type of course (lectures, practices, laboratory work, etc.)
    /// </summary>
    public string CourseType { get; set; } = string.Empty;

    /// <summary>
    /// Hours per semester
    /// </summary>
    public int SemesterHours { get; set; }

    /// <summary>
    /// Group
    /// </summary>
    public int GroupId { get; set; }

    /// <summary>
    /// Teacher
    /// </summary>
    public string TeachersName { get; set; } = string.Empty;
}
