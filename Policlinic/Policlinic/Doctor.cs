namespace Policlinic;
/// <summary>
/// Doctor describes a doctor
/// </summary>
public class Doctor
{
    /// <summary>
    /// Passport is a long int typed value of the passport series and number
    /// </summary>
    public long Passport { get; set; }
    /// <summary>
    /// Fio is a string typed value for storing the name, surname and patronymic of the doctor
    /// </summary>
    public string Fio { get; set; } = string.Empty;
    /// <summary>
    /// BirthDate is a datetime value of a doctor's birthday
    /// </summary>
    public DateTime BirthDate { get; set; } = DateTime.MinValue;
    /// <summary>
    /// WorkExperience is an int typed value of the doctor's work experience
    /// </summary>
    public int WorkExperience { get; set; }
    /// <summary>
    /// IdSpecialization is an int typed value for storing the id of a specialization
    /// </summary>
    public Specialization Specializations { get; set; } = new Specialization();

    public List<Reception> Receptions { get; set; } = new List<Reception>();

    public Doctor() { }

    public Doctor(long passport, string fio, DateTime birthDate, int workExperience, Specialization specializations, List<Reception> receptions)
    {
        Passport = passport;
        Fio = fio;
        BirthDate = birthDate;
        WorkExperience = workExperience;
        Specializations = specializations;
        Receptions = receptions;
    }

    public override bool Equals(object? obj)
    {
        if (obj is not Doctor param)
            return false;
        return Passport == param.Passport && Fio == param.Fio && BirthDate == param.BirthDate && WorkExperience == param.WorkExperience && Specializations == param.Specializations && Receptions == param.Receptions;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Passport);
    }
}
