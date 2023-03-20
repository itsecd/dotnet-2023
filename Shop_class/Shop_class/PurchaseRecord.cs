
namespace Shop_class;
/// <summary>
/// PurchaseRecord - class describing purchase record
/// </summary>
public class PurchaseRecord
{
    public PurchaseRecord(Customer customer, List<Product> products,
                         double sum, DateTime dateSale)
    {
        Customer = customer;
        Products = products;

        Sum = sum;
        DateSale = dateSale;
    }
    /// <summary>
    /// who bought 
    /// </summary>
    public Customer Customer { get; set; }
    /// <summary>
    /// What bought
    /// </summary>
    public List<Product> Products { get; set; }
    /// <summary>
    /// purchase amount
    /// </summary>
    public double Sum { get; set; }
    /// <summary>
    /// When bought
    /// </summary>
    public DateTime DateSale { get; set; }
}
