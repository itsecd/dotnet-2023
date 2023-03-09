namespace AdmissionCommittee;
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
    /// PrioritySpecialities - dictionary value for storing specialities and their priority
    /// </summary>
    public Dictionary<Speciality, int> PrioritySpecialities = new();

    public Statement(int idStatement, Dictionary<Speciality, int> prioritySpecialities)
    {
        IdStatement = idStatement;
        PrioritySpecialities = prioritySpecialities;
    }
}