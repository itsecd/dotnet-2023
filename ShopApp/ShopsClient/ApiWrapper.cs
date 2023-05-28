using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace ShopsClient;

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
    public Task<ICollection<CustomerGetDto>> GetCusomersAsync()
    {
        return _client.CustomerAllAsync();
    }
    public Task<CustomerGetDto> AddCustomerAsync(CustomerPostDto customer)
    {
        return _client.CustomerAsync(customer);
    }
    public Task UpdateCustomerAsync(int id, CustomerPostDto customer)
    {
        return _client.Customer3Async(id, customer);
    }
    public Task DeleteCustomerAsync(int id)
    {
        return _client.Customer4Async(id);
    }
}
