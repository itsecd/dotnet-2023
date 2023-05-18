using Enterprise.Data;

namespace EnterpriseWarehouseServer.Repositories;
public interface IMainRepository
{
    List<Invoice> Invoices { get; }
    List<Product> Products { get; }
    List<StorageCell> StorageCell { get; }
}