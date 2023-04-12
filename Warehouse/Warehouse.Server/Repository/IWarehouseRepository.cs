using Warehouse.Domain;
namespace Warehouse.Server.Repository;
public interface IWarehouseRepository
{
    List<Goods> Products { get; }
    List<Supply> Supplies { get; }
    List<WarehouseCells> Cells { get; }
}
