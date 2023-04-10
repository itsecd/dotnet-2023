namespace Polyclinic.Server.Dto;
/// <summary>
/// class describing the patient
/// </summary>
public class PatientGetDto
{
    /// <summary>
    /// patient passport number
    /// </summary>
    public int PassportNumber { get; set; } = 0;
    /// <summary>
    /// full name of the patient
    /// </summary>
    public string FullName { get; set; } = string.Empty;
    /// <summary>
    /// patient's date of birth
    /// </summary>
    public DateTime DateBirth { get; set; } = new DateTime();
    /// <summary>
    /// patient's address
    /// </summary>
    public string Address { get; set; } = string.Empty;
    /// <summary>
    /// individual patient number
    /// </summary>
    public int Id { get; set; } = 0;
}
