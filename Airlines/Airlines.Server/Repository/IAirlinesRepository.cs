using Airlines.Domain;

namespace Airlines.Server.Repository;
public interface IAirlinesRepository
{
    List<Flight> Flights { get; }
    List<Passenger> Passengers { get; }
    List<Ticket> Tickets { get; }
    List<Airplane> Airplanes { get; }
}