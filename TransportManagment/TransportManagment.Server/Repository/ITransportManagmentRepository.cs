using TransportManagment.Models;

namespace TransportManagment.Server.Repository;
/// <summary>
/// Interface of TransportManagmentRepository
/// </summary>
public interface ITransportManagmentRepository
{
    List<Driver> Drivers { get; }
    List<Models.Route> Routes { get; }
    List<Transport> Transports { get; }
}