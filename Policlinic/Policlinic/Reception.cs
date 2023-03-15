namespace Policlinic;
/// <summary>
/// Reception describes a reception
/// </summary>
public class Reception
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
    /// Status is a string typed value of the reception's status ("On treatment" or "Healthy")
    /// </summary>
    public string Status { get; set; } = string.Empty;
    /// <summary>
    /// Doctor is a value for storing the data about the doctor
    /// </summary>
    public Doctor Doctor { get; set; } = new Doctor();
    /// <summary>
    /// Patient is a value for storing the data about the patient
    /// </summary>
    public Patient Patient { get; set; } = new Patient();
    /// <summary>
    /// Conclution is a string typed value of the conclution (if status == "Healthy", this will be empty)
    /// </summary>
    public string Conclusion { get; set; } = string.Empty;

    public Reception() { }

    public Reception(int idReception, DateTime dateAndTime, string status, Doctor doctor, Patient patient, string conclution)
    {
        IdReception = idReception;
        DateAndTime = dateAndTime;
        Status = status;
        Doctor = doctor;
        Patient = patient;
        Conclusion = conclution;
    }

    public override bool Equals(object? obj)
    {
        if (obj is not Reception param)
            return false;
        return Doctor.Equals(param.Doctor) && Patient.Equals(param.Patient) &&
             DateAndTime == param.DateAndTime && Status == param.Status;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(IdReception);
    }
}
