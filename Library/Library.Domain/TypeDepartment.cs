namespace Library.Domain;

/// <summary>
/// Class TypeDepartment is used to store info about types of departments
/// </summary>
public class TypeDepartment
{
    /// <summary>
    /// Id stores department's id
    /// </summary>
    public int Id { set; get; }
    /// <summary>
    /// Name stores name of the department
    /// </summary>
    public string Name { set; get; } = string.Empty;
}
