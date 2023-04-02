namespace RecruitmentAgency;

/// <summary>
/// Class of job seeker
/// </summary>
public class Employee
{
    /// <summary>
    /// Surname, name and patronymic of employee
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Phone number of employee
    /// </summary>
    public string PhoneNumber { get; set; }

    /// <summary>
    /// Work experience of employee in years
    /// </summary>
    public uint? WorkExperience { get; set; }

    /// <summary>
    /// Info about education
    /// </summary>
    public string? Education { get; set; }

    /// <summary>
    /// Expected salary in RUB
    /// </summary>
    public uint? Salary { get; set; }

    /// <summary>
    /// List of all employee applications
    /// </summary>
    public List<EmployeeApplication> EmployeeApplicationList { get; set; } = new List<EmployeeApplication>();

    /// <summary>
    /// Unique ID of employee
    /// </summary>
    public uint Id { get; }

    /// <summary>
    /// Emplyee counter
    /// </summary>
    private static uint _employeeCount = 0;

    /// <summary>
    /// Construct Employee object
    /// </summary>
    public Employee(string name, string phoneNumber, uint? workExperience, string? education, uint? salary)
    {
        Name = name;
        PhoneNumber = phoneNumber;
        WorkExperience = workExperience;
        Education = education;
        Salary = salary;
        Id = _employeeCount++;
    }
}