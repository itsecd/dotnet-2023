using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Organization.Domain;
/// <summary>
/// class Department - represents a department in company
/// </summary>
public class Department
{
    /// <summary>
    /// Id - an id of the department
    /// </summary>
    [Key]
    public uint Id { get; set; }
    /// <summary>
    /// Name - a name of the department
    /// </summary>
    [Required]
    public string Name { get; set; } = string.Empty;
    /// <summary>
    /// DepartmentEmployees - a list of employee's departments in which the employee is currently working
    /// One employee can work in multiple departments
    /// </summary>
    [InverseProperty("Department")]
    public List<DepartmentEmployee> DepartmentEmployees { get; set; } = new List<DepartmentEmployee>();
}