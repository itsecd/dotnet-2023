using PonrfDomain;

namespace PonrfServer.Repository;

/// <summary>
/// Interface for PonrfRepository
/// </summary>
public interface IPonrfRepository
{
    /// <summary>
    /// List of all auctions
    /// </summary>
    List<Auction> Auctions { get; }
    /// <summary>
    /// List of all buildings
    /// </summary>
    List<Building> Buildings { get; }
    /// <summary>
    /// List of all customers
    /// </summary>
    List<Customer> Customers { get; }
    /// <summary>
    /// List of all privatized buildings
    /// </summary>
    List<PrivatizedBuilding> PrivatizedBuildings { get; }
}