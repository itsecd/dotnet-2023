using System.ComponentModel.DataAnnotations;

namespace Company.Domain;

/// <summary>
/// Department - describes a Department in the Company
/// </summary>
public class Department
{
    /// <summary>
    /// Id - an id of the Department
    /// </summary>
    [Key]
    public int Id { get; set; }


    /// <summary>
    /// Name - a name of the Department
    /// </summary>
    [Required]
    public string Name { get; set; } = string.Empty;


    /// <summary>
    /// DepartmentWorkers - a list of Workers, which are currently working in this department
    /// One Worker can work in multiple departments
    /// </summary>
    public List<WorkersAndDepartments> DepartmentWorkers { get; set; } = new List<WorkersAndDepartments>();
}