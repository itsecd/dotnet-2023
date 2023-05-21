using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace AirplaneBookingSystem.Client;
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
    public Task<ICollection<AirplaneGetDto>> GetAirplanesAsync()
    {
        return _client.AirplaneAllAsync();
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
    public Task<ICollection<FlightGetDto>> GetFlightsAsync()
    {
        return _client.FlightAllAsync();
    }
    public async Task AddFlightAsync(FlightPostDto flight)
    {
        await _client.FlightAsync(flight);
    }

    public async Task UpdateFlightAsync(int id, FlightPostDto flight)
    {
        await _client.Flight3Async(id, flight);
    }

    public async Task DeleteFlightAsync(int id)
    {
        await _client.Flight4Async(id);
    }
    public Task<ICollection<ClientGetDto>> GetClientsAsync()
    {
        return _client.ClientAllAsync();
    }
    public async Task AddClientAsync(ClientPostDto client)
    {
        await _client.ClientAsync(client);
    }

    public async Task UpdateClientAsync(int id, ClientPostDto сlient)
    {
        await _client.Client3Async(id, сlient);
    }

    public async Task DeleteClientAsync(int id)
    {
        await _client.Client4Async(id);
    }
    public Task<ICollection<TicketGetDto>> GetTicketsAsync()
    {
        return _client.TicketAllAsync();
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
    public Task<ICollection<FlightGetDto>> FlightWithMaxAmountOfClients()
    {
        return _client.FlightWithMaxAmountOfClientsAsync();
    }
}