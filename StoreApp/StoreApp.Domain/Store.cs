namespace StoreApp.Domain;

/// <summary>
/// Class describing the store
/// </summary>
public class Store
{
    /// <summary>
    /// Store ID
    /// </summary>
    public int StoreId { get; set; }

    /// <summary>
    /// Store name
    /// </summary>
    public string StoreName { get; set; }

    /// <summary>
    /// Store address
    /// </summary>
    public string StoreAddress { get; set; }

    public Store(int storeId, string storeName, string storeAddress)
    {
        StoreId = storeId;
        StoreName = storeName;
        StoreAddress = storeAddress;
    }
}

