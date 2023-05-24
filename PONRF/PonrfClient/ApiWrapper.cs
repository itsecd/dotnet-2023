using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace PonrfClient;

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

    public async Task<ICollection<PrivatizedBuildingGetDto>> GetPrivatizedBuildingAsync()
    {
        return await _client.PrivatizedBuildingAllAsync();
    }

    public async Task AddPrivatizedBuildingAsync(PrivatizedBuildingPostDto privatizedBuilding)
    {
        await _client.PrivatizedBuildingAsync(privatizedBuilding);
    }

    public async Task UpdatePrivatizedBuildingAsync(int id, PrivatizedBuildingPostDto privatizedBuilding)
    {
        await _client.PrivatizedBuilding3Async(id, privatizedBuilding);
    }

    public async Task DeletePrivatizedBuildingAsync(int id)
    {
        await _client.PrivatizedBuilding4Async(id);
    }
}

