using EnterpriseWarehouseClient;
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

    public Task<ICollection<InvoiceGetDto>> GetInvoicesAsync()
    {
        return _client.InvoiceAllAsync();
    }

    public Task<int> AddInvoiceAsync(InvoicePostDto invoice)
    {
        return _client.InvoicePOSTAsync(invoice);
    }

    public Task UpdateInvoiceAsync(int id, InvoicePostDto invoice)
    {
        return _client.InvoicePUTAsync(id, invoice);
    }

    public Task DeleteInvoiceAsync(int id)
    {
        return _client.InvoiceDELETEAsync(id);
    }

    public Task<ICollection<InvoiceContentGetDto>> GetInvoiceContentAsync()
    {
        return _client.InvoiceContentAllAsync();
    }

    public Task<int> AddInvoiceContentAsync(InvoiceContentPostDto invoiceContent)
    {
        return _client.InvoiceContentPOSTAsync(invoiceContent);
    }

    public Task UpdateInvoiceContentAsync(int id, InvoiceContentPostDto invoiceContent)
    {
        return _client.InvoiceContentPUTAsync(id, invoiceContent);
    }

    public Task DeleteInvoiceContentAsync(int id)
    {
        return _client.InvoiceContentDELETEAsync(id);
    }

    public Task<ICollection<ProductGetDto>> GetTopFiveProductsByStockAvailabilityAsync()
    {
        return _client.GetTopFiveProductsByStockAvailabilityAsync();
    }
}
