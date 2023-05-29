using System.ComponentModel.DataAnnotations.Schema;

namespace Department.Domain;

/// <summary>
/// Class Group has the info about all groups
/// </summary>
[Table("group")]
public class Group
{
    /// <summary>
    /// Group id
    /// </summary>
    [Column("id")]
    public int Id { get; set; }

    /// <summary>
    /// Group number
    /// </summary>
    [Column("group_number")]
    public int GroupNumber { get; set; }

    /// <summary>
    /// Amount of students
    /// </summary>
    [Column("student_amount")]
    public int StudentAmount { get; set; }

    /// <summary>
    /// Type of education (full-time education, evening education, extramural studies)
    /// </summary>
    [Column("education_type")]
    public string EducationType { get; set; } = string.Empty;
}
