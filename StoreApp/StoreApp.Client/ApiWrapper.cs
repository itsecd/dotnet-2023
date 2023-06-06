using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace StoreApp.Client;

public class ApiWrapper
{
    public readonly ApiClient _client;

    public ApiWrapper()
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();
        var serverUrl = configuration.GetSection("ServerUrl").Value;
        _client = new ApiClient(serverUrl, new HttpClient());
    }

    public Task<ICollection<ProductGetDto>> GetProductAsync()
    {
        return _client.ProductAllAsync();
    }

    public Task PostProductAsync(ProductPostDto product)
    {
        return _client.ProductAsync(product);
    }

    public Task UpdateProductAsync(int id, ProductPostDto product)
    {
        return _client.Product3Async(id, product);
    }

    public Task DeleteProductAsync(int id)
    {
        return _client.Product4Async(id);
    }


    public Task<ICollection<CustomerGetDto>> GetCustomerAsync()
    {
        return _client.CustomerAllAsync();
    }

    public Task PostCustomerAsync(CustomerPostDto customer)
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


    public Task<ICollection<StoreGetDto>> GetStoreAsync()
    {
        return _client.StoreAllAsync();
    }

    public Task PostStoreAsync(StorePostDto store)
    {
        return _client.StoreAsync(store);
    }

    public Task UpdateStoreAsync(int id, StorePostDto store)
    {
        return _client.Store3Async(id, store);
    }

    public Task DeleteStoreAsync(int id)
    {
        return _client.Store4Async(id);
    }
}
