using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopsDomain;
/// <summary>
/// PurchaseRecord - class describing purchase record
/// </summary>
public class PurchaseRecord
{
    public PurchaseRecord() { }
    public PurchaseRecord(int id, int shopId, int customerId, Customer customer, int productId, Product product, double quantity, DateTime dateSale)
    {
        Id = id;
        ShopId = shopId;
        CustomerId = customerId;
        Customer = customer;
        ProductId = productId;
        Product = product;
        Quantity = quantity;
        DateSale = dateSale;
        Sum = product.Price * quantity;
    }
    /// <summary>
    /// Id is used to store the ID.
    /// </summary>
    [Key]
    public int Id { get; set; }
    /// <summary>
    /// Were bought
    /// </summary>
    [ForeignKey("Shop")]
    public int ShopId { get; set; }
    /// <summary>
    /// Who bought (id)
    /// </summary>
    [ForeignKey("Customer")]
    public int CustomerId { get; set; }
    /// <summary>
    /// Customer is used to store information about the customer
    /// </summary>
    public Customer? Customer { get; set; }
    /// <summary>
    /// What bought (barcode)
    /// </summary>
    [ForeignKey("Product")]
    public int ProductId { get; set; }
    /// <summary>
    /// Product is used to store information about the product
    /// </summary>
    public Product? Product { get; set; }
    /// <summary>
    /// How much bought
    /// </summary>
    [Required]
    public double Quantity { get; set; } = 0.0;
    /// <summary>
    /// When bought
    /// </summary>
    [Required]
    public DateTime DateSale { get; set; }
    /// <summary>
    /// Purchase amount
    /// </summary>
    [Required]
    public double Sum { get; set; } = 0.0;
}
