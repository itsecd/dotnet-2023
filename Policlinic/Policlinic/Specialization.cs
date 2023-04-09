namespace Policlinic;

/// <summary>
/// Specialization describes specializations of doctors
/// </summary>
public class Specialization
{
    /// <summary>
    /// Id is an int typed value for storing Id of the specialization
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// NameSpecialization is a string typed value representing the name of specialization
    /// </summary>
    public string NameSpecialization { get; set; } = string.Empty;
    /// <summary>
    /// Default Constructor
    /// </summary>
    public Specialization() { }
    /// <summary>
    /// Constructor with parameters
    /// </summary>
    /// <param name="id"></param>
    /// <param name="specialization"></param>
    public Specialization(int id, string specialization)
    {
        Id = id;
        NameSpecialization = specialization;
    }
    /// <summary>
    /// Redefined comparison function
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public override bool Equals(object? obj)
    {
        if (obj is not Specialization param)
            return false;
        return NameSpecialization == param.NameSpecialization && Id == param.Id;
    }
    /// <summary>
    /// Redefined hash function
    /// </summary>
    /// <returns></returns>
    public override int GetHashCode()
    {
        return HashCode.Combine(Id);
    }
}
