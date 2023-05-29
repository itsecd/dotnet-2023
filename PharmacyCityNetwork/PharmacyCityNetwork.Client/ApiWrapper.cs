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

    public Task<ICollection<GroupGetDto>> GetGroupsAsync()
    {
        return _client.GroupAllAsync();
    }
    public async Task AddGroupAsync(GroupPostDto group)
    {
        await _client.GroupAsync(group);
    }
    public async Task UpdateGroupAsync(int id, GroupPostDto group)
    {
        await _client.Group3Async(id, group);
    }
    public async Task DeleteGroupAsync(int id)
    {
        await _client.Group4Async(id);
    }

    public Task<ICollection<PharmacyGetDto>> GetPharmacysAsync()
    {
        return _client.PharmacyAllAsync();
    }
    public async Task AddPharmacyAsync(PharmacyPostDto pharmacy)
    {
        await _client.PharmacyAsync(pharmacy);
    }
    public async Task UpdatePharmacyAsync(int id, PharmacyPostDto pharmacy)
    {
        await _client.Pharmacy3Async(id, pharmacy);
    }
    public async Task DeletePharmacyAsync(int id)
    {
        await _client.Pharmacy4Async(id);
    }
}
