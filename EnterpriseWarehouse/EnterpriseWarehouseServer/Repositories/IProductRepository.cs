using Enterprise.Data;

namespace EnterpriseWarehouseServer.Repositories;
public interface IProductRepository
{
    List<Product> Products { get; }
}