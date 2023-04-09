namespace PonrfServer.Dto;

/// <summary>
/// BuildingGetDto for HTTP GET request
/// </summary>
public class BuildingGetDto
{
    /// <summary>
    /// Id is an identifier of building
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// RegistNum contains information about registration number of building
    /// </summary>
    public string RegistNum { get; set; } = string.Empty;
    /// <summary>
    /// District contains information about district where the building is located
    /// </summary>  
    public string District { get; set; } = string.Empty;
    /// <summary>
    /// Street contains information about street where the building is located
    /// </summary>
    public string Street { get; set; } = string.Empty;
    /// <summary>
    /// HouseNumber contains information about house number of building
    /// </summary>
    public int HouseNumber { get; set; }
    /// <summary>
    /// Area contains information about building area
    /// </summary>
    public int Area { get; set; }
    /// <summary>
    /// Floors contains information about number of floors of the building
    /// </summary>
    public int Floors { get; set; }
    /// <summary>
    /// DateOfBuild contains information about date of construction of the building
    /// </summary>
    public DateTime DateOfBuild { get; set; } = DateTime.MinValue;
}