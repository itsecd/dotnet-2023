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

    public async Task<ICollection<BikeGetDto>> GetBikesAsync()
    {
        return await _client.BikesAllAsync();
    }

    public async Task<BikeGetDto> AddBikeAsync(BikeSetDto bike)
    {
        return await _client.BikesAsync(bike);
    }

    public async Task UpdateBikeAsync(int id, BikeSetDto bike)
    {
        await _client.Bikes3Async(id, bike);
    }

    public async Task DeleteBikeAsync(int id)
    {
        await _client.Bikes4Async(id);
    }

    public async Task<ICollection<BikeTypeGetDto>> GetBikeTypesAsync()
    {
        return await _client.BikeTypesAllAsync();
    }

    public async Task<ICollection<ClientGetDto>> GetClientsAsync()
    {
        return await _client.ClientsAllAsync();
    }

    public async Task<ClientGetDto> AddClientAsync(ClientSetDto client)
    {
        return await _client.ClientsAsync(client);
    }

    public async Task UpdateClientAsync(int id, ClientSetDto client)
    {
        await _client.Clients3Async(id, client);
    }

    public async Task DeleteClientAsync(int id)
    {
        await _client.Clients4Async(id);
    }

    public async Task<ICollection<RentRecordGetDto>> GetRentRecordsAsync()
    {
        return await _client.RentRecordsAllAsync();
    }

    public async Task<RentRecordGetDto> AddRentRecordAsync(RentRecordSetDto rentRecord)
    {
        return await _client.RentRecordsAsync(rentRecord);
    }

    public async Task UpdateRentRecordAsync(int id, RentRecordSetDto rentRecord)
    {
        await _client.RentRecords3Async(id, rentRecord);
    }

    public async Task DeleteRentRecordAsync(int id)
    {
        await _client.RentRecords4Async(id);
    }
}
