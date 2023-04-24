using System.ComponentModel.DataAnnotations;

namespace AdmissionCommittee.Model;
/// <summary>
/// Information about the result of the entrant's exam
/// </summary>
public class Result
{
    /// <summary>
    /// IdResult - int value for storing the id result
    /// </summary>
    [Key]
    public int IdResult { get; set; }

    /// <summary>
    /// NameSubject - string value for storing the name of the subject(exam)
    /// </summary>
    public string NameSubject { get; set; } = string.Empty;

    /// <summary>
    /// EntrantResults - list storing relatioship between Entrant and Result
    /// </summary>
    public List<EntrantResult> EntrantResults = new();
}