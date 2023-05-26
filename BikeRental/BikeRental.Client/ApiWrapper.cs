using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace BikeRental.Client;
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

    public Task<ICollection<BikeGetDto>> GetBikesAsync()
    {
        return _client.BikesAllAsync();
    }

    public Task<BikeGetDto> AddBikeAsync(BikeSetDto bike)
    {
        return _client.BikesAsync(bike);
    }

    public Task UpdateBikeAsync(int id, BikeSetDto bike)
    {
        return _client.Bikes3Async(id, bike);
    }

    public Task DeleteBikeAsync(int id)
    {
        return _client.Bikes4Async(id);
    }
}
