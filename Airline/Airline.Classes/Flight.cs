using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirLine.Domain;

public class Flight
{
    /// <summary>
    /// Cipher of flight
    /// </summary>
    public string Cipher { get; set; } = string.Empty;
    /// <summary>
    /// Field departure place 
    /// </summary>
    public string DeparturePlace { get; set; } = string.Empty;
    /// <summary>
    /// Field destination
    /// </summary>
    public string Destination { get; set; } = string.Empty;
    /// <summary>
    /// Field date of departure
    /// </summary>
    public DateTime? DepartureDate { get; set; }
    /// <summary>
    /// Field date of arrival
    /// </summary>
    public DateTime? ArrivalDate { get; set; }
    /// <summary>
    /// Flight time
    /// </summary>
    public TimeSpan FlightTime { get; set; }
    /// <summary>
    /// type airplane on flight
    /// </summary>
    public Airplane? Airplane { get; set; }
    /// <summary>
    /// List of tickets on flight
    /// </summary>
    public List<Ticket>? Tickets { get; set; }
    public Flight() {}
    public Flight(string cipher, string departurePlace, string destination, DateTime? departureDate, DateTime arrivalDate, Airplane airplane, List<Ticket> tickets)
    {
        Cipher = cipher;
        DeparturePlace = departurePlace;
        Destination = destination;
        DepartureDate = departureDate;
        ArrivalDate = arrivalDate;
        FlightTime = ArrivalDate.Value-DepartureDate.Value;
        Airplane = airplane;
        Tickets = tickets;
    }

    public override bool Equals(object? obj)
    {
        if (obj is not Flight param)
            return false;

        return Cipher == param.Cipher &&
               DeparturePlace == param.DeparturePlace &&
               Destination == param.Destination &&
               DepartureDate == param.DepartureDate &&
               ArrivalDate == param.ArrivalDate &&
               Airplane == param.Airplane &&
               Tickets == param.Tickets;
    }

    public override int GetHashCode()
    {
        return Cipher.GetHashCode();
    }
}
