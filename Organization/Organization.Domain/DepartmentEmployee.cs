using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Organization.Domain;
/// <summary>
/// class DepartmentEmployee - represents a many-to-many relationship
/// between Employee and Department
/// </summary>
public class DepartmentEmployee
{
    /// <summary>
    /// Id - an id of the link
    /// </summary>
    [Key]
    public uint Id { get; set; }
    /// <summary>
    /// DepartmentId - an id of Department object
    /// </summary>
    [ForeignKey("Department")]
    public uint? DepartmentId { get; set; }
    /// <summary>
    /// Department - a link to Department object
    /// </summary>
    public Department? Department { get; set; }
    /// <summary>
    /// EmployeeId - an id of Employee object
    /// </summary>
    [ForeignKey("Employee")]
    public uint? EmployeeId { get; set; }
    /// <summary>
    /// Employee - a link to Employee object
    /// </summary>
    public Employee? Employee { get; set; }
}