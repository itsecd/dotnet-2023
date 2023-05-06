using Warehouse.Domain;

namespace Warehouse.Server.Repository;

public interface IWarehouseRepository
{
    List<Products> Products { get; }
    List<Supplies> Supplies { get; }
    List<WarehouseCells> Cells { get; }
}
