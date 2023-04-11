using MusicMarket;

namespace MusicMarketServer.Repository;
public interface IMusicMarketRepository
{
    List<Customer> Customers { get; }
    List<Product> Products { get; }
    List<Purchase> Purchases { get; }
    List<Seller> Sellers { get; }
}