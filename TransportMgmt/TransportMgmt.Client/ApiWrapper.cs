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

    public Task<ICollection<ModelGetDto>> GetModelsAsync()
    {
        return _client.ModelAllAsync();
    }
    public Task<ModelGetDto> GetModelsByIdAsync(int id)
    {
        return _client.Model2Async(id);
    }
    public Task<ModelGetDto> AddModeslAsync(ModelPostDto model)
    {
        return _client.ModelAsync(model);
    }
    public Task UpdateModeslAsync(int id, ModelPostDto model)
    {
        return _client.Model3Async(id, model);
    }
    public Task DeleteModeslAsync(int id)
    {
        return _client.Model4Async(id);
    }

    public Task<ICollection<TransportGetDto>> GetTransportsAsync()
    {
        return _client.TransportAllAsync();
    }
    public Task<TransportGetDto> GetTransportsByIdAsync(int id)
    {
        return _client.Transport2Async(id);
    }
    public Task<TransportGetDto> AddTransportsAsync(TransportPostDto transport)
    {
        return _client.TransportAsync(transport);
    }
    public Task UpdateTransportsAsync(int id, TransportPostDto transport)
    {
        return _client.Transport3Async(id, transport);
    }
    public Task DeleteTransportsAsync(int id)
    {
        return _client.Transport4Async(id);
    }

    public Task<ICollection<TransportTypesGetDto>> GetTransportTypesAsync()
    {
        return _client.TransportTypeAllAsync();
    }
    public Task<TransportTypesGetDto> GetTransportTypeByIdAsync(int id)
    {
        return _client.TransportTypeAsync(id);
    }

    public Task<ICollection<TripGetDto>> GetTripsAsync()
    {
        return _client.TripAllAsync();
    }
    public Task<TripGetDto> GetTripsByIdAsync(int id)
    {
        return _client.Trip2Async(id);
    }
    public Task<TripGetDto> AddTripsAsync(TripPostDto trip)
    {
        return _client.TripAsync(trip);
    }
    public Task UpdateTripsAsync(int id, TripPostDto trip)
    {
        return _client.Trip3Async(id, trip);
    }
    public Task DeleteTripsAsync(int id)
    {
        return _client.Trip4Async(id);
    }
}
