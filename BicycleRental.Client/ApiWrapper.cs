using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace BicycleRental.Client;

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

    public async Task<ICollection<BicycleGetDto>> GetBicyclesAsync()
    {
        return await _client.BicycleAllAsync();
    }

    public async Task AddBicycleAsync(BicyclePostDto bicycle)
    {
        await _client.BicyclePOSTAsync(bicycle);
    }

    public async Task UpdateBicycleAsync(int id, BicyclePostDto bicycle)
    {
        await _client.BicyclePUTAsync(id, bicycle);
    }

    public async Task DeleteBicycleAsync(int id)
    {
        await _client.BicycleDELETEAsync(id);
    }


    public async Task<ICollection<CustomerGetDto>> GetCustomerAsync()
    {
        return await _client.CustomerAllAsync();
    }

    public async Task AddCustomerAsync(CustomerPostDto customer)
    {
        await _client.CustomerPOSTAsync(customer);
    }

    public async Task UpdateCustomerAsync(int id, CustomerPostDto customer)
    {
        await _client.CustomerPUTAsync(id, customer);
    }

    public async Task DeleteCustomerAsync(int id)
    {
        await _client.CustomerDELETEAsync(id);
    }

    public async Task<ICollection<RentalGetDto>> GetRentalsAsync()
    {
        return await _client.RentalAllAsync();
    }

    public async Task AddRentalAsync(RentalPostDto rental)
    {
        await _client.RentalPOSTAsync(rental);
    }

    public async Task UpdateRentalAsync(int id, RentalPostDto rental)
    {
        await _client.RentalPUTAsync(id, rental);
    }

    public async Task DeleteRentalAsync(int id)
    {
        await _client.RentalDELETEAsync(id);
    }

    public async Task<ICollection<BicycleTypeGetDto>> GetTypesAsync()
    {
        return await _client.BicycleTypeAllAsync();
    }

    public async Task<ICollection<BicycleGetDto>> GetSportAsync()
    {
        return await _client.GetSportBicyclesAsync();
    }
}

