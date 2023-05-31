using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace EnterpriseWarehouse.Client;

internal class ApiWrapper
{
    private readonly ApiClient _client;

    public ApiWrapper()
    {
        var configuration = new ConfigurationBuilder()
            .AddUserSecrets<ApiWrapper>()
            .Build();
        var serverUrl = configuration.GetConnectionString("ServerUrl");

        _client = new ApiClient(serverUrl, new HttpClient());
    }

    public Task<ICollection<ProductGetDto>> GetProductsAsync()
    {
        return _client.ProductAllAsync();
    }

    public Task<int> AddProductAsync(ProductPostDto product)
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
}
