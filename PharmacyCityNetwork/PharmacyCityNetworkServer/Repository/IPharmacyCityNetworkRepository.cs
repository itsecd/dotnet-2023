namespace PharmacyCityNetwork.Server.Repository;

public interface IPharmacyCityNetworkRepository
{
    List<Group> Groups { get; }
    List<Manufacturer> Manufacturers { get; }
    List<Pharmacy> Pharmacys { get; }
    List<PharmaGroup> PharmaGroups { get; }
    List<ProductPharmacy> ProductPharmacys { get; }
    List<ProductPharmaGroup> ProductPharmaGroups { get; }
    List<Product> Products { get; }
    List<Sale> Sale { get; }
}