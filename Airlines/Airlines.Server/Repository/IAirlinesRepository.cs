using Airlines.Domain;

namespace Airlines.Server.Repository;
public interface IAirlinesRepository
{
    List<FlightCLass> Flights { get; }
    List<PassengerClass> Passengers { get; }
    List<TicketClass> Tickets { get; }
    List<AirplaneClass> Airplanes { get; }
}