using Enterprise.Data;
using EnterpriseWarehouseServer.Repositories;

namespace EnterpriseWarehouseServer;

/// <summary>
///     ProductRepository - create list of element of the Product
/// </summary>
public class ProductRepository : IProductRepository
{
    private readonly List<Product> _products;

    public ProductRepository()
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
    }

    public List<Product> Products => _products;
}