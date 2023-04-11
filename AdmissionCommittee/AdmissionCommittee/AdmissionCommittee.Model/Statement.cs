namespace AdmissionCommittee.Model;
/// <summary>
/// Information about the entrant's statement
/// </summary>
public class Statement
{
    /// <summary>
    /// IdStatement - int value for storing the id statement
    /// </summary>
    public int IdStatement { get; set; }

    /// <summary>
    /// EntrantId - int value for storing the id entrant
    /// </summary>
    public int EntrantId { get; set; }

    /// <summary>
    /// Entrant - link to entrant
    /// </summary>
    public Entrant? Entrant { get; set; }

    /// <summary>
    /// StatementSpecialties - list storing relatioship between Statement and Specialty
    /// </summary>
    public List<StatementSpecialty> StatementSpecialties = new();
}