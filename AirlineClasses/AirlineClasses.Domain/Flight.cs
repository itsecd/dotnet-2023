using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineClasses;

public class Flight
{
    /// <summary>
    /// Cipher of flight
    /// </summary>
    public string Cipher { get; set; } = string.Empty;
    /// <summary>
    /// Field departure place 
    /// </summary>
    public string Departure_place { get; set; } = string.Empty;
    /// <summary>
    /// Field destination
    /// </summary>
    public string Destination { get; set; } = string.Empty;
    /// <summary>
    /// Field date of departure
    /// </summary>
    public DateTime? Departure_date { get; set; }
    /// <summary>
    /// Field date of arrival
    /// </summary>
    public DateTime? Arrival_date { get; set; }
    /// <summary>
    /// type airplane on flight
    /// </summary>
    public Airplane? Airplane { get; set; }
    public List<Ticket>? Tickets { get; set; }
    public Flight() {}
    public Flight(string cipher, string departure_place, string destination, DateTime? departure_date, DateTime arrival_date, Airplane airplane, List<Ticket> tickets)
    {
        Cipher = cipher;
        Departure_place = departure_place;
        Destination = destination;
        Departure_date = departure_date;
        Arrival_date = arrival_date;
        Airplane = airplane;
        Tickets = tickets;
    }

    public override bool Equals(object? obj)
    {
        if (obj is not Flight param)
            return false;

        return Cipher == param.Cipher &&
               Departure_place == param.Departure_place &&
               Destination == param.Destination &&
               Departure_date == param.Departure_date &&
               Arrival_date == param.Arrival_date &&
               Airplane == param.Airplane &&
               Tickets == param.Tickets;
    }
}
