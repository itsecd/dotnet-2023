using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace Taxi.Client;

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

    public Task<ICollection<Driver>> GetDriversAsync()
    {
        return _client.DriverAllAsync();
    }
    
    public Task<Driver> AddDriverAsync(DriverSetDto driver)
    {
        return _client.DriverPOSTAsync(driver);
    }
    
    public Task UpdateDriverAsync(ulong id, DriverSetDto driver)
    {
        return _client.DriverPUTAsync(id, driver);
    }
    
    public Task DeleteDriverAsync(ulong id)
    {
        return _client.DriverDELETEAsync(id);
    }
}