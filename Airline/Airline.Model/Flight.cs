using System.ComponentModel.DataAnnotations;

namespace AirLine.Model;

public class Flight
{
    [Key]
    public int Id { get; set; }
    /// <summary>
    /// Cipher of flight
    /// </summary>
    [Required] public string Cipher { get; set; } = string.Empty;
    /// <summary>
    /// Field departure place 
    /// </summary>
    [Required] public string DeparturePlace { get; set; } = string.Empty;
    /// <summary>
    /// Field destination
    /// </summary>
    [Required] public string Destination { get; set; } = string.Empty;
    /// <summary>
    /// Field date of departure
    /// </summary>
    [Required] public DateTime? DepartureDate { get; set; }
    /// <summary>
    /// Field date of arrival
    /// </summary>
    [Required] public DateTime? ArrivalDate { get; set; }
    /// <summary>
    /// Flight time
    /// </summary>
    public TimeSpan FlightTime { get; set; }
    public Flight() { }
    public Flight(int id, string cipher, string departurePlace, string destination, DateTime? departureDate, DateTime arrivalDate)
    {
        Id = id;
        Cipher = cipher;
        DeparturePlace = departurePlace;
        Destination = destination;
        DepartureDate = departureDate;
        ArrivalDate = arrivalDate;
        FlightTime = ArrivalDate.Value - DepartureDate.Value;
    }

    public override bool Equals(object? obj)
    {
        if (obj is not Flight param)
            return false;

        return Cipher == param.Cipher &&
               DeparturePlace == param.DeparturePlace &&
               Destination == param.Destination &&
               DepartureDate == param.DepartureDate &&
               ArrivalDate == param.ArrivalDate;
    }

    public override int GetHashCode()
    {
        return Cipher.GetHashCode();
    }
}
