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

    public async Task<ICollection<CarDto>> GetAllCarsAsync()
        => await _client.GetAllCarsAsync();

    public async Task<CarDto> AddCarAsync(CarDto car)
        => await _client.PostCarAsync(car);

    public async Task UpdateCarAsync(int id, CarDto car)
    {
        await _client.Cars2Async(id, car);
    }

    public async Task DeleteCarAsync(int id)
    {
        await _client.Cars3Async(id);
    }


    public async Task<ICollection<DriverDto>> GetAllDriversAsync()
        => await _client.GetAllDriversAsync();

    public async Task<DriverDto> AddDriverAsync(DriverDto driver)
        => await _client.PostDriverAsync(driver);

    public async Task UpdateDriverAsync(int id, DriverDto driver)
    {
        await _client.Drivers2Async(id, driver);
    }

    public async Task DeleteDriverAsync(int id)
    {
        await _client.Drivers3Async(id);
    }


    public async Task<ICollection<RideDto>> GetAllRidesAsync()
       => await _client.GetAllRidesAsync();

    public async Task<RideDto> AddRideAsync(RideDto ride)
        => await _client.PostRideAsync(ride);

    public async Task UpdateRideAsync(int id, RideDto ride)
    {
        await _client.Rides2Async(id, ride);
    }

    public async Task DeleteRideAsync(int id)
    {
        await _client.Rides3Async(id);
    }


    public async Task<ICollection<UserDto>> GetAllUsersAsync()
       => await _client.GetAllUsersAsync();

    public async Task<UserDto> AddUserAsync(UserDto user)
        => await _client.PostUserAsync(user);

    public async Task UpdateUserAsync(int id, UserDto user)
    {
        await _client.Users2Async(id, user);
    }

    public async Task DeleteUserAsync(int id)
    {
        await _client.Users3Async(id);
    }


}