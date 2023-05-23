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

            product_1.InvoicesContent.Add(invoiceContent_1);
            product_8.InvoicesContent.Add(invoiceContent_2);
            product_6.InvoicesContent.Add(invoiceContent_3);
            product_9.InvoicesContent.Add(invoiceContent_4);

            invoice_1.InvoicesContent.Add(invoiceContent_1);
            invoice_2.InvoicesContent.Add(invoiceContent_2);
            invoice_2.InvoicesContent.Add(invoiceContent_3);
            invoice_3.InvoicesContent.Add(invoiceContent_4);

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

            product_1.InvoicesContent.Add(invoiceContent_1);
            product_8.InvoicesContent.Add(invoiceContent_2);
            product_6.InvoicesContent.Add(invoiceContent_3);
            product_9.InvoicesContent.Add(invoiceContent_4);

            invoice_1.InvoicesContent.Add(invoiceContent_1);
            invoice_2.InvoicesContent.Add(invoiceContent_2);
            invoice_2.InvoicesContent.Add(invoiceContent_3);
            invoice_3.InvoicesContent.Add(invoiceContent_4);

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
}