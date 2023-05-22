namespace Enterprise.Data.Tests;
using Enterprise.Data;

/// <summary>
///     EnterpriseFixture - class that generates the test data
/// </summary>
public class EnterpriseFixture
{
    public List<Product> ProductsFixture
    {
        get
        {
            var product_1 = new Product(102302, "Картонная коробка 40*30*30", 100);
            var product_2 = new Product(104302, "Картонная коробка 60*40*50", 50);
            var product_3 = new Product(106302, "Чайник из нерж. стали 3л", 5);
            var product_4 = new Product(108302, "Кастрюля алюм. с крышкой 5л", 10);
            var product_5 = new Product(310510, "Столовая ложка из нерж. стали", 35);
            var product_6 = new Product(312510, "Чайная ложка из нерж. стали", 50);
            var product_7 = new Product(320510, "Вилка из нерж. стали", 25);
            var product_8 = new Product(101700, "Кувшин для воды из стекла 4л", 10);
            var product_9 = new Product(103700, "Кувшин для воды из стекла 3л", 15);

            var invoice_1 = new Invoice(1, "СамараПласт", "г. Самара, ул. Луцкая, 16.", new DateTime(2023, 2, 10));
            var invoice_2 = new Invoice(2, "Посуда Центр", "г. Самара, ул. Партизанская, 17.", new DateTime(2023, 2, 11));
            var invoice_3 = new Invoice(4, "Посуда Центр", "г. самара, ул. Партизанская, 17.", new DateTime(2023, 2, 15));

            var invoiceContent_1 = new InvoiceContent(1, invoice_1, product_1, 10);
            var invoiceContent_2 = new InvoiceContent(2, invoice_2, product_8, 5);
            var invoiceContent_3 = new InvoiceContent(3, invoice_2, product_7, 10);
            var invoiceContent_4 = new InvoiceContent(4, invoice_3, product_9, 10);

            product_1.InvoiceContent.Add(invoiceContent_1);
            product_8.InvoiceContent.Add(invoiceContent_2);
            product_6.InvoiceContent.Add(invoiceContent_3);
            product_9.InvoiceContent.Add(invoiceContent_4);

            invoice_1.InvoiceContent.Add(invoiceContent_1);
            invoice_2.InvoiceContent.Add(invoiceContent_2);
            invoice_2.InvoiceContent.Add(invoiceContent_3);
            invoice_3.InvoiceContent.Add(invoiceContent_4);

            product_1.StorageCell.Add(new StorageCell(1, product_1));
            product_2.StorageCell.Add(new StorageCell(2, product_2));
            product_3.StorageCell.Add(new StorageCell(3, product_3));
            product_4.StorageCell.Add(new StorageCell(4, product_4));
            product_5.StorageCell.Add(new StorageCell(5, product_5));
            product_5.StorageCell.Add(new StorageCell(6, product_5));
            product_5.StorageCell.Add(new StorageCell(7, product_5));
            product_6.StorageCell.Add(new StorageCell(8, product_6));
            product_6.StorageCell.Add(new StorageCell(9, product_6));
            product_7.StorageCell.Add(new StorageCell(10, product_7));
            product_8.StorageCell.Add(new StorageCell(11, product_8));
            product_8.StorageCell.Add(new StorageCell(12, product_8));
            product_8.StorageCell.Add(new StorageCell(13, product_8));
            product_8.StorageCell.Add(new StorageCell(14, product_8));
            product_9.StorageCell.Add(new StorageCell(15, product_9));
            product_9.StorageCell.Add(new StorageCell(16, product_9));

            var products = new List<Product> {
                product_1, product_2, product_3, product_4, product_5,
                product_6, product_7, product_8, product_9
            };

            return products;
        }
    }

    public List<Invoice> InvoicesFixture
    {
        get
        {
            var product_1 = new Product(102302, "Картонная коробка 40*30*30", 100);
            var product_2 = new Product(104302, "Картонная коробка 60*40*50", 50);
            var product_3 = new Product(106302, "Чайник из нерж. стали 3л", 5);
            var product_4 = new Product(108302, "Кастрюля алюм. с крышкой 5л", 10);
            var product_5 = new Product(310510, "Столовая ложка из нерж. стали", 35);
            var product_6 = new Product(312510, "Чайная ложка из нерж. стали", 50);
            var product_7 = new Product(320510, "Вилка из нерж. стали", 25);
            var product_8 = new Product(101700, "Кувшин для воды из стекла 4л", 10);
            var product_9 = new Product(103700, "Кувшин для воды из стекла 3л", 15);

            var invoice_1 = new Invoice(1, "СамараПласт", "г. Самара, ул. Луцкая, 16.", new DateTime(2023, 2, 10));
            var invoice_2 = new Invoice(2, "Посуда Центр", "г. Самара, ул. Партизанская, 17.", new DateTime(2023, 2, 11));
            var invoice_3 = new Invoice(4, "Посуда Центр", "г. самара, ул. Партизанская, 17.", new DateTime(2023, 2, 15));

            var invoiceContent_1 = new InvoiceContent(1, invoice_1, product_1, 10);
            var invoiceContent_2 = new InvoiceContent(2, invoice_2, product_8, 5);
            var invoiceContent_3 = new InvoiceContent(3, invoice_2, product_7, 10);
            var invoiceContent_4 = new InvoiceContent(4, invoice_3, product_9, 10);

            product_1.InvoiceContent.Add(invoiceContent_1);
            product_8.InvoiceContent.Add(invoiceContent_2);
            product_6.InvoiceContent.Add(invoiceContent_3);
            product_9.InvoiceContent.Add(invoiceContent_4);

            invoice_1.InvoiceContent.Add(invoiceContent_1);
            invoice_2.InvoiceContent.Add(invoiceContent_2);
            invoice_2.InvoiceContent.Add(invoiceContent_3);
            invoice_3.InvoiceContent.Add(invoiceContent_4);

            product_1.StorageCell.Add(new StorageCell(1, product_1));
            product_2.StorageCell.Add(new StorageCell(2, product_2));
            product_3.StorageCell.Add(new StorageCell(3, product_3));
            product_4.StorageCell.Add(new StorageCell(4, product_4));
            product_5.StorageCell.Add(new StorageCell(5, product_5));
            product_5.StorageCell.Add(new StorageCell(6, product_5));
            product_5.StorageCell.Add(new StorageCell(7, product_5));
            product_6.StorageCell.Add(new StorageCell(8, product_6));
            product_6.StorageCell.Add(new StorageCell(9, product_6));
            product_7.StorageCell.Add(new StorageCell(10, product_7));
            product_8.StorageCell.Add(new StorageCell(11, product_8));
            product_8.StorageCell.Add(new StorageCell(12, product_8));
            product_8.StorageCell.Add(new StorageCell(13, product_8));
            product_8.StorageCell.Add(new StorageCell(14, product_8));
            product_9.StorageCell.Add(new StorageCell(15, product_9));
            product_9.StorageCell.Add(new StorageCell(16, product_9));

            var invoices = new List<Invoice>
            {
                invoice_1, invoice_2, invoice_3
            };

            return invoices;
        }
    }
    /*
    /// <summary>
    ///     ProductFixture - return list of element of the Product
    /// </summary>
    public static List<Product> ProductFixture
    {
        get
        {
            return new List<Product> {
                new Product (102302, "Картонная коробка 40*30*30", 100, new List<uint>{1}),
                new Product (104302, "Картонная коробка 60*40*50", 50, new List<uint>{2}),
                new Product (106302, "Чайник из нерж. стали 3л", 5, new List<uint>{3}),
                new Product (108302, "Кастрюля алюм. с крышкой 5л", 10, new List<uint>{4}),
                new Product (310510, "Столовая ложка из нерж. стали", 35, new List<uint>{5, 6, 7}),
                new Product (312510, "Чайная ложка из нерж. стали", 50, new List<uint>{8, 9}),
                new Product (320510, "Вилка из нерж. стали", 25, new List<uint>{10}),
                new Product (101700, "Кувшин для воды из стекла 4л", 10, new List<uint>{11, 12, 13, 14}),
                new Product (103700, "Кувшин для воды из стекла 3л", 15, new List<uint>{15, 16})
            };
        }
    }

    /// <summary>
    ///     StorageCellFixture - return list of element of the Storage Cell
    /// </summary>
    public static List<StorageCell> StorageCellFixture
    {
        get
        {
            return new List<StorageCell>
            {
                new StorageCell (1, 102302),
                new StorageCell (2, 104302),
                new StorageCell (3, 106302),
                new StorageCell (4, 108302),
                new StorageCell (5, 310510),
                new StorageCell (6, 310510),
                new StorageCell (7, 310510),
                new StorageCell (8, 312510),
                new StorageCell (9, 312510),
                new StorageCell (10, 320510),
                new StorageCell (11, 101700),
                new StorageCell (12, 101700),
                new StorageCell (13, 101700),
                new StorageCell (14, 101700),
                new StorageCell (15, 103700),
                new StorageCell (16, 103700)

            };
        }
    }

    /// <summary>
    ///     InvoceContentFixture - return list of element of the Invoice Content
    /// </summary>
    public static List<InvoiceContent> InvoiceContentFixture
    {
        get
        {
            return new List<InvoiceContent>
            {
                new InvoiceContent (1, 1, 102302, 10),
                new InvoiceContent (2, 2, 101700, 5),
                new InvoiceContent (3, 2, 320510, 10),
                new InvoiceContent (4, 4, 103700, 10)
            };
        }
    }

    /// <summary>
    ///     InvoceFixture - return list of element of the Invoce
    /// </summary>
    public static List<Invoice> InvoiceFixture
    {
        get
        {
            return new List<Invoice>
            {
                new Invoice (1, "СамараПласт", "г. Самара, ул. Луцкая, 16.", new DateTime(2023, 2, 10), new List<uint>{1 }),
                new Invoice (2, "Посуда Центр", "г. Самара, ул. Партизанская, 17.", new DateTime(2023, 2, 11), new List<uint>{2, 3 }),
                new Invoice (4, "Посуда Центр", "г. самара, ул. Партизанская, 17.", new DateTime(2023, 2, 15), new List<uint>{4 })
            };
        }
    }*/
}