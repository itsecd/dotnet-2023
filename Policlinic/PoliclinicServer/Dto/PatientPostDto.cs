namespace PoliclinicServer.Dto;
/// <summary>
/// PatientPostDto is for HTTP POST request
/// </summary>
public class PatientPostDto
{
    /// <summary>
    ///  Fio is a string typed value for storing the name, surname and patronymic of the patient
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
}
