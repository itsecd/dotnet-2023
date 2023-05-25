using System.ComponentModel.DataAnnotations.Schema;

namespace Department.Domain;

/// <summary>
/// Class Subject has the info about all subjects
/// </summary>

[Table("subject")]
public class Subject
{
    /// <summary>
    /// Subject's id
    /// </summary>
    [Column("id")]
    public int Id { get; set; }

    /// <summary>
    /// Subject's name
    /// </summary>
    [Column("name")]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Subject's semester
    /// </summary>
    [Column("semester")]
    public int Semester { get; set; }
}
