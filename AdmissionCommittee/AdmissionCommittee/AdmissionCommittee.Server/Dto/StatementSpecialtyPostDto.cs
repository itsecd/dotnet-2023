namespace AdmissionCommittee.Server.Dto;
/// <summary>
/// Relationship between Statement and Specialty
/// </summary>
public class StatementSpecialtyPostDto
{
    /// <summary>
    /// StatementId - int value for storing the id Statement
    /// </summary>
    public int StatementId { get; set; }

    /// <summary>
    /// SpecialtyId - int value for storing the id Specialty
    /// </summary>
    public int SpecialtyId { get; set; }

    /// <summary>
    /// Priority - int value storing priority of specialty
    /// </summary>
    public int Priority { get; set; }
}