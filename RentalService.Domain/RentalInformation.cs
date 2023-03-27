namespace RentalService.Domain;

/// <summary>
/// class RentalInformation contains all the information about car rental
/// </summary>
public class RentalInformation
{
    /// <summary>
    /// Id - unique client ID
    /// </summary>
    public ulong Id { get; set; }

    /// <summary>
    /// RentalPointId - ID of the rental point 
    /// </summary>
    public ulong RentalPointId { get; set; }

    /// <summary>
    /// RentalDate - when the car was rented
    /// </summary>
    public DateTime RentalDate { get; set; } = DateTime.MinValue;

    /// <summary>
    /// RentalPeriod - for what time the car was rented (in days)
    /// </summary>
    public ulong RentalPeriod { get; set; }
}
