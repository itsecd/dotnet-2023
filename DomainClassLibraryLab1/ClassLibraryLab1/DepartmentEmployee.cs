namespace EmployeeDomain;
/// <summary>
/// class DepartmentEmployee - represents a many-to-many relationship
/// between Employee and Department
/// </summary>
public class DepartmentEmployee
{
    /// <summary>
    /// Id - an id of the link
    /// </summary>
    public uint Id { get; set; }
    /// <summary>
    /// Department - a link to Department object
    /// </summary>
    public Department? Department { get; set; }
    /// <summary>
    /// Employee - a link to Employee object
    /// </summary>
    public Employee? Employee { get; set; }
}