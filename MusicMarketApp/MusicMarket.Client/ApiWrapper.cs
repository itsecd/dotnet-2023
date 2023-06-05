using Microsoft.Extensions.Configuration;
using MusicMarketClient;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace MusicMarket.Client;
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
        return (Task<CustomerGetDto>)_client.CustomerAsync(customer);
    }

    public Task UpdateCustomerAsync(int id, CustomerPostDto customer)
    {
        return _client.Customer3Async(id, customer);
    }
    public Task DeleteCustomerAsync(int id)
    {
        return _client.Customer4Async(id);
    }

    public Task<ICollection<ProductGetDto>> GetProductsAsync()
    {
        return _client.ProductAllAsync();
    }
    public Task<ProductGetDto> AddProductAsync(ProductPostDto product)
    {
        return (Task<ProductGetDto>)_client.ProductAsync(product);
    }
    public Task UpdateProductAsync(int id, ProductPostDto product)
    {
        return _client.Product3Async(id, product);
    }
    public Task DeleteProductAsync(int id)
    {
        return _client.Product4Async(id);
    }

    public Task<ICollection<PurchaseGetDto>> GetPurchasesAsync()
    {
        return _client.PurchaseAllAsync();
    }
    public Task<PurchaseGetDto> AddPurchaseAsync(PurchasePostDto record)
    {
        return (Task<PurchaseGetDto>)_client.PurchaseAsync(record);
    }
    public Task UpdatePurchaseAsync(int id, PurchasePostDto record)
    {
        return _client.Purchase3Async(id, record);
    }
    public Task DeletePurchaseAsync(int id)
    {
        return _client.Purchase4Async(id);
    }


    public Task<ICollection<SellerGetDto>> GetSellersAsync()
    {
        return _client.SellerAllAsync();
    }
    public Task<SellerGetDto> AddSellerAsync(SellerPostDto shop)
    {
        return (Task<SellerGetDto>)_client.SellerAsync(shop);
    }
    public Task UpdateSellerAsync(int id, SellerPostDto shop)
    {
        return _client.Seller3Async(id, shop);
    }
    public Task DeleteSellerAsync(int id)
    {
        return _client.Seller4Async(id);
    }

}
