using System.ComponentModel.DataAnnotations;
namespace Policlinic;

/// <summary>
/// Specialization describes specializations of doctors
/// </summary>
public class Specialization
{
    /// <summary>
    /// Id is an int typed value for storing Id of the specialization
    /// </summary>
    [Key]
    public int Id { get; set; }
    /// <summary>
    /// NameSpecialization is a string typed value representing the name of specialization
    /// </summary>
    public string NameSpecialization { get; set; } = string.Empty;
    /// <summary>
    /// Doctors is a list of doctors
    /// </summary>
    public List<Doctor>? Doctors { get; set; }
    /// <summary>
    /// Default Constructor
    /// </summary>
    public Specialization() { }
    /// <summary>
    /// Constructor with parameters
    /// </summary>
    /// <param name="id">Specialization's id</param>
    /// <param name="nameSpecialization">Specialization's name</param>
    public Specialization(int id, string nameSpecialization)
    {
        Id = id;
        NameSpecialization = nameSpecialization;
    }
    /// <summary>
    /// Redefined comparison function
    /// </summary>
    /// <param name="obj"></param>
    /// <returns>Bool value representing are objects equal or not</returns>
    public override bool Equals(object? obj)
    {
        if (obj is not Specialization param)
            return false;
        return NameSpecialization == param.NameSpecialization && Id == param.Id;
    }
    /// <summary>
    /// Redefined hash function
    /// </summary>
    /// <returns>Hash code of Id</returns>
    public override int GetHashCode()
    {
        return HashCode.Combine(Id);
    }
}
