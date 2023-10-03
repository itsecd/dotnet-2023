namespace Company.Server.Dto;

/// <summary>
/// DepartmentPostDto - narrows the Department class for Post method in controller
/// </summary>
public class DepartmentPostDto
{
    /// <summary>
    /// Name - a name of the Department
    /// </summary>
    public string? Name { get; set; } = string.Empty;
}
