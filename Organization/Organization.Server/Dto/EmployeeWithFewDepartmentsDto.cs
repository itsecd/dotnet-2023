namespace Organization.Server.Dto;
/// <summary>
/// Classs EmployeeWithFewDepartmentsDto represents an employee, who works in 2 or more departments of the organization
/// </summary>
public class EmployeeWithFewDepartmentsDto
{
    /// <summary>
    /// RegNumber - registration number of an Employee
    /// </summary>
    public uint RegNumber { get; set; }
    /// <summary>
    /// FirstName - first name of an Employee
    /// </summary>
    public string FirstName { get; set; } = string.Empty;
    /// <summary>
    /// LastName - last name of an Employee
    /// </summary>
    public string LastName { get; set; } = string.Empty;
    /// <summary>
    /// LastName - patronymic name of on Employee
    /// </summary>
    public string PatronymicName { get; set; } = string.Empty;
    /// <summary>
    /// CountDepart - a number of departments, in which the employee works
    /// </summary>
    public int CountDepart { get; set; }
}