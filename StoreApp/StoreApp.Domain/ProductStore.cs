namespace StoreApp.Domain;

/// <summary>
/// Relationship between a product, a store, and the quantity of that product
/// </summary>
public class ProductStore
{
    /// <summary>
    /// Product ID
    /// </summary>
    public int ProductId { get; set; }

    /// <summary>
    /// Store ID
    /// </summary>
    public int StoreId { get; set; }

    /// <summary>
    /// Product quantity
    /// </summary>
    public int Quantity { get; set; }


}

