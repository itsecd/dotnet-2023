namespace BikeRental.Domain;

/// <summary>
/// Class RentRecord has the info about a bike rent: client info, rented bike info, rent time
/// </summary>
public class RentRecord
{
    /// <summary>
    /// Id of a rent record
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// A client who rented a bike
    /// </summary>
    public Client Client { get; set; } = new();

    /// <summary>
    /// Full name of a client who rented a bike
    /// </summary>
    public string ClientName { get; set; } = string.Empty;


    public Bike Bike { get; set; } = new();
    /// <summary>
    /// Serial number of a rented bike
    /// </summary>
    public int BikeSerialNumber { get; set; }

    /// <summary>
    /// Date and time of the start of the rent
    /// </summary>
    public DateTime RentStartTime { get; set; } = DateTime.MinValue;

    /// <summary>
    /// Date and time when whe client must return a bike
    /// </summary>
    public DateTime RentEndTime { get; set; } = DateTime.MinValue;

}
