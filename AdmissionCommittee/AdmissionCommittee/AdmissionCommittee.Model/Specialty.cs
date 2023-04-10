namespace AdmissionCommittee.Model;
/// <summary>
/// Information about the speciality
/// </summary>
public class Specialty
{
    /// <summary>
    /// IdSpeciality - int value for storing the id speciality
    /// </summary>
    public int IdSpeciality { get; set; }
    /// <summary>
    /// Cypher - string value for storing a speciality cypher
    /// </summary>
    public string Cypher { get; set; } = string.Empty;

    /// <summary>
    /// NameSpeciality - string value for storing the name speciality
    /// </summary>
    public string NameSpeciality { get; set; } = string.Empty;

    /// <summary>
    /// Faculty - string value for storing the name faculty
    /// </summary>
    public string Faculty { get; set; } = string.Empty;

    /// <summary>
    /// StatementSpecialties - list storing relatioship between Statement and Specialty
    /// </summary>
    public List<StatementSpecialty> StatementSpecialties = new();
}