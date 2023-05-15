using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using RentalService.Server.Dto;

namespace RentalService.Client;

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

    public async Task<ICollection<ApiClient.ClientGetDto>> GetClientsAsync()
    {
        return await _client.ClientAllAsync();
    }
    
    public async Task AddClientsAsync(ApiClient.ClientPostDto client)
    {
        await _client.ClientPOSTAsync(client);
    }
    
    public async Task UpdateClientsAsync(long id, ApiClient.ClientPostDto client)
    {
        await _client.ClientPUTAsync(id, client);
    }

    public async Task DeleteClientsAsync(long id)
    {
        await _client.ClientDELETEAsync(id);
    }
}