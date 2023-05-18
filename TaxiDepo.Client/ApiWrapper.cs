using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace TaxiDepo.Client;
public class ApiWrapper
{
    private readonly ApiClient _client;

    public ApiWrapper()
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        _client = new ApiClient(configuration.GetSection("ServerUrl").Value,
            new HttpClient());
    }

    public async Task<ICollection<CarDto>> GetAllCars()
        => await _client.GetAllCarsAsync();

    public async Task<CarDto> AddCar(CarDto car)
        => await _client.PostCarAsync(car);

    public async Task UpdateCar(int id, CarDto car)
    {
        await _client.CarsPUTAsync(id, car);
    }

    public async Task DeleteCar(int id)
    {
        await _client.CarsDELETEAsync(id);
    }


    public async Task<ICollection<DriverDto>> GetAllDrivers()
        => await _client.GetAllDriversAsync();

    public async Task<DriverDto> AddDriver(DriverDto driver)
        => await _client.PostDriverAsync(driver);

    public async Task UpdateDriver(int id, DriverDto driver)
    {
        await _client.DriversPUTAsync(id, driver);
    }

    public async Task DeleteDriver(int id)
    {
        await _client.DriversDELETEAsync(id);
    }


    public async Task<ICollection<RideDto>> GetAllRides()
       => await _client.GetAllRidesAsync();

    public async Task<RideDto> AddRide(RideDto ride)
        => await _client.PostRideAsync(ride);

    public async Task UpdateRide(int id, RideDto ride)
    {
        await _client.RidesPUTAsync(id, ride);
    }

    public async Task DeleteRide(int id)
    {
        await _client.RidesDELETEAsync(id);
    }


    public async Task<ICollection<UserDto>> GetAllUsers()
       => await _client.GetAllUsersAsync();

    public async Task<UserDto> AddUser(UserDto user)
        => await _client.PostUserAsync(user);

    public async Task UpdateUser(int id, UserDto user)
    {
        await _client.UsersPUTAsync(id, user);
    }

    public async Task DeleteUser(int id)
    {
        await _client.UsersDELETEAsync(id);
    }


}