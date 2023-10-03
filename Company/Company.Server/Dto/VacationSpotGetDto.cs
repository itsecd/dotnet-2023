namespace Company.Server.Dto;

/// <summary>
/// VacationSpotGetDto - narrows the VacationSpot class for Get method in controller
/// </summary>
public class VacationSpotGetDto
{
    /// <summary>
    /// Id - an id of the VacationSpot
    /// </summary>
    public int Id { get; set; }


    /// <summary>
    /// Name - a name of the VacationSpot
    /// </summary>
    public string Name { get; set; } = string.Empty;
}
