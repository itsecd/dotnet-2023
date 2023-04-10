namespace Polyclinic.Server.Dto;

public class DoctorGetDto
{
    /// <summary>
    /// doctor's id
    /// </summary>
    public int Id { get; set; } = 0;

    /// <summary>
    /// doctor's passport number
    /// </summary>
    public int PassportNumber { get; set; } = 0;
    /// <summary>
    /// doctor's full name
    /// </summary>
    public string FullName { get; set; } = string.Empty;
    /// <summary>
    /// doctor's date of birth
    /// </summary>
    public DateTime DateBirth { get; set; } = new DateTime();
    /// <summary>
    /// doctor's specialization id
    /// </summary>
    public int IdSpecialization { get; set; } = 0;
    /// <summary>
    /// doctor's work experience
    /// </summary>
    public int WorkExperience { get; set; } = 0;

}
