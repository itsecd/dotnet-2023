namespace OrganizationServer.Dto;
/// <summary>
/// AverageAgeInDepartmentDto represents a department and a calculated employees' average age in that department
/// </summary>

public class AverageAgeInDepartmentDto
{
    /// <summary>
    /// AverageAge - an average age of employees in the department
    /// </summary>
    public double? AverageAge { get; set; }
    /// <summary>
    /// DepartmentName - a name of the department
    /// </summary>
    public string? DepartmentName { get; set; }

}
