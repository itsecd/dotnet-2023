namespace Company.Server.Dto;

/// <summary>
/// WorkshopGetDto - narrows the Workshop class for Get method in controller
/// </summary>
public class WorkshopGetDto
{
    /// <summary>
    /// Id - an id of the Workshop
    /// </summary>
    public int Id { get; set; }


    /// <summary>
    /// Name - a name of the Workshop
    /// </summary>
    public string Name { get; set; } = string.Empty;
}
