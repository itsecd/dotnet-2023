using System.ComponentModel.DataAnnotations.Schema;

namespace StoreApp.Domain;

/// <summary>
/// The class describing the sale
/// </summary>
public class Sale
{
    /// <summary>
    /// Sale ID
    /// </summary>
    public int SaleId { get; set; } = -1;
    /// <summary>
    /// Date and time of sale
    /// </summary>
    public DateTime DateSale { get; set; } = new DateTime(1970, 1, 1);

    /// <summary>
    /// Customer
    /// </summary>
    [ForeignKey("CustomerId")]
    public int CustomerId { get; set; } = -1;

    /// <summary>
    /// Store
    /// </summary>
    [ForeignKey("StoreId")]
    public int StoreId { get; set; } = -1;

    /// <summary>
    /// Purchase amount
    /// </summary>
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



