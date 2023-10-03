namespace Company.Server.Dto;

/// <summary>
/// DepartmentGetDto - narrows the Department class for Get method in controller
/// </summary>
public class DepartmentGetDto
{
    /// <summary>
    /// Id - an id of the Department
    /// </summary>
    public int Id { get; set; }


    /// <summary>
    /// Name - a name of the Department
    /// </summary>
    public string Name { get; set; } = string.Empty;
}