namespace RecruitmentAgency;

/// <summary>
/// Class of employer application
/// </summary>
public class EmployerApplication
{
    /// <summary>
    /// Class of employer
    /// </summary>
    public Employer Employer { get; set; }

    /// <summary>
    /// Offered vacancy
    /// </summary>
	public Vacancy Vacancy { get; set; }

    /// <summary>
    /// Expected work experience in years
    /// </summary>
    public uint? WorkExperience { get; set; }

    /// <summary>
    /// Expected education level
    /// </summary>
	public string? Education { get; set; }

    /// <summary>
    /// Offered salary in RUB
    /// </summary>
    public uint? Salary { get; set; }

    /// <summary>
    /// Filing date of application
    /// </summary>
	public DateTime Date { get; set; }

    /// <summary>
    /// Unique ID of employer application
    /// </summary>
	public uint Id { get; }

    /// <summary>
    /// Emplyer applications counter
    /// </summary>
    private static uint _employerApplicationCount = 0;

    /// <summary>
    /// Construct EmployerApplication object
    /// </summary>
    public EmployerApplication(Employer employer, Vacancy vacancy, uint? workExperience, string? education, uint? salary, DateTime date)
    {
        vacancy.EmployerApplicationList.Add(this);
        employer.EmployerApplicationList.Add(this);

        Employer = employer;
        Vacancy = vacancy;
        WorkExperience = workExperience;
        Education = education;
        Salary = salary;
        Date = date;
        Id = _employerApplicationCount++;
    }
}