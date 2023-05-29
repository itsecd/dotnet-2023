using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;


namespace CarSharingClient;
public class ApiWrapper
{
    private readonly ApiClient _client;
    public ApiWrapper()
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();
        var serverUrl = configuration.GetSection("ServerUrl").Value;

        _client = new ApiClient(serverUrl, new HttpClient());
    }

    public async Task<ICollection<CarGetDto>> GetCarsAsync()
    {
        return await _client.CarAllAsync();
    }
    public async Task AddCarsAsync(CarPostDto car)
    {
         await _client.CarAsync(car);
    }
    public async Task UpdateCarsAsync(int id, CarPostDto car)
    {
        await _client.Car3Async(id, car);
    }
    public async Task DeleteCarsAsync(int id)
    {
        await _client.Car4Async(id);
    }

    public async Task<ICollection<RentalPointPostDto>> GetRentalPointsAsync()
    {
        return await _client.RentalPointAllAsync();
    }
    public async Task AddRentalPointsAsync(RentalPointPostDto rentalPoint)
    {
        await _client.RentalPointAsync(rentalPoint);
    }
    public async Task UpdateRentalPointsAsync(int id, RentalPointPostDto rentalPoint)
    {
        await _client.RentalPoint3Async(id, rentalPoint);
    }
    public async Task DeleteRentalPointsAsync(int id)
    {
        await _client.RentalPoint4Async(id);
    }
}
