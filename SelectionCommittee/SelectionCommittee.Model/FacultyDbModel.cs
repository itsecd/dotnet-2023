using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SelectionCommittee.Model;

/// <summary>
/// Факультет.
/// </summary>
[Table("faculty")]
public class FacultyDbModel
{
    /// <summary>
    /// Идентификатор.
    /// </summary>
    [Column("id")]
    [Key]
    public int Id { get; set; }

    /// <summary>
    /// Название.
    /// </summary>
    [Column("name")]
    [Required]
    public string Name { get; set; }
}
