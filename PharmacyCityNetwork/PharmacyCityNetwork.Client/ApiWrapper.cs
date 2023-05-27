using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace PharmacyCityNetwork.Client;
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
    public Task<ICollection<ProductGetDto>> GetProductsAsync()
    {
       return _client.ProductAllAsync();
    }
    public async Task AddProductAsync(ProductPostDto product)
    {
        await _client.ProductAsync(product);
    }
    public async Task UpdateProductAsync(int id, ProductPostDto product)
    {
        await _client.Product3Async(id, product);
    }
    public async Task DeleteProductAsync(int id)
    {
        await _client.Product4Async(id);
    }
}
