using Enterprise.Data;

namespace EnterpriseWarehouseServer.Repositories;

/// <summary>
///     StorageCellRepository - create list of element of the Storage Cell
/// </summary>
public class StorageCellRepository : IStorageCellRepository
{

    private readonly List<StorageCell> _storageCells;

    public StorageCellRepository()
    {
        _storageCells = new List<StorageCell>{
                new StorageCell (1, 102302),
                new StorageCell (2, 104302),
                new StorageCell (3, 106302),
                new StorageCell (4, 108302),
                new StorageCell (5, 310510),
                new StorageCell (6, 310510),
                new StorageCell (7, 310510),
                new StorageCell (8, 312510),
                new StorageCell (9, 312510),
                new StorageCell (10, 320510),
                new StorageCell (11, 101700),
                new StorageCell (12, 101700),
                new StorageCell (13, 101700),
                new StorageCell (14, 101700),
                new StorageCell (15, 103700),
                new StorageCell (16, 103700)
            };
    }

    public List<StorageCell> StorageCell => _storageCells;
}