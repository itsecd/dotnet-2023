using Fabrics.Domain;

namespace Fabrics.Server.Repository;
public interface IFabricsRepository
{
    List<Fabric> Fabrics { get; }
    List<Provider> Providers { get; }
    List<Shipment> Shipment { get; }
}