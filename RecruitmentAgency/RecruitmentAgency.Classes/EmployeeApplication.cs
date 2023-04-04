namespace RecruitmentAgency.Classes;

/// <summary>
/// Class of job seeker application
/// </summary>
public class EmployeeApplication
{
	/// <summary>
	/// Class of job seeker
	/// </summary>
	public Employee Employee { get; set; }

	/// <summary>
	/// Desired vacancy
	/// </summary>
	public Vacancy Vacancy { get; set; }

	/// <summary>
	/// Filing date of application
	/// </summary>
	public DateTime Date { get; set; }

	/// <summary>
	/// Unique ID of application
	/// </summary>
	public uint Id { get; }

	/// <summary>
	/// Construct EmployeeApplication object
	/// </summary>
	public EmployeeApplication(Employee employee, Vacancy vacancy, DateTime date, uint id)
	{
		vacancy.EmployeeApplicationList.Add(this);
		employee.EmployeeApplicationList.Add(this);

		Employee = employee;
		Vacancy = vacancy;
		Date = date;
		Id = id;
	}
}