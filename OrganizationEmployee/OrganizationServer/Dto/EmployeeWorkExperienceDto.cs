namespace OrganizationServer.Dto;
/// <summary>
/// EmployeeWorkExperienceDto - represents an employee and employee's work experience
/// </summary>
public class EmployeeWorkExperienceDto
{
    /// <summary>
    /// RegNumber - registration number of an Employee
    /// </summary>
    public uint? RegNumber { get; set; }
    /// <summary>
    /// FirstName - first name of an Employee
    /// </summary>
    public string? FirstName { get; set; }
    /// <summary>
    /// LastName - last name of an Employee
    /// </summary>
    public string? LastName { get; set; }
    /// <summary>
    /// WorkExperience - a work experience of an Employee 
    /// </summary>
    public double? WorkExperience { get; set; }
}
