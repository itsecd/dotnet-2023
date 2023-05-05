using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Domain;

/// <summary>
/// Class TypeDepartment is used to store info about types of departments
/// </summary>
[Table("type_department")]
public class TypeDepartment
{
    /// <summary>
    /// Id stores department's id
    /// </summary>
    [Column("id")]
    public int Id { set; get; }
    /// <summary>
    /// Name stores name of the department
    /// </summary>
    [Column("name")]
    public string Name { set; get; } = string.Empty;
    /// <summary>
    /// Departments stores list of departments
    /// </summary>
    public List<Department> Departments { set; get; } = new List<Department>();
}
