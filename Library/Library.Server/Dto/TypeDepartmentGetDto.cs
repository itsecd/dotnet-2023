namespace Library.Server.Dto;
/// <summary>
/// Class TypeDepartmentGetDto is used to store info about types of departments
/// </summary>
public class TypeDepartmentGetDto
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
