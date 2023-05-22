using MusicMarket;

namespace MusicMarketServer.Repository;
/// <summary>
/// Make interface Music Market repository
/// </summary>
public interface IMusicMarketRepository
{
    /// <summary>
    /// List of сustomers
    /// </summary>
    List<Customer> Customers { get; }
    /// <summary>
    /// List of products
    /// </summary>
    List<Product> Products { get; }
    /// <summary>
    /// List of purchases
    /// </summary>
    List<Purchase> Purchases { get; }
    /// <summary>
    /// List of sellers
    /// </summary>
    List<Seller> Sellers { get; }
}