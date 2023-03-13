namespace Policlinic;

/// <summary>
/// PatientType describes a patient
/// </summary>
public class PatientType
{
    /// <summary>
    /// Passport is a long int typed value of the passport series and number
    /// </summary>
    public long Passport { get; set; }
    /// <summary>
    ///  FIO is a string typed value for storing the name, surname and patronymic of the patient
    /// </summary>
    public string FIO { get; set; } = string.Empty;
    /// <summary>
    /// BirthDate is a datetime value of a doctor's birthday
    /// </summary>
    public DateTime BirthDate { get; set; } = DateTime.MinValue;
    /// <summary>
    /// Address is a string typed value of the patient's address
    /// </summary>
    public string Address { get; set; } = string.Empty;

    public PatientType() { }

    public PatientType(long passport, string fIO, DateTime birthDate, string address)
    {
        Passport = passport;
        FIO = fIO;
        BirthDate = birthDate;
        Address = address;
    }

    public override bool Equals(object? obj)
    {
        if (obj is not PatientType param)
            return false;
        return Passport == param.Passport && FIO == param.FIO && BirthDate == param.BirthDate && Address == param.Address;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Passport);
    }
}
