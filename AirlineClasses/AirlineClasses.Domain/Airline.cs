using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineClasses;
public class Airline
{
    /// <summary>
    /// List airplanes in airline
    /// </summary>
    public List<Airplane> Airplanes { get; set; } = new List<Airplane>();
    /// <summary>
    /// List flights in airline
    /// </summary>
    public List<Flight> Flights { get; set; } = new List<Flight>();
    /// <summary>
    /// List passengers in airline
    /// </summary>
    public List<Passenger> Passengers { get; set; } = new List<Passenger>();

    public Airline() {}
    public Airline(List<Airplane> airplanes, List<Flight> flights, List<Passenger> passengers)
    {
        Airplanes = airplanes;
        Flights = flights;
        Passengers = passengers;
    }    

    /// <summary>
    /// Method for adding airplane in airline
    /// </summary>
    /// <param name="airplane">
    /// airplane
    /// </param>
    public void Add_to_airplane_list(Airplane airplane)
    {
        Airplanes.Add(airplane);
    }

    /// <summary>
    /// Method for adding flight in airline
    /// </summary>
    /// <param name="flight">
    /// flight
    /// </param>
    public void Add_to_flight_list(Flight flight)
    {
        Flights.Add(flight);
    }

    /// <summary>
    /// Method for adding passenger in airline
    /// </summary>
    /// <param name="passenger">
    /// passenger
    /// </param>
    public void Add_to_passenger_list(Passenger passenger)
    {
        Passengers.Add(passenger);
    }

}
