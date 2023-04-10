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
        _productStores = new List<ProductStore>()
        {
            new ProductStore(1, 0, 1, 10),
            new ProductStore(2, 1, 1, 2),
            new ProductStore(3, 2, 1, 5),
            new ProductStore(4, 2, 2, 15),
            new ProductStore(5, 3, 1, 0),
            new ProductStore(6, 3, 2, 20)
        };
        _sales = new List<Sale>()
        {
            new Sale(1, "03.03.2023", 1, 0, new List<int> {0, 1, 2}, 357.0),
            new Sale(2, "03.01.2023", 0, 1, new List<int> {3, 4, 0}, 221.0),
            new Sale(3, "15.02.2023", 1, 0, new List<int> {1, 2, 3}, 364.0),
            new Sale(4, "18.02.2023", 2, 2, new List<int> {4, 0, 1}, 284.0),
            new Sale(5, "16.02.2023", 3, 3, new List<int> {2, 3, 4}, 241.0),
            new Sale(6, "28.02.2023", 4, 1, new List<int> {1, 2, 3}, 364.0),
            new Sale(7, "01.03.2023", 4, 0, new List<int> {4, 0, 3}, 284.0),
        };

    }

    public List<Product> Products => _products;
    public List<Customer> Customers => _customers;
    public List<Store> Stores => _stores;
    public List<ProductStore> ProductStores => _productStores;
    public List<Sale> Sales => _sales;
}
