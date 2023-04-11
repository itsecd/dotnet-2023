namespace Policlinic;
/// <summary>
/// Reception describes a reception
/// </summary>
public class Reception
{
    /// <summary>
    /// Id is an int typed value of the reception's id
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// DateAndTime is a datetime value of the reception's date and time
    /// </summary>
    public DateTime DateAndTime { get; set; }
    /// <summary>
    /// Status is a string typed value of the reception's status ("On treatment" or "Healthy")
    /// </summary>
    public string Status { get; set; } = string.Empty;
    /// <summary>
    /// DoctorId is an int typed value for storing the id of the doctor
    /// </summary>
    public int DoctorId { get; set; }
    /// <summary>
    /// PatientId is an int typed value for storing the id of the Patient
    /// </summary>
    public int PatientId { get; set; }
    /// <summary>
    /// Conclusion is a string typed value of the conclusion (if status == "Healthy", this will be empty)
    /// </summary>
    public string Conclusion { get; set; } = string.Empty;
    /// <summary>
    /// Default Constructor
    /// </summary>
    public Reception() { }
    /// <summary>
    /// Constructor with parameters
    /// </summary>
    /// <param name="id"></param>
    /// <param name="dateAndTime"></param>
    /// <param name="status"></param>
    /// <param name="doctorId"></param>
    /// <param name="patientId"></param>
    /// <param name="conclution"></param>
    public Reception(int id, DateTime dateAndTime, string status, int doctorId, int patientId, string conclution)
    {
        Id = id;
        DateAndTime = dateAndTime;
        Status = status;
        DoctorId = doctorId;
        PatientId = patientId;
        Conclusion = conclution;
    }
    /// <summary>
    /// Redefined comparison function
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public override bool Equals(object? obj)
    {
        if (obj is not Reception param)
            return false;
        return //Doctor.Equals(param.Doctor) && Patient.Equals(param.Patient) &&
             DateAndTime == param.DateAndTime && Status == param.Status;
    }
    /// <summary>
    /// Redefined hash function
    /// </summary>
    /// <returns></returns>
    public override int GetHashCode()
    {
        return HashCode.Combine(Id);
    }
}
