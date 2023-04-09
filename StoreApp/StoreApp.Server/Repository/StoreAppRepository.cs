using StoreApp.Domain;

namespace StoreApp.Server.Repository;

public class StoreAppRepository : IStoreAppRepository
{
    private readonly List<Product> _products;
    private readonly List<Customer> _customers;
    private readonly List<Store> _stores;
    private readonly List<ProductStore> _productStores;
    private readonly List<Sale> _sales;

    public StoreAppRepository()
    {
        _products = new List<Product>()
        {
            new Product(0, 1, "Milk", 0.940, false, 89.0, "23.02.2023"),
            new Product(1, 1, "Butter", 0.940, false, 159.0, "21.05.2023"),
            new Product(2, 2, "Pasta", 0.400, true, 109.0, "10.01.2023"),
            new Product(3, 3, "Eggs", 0.600, false, 96.0, "09.05.2023"),
            new Product(4, 3, "Bread", 0.440, false, 36.0, "23.02.2023")
        };
        _customers = new List<Customer>()
        {
            new Customer(1, "Michelle Padilla", 111111),
            new Customer(2, "Manuel Gomez", 222222),
            new Customer(3, "Raymond Oliver", 333333),
            new Customer(4, "Enrique Morgan", 444444),
            new Customer(5, "Walter Mullins", 555555)
        };
        _stores = new List<Store>()
        {
            new Store(0, "Walmart", "Polevaya 123"),
            new Store(1, "Pyaterochka", "Pushkina 1837"),
            new Store(2, "Shestorochka", "Kolotushkina 0"),
            new Store(3, "Magnit", "Moskovskoye shosse 666"),
            new Store(4, "Perekrestok", "Revolyutsionnaya 1917")
        };
    }

    public List<Product> Products => _products;
    public List<Customer> Customers => _customers;
    public List<Store> StoredStores => _stores;
}
