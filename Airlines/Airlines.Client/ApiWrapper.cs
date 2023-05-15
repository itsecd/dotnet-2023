using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace Airlines.Client;
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
    public async Task<ICollection<PassengerGetDto>> GetPassengersAsync()
    {
        return await _client.PassengerAllAsync();
    }
    public async Task AddPassengerAsync(PassengerPostDto passenger)
    {
        await _client.PassengerAsync(passenger);
    }
    public async Task UpdatePassengerAsync(int id, PassengerPostDto passenger)
    {
        await _client.Passenger3Async(id, passenger);
    }
    public async Task DeletePassengerAsync(int id)
    {
        await _client.Passenger4Async(id);
    }
    public async Task<ICollection<TicketGetDto>> GetTicketsAsync()
    {
        return await _client.TicketAllAsync();
    }
    public async Task AddTicketAsync(TicketPostDto ticket)
    {
        await _client.TicketAsync(ticket);
    }
    public async Task UpdateTicketAsync(int id, TicketPostDto ticket)
    {
        await _client.Ticket3Async(id, ticket);
    }
    public async Task DeleteTicketAsync(int id)
    {
        await _client.Ticket4Async(id);
    }
    public async Task<ICollection<AirplaneGetDto>> GetAirplanesAsync()
    {
        return await _client.AirplaneAllAsync();
    }
    public async Task AddAirplaneAsync(AirplanePostDto airplane)
    {
        await _client.AirplaneAsync(airplane);
    }
    public async Task UpdateAirplaneAsync(int id, AirplanePostDto airplane)
    {
        await _client.Airplane3Async(id, airplane);
    }
    public async Task DeleteAirplaneAsync(int id)
    {
        await _client.Airplane4Async(id);
    }
    public async Task<ICollection<PassengerGetDto>> PassengersWithoutBaggage()
    {
        return await _client.PassengersWithoutBaggageAsync();
    }
}