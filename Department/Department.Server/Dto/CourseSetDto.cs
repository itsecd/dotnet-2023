namespace Department.Server.Dto;

public class CourseSetDto
{
    /// <summary>
    /// Subject
    /// </summary>
    public int SubjectId { get; set; }

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
    public int TeacherId { get; set; }
}
