namespace Polyclinic.Domain;
public class Specializations
{
    public int IdSpecialization { get; set; } = 0;
    public string NameSpecialization { get; set; } = string.Empty;

    public Specializations(int idSpecialization, string nameSpecialization)
    {
        IdSpecialization = idSpecialization;
        NameSpecialization = nameSpecialization;
    }
}
