using System.ComponentModel.DataAnnotations;

namespace EmployeeDomain;
/// <summary>
/// Occupation - represents an employee occupation.
/// The class has list of EmployeeOccupation objects for many-to-many relationship.
/// </summary>
public class Occupation
{
    /// <summary>
    /// Id - an id of the occupation
    /// </summary>
    [Key]
    public uint Id { get; set; }
    /// <summary>
    /// Name - a name of the given occupation
    /// </summary>
    [Required]
    public string Name { get; set; } = string.Empty;
    /// <summary>
    /// EmployeeOccupation - a list of EmployeeOccupation objects, used for many-to-many relationship.
    /// </summary>
    public List<EmployeeOccupation> EmployeeOccupations { get; set; } = new List<EmployeeOccupation>();
}