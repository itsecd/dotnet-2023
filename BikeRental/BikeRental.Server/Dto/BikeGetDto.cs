namespace BikeRental.Server.Dto;

/// <summary>
/// Class BikeGetDto has the info about bikes
/// </summary>
public class BikeGetDto
{
    /// <summary>
    /// Id of a bike
    /// </summary>
    public int Id { get; set; }

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
