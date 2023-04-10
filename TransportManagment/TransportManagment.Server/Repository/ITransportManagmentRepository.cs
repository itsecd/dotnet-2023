using TransportManagment.Classes;

namespace TransportManagment.Server.Repository;
public interface ITransportManagmentRepository
{
    List<Driver> Drivers { get; }
    List<Classes.Route> Routes { get; }
    List<Transport> Transports { get; }
}