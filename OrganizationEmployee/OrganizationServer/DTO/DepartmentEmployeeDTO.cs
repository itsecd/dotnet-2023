namespace OrganizationServer.DTO;
using EmployeeDomain;
/// <summary>
/// class DepartmentEmployee - represents a many-to-many relationship
/// between Employee and Department
/// </summary>
public class DepartmentEmployeeDTO
{
    /// <summary>
    /// Department - a link to Department object
    /// </summary>
    public DepartmentDTO? Department { get; set; }
    /// <summary>
    /// Employee - a link to Employee object
    /// </summary>
    public EmployeeDTO? Employee { get; set; }
}