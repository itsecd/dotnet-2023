using TransportManagment.Classes;
namespace TransportManagment.Server.Repository;
/// <summary>
/// Interface of TransportManagmentRepository
/// </summary>
public interface ITransportManagmentRepository
{
    List<Driver> Drivers { get; }
    List<Classes.Route> Routes { get; }
    List<Transport> Transports { get; }
}