namespace RecruitmentAgency;

/// <summary>
/// Class of employee seeker
/// </summary>
public class Employer
{
    /// <summary>
    /// Name of company or person
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Name of recruiter
    /// </summary>
    public string ContactName { get; set; }

    /// <summary>
    /// Phone number of recruiter
    /// </summary>
    public string PhoneNumber { get; set; }

    /// <summary>
    /// List of all employer applications
    /// </summary>
    public List<EmployerApplication> EmployerApplicationList { get; set; } = new List<EmployerApplication>();

    /// <summary>
    /// Unique ID of employer
    /// </summary>
    public uint Id { get; }

    /// <summary>
    /// Emplyer counter
    /// </summary>
    private static uint _employerCount = 0;

    /// <summary>
    /// Construct Employer object
    /// </summary>
    public Employer(string name, string contactName, string phoneNumber)
    {
        Name = name;
        ContactName = contactName;
        PhoneNumber = phoneNumber;
        Id = _employerCount++;
    }
}