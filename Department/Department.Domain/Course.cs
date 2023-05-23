namespace Department.Domain;

/// <summary>
/// Class Course has info about all courses at the department
/// </summary>
public class Course
{
    public int Id { get; set; }

    /// <summary>
    /// Subject
    /// </summary>
    public string SubjectName { get; set; } = string.Empty;

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
    public string TeachersName { get; set; } = string.Empty;

    public int TeacherId { get; set; }
}
