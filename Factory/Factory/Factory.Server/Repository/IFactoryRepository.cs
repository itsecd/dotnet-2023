using Factory.Domain;

namespace Factory.Server.Repository;
public interface IFactoryRepository
{
    List<Enterprise> Enterprises { get; }
    List<TypeIndustry> IndustryTypes { get; }
    List<OwnershipForm> OwnershipForms { get; }
    List<Supplier> Suppliers { get; }
    List<Supply> Supplies { get; }
}