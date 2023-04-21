using System.ComponentModel.DataAnnotations.Schema;

namespace StoreApp.Domain;

/// <summary>
/// Class describing the store
/// </summary>
public class Store
{
    /// <summary>
    /// Store ID
    /// </summary>
    public int StoreId { get; set; } = -1;

    /// <summary>
    /// Store name
    /// </summary>
    public string StoreName { get; set; } = string.Empty;

    /// <summary>
    /// Store address
    /// </summary>
    public string StoreAddress { get; set; } = string.Empty;

    /// <summary>
    /// Store sales collection
    /// </summary>
    public List<Sale> Sales { get; set; } = null!;

    /// <summary>
    /// Collection ProductStore
    /// </summary>
    public List<ProductStore> ProductStores { get; set; } = null!;

    public Store() { }

    public Store(int storeId, string storeName, string storeAddress)
    {
        StoreId = storeId;
        StoreName = storeName;
        StoreAddress = storeAddress;
        Sales = new List<Sale>();
        ProductStores = new List<ProductStore>();
    }
}

