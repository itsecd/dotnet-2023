using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet.classes;

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
    public string Airplane_type { get; set; } = string.Empty;
    public Flight() {}
    public Flight(string cipher, string departure_place, string destination, DateTime? departure_date, DateTime arrival_date, string airplane_type)
    {
        Cipher = cipher;
        Departure_place = departure_place;
        Destination = destination;
        Departure_date = departure_date;
        Arrival_date = arrival_date;
        Airplane_type = airplane_type;
    }
}
