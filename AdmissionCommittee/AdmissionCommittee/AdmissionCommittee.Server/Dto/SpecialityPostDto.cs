namespace AdmissionCommittee.Server.Dto;

/// <summary>
/// Information about the speciality
/// </summary>
public class SpecialityPostDto
{
    /// <summary>
    /// Cypher - string value for storing a speciality cypher
    /// </summary>
    public string Cypher { get; set; }

    /// <summary>
    /// NameSpeciality - string value for storing the name speciality
    /// </summary>
    public string NameSpeciality { get; set; }

    /// <summary>
    /// Faculty - string value for storing the name faculty
    /// </summary>
    public string Faculty { get; set; }
}
