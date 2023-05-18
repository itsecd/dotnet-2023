using Enterprise.Data;

namespace EnterpriseWarehouseServer.Repositories;

/// <summary>
///     MainRepository - create list of elements of the Product, StorageCell and Invoce
/// </summary>
public class MainRepository : IMainRepository
{

    private readonly List<Product> _products;

    private readonly List<StorageCell> _storageCells;

    private readonly List<Invoice> _invoices;

    public MainRepository()
    {
        _products = new List<Product>{
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

        _storageCells = new List<StorageCell>{
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

        _invoices = new List<Invoice>{
                new Invoice (1, "СамараПласт", "г. Самара, ул. Луцкая, 16.", new DateTime(2023, 2, 10), new Dictionary<uint, uint>{ { 102302, 10} } ),
                new Invoice (2, "Посуда Центр", "г. Самара, ул. Партизанская, 17.", new DateTime(2023, 2, 11), new Dictionary<uint, uint>{{ 101700, 5}, { 320510, 10 } }),
                new Invoice (4, "Посуда Центр", "г. самара, ул. Партизанская, 17.", new DateTime(2023, 2, 15), new Dictionary<uint, uint>{{103700, 10}})
            };
    }

    public List<Product> Products => _products;

    public List<StorageCell> StorageCell => _storageCells;

    public List<Invoice> Invoices => _invoices;
}