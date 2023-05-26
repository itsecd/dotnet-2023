
using Microsoft.Extensions.Configuration;
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

    public async Task<ICollection<FabricGetDto>> GetFabricAsync()
    {
        return await _client.FabricAllAsync();
    }

    public async Task<FabricGetDto> AddFabricAsync(FabricPostDto fabric)
    {
        return await _client.FabricAsync(fabric);
    }

    public async Task UpdateFabricAsync(int id, FabricPostDto fabric)
    {
        await _client.Fabric3Async(id, fabric);
    }

    public async Task DeleteFabricAsync(int id)
    {
        await _client.Fabric4Async(id);
    }

    public async Task<ICollection<ProviderGetDto>> GetProviderAsync()
    {
        return await _client.ProviderAllAsync();
    }

    public async Task<ProviderGetDto> AddProviderAsync(ProviderPostDto provider)
    {
        return await _client.ProviderAsync(provider);
    }

    public async Task UpdateProviderAsync(int id, ProviderPostDto provider)
    {
        await _client.Provider3Async(id, provider);
    }

    public async Task DeleteProviderAsync(int id)
    {
        await _client.Provider4Async(id);
    }

    public async Task<ICollection<ShipmentGetDto>> GetShipmentAsync()
    {
        return await _client.ShipmentAllAsync();
    }

    public async Task<ShipmentGetDto> AddShipmentAsync(ShipmentPostDto shipment)
    {
        return await _client.ShipmentAsync(shipment);
    }

    public async Task UpdateShipmentAsync(int id, ShipmentPostDto shipment)
    {
        await _client.Shipment3Async(id, shipment);
    }

    public async Task DeleteShipmentAsync(int id)
    {
        await _client.Shipment4Async(id);
    }
}