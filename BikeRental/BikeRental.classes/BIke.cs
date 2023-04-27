namespace BikeRental.Domain;

/// <summary>
/// Class Bike has the info about bikes
/// </summary>
public class Bike
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
    /// Type of a rented bike
    /// </summary>
    public BikeType Type { get; set; } = new();
}
