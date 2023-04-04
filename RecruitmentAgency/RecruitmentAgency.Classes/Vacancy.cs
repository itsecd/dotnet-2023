namespace RecruitmentAgency.Classes;

/// <summary>
/// Class of vacancy
/// </summary>
public class Vacancy
{
    /// <summary>
    /// Sector of vacancy
    /// </summary>
    public string Sector { get; set; }

    /// <summary>
    /// Name of vacancy (duty)
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// List of all employee applications for that vacancy
    /// </summary>
    public List<EmployeeApplication> EmployeeApplicationList { get; set; } = new List<EmployeeApplication>();

    /// <summary>
    /// List of all employer applications for that vacancy
    /// </summary>
    public List<EmployerApplication> EmployerApplicationList { get; set; } = new List<EmployerApplication>();

    /// <summary>
    /// Unique ID of Vacancy
    /// </summary>
    public uint Id { get; }

    /// <summary>
    /// Construct Vacancy object
    /// </summary>
    public Vacancy(string sector, string name, uint id)
    {
        Sector = sector;
        Name = name;
        Id = id;
    }
}
