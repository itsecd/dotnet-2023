using Realtor;

namespace RealtorServer.Repository;

public interface IRealtorRepository
{
    List<House> Houses { get; }
    List<Client> Clients { get; }
    List<Application> Applications { get; }
}
