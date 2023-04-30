using AirplaneBookingSystem.Model;
namespace AirplaneBookingSystem.Server.Repository;
public interface IAirplaneBookingSystemRepository
{
    List<Airplane> Airplanes { get; }
    List<Client> Client { get; }
    List<Flight> Flights { get; }
    List<Ticket> Tickets { get; }
}