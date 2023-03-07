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
    public DateOnly DateBirth { get; set; } = new DateOnly();
    /// <summary>
    /// doctor's specialization     
    /// </summary>
    public string Specialization { get; set; } = string.Empty;
    /// <summary>
    /// doctor's work experience
    /// </summary>
    public int WorkExperience { get; set; } = 0;
    /// <summary>
    /// doctor's id
    /// </summary>
    public int Id { get; set; } = 0;
    /// <summary>
    /// list of appointments for this doctor
    /// </summary>
    public List<int> RegistrationsList { get; set; }
    /// <summary>
    /// list of conclusions made by this doctor
    /// </summary>
    public List<int> CompletionsList { get; set; }
    public Doctor(int passportNumber, string fullName, DateOnly dateBirth, string specialization, int workExperience, int id)
    {
        PassportNumber = passportNumber;
        FullName = fullName;
        DateBirth = dateBirth;
        Specialization = specialization;
        WorkExperience = workExperience;
        Id = id;
        RegistrationsList = new List<int>();
        CompletionsList = new List<int>();
    }
    /// <summary>
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
    }

}
