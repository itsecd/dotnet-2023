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

    public Task<ICollection<ProductGetDto>> GetProductsAsync()
    {
        return _client.ProductsAllAsync();
    }
    public Task<ProductGetDto> AddProductAsync(ProductPostDto product)
    {
        return _client.ProductsAsync(product);
    }
    public Task UpdateProductAsync(int id, ProductPostDto product)
    {
        return _client.Products3Async(id, product);
    }
    public Task DeleteProductAsync(int id)
    {
        return _client.Products4Async(id);
    }

    public Task<ICollection<ProductGroupGetDto>> GetProductGroupsAsync()
    {
        return _client.ProductGroupAllAsync();
    }
    public Task<ProductGetDto> AddProductGroupAsync(ProductGroupPostDto productGroup)
    {
        return _client.ProductGroupAsync(productGroup);
    }
    public Task UpdateProductGroupAsync(int id, ProductGroupPostDto productGroup)
    {
        return _client.ProductGroup3Async(id, productGroup);
    }
    public Task DeleteProductGroupAsync(int id)
    {
        return _client.ProductGroup4Async(id);
    }

    public Task<ICollection<ProductQuantityGetDto>> GetProductQuantitysAsync()
    {
        return _client.ProductQuantityAllAsync();
    }
    public Task<ProductQuantityGetDto> AddProductQuantityAsync(ProductQuantityPostDto product)
    {
        return _client.ProductQuantityAsync(product);
    }
    public Task UpdateProductQuantityAsync(int id, ProductQuantityPostDto product)
    {
        return _client.ProductQuantity3Async(id, product);
    }
    public Task DeleteProductQuantityAsync(int id)
    {
        return _client.ProductQuantity4Async(id);
    }

    public Task<ICollection<PurchaseRecordGetDto>> GetPurchaseRecordsAsync()
    {
        return _client.PurchaseRecordAllAsync();
    }
    public Task<PurchaseRecordGetDto> AddPurchaseRecordAsync(PurchaseRecordPostDto record)
    {
        return _client.PurchaseRecordAsync(record);
    }
    public Task UpdatePurchaseRecordAsync(int id, PurchaseRecordPostDto record)
    {
        return _client.PurchaseRecord3Async(id, record);
    }
    public Task DeletePurchaseRecordAsync(int id)
    {
        return _client.PurchaseRecord4Async(id);
    }

    public Task<ICollection<ShopGetDto>> GetShopsAsync()
    {
        return _client.ShopAllAsync();
    }
    public Task<ShopGetDto> AddShopAsync(ShopPostDto shop)
    {
        return _client.ShopAsync(shop);
    }
    public Task UpdateShopAsync(int id, ShopPostDto shop)
    {
        return _client.Shop3Async(id, shop);
    }
    public Task DeleteShopAsync(int id)
    {
        return _client.Shop4Async(id);
    }

    public Task<ICollection<PurchaseRecordGetDto>> Top5PurchasesAsync()
    {
        return _client.Top5PurchasesAsync();
    }
}
