
using Shop_class;

namespace xUnitTest;
public class ShopFixtture
{
    public List<Product> Products
    {
        get
        {
            return new List<Product>()
            {
            new Product ("1", "Молоко", 1,  0.5, "штучный", 70, new DateTime(2023, 01, 30) ),
            new Product ("2", "Лапша", 5,  0.9, "штучный", 90, new DateTime(2033, 03, 30) ),
            new Product ("3", "Масло", 1,  0.25, "штучный", 80, new DateTime(2023, 04, 05) ),
            new Product ("4", "Свинина", 2,  1.0, "развесной", 350, new DateTime(2023, 03, 27) ),
            new Product ("5", "Яйца", 2,  0.35, "штучный", 99, new DateTime(2023, 04, 20) ),
            new Product ("6", "Хлеб", 4,  0.5, "штучный", 50, new DateTime(2023, 02, 25) ),
            new Product ("7", "Вода", 6,  1.5, "штучный", 50, new DateTime(2033, 03, 25) ),
            new Product ("8", "Форель", 3,  1.0, "развесной", 500, new DateTime(2023, 03, 27) ),
            new Product ("9", "Сникерс", 7,  0.035, "штучный", 40, new DateTime(2023, 09, 27) )
            };
        }
    }

    public List<ProductQuantity> ProductQuantities1
    {
        get
        {
            return new List<ProductQuantity>
            {
                new ProductQuantity("1", 1, 250),
                new ProductQuantity("2", 1, 100),
                new ProductQuantity("3", 1, 50),
                new ProductQuantity("5", 1, 60),
                new ProductQuantity("6", 1, 75),
                new ProductQuantity("7", 1, 100),
                new ProductQuantity("9", 1, 200)
            };
        }
    }
    public List<ProductQuantity> ProductQuantities2
    {
        get
        {
            return new List<ProductQuantity>
            {
                new ProductQuantity("2", 2, 200),
                new ProductQuantity("5", 2, 100),
                new ProductQuantity("6", 2, 100),
                new ProductQuantity("7", 2, 90),
                new ProductQuantity("9", 2, 40)
            };
        }
    }
    public List<ProductQuantity> ProductQuantities3
    {
        get
        {
            return new List<ProductQuantity>
            {
                new ProductQuantity("1", 3, 200),
                new ProductQuantity("3", 3, 100),
                new ProductQuantity("4", 3, 50),
                new ProductQuantity("5", 3, 60),
                new ProductQuantity("6", 3, 75),
                new ProductQuantity("7", 3, 30),
                new ProductQuantity("8", 3, 130),
            };
        }
    }
    public List<Customer> Customers
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
            return new List<PurchaseRecord>
            {
                new PurchaseRecord(Customers[0], new List<Product> {Products[0], Products[1] }, 400.0, new DateTime(2023, 03, 13)),
                new PurchaseRecord(Customers[1], new List<Product> {Products[0], Products[3] }, 300.0, new DateTime(2023, 03, 14)),
            };
        }
    }
    public List<PurchaseRecord> ListPurchaseRecords2
    {
        get
        {
            return new List<PurchaseRecord>
            {
                new PurchaseRecord(Customers[4], new List<Product> {Products[3], Products[6] }, 400.0, new DateTime(2023, 03, 13)),
                new PurchaseRecord(Customers[3], new List<Product> {Products[0], Products[3] }, 300.0, new DateTime(2023, 03, 14)),
            };
        }
    }
    public List<PurchaseRecord> ListPurchaseRecords3
    {
        get
        {
            return new List<PurchaseRecord>
            {
                new PurchaseRecord(Customers[2], new List<Product> {Products[0], Products[1] }, 200.0, new DateTime(2023, 03, 13)),
                new PurchaseRecord(Customers[4], new List<Product> {Products[0], Products[3] }, 150.0, new DateTime(2023, 03, 14)),
            };
        }
    }

    public List<Shop> Shops
    {           
        get 
        {
            return new List<Shop>()
            {
                new Shop(1, ProductQuantities1, ListPurchaseRecords1),
                new Shop(2, ProductQuantities2, ListPurchaseRecords2),
                new Shop(3, ProductQuantities3, ListPurchaseRecords3)
            };
        } 
    }

}

        
