using System.ComponentModel.DataAnnotations;

namespace Polyclinic.Domain;
/// <summary>
/// class describing the patient
/// </summary>
public class Patient
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
    [Key]
    public int Id { get; set; } = 0;
    /// <summary>
    /// list of patient appointments
    /// </summary>
    public List<Registration> RegistrationsList { get; set; } = null!;
    /// <summary>
    /// list of doctor's conclusions issued to the patient
    /// </summary>
    public List<Completion> CompletionList { get; set; } = null!;
    public Patient(int passportNumber, string fullName, DateTime dateBirth, string address, int id)
    {
        PassportNumber = passportNumber;
        FullName = fullName;
        DateBirth = dateBirth;
        Address = address;
        Id = id;
        RegistrationsList = new List<Registration>();
        CompletionList = new List<Completion>();
    }

    public Patient()
    {
    }
}
