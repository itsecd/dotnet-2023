using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeDomain;
/// <summary>
/// Class Workshop represents a workshop on the organization
/// </summary>
public class Workshop
{
    /// <summary>
    /// Id - an id of the workshop
    /// </summary>
    [Key]
    public uint Id { get; set; }
    /// <summary>
    /// Name - a name of the workshop
    /// </summary>
    [Required]
    public string Name { get; set; } = string.Empty;
    /// <summary>
    /// Employees - a list of Employee objects, used to maintain an one-to-many relationship.
    /// </summary>
    [InverseProperty("Workshop")]
    public List<Employee> Employees { get; set; } = new List<Employee>();
}
