namespace OrganizationServer.Dto;
/// <summary>
/// class DepartmentEmployee - represents a many-to-many relationship
/// between Employee and Department
/// </summary>
public class GetDepartmentEmployeeDto
{
    /// <summary>
    /// Id - an id of the link
    /// </summary>
    public uint Id { get; set; }
    /// <summary>
    /// DepartmentId - an id of Department object
    /// </summary>
    public uint? DepartmentId { get; set; }
    /// <summary>
    /// EmployeeId - an id of Employee object
    /// </summary>
    public uint? EmployeeId { get; set; }
}