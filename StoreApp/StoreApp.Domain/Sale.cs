namespace StoreApp.Domain;

/// <summary>
/// The class describing the sale
/// </summary>
public class Sale
{
    /// <summary>
    /// Sale ID
    /// </summary>
    public int SaleId { get; set; }
    /// <summary>
    /// Date and time of sale
    /// </summary>
    public DateTime DateSale { get; set; } = new DateTime(1970, 1, 1);

    /// <summary>
    /// Customer
    /// </summary>
    public Customer Customer { get; set; }

    /// <summary>
    /// Store
    /// </summary>
    public Store Store { get; set; }

    /// <summary>
    /// List of products purchased by the customer 
    /// </summary>
    public List<Product> Products { get; set; }

    /// <summary>
    /// Purchase amount
    /// </summary>
    public double Sum { get; set; } = 0.0;

    public Sale(int saleId, string dateSale, Customer customer, Store store, List<Product> products)
    {
        SaleId = saleId;
        DateSale = DateTime.Parse(dateSale);
        Customer = customer;
        Store = store;
        Products = products;

        foreach (Product product in products)
        {
            Sum += product.ProductPrice;
            product.AddToSalesList(saleId);
        }
        customer.AddToSalesList(saleId);
        store.AddToSalesList(saleId);
    }

}



