namespace Shops.Domain;
/// <summary>
/// PurchaseRecord - class describing purchase record
/// </summary>
public class PurchaseRecord
{
    public PurchaseRecord() { }

    public PurchaseRecord(int shopId, Customer customer, Product product, double quantity, DateTime dateSale)
    {
        ShopId = shopId;
        Customer = customer;
        Product = product;
        Quantity = quantity;
        DateSale = dateSale;
        Sum = product.Price * quantity;
    }
    public int ShopId { get; set; }
    /// <summary>
    /// Who bought 
    /// </summary>
    public Customer Customer { get; set; } = new Customer();
    /// <summary>
    /// What bought
    /// </summary>
    public Product Product { get; set; } = new Product();
    /// <summary>
    /// How much bought
    /// </summary>
    public double Quantity { get; set; } = 0.0;
    /// <summary>
    /// When bought
    /// </summary>
    public DateTime DateSale { get; set; }
    /// <summary>
    /// Purchase amount
    /// </summary>
    public double Sum { get; set; } = 0.0;
}
