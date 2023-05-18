namespace Department.Domain;

/// <summary>
/// Class Course has info about all courses at the department
/// </summary>
public class Course
{
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
    public int GroupNumber { get; set; }

    /// <summary>
    /// Teacher
    /// </summary>
    public string TeachersName { get; set; } = string.Empty;
}
