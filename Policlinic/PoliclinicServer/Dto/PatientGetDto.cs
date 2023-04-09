namespace PoliclinicServer.Dto;
/// <summary>
/// Patient is for HTTP GET request
/// </summary>
public class PatientGetDto
{
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
    /// ReceptionId is an int typed value for storing the id of a reception
    /// </summary>
    public int ReceptionId { get; set; }
}
