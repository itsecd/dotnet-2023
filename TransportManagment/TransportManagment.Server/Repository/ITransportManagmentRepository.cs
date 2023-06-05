using TransportManagment.Model;

namespace TransportManagment.Server.Repository;
/// <summary>
/// Interface of TransportManagmentRepository
/// </summary>
public interface ITransportManagmentRepository
{
    List<Driver> Drivers { get; }
    List<Model.Route> Routes { get; }
    List<Transport> Transports { get; }
}