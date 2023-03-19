
namespace Shop_class;
/// <summary>
/// 
/// </summary>
public class PurchaseRecord
{
    public PurchaseRecord(Customer customer, List<Product> products,
        Shop shop, double sum, DateTime dateSale)
    {
        Customer = customer;
        Products = products;
        Shop = shop;
        Sum = sum;
        DateSale = dateSale;
    }

    public Customer Customer { get; set; }
    public List<Product> Products { get; set; }
    public Shop Shop { get; set; }
    public double Sum { get; set; }
    public DateTime DateSale { get; set; }
}
