using Shops.Domain;

namespace Shops.Server.Repository;
public interface IShopRepository
{
    List<Customer> Customers { get; }
    List<ProductGroup> ProductGroups { get; }
    List<Product> Products { get; }
    List<Shop> Shops { get; }
}