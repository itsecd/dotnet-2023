using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet.classes;
public class Airline
{
    /// <summary>
    /// List airplanes in airline
    /// </summary>
    public List<Airplane> Airplanes { get; set; }
    /// <summary>
    /// List flights in airline
    /// </summary>
    public List<Flight> Flights { get; set; }
    /// <summary>
    /// List passengers in airline
    /// </summary>
    public List<Passenger> Passengers { get; set; }

    public Airline() {}
    public Airline(List<Airplane> airplanes, List<Flight> flights, List<Passenger> passengers)
    {
        Airplanes = airplanes;
        Flights = flights;
        Passengers = passengers;
    }

}
