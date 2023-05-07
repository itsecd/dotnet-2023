using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace StoreApp.Model;

/// <summary>
/// The class describing the sale
/// </summary>
public class Sale
{
    /// <summary>
    /// Sale ID
    /// </summary>
    [Key]
    public int SaleId { get; set; }

    /// <summary>
    /// Date and time of sale
    /// </summary>
    [Required]
    public DateTime DateSale { get; set; } = new DateTime(1970, 1, 1);

    /// <summary>
    /// Customer
    /// </summary>
    [ForeignKey("Customer")]
    [Required]
    public int CustomerId { get; set; } = -1;

    /// <summary>
    /// Store
    /// </summary>
    [ForeignKey("Store")]
    [Required]
    public int StoreId { get; set; } = -1;

    /// <summary>
    /// Purchase amount
    /// </summary>
    [Required]
    public double Sum { get; set; } = 0.0;

    /// <summary>
    /// Collection of ProductSales
    /// </summary>
    public List<ProductSale> ProductSales { get; set; } = new List<ProductSale>();

    public Sale() { }

    public Sale(int saleId, string dateSale, int customerId, int storeId, double sum)
    {
        SaleId = saleId;
        DateSale = DateTime.Parse(dateSale);
        CustomerId = customerId;
        StoreId = storeId;
        Sum = sum;
    }
}



