using System.Net.Sockets;
using Warehouse.Domain;
namespace Warehouse.Server.Repository;
public interface IWarehouseRepository
{
    List<Goods> Goods { get; }
    List<Supply> Supply { get; }
    List<WarehouseCells> WarehouseCells { get; }
}