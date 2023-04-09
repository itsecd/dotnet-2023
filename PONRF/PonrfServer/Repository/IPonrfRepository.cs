using PonrfDomain;

namespace PonrfServer.Repository;
public interface IPonrfRepository
{
    List<Auction> Auctions { get; }
    List<Building> Buildings { get; }
    List<Customer> Customers { get; }
    List<PrivatizedBuilding> PrivatizedBuildings { get; }
}