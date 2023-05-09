namespace PoliclinicServer.Dto;

/// <summary>
/// DoctorGetDto is for HTTP GET request
/// </summary>
public class DoctorGetDto
{
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
    /// SpecializationId is an int typed value for storing the id of a specialization
    /// </summary>
    public int SpecializationId { get; set; }
}
