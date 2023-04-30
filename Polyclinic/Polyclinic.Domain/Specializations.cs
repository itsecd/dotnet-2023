namespace Polyclinic.Domain;

/// <summary>
/// class reference book containing specialties of doctors
/// </summary>
public class Specializations
{
    /// <summary>
    /// specialty identifier
    /// </summary>
    public int Id { get; set; } = 0;
    /// <summary>
    /// name of specialty
    /// </summary>
    public string NameSpecialization { get; set; } = string.Empty;

    public Specializations(int id, string nameSpecialization)
    {
        Id = id;
        NameSpecialization = nameSpecialization;
    }

    public Specializations()
    {
    }
}
