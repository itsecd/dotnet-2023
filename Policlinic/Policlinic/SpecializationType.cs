namespace Policlinic;

/// <summary>
/// SpecializationType describes specializations of doctors
/// </summary>
public class SpecializationType
{
    /// <summary>
    /// Id is an int typed value for storing Id of the specialization
    /// </summary>
    public int Id;
    /// <summary>
    /// Specialization is a string typed value representing the name of specialization
    /// </summary>
    public string Specialization { get; set; } = string.Empty;

    public SpecializationType() { }

    public SpecializationType(int id, string specialization)
    {
        Id = id;
        Specialization = specialization;
    }

    public override bool Equals(object? obj)
    {
        if (obj is not SpecializationType param)
            return false;
        return Specialization == param.Specialization && Id == param.Id;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Id);
    }
}
