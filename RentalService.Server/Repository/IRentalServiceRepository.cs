using RentalService.Domain;

namespace RentalService.Server.Repository;

public interface IRentalServiceRepository
{
    List<Client> Clients { get; }
    List<RentalPoint> RentalPoints { get; }
    List<VehicleModel> VehicleModels { get; }
    List<Vehicle> Vehicles { get; }
    List<RefundInformation> RefundInformations { get; }
    List<RentalInformation> RentalInformations { get; }
    List<IssuedCar> IssuedCars { get; }
}