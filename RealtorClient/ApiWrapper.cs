using Microsoft.Extensions.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace RealtorClient;
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
    public Task<ICollection<HouseGetDto>> GetHouseAsync()
    {
        return _client.HousesAllAsync();
    }
    public Task<HouseGetDto> AddHouseAsync(HousePostDto house)
    {
        return _client.HousesAsync(house);
    }
    public Task UpdateHouseAsync(int id, HousePostDto house)
    {
        return _client.Houses3Async(id,house);
    }
    public Task DeleteHouseAsync(int id)
    {
        return _client.Houses4Async(id);
    }



    public Task<ICollection<ApplicationGetDto>> GetApplicationAsync()
    {
        return _client.ApplicationsAllAsync();
    }
    public Task<ApplicationGetDto> AddApplicationAsync(ApplicationPostDto application)
    {
        return _client.ApplicationsAsync(application);
    }
    public Task UpdateApplicationAsync(int id, ApplicationPostDto application)
    {
        return _client.Applications3Async(id, application);
    }
    public Task DeleteApplicationAsync(int id)
    {
        return _client.Applications4Async(id);
    }



    public Task<ICollection<ClientGetDto>> GetClientAsync()
    {
        return _client.ClientsAllAsync();
    }
    public Task<ClientGetDto> AddClientAsync(ClientPostDto client)
    {
        return _client.ClientsAsync(client);
    }
    public Task UpdateClientAsync(int id, ClientPostDto client)
    {
        return _client.Clients3Async(id, client);
    }
    public Task DeleteClientAsync(int id)
    {
        return _client.Clients4Async(id);
    }



    public Task<ICollection<ApplicationHasHouseDto>> GetApplicationHasHouseAsync()
    {
        return _client.ApplicationHasHousesAllAsync();
    }
    public Task<ApplicationHasHouseDto> AddApplicationHasHouseAsync(ApplicationHasHouseDto applicationHasHouse)
    {
        return _client.ApplicationHasHousesAsync(applicationHasHouse);
    }
    public Task UpdateApplicationHasHouseAsync(int id, ApplicationHasHouseDto applicationHasHouse)
    {
        return _client.ApplicationHasHouses3Async(id, applicationHasHouse);
    }
    public Task DeleteApplicationHasHouseAsync(int id)
    {
        return _client.ApplicationHasHouses4Async(id);
    }
    public async Task<System.Collections.Generic.ICollection<ClientGetDto>> GetBuyers()
    {
        return await _client.ClientsBuyersAsync();
    }
}
