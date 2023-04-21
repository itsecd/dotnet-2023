using StoreApp.Domain;

namespace StoreApp.Server.Repository;
public interface IStoreAppRepository
{
    List<Customer> Customers { get; }
    List<Product> Products { get; }
    List<Store> Stores { get; }
    List<ProductSale> ProductSales { get; }
    List<ProductStore> ProductStores { get; }
    List<Sale> Sales { get; }
}