namespace Polyclinic.Server.Dto;
/// <summary>
/// class describing the conclusion of the doctor on the admission of the patient
/// </summary>
public class CompletionPostDto
{
    /// <summary>
    /// conclusion - patient's diagnosis
    /// </summary>
    public string Conclusion { get; set; } = string.Empty;
    /// <summary>
    /// number of the doctor conducting the appointment
    /// </summary>
    public int IdDoctor { get; set; } = 0;
    /// <summary>
    /// number of the patient who came to the appointment
    /// </summary>
    public int IdPatient { get; set; } = 0;
    /// <summary>
    /// patient status (0 - on treatment, 1 - healthy)
    /// </summary>
    public int Status { get; set; } = 0;
}
