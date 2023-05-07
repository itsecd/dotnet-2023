using StoreApp.Model;

namespace StoreApp.Server.Repository;

public class StoreAppRepository : IStoreAppRepository
{
    private readonly List<Product> _products;
    private readonly List<Customer> _customers;
    private readonly List<Store> _stores;
    private readonly List<ProductStore> _productStores;
    private readonly List<ProductSale> _productSales;
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
        _productSales = new List<ProductSale>()
        {
            new ProductSale(1, 1, 0, 1),
            new ProductSale(2, 1, 1, 1),
            new ProductSale(3, 1, 2, 1),
            new ProductSale(4, 2, 3, 1),
            new ProductSale(5, 2, 4, 1),
            new ProductSale(6, 2, 0, 1),
            new ProductSale(7, 3, 1, 1),
            new ProductSale(8, 3, 2, 1),
            new ProductSale(9, 3, 3, 1),
            new ProductSale(10, 4, 4, 1),
            new ProductSale(11, 4, 0, 1),
            new ProductSale(12, 4, 1, 1),
            new ProductSale(13, 5, 2, 1),
            new ProductSale(14, 5, 3, 1),
            new ProductSale(15, 5, 4, 1),
            new ProductSale(16, 6, 1, 1),
            new ProductSale(17, 6, 2, 1),
            new ProductSale(18, 6, 3, 1),
            new ProductSale(19, 7, 4, 1),
            new ProductSale(20, 7, 0, 1),
            new ProductSale(21, 7, 3, 1)
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
            new Sale(1, "03.03.2023", 1, 0, 357.0),
            new Sale(2, "03.01.2023", 0, 1, 221.0),
            new Sale(3, "15.02.2023", 1, 0, 364.0),
            new Sale(4, "18.02.2023", 2, 2, 284.0),
            new Sale(5, "16.02.2023", 3, 3, 241.0),
            new Sale(6, "28.02.2023", 4, 1, 364.0),
            new Sale(7, "01.03.2023", 4, 0, 284.0)
        };

    }

    public List<Product> Products => _products;
    public List<Customer> Customers => _customers;
    public List<Store> Stores => _stores;
    public List<ProductStore> ProductStores => _productStores;
    public List<ProductSale> ProductSales => _productSales;
    public List<Sale> Sales => _sales;

}
