
using Microsoft.Extensions.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace Fabrics.Client;
public class ApiWrapper
{
    private readonly ApiClient _client;

    public ApiWrapper()
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();
        var serverUrl = configuration.GetRequiredSection("ServerUrl").Value;

        _client = new ApiClient(serverUrl, new HttpClient());
    }

    public Task<ICollection<FabricGetDto>> GetFabricAsync()
    {
        return _client.FabricAllAsync();
    }
    
    public Task AddFabricAsync(FabricPostDto fabric)
    {
        return _client.FabricAsync(fabric);
    }
    
    public Task UpdateFabricAsync(int id, FabricPostDto fabric)
    {
        return _client.Fabric3Async(id, fabric);
    }
    
    public Task DeleteFabricAsync(int id)
    {
        return _client.Fabric4Async(id);
    }

    public Task<ICollection<ProviderGetDto>> GetProviderAsync()
    {
        return _client.ProviderAllAsync();
    }

    public Task AddProviderAsync(ProviderPostDto provider)
    {
        return _client.ProviderAsync(provider);
    }

    public Task UpdateProviderAsync(int id, ProviderPostDto provider)
    {
        return _client.Provider3Async(id, provider);
    }

    public Task DeleteProviderAsync(int id)
    {
        return _client.Provider4Async(id);
    }

    public Task<ICollection<ShipmentGetDto>> GetShipmentAsync()
    {
        return _client.ShipmentAllAsync();
    }

    public Task AddShipmentAsync(ShipmentPostDto shipment)
    {
        return _client.ShipmentAsync(shipment);
    }

    public Task UpdateShipmentAsync(int id, ShipmentPostDto shipment)
    {
        return _client.Shipment3Async(id, shipment);
    }

    public Task DeleteShipmentAsync(int id)
    {
        return _client.Shipment4Async(id);
    }
}
