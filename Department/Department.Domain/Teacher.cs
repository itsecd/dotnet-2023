using System.ComponentModel.DataAnnotations.Schema;

namespace Department.Domain;

/// <summary>
/// Class Teacher has the info about all teachers
/// </summary>

[Table("teacher")]
public class Teacher
{
    /// <summary>
    /// Teacher's id
    /// </summary>
    [Column("id")]
    public int Id { get; set;  }
    /// <summary>
    /// Teacher's full name
    /// </summary>
    [Column("full_name")]
    public string FullName { get; set; } = string.Empty;

    /// <summary>
    /// Teacher's academic degree
    /// </summary>
    [Column("degree")]
    public string Degree { get; set; } = string.Empty;
}
