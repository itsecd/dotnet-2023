using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdmissionCommittee.Model;
/// <summary>
/// Relationship between Statement and Specialty
/// </summary>
public class StatementSpecialty
{
    /// <summary>
    /// IdStatementSpecialty - int value for storing the id StatementSpecialty
    /// </summary>
    [Key]
    public int IdStatementSpecialty { get; set; }

    /// <summary>
    /// StatementId - int value for storing the id Statement
    /// </summary>
    [ForeignKey("StatementSpecialty")]
    public int StatementId { get; set; }

    /// <summary>
    /// Statement - link to statement
    /// </summary>
    public Statement Statement { get; set; } = null!;

    /// <summary>
    /// SpecialtyId - int value for storing the id Specialty
    /// </summary>
    [ForeignKey("Specialty")]
    public int SpecialtyId { get; set; }

    /// <summary>
    /// Specialty - link to specialty
    /// </summary>
    public Specialty Specialty { get; set; } = null!;

    /// <summary>
    /// Priority - int value storing priority of specialty
    /// </summary>
    public int Priority { get; set; }
}