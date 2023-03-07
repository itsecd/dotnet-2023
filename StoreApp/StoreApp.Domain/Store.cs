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

    /// <summary>
    /// Store sales ID collection
    /// </summary>
    public List<int> SalesId { get; set; }


    public Store(int storeId, string storeName, string storeAddress)
    {
        StoreId = storeId;
        StoreName = storeName;
        StoreAddress = storeAddress;
        SalesId = new List<int>();
    }

    /// <summary>
    /// Method for adding sales id to the collection
    /// </summary>
    /// <param name="idsale">
    /// ID sale
    /// </param>
    public void AddToSalesList(int idsale)
    {
        SalesId.Add(idsale);
    }
}

