using ShopsDomain;

namespace ShopsServer.Repository;

public class ShopRepository : IShopRepository
{
    private readonly List<Shop> _shop;
    private readonly List<Product> _products;
    private readonly List<Customer> _customers;
    private readonly List<ProductGroup> _productGroups;
    private readonly List<ProductQuantity> _productQuantities;
    private readonly List<PurchaseRecord> _purchaseRecords;
    public ShopRepository()
    {
        _shop = ShopsList;
        _products = ListProducts;
        _customers = ListCustomers;
        _productGroups = ListProductGroups;
        _productQuantities = ListProductQuantities;
        _purchaseRecords = new List<PurchaseRecord>(ListPurchaseRecords1.Count +
                                                    ListPurchaseRecords2.Count +
                                                    ListPurchaseRecords3.Count);
        _purchaseRecords.AddRange(ListPurchaseRecords1);
        _purchaseRecords.AddRange(ListPurchaseRecords2);
        _purchaseRecords.AddRange(ListPurchaseRecords3);
    }
    public List<Shop> ShopsList
    {
        get
        {
            var shops = new List<Shop>();
            var products = ListProductQuantities;
            var purchases1 = ListPurchaseRecords1;
            var firstShop = new Shop(1, "Чан-чан", "Гагарин, 29", new List<ProductQuantity>() { products[0], products[1], products[2], products[3], products[4], products[5], products[6] }, purchases1);
            shops.Add(firstShop);
            var purchases2 = ListPurchaseRecords2;
            var secondShop = new Shop(2, "Магазин продуктов", "Московсковское шоссе, 34Б", new List<ProductQuantity>() { products[7], products[8], products[9], products[10], products[11] }, purchases2);
            shops.Add(secondShop);
            var purchases3 = ListPurchaseRecords3;
            var thirdShop = new Shop(3, "Один для всех", "Потапова, 65", new List<ProductQuantity>() { products[12], products[13], products[14], products[15], products[16], products[17], products[18] }, purchases3);
            shops.Add(thirdShop);
            return shops;
        }
    }
    public List<Product> ListProducts
    {
        get
        {
            return new List<Product>()
                {
                new Product (1, "1", "Молоко", 1,  0.5, "штучный", 70, new DateTime(2023, 01, 30) ),
                new Product (2, "2", "Лапша", 5,  0.9, "штучный", 90, new DateTime(2033, 03, 30) ),
                new Product (3, "3", "Масло", 1,  0.25, "штучный", 80, new DateTime(2023, 04, 05) ),
                new Product (4, "4", "Свинина", 2,  1.0, "развесной", 350, new DateTime(2023, 03, 27) ),
                new Product (5, "5", "Яйца", 2,  0.35, "штучный", 99, new DateTime(2023, 04, 20) ),
                new Product (6, "6", "Хлеб", 4,  0.5, "штучный", 50, new DateTime(2023, 02, 25) ),
                new Product (7, "7", "Вода", 6,  1.5, "штучный", 50, new DateTime(2033, 03, 25) ),
                new Product (8, "8", "Форель", 3,  1.0, "развесной", 500, new DateTime(2023, 03, 27) ),
                new Product (9, "9", "Сникерс", 7,  0.035, "штучный", 40, new DateTime(2023, 09, 27) )
                };
        }
    }

    public List<ProductQuantity> ListProductQuantities
    {
        get
        {
            var products = ListProducts;
            return new List<ProductQuantity>()
            {
            new ProductQuantity(1,products[0].Id, 1, 250),
            new ProductQuantity(2 ,products[1].Id, 1, 100),
            new ProductQuantity(3 ,products[2].Id, 1, 50),
            new ProductQuantity(4 ,products[4].Id, 1, 60),
            new ProductQuantity(5 ,products[5].Id, 1, 75),
            new ProductQuantity(6 ,products[6].Id, 1, 100),
            new ProductQuantity(7 ,products[8].Id, 1, 200),
            new ProductQuantity(8 ,products[1].Id, 2, 200),
            new ProductQuantity(9 ,products[4].Id, 2, 100),
            new ProductQuantity(10 ,products[5].Id, 2, 100),
            new ProductQuantity(11 ,products[6].Id, 2, 90),
            new ProductQuantity(12 ,products[8].Id, 2, 40),
            new ProductQuantity(13 ,products[0].Id, 3, 200),
            new ProductQuantity(14 ,products[2].Id, 3, 100),
            new ProductQuantity(15 ,products[3].Id, 3, 50),
            new ProductQuantity(16 ,products[4].Id, 3, 60),
            new ProductQuantity(17 ,products[5].Id, 3, 75),
            new ProductQuantity(18 ,products[6].Id, 3, 30),
            new ProductQuantity(19 ,products[7].Id, 3, 130)
            };
        }
    }
    public List<Customer> ListCustomers
    {
        get
        {
            return new List<Customer>
                {
                    new Customer(1, "Максим", "Матросов", "Владимирович", "10000"),
                    new Customer(2, "Иван", "Иванов", "Иванович", "10001"),
                    new Customer(3, "Лиана", "Волкова", "Степановна", "10002"),
                    new Customer(4, "Екатерина", "Анисимова", "Александровна", "10003"),
                    new Customer(5, "Александр", "Фатьянов", "Игоревич", "10004")
                };
        }
    }
    public List<PurchaseRecord> ListPurchaseRecords1
    {
        get
        {
            var customers = ListCustomers;
            var products = ListProducts;
            return new List<PurchaseRecord>
                {
                    new PurchaseRecord(1, 1, 1, customers[0], 1, products[0], 5.0, new DateTime(2023, 03, 13)),
                    new PurchaseRecord(2, 1, 1, customers[0], 2, products[1], 7.0, new DateTime(2023, 03, 13)),
                    new PurchaseRecord(3, 1, 2, customers[1], 1 ,products[0], 2.0, new DateTime(2023, 03, 14)),
                    new PurchaseRecord(4, 1, 2, customers[1], 4, products[3], 3.0, new DateTime(2023, 03, 14)),
                    new PurchaseRecord(5, 1, 3, customers[2], 1, products[0], 6.0, new DateTime(2023, 01, 20)),
                    new PurchaseRecord(6, 1, 3, customers[2], 2, products[1], 4.0, new DateTime(2023, 01, 20)),
                    new PurchaseRecord(7, 1, 5, customers[4], 1, products[0], 1.0, new DateTime(2023, 02, 23)),
                    new PurchaseRecord(8, 1, 5, customers[4], 4, products[3], 2.0, new DateTime(2023, 02, 23)),
                };
        }
    }
    public List<PurchaseRecord> ListPurchaseRecords2
    {
        get
        {
            var customers = ListCustomers;
            var products = ListProducts;
            return new List<PurchaseRecord>
                {
                    new PurchaseRecord(9, 2, 5, customers[4], 4, products[3], 2.0,   new DateTime(2023, 03, 13)),
                    new PurchaseRecord(10, 2, 5, customers[4], 6, products[6], 5.0,  new DateTime(2023, 03, 13)),
                    new PurchaseRecord(11, 2, 4, customers[3], 1, products[0], 1.0,  new DateTime(2023, 01, 14)),
                    new PurchaseRecord(12, 2, 4, customers[3], 4, products[3], 4.0,  new DateTime(2023, 01, 14)),
                    new PurchaseRecord(13, 2, 5, customers[4], 4, products[3], 2.0,  new DateTime(2023, 03, 13)),
                    new PurchaseRecord(14, 2, 5, customers[4], 7, products[6], 3.0,  new DateTime(2023, 03, 13)),
                    new PurchaseRecord(15, 2, 3, customers[2], 1, products[0], 2.0,  new DateTime(2023, 03, 14)),
                    new PurchaseRecord(16, 2, 3, customers[2], 4,  products[3], 1.0, new DateTime(2023, 03, 14)),
                };
        }
    }
    public List<PurchaseRecord> ListPurchaseRecords3
    {
        get
        {
            var customers = ListCustomers;
            var products = ListProducts;
            return new List<PurchaseRecord>
                {
                    new PurchaseRecord(17, 3, 3, customers[2], 1, products[0], 5.0, new DateTime(2023, 03, 13)),
                    new PurchaseRecord(18, 3, 3, customers[2], 2, products[1], 1.0, new DateTime(2023, 03, 13)),
                    new PurchaseRecord(19, 3, 5, customers[4], 1, products[0], 3.0, new DateTime(2023, 03, 14)),
                    new PurchaseRecord(20, 3, 5, customers[4], 4, products[3], 6.0, new DateTime(2023, 03, 14)),
                    new PurchaseRecord(21, 3, 1, customers[1], 4, products[3], 2.0, new DateTime(2023, 03, 13)),
                    new PurchaseRecord(22, 3, 1, customers[1], 7, products[6], 1.0, new DateTime(2023, 03, 13)),
                    new PurchaseRecord(23, 3, 1, customers[0], 1, products[0], 3.0, new DateTime(2023, 03, 14)),
                    new PurchaseRecord(24, 3, 1, customers[0], 4, products[3], 5.0, new DateTime(2023, 03, 14)),
                    };
        }
    }

    public List<ProductGroup> ListProductGroups
    {
        get
        {
            return new List<ProductGroup>
                {
                    new ProductGroup(1, "Молочный"),
                    new ProductGroup(2, "Мясной"),
                    new ProductGroup(3, "Рыбный"),
                    new ProductGroup(4, "Выпечка"),
                    new ProductGroup(5, "Бакалея"),
                    new ProductGroup(6, "Напитки"),
                    new ProductGroup(7, "Конфеты"),

                };
        }
    }
    public List<Product> Products => _products;
    public List<Shop> Shops => _shop;
    public List<Customer> Customers => _customers;
    public List<ProductGroup> ProductGroups => _productGroups;
    public List<ProductQuantity> ProductQuantities => _productQuantities;
    public List<PurchaseRecord> PurchaseRecords => _purchaseRecords;

}


