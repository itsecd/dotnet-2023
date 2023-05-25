using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;

namespace Department.Domain;

/// <summary>
/// Class Course has info about all courses at the department
/// </summary>

[Table("course")]
public class Course
{
    /// <summary>
    /// Course id
    /// </summary>
    [Column("id")]
    public int Id { get; set; }

    /// <summary>
    /// Subject
    /// </summary>
    [Column("subject_name")]
    public string SubjectName { get; set; } = string.Empty;

    /// <summary>
    /// Id of subject
    /// </summary>
    [Column("subject_id")]
    public int SubjectId { get; set; }

    /// <summary>
    /// Connection to another class
    /// </summary>
    public Subject? Subject { get; set; }

    /// <summary>
    /// Type of course (lectures, practices, laboratory work, etc.)
    /// </summary>
    [Column("course_type")]
    public string CourseType { get; set; } = string.Empty;

    /// <summary>
    /// Hours per semester
    /// </summary>
    [Column("semester_hours")]
    public int SemesterHours { get; set; }

    /// <summary>
    /// Group
    /// </summary>
    [Column("group_id")]
    public int GroupId { get; set; }

    /// <summary>
    /// Connection to another class
    /// </summary>
    public Group? Group { get; set; }

    /// <summary>
    /// Teacher
    /// </summary>
    [Column("teachers_name")]
    public string TeachersName { get; set; } = string.Empty;

    /// <summary>
    /// Teacher's id
    /// </summary>
    [Column("teacher_id")]
    public int TeacherId { get; set; }

    /// <summary>
    /// Connection to another class
    /// </summary>
    public Teacher? Teacher { get; set;}
}
