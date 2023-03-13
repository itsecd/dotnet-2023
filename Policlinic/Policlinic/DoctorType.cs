namespace Policlinic;
/// <summary>
/// DoctorType describes a doctor
/// </summary>
public class DoctorType
{
    /// <summary>
    /// Passport is a long int typed value of the passport series and number
    /// </summary>
    public long Passport { get; set; }
    /// <summary>
    /// FIO is a string typed value for storing the name, surname and patronymic of the doctor
    /// </summary>
    public string FIO { get; set; } = string.Empty;
    /// <summary>
    /// BirthDate is a datetime value of a doctor's birthday
    /// </summary>
    public DateTime BirthDate { get; set; }
    /// <summary>
    /// WorkExperience is an int typed value of the doctor's work experience
    /// </summary>
    public int WorkExperience { get; set; }
    /// <summary>
    /// IdSpecialization is an int typed value for storing the id of a specialization
    /// </summary>
    public int IdSpecialization { get; set; }

    public DoctorType() { }

    public DoctorType(long passport, string fIO, DateTime birthDate, int workExperience, int idSpecialization)
    {
        Passport = passport;
        FIO = fIO;
        BirthDate = birthDate;
        WorkExperience = workExperience;
        IdSpecialization = idSpecialization;
    }

    public override bool Equals(object? obj)
    {
        if (obj is not DoctorType param)
            return false;
        return Passport == param.Passport && FIO == param.FIO && BirthDate == param.BirthDate && WorkExperience == param.WorkExperience && IdSpecialization == param.IdSpecialization;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Passport);
    }
}
