namespace AdmissionCommittee;
/// <summary>
/// Information about the speciality
/// </summary>
public class Speciality
{
    /// <summary>
    /// IdSpeciality - int value for storing the id speciality
    /// </summary>
    public int IdSpeciality { get; set; }
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

    public Speciality(int idSpeciality, string cypher, string nameSpeciality, string faculty)
    {
        IdSpeciality = idSpeciality;
        Cypher = cypher;
        NameSpeciality = nameSpeciality;
        Faculty = faculty;
    }
}
