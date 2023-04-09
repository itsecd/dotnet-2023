using StoreApp.Domain;

namespace StoreApp.Server.Repository;
public interface IStoreAppRepository
{
    List<Customer> Customers { get; }
    List<Product> Products { get; }
    List<Store> StoredStores { get; }
}