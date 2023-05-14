using Microsoft.Extensions.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace AirplaneBookingSystem.Client;
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
    public Task<ICollection<AirplaneGetDto>> GetAirplanesAsync()
    {
        return _client.AirplaneAllAsync();
    }

    public Task<AirplaneGetDto> AddAirplaneAsync(AirplanePostDto airplane)
    {
        return (Task<AirplaneGetDto>)_client.AirplaneAsync(airplane);
    }

    public Task UpdateAirplaneAsync(int id, AirplanePostDto airplane)
    {
        return _client.Airplane3Async(id, airplane);
    }

    public Task DeleteAirplaneAsync(int id)
    {
        return _client.Airplane4Async(id);
    }
}
