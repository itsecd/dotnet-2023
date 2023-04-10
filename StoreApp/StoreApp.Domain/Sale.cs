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
    public int CustomerId { get; set; } = -1;

    /// <summary>
    /// Store
    /// </summary>
    public int StoreId { get; set; } = -1;

    /// <summary>
    /// List of products purchased by the customer 
    /// </summary>
    public List<int> Products { get; set; } = new List<int>();

    /// <summary>
    /// Purchase amount
    /// </summary>
    public double Sum { get; set; } = 0.0;

    public Sale() { }

    public Sale(int saleId, string dateSale, int customerId, int storeId, List<int> products, double sum)
    {
        SaleId = saleId;
        DateSale = DateTime.Parse(dateSale);
        CustomerId = customerId;
        StoreId = storeId;
        Products = products;
        Sum = sum;
    }
}



