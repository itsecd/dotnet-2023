using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SelectionCommittee.Model;

/// <summary>
/// Специальность.
/// </summary>
[Table("specialization")]
public class SpecializationDbModel
{
    /// <summary>
    /// Идентификатор.
    /// </summary>
    [Column("id")]
    [Key]
    public int Id { get; set; }

    /// <summary>
    /// Приоритет.
    /// </summary>
    [Column("priority")]
    [Required]
    public int Priority { get; set; }

    /// <summary>
    /// Название.
    /// </summary>
    [Column("name")]
    [Required]
    public string Name { get; set; }

    /// <summary>
    /// Идентификатор факультета.
    /// </summary>
    [Column("faculty_id")]
    [Required]
    public int FacultyId { get; set; }

    /// <summary>
    /// Факультет.
    /// </summary>
    public FacultyDbModel? Faculty { get; set; }
}
