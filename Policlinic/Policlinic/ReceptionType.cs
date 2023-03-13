namespace Policlinic;
/// <summary>
/// ReceptionType describes a reception
/// </summary>
public class ReceptionType
{
    /// <summary>
    /// IdReception is an int typed value of the reception's id
    /// </summary>
    public int IdReception { get; set; }
    /// <summary>
    /// DateAndTime is a datetime value of the reception's date and time
    /// </summary>
    public DateTime DateAndTime { get; set; }
    /// <summary>
    /// Status is a string typed value of the reception's status ("На лечении" or "Здоров")
    /// </summary>
    public string Status { get; set; } = string.Empty;
    /// <summary>
    /// PassportDoctor is a long int typed value for storing the doctor's passport series and number
    /// </summary>
    public long PassportDoctor { get; set; }
    /// <summary>
    /// PassportPatient is a long int typed value for storing the patient's passport series and number
    /// </summary>
    public long PassportPatient { get; set; }
    /// <summary>
    /// Conclution is a string typed value of the conclution (if status == "Здоров", this will be empty)
    /// </summary>
    public string Conclution { get; set; } = string.Empty;

    public ReceptionType() { }

    public ReceptionType(DateTime dateAndTime, string status, long doctor, long patient, string conclution)
    {
        DateAndTime = dateAndTime;
        Status = status;
        PassportDoctor = doctor;
        PassportPatient = patient;
        Conclution = conclution;
    }

    public override bool Equals(object? obj)
    {
        if (obj is not ReceptionType param)
            return false;
        return PassportDoctor.Equals(param.PassportDoctor) && PassportPatient.Equals(param.PassportPatient) &&
             DateAndTime == param.DateAndTime && Status == param.Status;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(IdReception);
    }
}
