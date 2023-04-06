using CarSharingDomain;

namespace CarSharingServer.Repository;
/// <summary>
/// Interface for CarSharingRepository
/// </summary>
public interface ICarSharingRepository
{
    /// <summary>
    /// List of all clients
    /// </summary>
    List<Client> Clients { get; }
    /// <summary>
    /// List of all cars
    /// </summary>
    List<Car> Cars { get; }
    /// <summary>
    /// List of all rental points
    /// </summary>
    List<RentalPoint> RentalPoints { get; }
    /// <summary>
    /// List of all rented cars
    /// </summary>
    List<RentedCar> RentedCars { get; }
}
