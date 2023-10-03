namespace Company.Server.Dto;

/// <summary>
/// VacationSpotPostDto - narrows the VacationSpot class for Post method in controller
/// </summary>
public class VacationSpotPostDto
{
    /// <summary>
    /// Name - a name of the VacationSpot
    /// </summary>
    public string Name { get; set; } = string.Empty;
}
