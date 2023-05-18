namespace Department.Domain;

/// <summary>
/// Class Course has info about all courses at the department
/// </summary>
public class Course
{
    /// <summary>
    /// Subject
    /// </summary>
    public Subject Subject { get; set; } = new Subject();

    /// <summary>
    /// Type of course (lectures, practices, laboratory work, etc.)
    /// </summary>
    public string CourseType { get; set; } = string.Empty;

    /// <summary>
    /// Hours per semester
    /// </summary>
    public uint SemesterHours { get; set; }

    /// <summary>
    /// Group
    /// </summary>
    public Group Group { get; set; } = new Group();

    /// <summary>
    /// Teacher
    /// </summary>
    public Teacher Teacher { get; set; } = new Teacher();
}
