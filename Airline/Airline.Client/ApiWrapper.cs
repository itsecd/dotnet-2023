using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace Airline.Client;
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

    public Task AddAirplanesAsync(AirplanePostDto airplane)
    {
        return _client.AirplaneAsync(airplane);
    }
    public Task UpdateAirplaneAsync(int id, AirplanePostDto airplane)
    {
        return _client.Airplane3Async(id, airplane);
    }

    public Task DeleteAirplaneAsync(int id)
    {
        return _client.Airplane4Async(id);
    }

    public Task<ICollection<FlightGetDto>> GetFlightsAsync()
    {
        return _client.FlightAllAsync();
    }

    public Task AddSupplierAsync(FlightPostDto flight)
    {
        return _client.FlightAsync(flight);
    }

    public Task UpdateFlightAsync(int id, FlightPostDto flight)
    {
        return _client.Flight3Async(id, flight);
    }

    public Task DeleteFlightAsync(int id)
    {
        return _client.Flight4Async(id);
    }

    public Task<ICollection<PassengerGetDto>> GetPassengersAsync()
    {
        return _client.PassengerAllAsync();
    }

    public Task AddPassengerAsync(PassengerPostDto passenger)
    {
        return _client.PassengerAsync(passenger);
    }

    public Task UpdatePassengerAsync(int id, PassengerPostDto passenger)
    {
        return _client.Passenger3Async(id, passenger);
    }

    public Task DeletePassengerAsync(int id)
    {
        return _client.Passenger4Async(id);
    }

    public Task<ICollection<TicketGetDto>> GetTicketsAsync()
    {
        return _client.TicketAllAsync();
    }

    public Task AddTicketAsync(TicketPostDto ticket)
    {
        return _client.TicketAsync(ticket);
    }

    public Task UpdateTicketAsync(int id, TicketPostDto ticket)
    {
        return _client.Ticket3Async(id, ticket);
    }

    public Task DeleteTicketAsync(int id)
    {
        return _client.Ticket4Async(id);
    }

}

