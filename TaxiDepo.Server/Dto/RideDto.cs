namespace TaxiDepo.Server.Dto;

/// <summary>
/// Dto ride class
/// </summary>
public class RideDto
{
    /// <summary>
    /// Ride id
    /// </summary>
    public int Id { get; set; } = 0; 
    /// <summary>
    /// Departure place 
    /// </summary>
    public string TripDeparturePlace { get; set; } = string.Empty;
    /// <summary>
    /// Destination place
    /// </summary>
    public string TripDestinationPlace { get; set; } = string.Empty;
    /// <summary>
    /// Trip date
    /// </summary>
    public DateTime TripDate { get; set; }
    /// <summary>
    /// Trip time
    /// </summary>
    public TimeSpan TripTime { get; set; }
    /// <summary>
    /// Trip price
    /// </summary>
    public double TripPrice { get; set;  } = 0.0;
    /// <summary>
    /// Trip car Id
    /// </summary>
    public int CarId { get; set; }
    /// <summary>
    /// Trip user Id
    /// </summary>
    public int UserId { get; set; }
}