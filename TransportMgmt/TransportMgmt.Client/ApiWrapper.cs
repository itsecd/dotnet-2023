using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace TransportMgmt.Client;

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


    public Task<ICollection<RoutesGetDto>> GetRoutesAsync()
    {
        return _client.RoutesAllAsync();
    }

    public Task<RoutesGetDto> GetRoutesByIdAsync(int id)
    {
        return _client.RoutesAsync(id);
    }

    public Task<ICollection<DriverGetDto>> GetDriversAsync()
    {
        return _client.DriverAllAsync();
    }

    public Task<DriverGetDto> GetDriversByIdAsync(int id)
    {
        return _client.Driver2Async(id);
    }

    public Task<DriverGetDto> AddDriversAsync(DriverPostDto driver)
    {
        return _client.DriverAsync(driver);
    }

    public Task UpdateDriversAsync(int id, DriverPostDto driver)
    {
        return _client.Driver3Async(id, driver);
    }

    public Task DeleteDriversAsync(int id)
    {
        return _client.Driver4Async(id);
    }
}
