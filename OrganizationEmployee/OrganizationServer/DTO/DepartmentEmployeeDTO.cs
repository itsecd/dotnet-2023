namespace OrganizationServer.DTO;
using EmployeeDomain;
/// <summary>
/// class DepartmentEmployee - represents a many-to-many relationship
/// between Employee and Department
/// </summary>
public class DepartmentEmployeeDTO
{
    /// <summary>
    /// DepartmentId - an id of Department object
    /// </summary>
    public uint? DepartmentId { get; set; }
    /// <summary>
    /// EmployeeId - an id of Employee object
    /// </summary>
    public uint? EmployeeId { get; set; }
}