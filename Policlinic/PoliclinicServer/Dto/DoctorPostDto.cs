namespace PoliclinicServer.Dto;

/// <summary>
/// DoctorPostDto is for HTTP POST request
/// </summary>
public class DoctorPostDto
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
    /// SpecializationId is an int typed value for storing the id of a specialization
    /// </summary>
    public int SpecializationId { get; set; }

    /// <summary>
    /// ReceptionId is an int typed value for storing the id of a reception
    /// </summary>
    public int ReceptionId { get; set; }
}
