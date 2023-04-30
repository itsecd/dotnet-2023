using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Polyclinic.Domain;
/// <summary>
/// class describing doctor
/// </summary>
public class Doctor
{
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
    [ForeignKey("Specializations")]
    public int IdSpecialization { get; set; } = 0;
    /// <summary>
    /// doctor's work experience
    /// </summary>
    public int WorkExperience { get; set; } = 0;
    /// <summary>
    /// doctor's id
    /// </summary>
    [Key]
    public int Id { get; set; } = 0;
    /// <summary>
    /// list of appointments for this doctor
    /// </summary>
    public List<Registration> RegistrationsList { get; set; } = null!;
    /// <summary>
    /// list of conclusions made by this doctor
    /// </summary>
    public List<Completion> CompletionsList { get; set; } = null!;
    public Doctor(int passportNumber, string fullName, DateTime dateBirth, int specialization, int workExperience, int id)
    {
        PassportNumber = passportNumber;
        FullName = fullName;
        DateBirth = dateBirth;
        IdSpecialization = specialization;
        WorkExperience = workExperience;
        Id = id;
        RegistrationsList = new List<Registration>();
        CompletionsList = new List<Completion>();
    }

    public Doctor()
    {
    }

    /*/// <summary>
    /// method for adding an appointment to the doctor's list of appointments
    /// </summary>
    public void AddToRegList(int id)
    {
        RegistrationsList.Add(id);
    }
    /// <summary>
    /// method for adding admission conclusions to the list of doctor's conclusions
    /// </summary>
    public void AddToComList(int id)
    {
        RegistrationsList.Add(id);
    }*/

}
