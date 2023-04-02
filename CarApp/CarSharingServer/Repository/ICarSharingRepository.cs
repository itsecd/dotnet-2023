using CarSharingDomain;

namespace CarSharingServer.Repository;

public interface ICarSharingRepository
{
    List<Client> Clients { get; }
    List<Car> Cars { get; }
    List<RentalPoint> RentalPoints { get; }
    List<RentedCar> RentedCars { get; }
}
