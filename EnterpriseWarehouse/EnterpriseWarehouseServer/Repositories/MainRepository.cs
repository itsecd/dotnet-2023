using Enterprise.Data;

namespace EnterpriseWarehouseServer.Repositories;

/// <summary>
///     MainRepository - create list of elements of the Product, StorageCell and Invoce
/// </summary>
public class MainRepository : IMainRepository
{

    private readonly List<Product> _products;

    private readonly List<StorageCell> _storageCells;

    private readonly List<InvoiceContent> _invoicesContent;

    private readonly List<Invoice> _invoices;

    public MainRepository()
    {
        _products = new List<Product>{
            new Product(102302, "Картонная коробка 40*30*30", 100),
            new Product(104302, "Картонная коробка 60*40*50", 50),
            new Product(106302, "Чайник из нерж. стали 3л", 5),
            new Product(108302, "Кастрюля алюм. с крышкой 5л", 10),
            new Product(310510, "Столовая ложка из нерж. стали", 35),
            new Product(312510, "Чайная ложка из нерж. стали", 50),
            new Product(320510, "Вилка из нерж. стали", 25),
            new Product(101700, "Кувшин для воды из стекла 4л", 10),
            new Product(103700, "Кувшин для воды из стекла 3л", 15)
        };

        _storageCells = new List<StorageCell>{
            new StorageCell(1, _products[0]),
            new StorageCell(2, _products[1]),
            new StorageCell(3, _products[2]),
            new StorageCell(4, _products[3]),
            new StorageCell(5, _products[4]),
            new StorageCell(6, _products[4]),
            new StorageCell(7, _products[4]),
            new StorageCell(8, _products[5]),
            new StorageCell(9, _products[5]),
            new StorageCell(10, _products[6]),
            new StorageCell(11, _products[7]),
            new StorageCell(12, _products[7]),
            new StorageCell(13, _products[7]),
            new StorageCell(14, _products[7]),
            new StorageCell(15, _products[8]),
            new StorageCell(16, _products[8])
        };

        _storageCells[0].ProductIN = _products[0].ItemNumber;
        _storageCells[1].ProductIN = _products[1].ItemNumber;
        _storageCells[2].ProductIN = _products[2].ItemNumber;
        _storageCells[3].ProductIN = _products[3].ItemNumber;
        _storageCells[4].ProductIN = _products[4].ItemNumber;
        _storageCells[5].ProductIN = _products[4].ItemNumber;
        _storageCells[6].ProductIN = _products[4].ItemNumber;
        _storageCells[7].ProductIN = _products[5].ItemNumber;
        _storageCells[8].ProductIN = _products[5].ItemNumber;
        _storageCells[9].ProductIN = _products[6].ItemNumber;
        _storageCells[10].ProductIN = _products[7].ItemNumber;
        _storageCells[11].ProductIN = _products[7].ItemNumber;
        _storageCells[12].ProductIN = _products[7].ItemNumber;
        _storageCells[13].ProductIN = _products[7].ItemNumber;
        _storageCells[14].ProductIN = _products[8].ItemNumber;
        _storageCells[15].ProductIN = _products[8].ItemNumber;

        _products[0].StorageCell.Add(_storageCells[0]);
        _products[1].StorageCell.Add(_storageCells[1]);
        _products[2].StorageCell.Add(_storageCells[2]);
        _products[3].StorageCell.Add(_storageCells[3]);
        _products[4].StorageCell.Add(_storageCells[4]);
        _products[4].StorageCell.Add(_storageCells[5]);
        _products[4].StorageCell.Add(_storageCells[6]);
        _products[5].StorageCell.Add(_storageCells[7]);
        _products[5].StorageCell.Add(_storageCells[8]);
        _products[6].StorageCell.Add(_storageCells[9]);
        _products[7].StorageCell.Add(_storageCells[10]);
        _products[7].StorageCell.Add(_storageCells[11]);
        _products[7].StorageCell.Add(_storageCells[12]);
        _products[7].StorageCell.Add(_storageCells[13]);
        _products[8].StorageCell.Add(_storageCells[14]);
        _products[8].StorageCell.Add(_storageCells[15]);

        _invoices = new List<Invoice>{
            new Invoice(1, "СамараПласт", "г. Самара, ул. Луцкая, 16.", new DateTime(2023, 2, 10)),
            new Invoice(2, "Посуда Центр", "г. Самара, ул. Партизанская, 17.", new DateTime(2023, 2, 11)),
            new Invoice(4, "Посуда Центр", "г. самара, ул. Партизанская, 17.", new DateTime(2023, 2, 15))
        };

        _invoicesContent = new List<InvoiceContent>
        {
            new InvoiceContent(1, _invoices[0], _products[0], 10),
            new InvoiceContent(2, _invoices[1], _products[7], 5),
            new InvoiceContent(3, _invoices[1], _products[6], 10),
            new InvoiceContent(4, _invoices[2], _products[8], 10)
        };

        _invoicesContent[0].InvoiceId = _invoices[0].Id;
        _invoicesContent[1].InvoiceId = _invoices[1].Id;
        _invoicesContent[2].InvoiceId = _invoices[1].Id;
        _invoicesContent[3].InvoiceId = _invoices[2].Id;

        _invoicesContent[0].ProductItemNumber = _products[0].ItemNumber;
        _invoicesContent[1].ProductItemNumber = _products[7].ItemNumber;
        _invoicesContent[2].ProductItemNumber = _products[6].ItemNumber;
        _invoicesContent[3].ProductItemNumber = _products[8].ItemNumber;

        _invoices[0].InvoicesContent.Add(_invoicesContent[0]);
        _invoices[1].InvoicesContent.Add(_invoicesContent[1]);
        _invoices[1].InvoicesContent.Add(_invoicesContent[2]);
        _invoices[2].InvoicesContent.Add(_invoicesContent[3]);

        _products[0].InvoicesContent.Add(_invoicesContent[0]);
        _products[7].InvoicesContent.Add(_invoicesContent[1]);
        _products[6].InvoicesContent.Add(_invoicesContent[2]);
        _products[8].InvoicesContent.Add(_invoicesContent[3]);
    }

    public List<Product> Products => _products;

    public List<StorageCell> StorageCell => _storageCells;

    public List<InvoiceContent> InvoicesContent => _invoicesContent;

    public List<Invoice> Invoices => _invoices;
}