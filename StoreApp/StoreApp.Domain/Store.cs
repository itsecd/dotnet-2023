using System.ComponentModel.DataAnnotations;
namespace StoreApp.Domain;

/// <summary>
/// Class describing the store
/// </summary>
public class Store
{
    /// <summary>
    /// Store ID
    /// </summary>
    [Key]
    public int StoreId { get; set; }

    /// <summary>
    /// Store name
    /// </summary>
    [Required]
    public string StoreName { get; set; } = string.Empty;

    /// <summary>
    /// Store address
    /// </summary>
    [Required]
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

