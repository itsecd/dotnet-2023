using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet.classes;

public class Flight
{
    public string Cipher { get; set; } = string.Empty;

    public string Departure_place { get; set; } = string.Empty;
    public string Destination { get; set; } = string.Empty;
    public DateTime? Departure_date { get; set; }
    public DateTime? Arrival_date { get; set; }
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
