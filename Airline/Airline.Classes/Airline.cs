using System.ComponentModel.DataAnnotations;

namespace AirLine.Model;
public class Airline
{
    [Key]
    public int Id { get; set; }
    /// <summary>
    /// List airplanes in airline
    /// </summary>
    [Required]    public List<Airplane> Airplanes { get; set; } = new List<Airplane>();
    /// <summary>
    /// List flights in airline
    /// </summary>
    [Required] public List<Flight> Flights { get; set; } = new List<Flight>();
    /// <summary>
    /// List passengers in airline
    /// </summary>
    [Required] public List<Passenger> Passengers { get; set; } = new List<Passenger>();

    public Airline() { }
    public Airline(int id, List<Airplane> airplanes, List<Flight> flights, List<Passenger> passengers)
    {
        Id = id;
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
    public void AddToAirplaneList(Airplane airplane)
    {
        Airplanes.Add(airplane);
    }

    /// <summary>
    /// Method for adding flight in airline
    /// </summary>
    /// <param name="flight">
    /// flight
    /// </param>
    public void AddToFlightList(Flight flight)
    {
        Flights.Add(flight);
    }

    /// <summary>
    /// Method for adding passenger in airline
    /// </summary>
    /// <param name="passenger">
    /// passenger
    /// </param>
    public void AddToPassengerList(Passenger passenger)
    {
        Passengers.Add(passenger);
    }

}
