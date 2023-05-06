using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SelectionCommittee.Model;

/// <summary>
/// Результат экзамена.
/// </summary>
[Table("exam_result")]
public class ExamResultDbModel
{
    /// <summary>
    /// Идентификатор.
    /// </summary>
    [Column("id")]
    [Key]
    public int Id { get; set; }

    /// <summary>
    /// Название предмета.
    /// </summary>
    [Column("subject_name")]
    [Required]
    public string SubjectName { get; set; }

    /// <summary>
    /// Количество баллов.
    /// </summary>
    [Column("points")]
    [Required]
    public int Points { get; set; }

    /// <summary>
    /// Идентификатор абитуриента.
    /// </summary>
    [Column("enrollee_id")]
    [Required]
    public int EnrolleeId { get; set; }

    /// <summary>
    /// Абитуриент.
    /// </summary>
    public EnrolleeDbModel? Enrollee { get; set; }
}
