using NonResidentialFund.Domain;

namespace NonResidentialFund.Server.Repository;
public interface INonResidentialFundRepository
{
    List<Auction> Auctions { get; }
    List<Building> Buildings { get; }
    List<Buyer> Buyers { get; }
    List<District> Districts { get; }
    List<Organization> Organizations { get; }
    List<Privatized> Privatized { get; }
}