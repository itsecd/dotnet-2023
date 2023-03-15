namespace Policlinic;

/// <summary>
/// Patient describes a patient
/// </summary>
public class Patient
{
    /// <summary>
    /// Passport is a long int typed value of the passport series and number
    /// </summary>
    public long Passport { get; set; }
    /// <summary>
    ///  Fio is a string typed value for storing the name, surname and patronymic of the patient
    /// </summary>
    public string Fio { get; set; } = string.Empty;
    /// <summary>
    /// BirthDate is a datetime value of a doctor's birthday
    /// </summary>
    public DateTime BirthDate { get; set; } = DateTime.MinValue;
    /// <summary>
    /// Address is a string typed value of the patient's address
    /// </summary>
    public string Address { get; set; } = string.Empty;

    public List<Reception> Receptions { get; set; } = new List<Reception>();

    public Patient() { }

    public Patient(long passport, string fio, DateTime birthDate, string address, List<Reception> receptions)
    {
        Passport = passport;
        Fio = fio;
        BirthDate = birthDate;
        Address = address;
        Receptions = receptions;
    }

    public override bool Equals(object? obj)
    {
        if (obj is not Patient param)
            return false;
        return Passport == param.Passport && Fio == param.Fio && BirthDate == param.BirthDate && Address == param.Address && Receptions == param.Receptions;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Passport);
    }
}
