namespace BikeRental.Server.Dto;

/// <summary>
/// Class RentRecordSetDto has the info about a bike rent: client info, rented bike info, rent time
/// </summary>
public class RentRecordSetDto
{
    /// <summary>
    /// Id of a client who rented a bike
    /// </summary>
    public int ClientId { get; set; }

    /// <summary>
    /// Id of a rented bike
    /// </summary>
    public int BikeId { get; set; }

    /// <summary>
    /// Date and time of the start of the rent
    /// </summary>
    public DateTime RentStartTime { get; set; } = DateTime.MinValue;

    /// <summary>
    /// Date and time when whe client must return a bike
    /// </summary>
    public DateTime RentEndTime { get; set; } = DateTime.MinValue;
}
