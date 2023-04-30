using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Polyclinic.Domain;
/// <summary>
/// a class describing a patient's appointment with a doctor
/// </summary>
public class Registration
{
    /// <summary>
    /// admission record number
    /// </summary>
    [Key]
    public int Id { get; set; } = 0;
    /// <summary>
    /// individual number of the patient registered for the appointment
    /// </summary>
    [ForeignKey("Patient")]
    public int IdPatient { get; set; } = 0;
    /// <summary>
    /// individual number of the doctor to whom the patient is registered
    /// </summary>
    [ForeignKey("Doctor")]
    public int IdDoctor { get; set; } = 0;
    /// <summary>
    /// date and time of the appointment
    /// </summary>
    public DateTime TimeAdmission { get; set; } = new DateTime();

    public Registration(int id, int idPatient, int idDoctor, DateTime timeAdmission)
    {
        Id = id;
        IdPatient = idPatient;
        IdDoctor = idDoctor;
        TimeAdmission = timeAdmission;
    }

    public Registration()
    {
    }
}
