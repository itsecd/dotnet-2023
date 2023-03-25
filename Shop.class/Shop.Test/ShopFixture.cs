using Shops.Domain;

namespace Shops.Test;
public class ShopFixture
{
    //Не получается сделать нормально объекты поля которых ссылаются друг на друга, делать как делал
    public List<Shop> ShopsList
    {
        get
        {
            var shops = new List<Shop>();
            var products = ProductQuantities;
            var purchases1 = ListPurchaseRecords1;
            var firstShop = new Shop(1, new List<ProductQuantity>() { products[0][0], products[0][1], products[0][2], products[0][3], products[0][4], products[0][5], products[0][6] }, purchases1);
            shops.Add(firstShop);
            var purchases2 = ListPurchaseRecords2;
            var secondShop = new Shop(2, new List<ProductQuantity>() { products[1][0], products[1][1], products[1][2], products[1][3], products[1][4]}, purchases2);
            shops.Add(secondShop);
            var purchases3 = ListPurchaseRecords3;
            var thirdShop = new Shop(3, new List<ProductQuantity>() { products[2][0], products[2][1], products[2][2], products[2][3], products[2][4], products[2][5], products[2][6] }, purchases3);
            shops.Add(thirdShop);
            return shops;

        }
        
    }
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

    public List<List<ProductQuantity>> ProductQuantities
    {
        get
        {
            var productQuantities = new List<List<ProductQuantity>>();
            var products = Products;
            var firstProductQuantities = new List<ProductQuantity>
            {   new ProductQuantity(products[0].Barcode, 1, 250),
                new ProductQuantity(products[1].Barcode, 1, 100),
                new ProductQuantity(products[2].Barcode, 1, 50),
                new ProductQuantity(products[4].Barcode, 1, 60),
                new ProductQuantity(products[5].Barcode, 1, 75),
                new ProductQuantity(products[6].Barcode, 1, 100),
                new ProductQuantity(products[8].Barcode, 1, 200)
            };
            productQuantities.Add(firstProductQuantities);
            var secondProductQuantities = new List<ProductQuantity>
            {
                new ProductQuantity(products[1].Barcode, 2, 200),
                new ProductQuantity(products[4].Barcode, 2, 100),
                new ProductQuantity(products[5].Barcode, 2, 100),
                new ProductQuantity(products[6].Barcode, 2, 90),
                new ProductQuantity(products[8].Barcode, 2, 40)
            };
            productQuantities.Add(secondProductQuantities);
            var thirdProductQuantities = new List<ProductQuantity>
            {
                new ProductQuantity(products[0].Barcode, 3, 200),
                new ProductQuantity(products[2].Barcode, 3, 100),
                new ProductQuantity(products[3].Barcode, 3, 50),
                new ProductQuantity(products[4].Barcode, 3, 60),
                new ProductQuantity(products[5].Barcode, 3, 75),
                new ProductQuantity(products[6].Barcode, 3, 30),
                new ProductQuantity(products[7].Barcode, 3, 130),
            };
            productQuantities.Add(thirdProductQuantities);

            return productQuantities;
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
            var customers = Customers;
            var products = Products;
            return new List<PurchaseRecord>
            {
                new PurchaseRecord(1, customers[0], products[0], 5.0, new DateTime(2023, 03, 13)),
                new PurchaseRecord(1, customers[0], products[1], 7.0, new DateTime(2023, 03, 13)),
                new PurchaseRecord(1, customers[1], products[0], 2.0, new DateTime(2023, 03, 14)),
                new PurchaseRecord(1, customers[1], products[3], 3.0, new DateTime(2023, 03, 14)),
                new PurchaseRecord(1, customers[2], products[0], 6.0, new DateTime(2023, 01, 20)),
                new PurchaseRecord(1, customers[2], products[1], 4.0, new DateTime(2023, 01, 20)),
                new PurchaseRecord(1, customers[4], products[0], 1.0, new DateTime(2023, 02, 23)),
                new PurchaseRecord(1, customers[4], products[3], 2.0, new DateTime(2023, 02, 23)),
            };
        }
    }
    public List<PurchaseRecord> ListPurchaseRecords2
    {
        get
        {
            var customers = Customers;
            var products = Products;
            return new List<PurchaseRecord>
            {
                new PurchaseRecord(2, customers[4], products[3], 2.0, new DateTime(2023, 03, 13)),
                new PurchaseRecord(2, customers[4], products[6], 5.0, new DateTime(2023, 03, 13)),
                new PurchaseRecord(2, customers[3], products[0], 1.0, new DateTime(2023, 01, 14)),
                new PurchaseRecord(2, customers[3], products[3], 4.0, new DateTime(2023, 01, 14)),
                new PurchaseRecord(2, customers[4], products[3], 2.0, new DateTime(2023, 03, 13)),
                new PurchaseRecord(2, customers[4], products[6], 3.0, new DateTime(2023, 03, 13)),
                new PurchaseRecord(2, customers[2], products[0], 2.0, new DateTime(2023, 03, 14)),
                new PurchaseRecord(2, customers[2], products[3], 1.0, new DateTime(2023, 03, 14)),
            };
        }
    }
    public List<PurchaseRecord> ListPurchaseRecords3
    {
        get
        {
            var customers = Customers;
            var products = Products;
            return new List<PurchaseRecord>
            {
                new PurchaseRecord(3, customers[2], products[0], 5.0, new DateTime(2023, 03, 13)),
                new PurchaseRecord(3, customers[2], products[1], 1.0, new DateTime(2023, 03, 13)),
                new PurchaseRecord(3, customers[4], products[0], 3.0, new DateTime(2023, 03, 14)),
                new PurchaseRecord(3, customers[4], products[3], 6.0, new DateTime(2023, 03, 14)),
                new PurchaseRecord(3, customers[1], products[3], 2.0, new DateTime(2023, 03, 13)),
                new PurchaseRecord(3, customers[1], products[6], 1.0, new DateTime(2023, 03, 13)),
                new PurchaseRecord(3, customers[0], products[0], 3.0, new DateTime(2023, 03, 14)),
                new PurchaseRecord(3, customers[0], products[3], 5.0, new DateTime(2023, 03, 14)),   
             };
        }
    }

    
}


