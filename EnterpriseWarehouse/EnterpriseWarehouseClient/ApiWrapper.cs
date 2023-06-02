using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace EnterpriseWarehouseClient;

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
        return _client.ProductPOSTAsync(product);
    }

    public Task UpdateProductAsync(int id, ProductPostDto product)
    {
        return _client.ProductPUTAsync(id, product);
    }

    public Task DeleteProductAsync(int id)
    {
        return _client.ProductDELETEAsync(id);
    }
}
