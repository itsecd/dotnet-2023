using TransportMgmt.Domain;

namespace TransportMgmtServer.Repository;
/// <summary>
/// Interface for the TransportMgmtRepository class
/// </summary>
public interface ITransportMgmtRepository
{
    /// <summary>
    /// A list of transport types that will change by methods
    /// </summary>
    List<TransportType> TransportType { get; }
    /// <summary>
    /// A list of drivers that will change by methods
    /// </summary>
    List<Driver> Drivers { get; }
    /// <summary>
    /// A list of models that will change by methods
    /// </summary>
    List<Model> Models { get; }
    /// <summary>
    /// A list of routes that will change by methods
    /// </summary>
    List<Routes> Routes { get; }
    /// <summary>
    /// A list of transport that will change by methods
    /// </summary>
    List<Transport> Transports { get; }
    /// <summary>
    /// A list of trips that will change by methods
    /// </summary>
    List<Trip> Trips { get; }
}