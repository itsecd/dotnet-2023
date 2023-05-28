using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace PonrfClient;

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

    public async Task<ICollection<PrivatizedBuildingGetDto>> GetPrivatizedBuildingAsync()
    {
        return await _client.PrivatizedBuildingAllAsync();
    }

    public async Task AddPrivatizedBuildingAsync(PrivatizedBuildingPostDto privatizedBuilding)
    {
        await _client.PrivatizedBuildingAsync(privatizedBuilding);
    }

    public async Task UpdatePrivatizedBuildingAsync(int id, PrivatizedBuildingPostDto privatizedBuilding)
    {
        await _client.PrivatizedBuilding3Async(id, privatizedBuilding);
    }

    public async Task DeletePrivatizedBuildingAsync(int id)
    {
        await _client.PrivatizedBuilding4Async(id);
    }

    public async Task<ICollection<AuctionGetDto>> GetAuctionAsync()
    {
        return await _client.AuctionAllAsync();
    }

    public async Task AddAuctionAsync(AuctionPostDto Auction)
    {
        await _client.AuctionAsync(Auction);
    }

    public async Task UpdateAuctionAsync(int id, AuctionPostDto Auction)
    {
        await _client.Auction3Async(id, Auction);
    }

    public async Task DeleteAuctionAsync(int id)
    {
        await _client.Auction4Async(id);
    }

    public async Task<ICollection<BuildingGetDto>> GetBuildingAsync()
    {
        return await _client.BuildingAllAsync();
    }

    public async Task AddBuildingAsync(BuildingPostDto Building)
    {
        await _client.BuildingAsync(Building);
    }

    public async Task UpdateBuildingAsync(int id, BuildingPostDto Building)
    {
        await _client.Building3Async(id, Building);
    }

    public async Task DeleteBuildingAsync(int id)
    {
        await _client.Building4Async(id);
    }

    public async Task<ICollection<CustomerGetDto>> GetCustomerAsync()
    {
        return await _client.CustomerAllAsync();
    }

    public async Task AddCustomerAsync(CustomerPostDto Customer)
    {
        await _client.CustomerAsync(Customer);
    }

    public async Task UpdateCustomerAsync(int id, CustomerPostDto Customer)
    {
        await _client.Customer3Async(id, Customer);
    }

    public async Task DeleteCustomerAsync(int id)
    {
        await _client.Customer4Async(id);
    }

    public async Task<ICollection<CustomerGetDto>> ViewAllCustomers()
    {
        return await _client.ViewAllCustomersAsync();
    }

    public async Task<ICollection<AuctionGetDto>> AuctionWithoutFullSales()
    {
        return await _client.AuctionsWithoutFullSalesAsync();
    }

    public async Task<ICollection<TopCustomerGetDto>> TopCustomer()
    {
        return await _client.TopCustomersAsync();
    }

    public async Task<ICollection<TopAuctionGetDto>> TopAuction()
    {
        return await _client.TopAuctionsAsync();
    }
}

