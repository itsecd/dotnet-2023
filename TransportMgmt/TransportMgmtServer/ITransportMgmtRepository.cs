using TransportMgmt.Domain;

namespace TransportMgmtServer;
public interface ITransportMgmtRepository
{
    List<Driver> Drivers { get; }
    List<Model> Models { get; }
    List<Routes> Routes { get; }
    List<Transport> Transports { get; }
    List<TransportType> TransportType { get; }
    List<Trip> Trips { get; }
}