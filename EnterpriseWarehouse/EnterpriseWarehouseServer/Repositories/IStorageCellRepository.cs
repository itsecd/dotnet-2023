using Enterprise.Data;

namespace EnterpriseWarehouseServer.Repositories;
public interface IStorageCellRepository
{
    List<StorageCell> StorageCell { get; }
}