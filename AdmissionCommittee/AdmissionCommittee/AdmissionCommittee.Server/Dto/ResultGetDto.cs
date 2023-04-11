namespace AdmissionCommittee.Server.Dto;
/// <summary>
/// Information about the result of the entrant's exam
/// </summary>
public class ResultGetDto
{
    /// <summary>
    /// IdResult - int value for storing the id result
    /// </summary>
    public int IdResult { get; set; }

    /// <summary>
    /// NameSubject - string value for storing the name of the subject(exam)
    /// </summary>
    public string NameSubject { get; set; } = string.Empty;
}