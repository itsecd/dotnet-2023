using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace Airlines.Client;
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

    public async Task<ICollection<PassengerGetDto>> GetPassengersAsync()
    {
            return await _client.PassengerAllAsync();
    }

public async Task AddPassengerAsync(PassengerPostDto passenger)
{
    await _client.PassengerAsync(passenger);
}

public async Task UpdatePassengerAsync(int id, PassengerPostDto passenger)
{
    await _client.Passenger3Async(id, passenger);
}

public async Task DeletePassengerAsync(int id)
{
    await _client.Passenger4Async(id);
}
}