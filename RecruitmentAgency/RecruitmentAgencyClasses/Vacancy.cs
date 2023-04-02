namespace RecruitmentAgency;

/// <summary>
/// Class of vacancy
/// </summary>
public class Vacancy
{
    /// <summary>
    /// Sector of vacancy
    /// </summary>
    public string? Sector { get; set; }

    /// <summary>
    /// Name of vacancy (duty)
    /// </summary>
	public string? Name { get; set; }

    /// <summary>
    /// List of all employee applications for that vacancy
    /// </summary>
    public List<EmployeeApplication> EmployeeApplicationsList { get; set; } = new List<EmployeeApplication>();

    /// <summary>
    /// List of all employer applications for that vacancy
    /// </summary>
    public List<EmployerApplication> EmployerApplicationsList { get; set; } = new List<EmployerApplication>();

    /// <summary>
    /// Unique ID of Vacancy
    /// </summary>
	public uint Id { get; set; }
}
