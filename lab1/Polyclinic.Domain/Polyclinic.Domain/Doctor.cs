namespace Polyclinic.Domain;
public class Doctor
{
    public int PassportNumber { get; set; } = 0;
    public string FullName { get; set; } = string.Empty;
    public DateOnly DateBirth { get; set; } = new DateOnly();
    public string Specialization { get; set; } = string.Empty;
    public int WorkExperience { get; set; } = 0;
    public int Id { get; set; } = 0;

    public Doctor(int passportNumber, string fullName, DateOnly dateBirth, string specialization, int workExperience, int id)
    {
        PassportNumber = passportNumber;
        FullName = fullName;
        DateBirth = dateBirth;
        Specialization = specialization;
        WorkExperience = workExperience;
        Id = id;
    }
}
