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

    public Task UpdateProductAsync(int itemNumber, ProductPostDto product)
    {
        return _client.ProductPUTAsync(itemNumber, product);
    }

    public Task DeleteProductAsync(int itemNumber)
    {
        return _client.ProductDELETEAsync(itemNumber);
    }

    public Task<ICollection<StorageCellGetDto>> GetStorageCellsAsync()
    {
        return _client.StorageCellAllAsync();
    }

    public Task<int> AddStorageCellAsync(StorageCellPostDto storageCell)
    {
        return _client.StorageCellPOSTAsync(storageCell);
    }

    public Task UpdateStorageCellAsync(int cellNumber, StorageCellPostDto storageCell)
    {
        return _client.StorageCellPUTAsync(cellNumber, storageCell);
    }

    public Task DeleteStorageCellAsync(int cellNumber)
    {
        return _client.StorageCellDELETEAsync(cellNumber);
    }
}
