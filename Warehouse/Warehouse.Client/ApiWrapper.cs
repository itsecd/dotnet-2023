using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace Warehouse.Client;
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

    public async Task<ICollection<ProductsGetDto>> GetProductsAsync()
    {
        return await _client.AllProductsAsync();
    }

    public async Task AddProductAsync(ProductsPostDto product)
    {
        await _client.ProductsPOSTAsync(product);
    }

    public async Task UpdateProductAsync(int id, ProductsPostDto product)
    {
        await _client.ProductsPUTAsync(id, product);
    }

    public async Task DeleteProductAsync(int id)
    {
        await _client.ProductsDELETEAsync(id);
    }

    public async Task<ICollection<SuppliesGetDto>> GetSuppliesAsync()
    {
        return await _client.SuppliesAllAsync();
    }

    public async Task AddSupplyAsync(SuppliesPostDto supply)
    {
        await _client.SuppliesPOSTAsync(supply);
    }

    public async Task UpdateSupplyAsync(int id, SuppliesPostDto supply)
    {
        await _client.SuppliesPUTAsync(id, supply);
    }

    public async Task DeleteSupplyAsync(int id)
    {
        await _client.SuppliesDELETEAsync(id);
    }

    public async Task<ICollection<WarehouseCellsDto>> GetWarehouseCellsAsync()
    {
        return await _client.WarehouseCellsAllAsync();
    }

    public async Task AddWarehouseCellAsync(WarehouseCellsDto cell)
    {
        await _client.WarehouseCellsPOSTAsync(cell);
    }

    public async Task UpdateWarehouseCellAsync(int id, WarehouseCellsDto cell)
    {
        await _client.WarehouseCellsPUTAsync(id, cell);
    }

    public async Task DeleteWarehouseCellAsync(int id)
    {
        await _client.WarehouseCellsDELETEAsync(id);
    }

    public async Task<ICollection<ProductsGetDto>> GetAllProductsAsync()
    {
        return await _client.AllProductsAsync();
    }
}