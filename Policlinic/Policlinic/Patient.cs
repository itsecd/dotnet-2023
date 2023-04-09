namespace Policlinic;

/// <summary>
/// Patient describes a patient
/// </summary>
public class Patient
{
    /// <summary>
    /// IdDoctor is an int typed value of the doctor's id
    /// </summary>
    public int IdPatient { get; set; }
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
    /// <summary>
    /// Receptions is a list of receptions
    /// </summary>
    public List<Reception> Receptions { get; set; } = new List<Reception>();
    /// <summary>
    /// ReceptionId is an int typed value for storing the id of a reception
    /// </summary>
    public int ReceptionId { get; set; }
    /// <summary>
    /// Default Constructor
    /// </summary>
    public Patient() { }
    /// <summary>
    /// Constructor with parameters
    /// </summary>
    /// <param name="idPatient"></param>
    /// <param name="passport"></param>
    /// <param name="fio"></param>
    /// <param name="birthDate"></param>
    /// <param name="address"></param>
    /// <param name="receptions"></param>
    /// <param name="receptionId"></param>
    public Patient(int idPatient, long passport, string fio, DateTime birthDate, string address, List<Reception> receptions, int receptionId)
    {
        IdPatient = idPatient;
        Passport = passport;
        Fio = fio;
        BirthDate = birthDate;
        Address = address;
        Receptions = receptions;
        ReceptionId = receptionId;
    }
    /// <summary>
    /// Redefined comparison function
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public override bool Equals(object? obj)
    {
        if (obj is not Patient param)
            return false;
        return Passport == param.Passport && Fio == param.Fio && BirthDate == param.BirthDate && Address == param.Address && Receptions == param.Receptions && ReceptionId == param.ReceptionId;
    }
    /// <summary>
    /// Redefined hash function
    /// </summary>
    /// <returns></returns>
    public override int GetHashCode()
    {
        return HashCode.Combine(Passport);
    }
}
