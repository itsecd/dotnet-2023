namespace AdmissionCommittee.Server.Dto;
/// <summary>
/// Relationship between Statement and Specialty
/// </summary>
public class StatementSpecialtyGetDto
{
    /// <summary>
    /// IdStatementSpecialty - int value for storing the id StatementSpecialty
    /// </summary>
    public int IdStatementSpecialty { get; set; }

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