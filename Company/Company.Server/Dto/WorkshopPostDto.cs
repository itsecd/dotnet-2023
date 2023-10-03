namespace Company.Server.Dto;

/// <summary>
/// WorkshopPostDto - narrows the Workshop class for Post method in controller
/// </summary>
public class WorkshopPostDto
{
    /// <summary>
    /// Name - a name of the Workshop
    /// </summary>
    public string Name { get; set; } = string.Empty;
}
