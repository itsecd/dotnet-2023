using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdmissionCommittee.Model;
/// <summary>
/// Relationship between Entrant and Result
/// </summary>
public class EntrantResult
{
    /// <summary>
    /// IdEntrantResult - int type value for storing the id entrantresult
    /// </summary>
    [Key]
    public int IdEntrantResult { get; set; }

    /// <summary>
    /// EntrantId - int value for storing the id entrant
    /// </summary>
    [ForeignKey("Entrant")]
    public int EntrantId { get; set; }

    /// <summary>
    /// Entrant - link to Entrant
    /// </summary>
    public Entrant? Entrant { get; set; }

    /// <summary>
    /// ResultId - int value for storing the id result
    /// </summary>
    [ForeignKey("Result")]
    public int ResultId { get; set; }

    /// <summary>
    /// Result - link to Result's Entrant
    /// </summary>
    public Result Result { get; set; } = null!;

    /// <summary>
    /// Mark - int value for storing mark for the subject
    /// </summary>
    public int Mark { get; set; }
}