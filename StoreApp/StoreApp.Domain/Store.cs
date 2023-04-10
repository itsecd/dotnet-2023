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
    /// Store sales ID collection
    /// </summary>
    public List<int> SalesId { get; set; } = new List<int>();

    public Store() { }

    public Store(int storeId, string storeName, string storeAddress)
    {
        StoreId = storeId;
        StoreName = storeName;
        StoreAddress = storeAddress;
        SalesId = new List<int>();
    }
}

