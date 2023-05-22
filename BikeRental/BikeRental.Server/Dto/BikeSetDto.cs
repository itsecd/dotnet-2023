namespace BikeRental.Server.Dto;

/// <summary>
/// Class BikeSetDto has the info about bikes
/// </summary>
public class BikeSetDto
{
    /// <summary>
    /// Serial number of a bike
    /// </summary>
    public int SerialNumber { get; set; }

    /// <summary>
    /// Model info of a bike
    /// </summary>
    public string Model { get; set; } = string.Empty;

    /// <summary>
    /// Color info of a bike
    /// </summary>
    public string Color { get; set; } = string.Empty;

    /// <summary>
    /// Id of a bike type
    /// </summary>
    public int TypeId { get; set; }
}
