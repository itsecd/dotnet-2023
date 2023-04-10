namespace StoreApp.Domain;

/// <summary>
/// Relationship between a product, a store, and the quantity of that product
/// </summary>
public class ProductStore
{
    /// <summary>
    /// Id
    /// </summary>
    public int Id { get; set; } = -1;
    /// <summary>
    /// Product ID
    /// </summary>
    public int ProductId { get; set; } = -1;

    /// <summary>
    /// Store ID
    /// </summary>
    public int StoreId { get; set; } = -1;

    /// <summary>
    /// Product quantity
    /// </summary>
    public int Quantity { get; set; } = 0;

    public ProductStore() { }

    public ProductStore(int id, int productId, int storeId, int quantity)
    {
        Id = id;
        ProductId = productId;
        StoreId = storeId;
        Quantity = quantity;
    }
}

