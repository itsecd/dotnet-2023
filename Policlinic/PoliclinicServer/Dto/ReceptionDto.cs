namespace PoliclinicServer.Dto;
/// <summary>
/// ReceptionDto is for HTTP GET and POST requests
/// </summary>
public class ReceptionDto
{
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
}
