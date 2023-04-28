using AirplaneBookingSystem.Domain;
using AirplaneBookingSystem.Server.Dto;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AirplaneBookingSystem.Server.Controllers;

/// <summary>
/// Controller for get methods which returns a specified data from Airplane Booking System data base
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class AnalyticsController : ControllerBase
{
    private readonly ILogger<AnalyticsController> _logger;
    private readonly IDbContextFactory<AirplaneBookingSystemDbContext> _contextFactory;
    private readonly IMapper _mapper;
    public AnalyticsController(ILogger<AnalyticsController> logger, IDbContextFactory<AirplaneBookingSystemDbContext> contextFactory, IMapper mapper)
    {
        _logger = logger;
        _contextFactory = contextFactory;
        _mapper = mapper;
    }
    /// <summary>
    /// Get method which return all flight
    /// </summary>
    /// <returns>All flight</returns>
    [HttpGet("all-flight")]
    public async Task<ActionResult<List<FlightGetDto>>> GetAllFlight()
    {
        var ctx = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation("Get all flights");
        var request = await (from flight in ctx.Flights
                             select _mapper.Map<FlightGetDto>(flight)).ToListAsync();
        return Ok(request);
    }
    /// <summary>
    /// Get method which return clients with specific flight
    /// </summary>
    /// <param name="numberOfFlight">Number of flight</param>
    /// <returns>Clients with specific flight</returns>
    [HttpGet("clients-with-specific-flight")]
    public async Task<ActionResult<List<ClientGetDto>>> ClientsWithSpecificFlight(uint numberOfFlight)
    {
        var ctx = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation("Get clients with specific flight");
        var request = await (from client in ctx.Clients
                             from ticket in client.Tickets
                             where ticket.FlightId == numberOfFlight
                             orderby client.Name
                             select _mapper.Map<ClientGetDto>(client)).ToListAsync();
        if (!request.Any())
        {
            _logger.LogInformation("Not found clients with flight {numberOfFlight}", numberOfFlight);
            return NotFound($"There are no clients with flight {numberOfFlight}");
        }
        else
        {
            _logger.LogInformation("Get information about all clients with flight: {numberOfFlight}", numberOfFlight);
            return Ok(request);
        }
    }
    /// <summary>
    /// Get method which return flight with specific departure city and data
    /// </summary>
    /// <param name="departureCity">Departure city</param>
    /// <param name="departureData">Departure date</param>
    /// <returns>Flight with specific departure city and data</returns>
    [HttpGet("flight-with-specific-departure-city-and-data")]
    public async Task<ActionResult<List<FlightGetDto>>> FlightWithSpecificDepartureCityAndData(string departureCity, DateTime departureData)
    {
        var ctx = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation("Flight with specific departure city and data");
        var request = await (from flight in ctx.Flights
                             where (flight.DepartureCity == departureCity) && (flight.DepartureDate == departureData)
                             select _mapper.Map<FlightGetDto>(flight)).ToListAsync(); ;
        if (!request.Any())
        {
            _logger.LogInformation("Not found flights with departure city {departureCity} and data {departureData}", departureCity, departureData);
            return NotFound($"There are no flights with departure city {departureCity} and data {departureData}");
        }
        else
        {
            _logger.LogInformation("Get information about all flights with departure city {departureCity} and data {departureData}", departureCity, departureData);
            return Ok(request);
        }
    }
    /// <summary>
    /// Get method which return top five flight 
    /// </summary>
    /// <returns>Top five flight</returns>
    [HttpGet("top-five-flight")]
    public async Task<ActionResult<List<FlightGetDto>>> TopFiveFlight()
    {
        var ctx = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation("Top 5 flight");
        var request = await (from flight in ctx.Flights
                             orderby flight.Tickets.Count descending
                             select _mapper.Map<FlightGetDto>(flight)).Take(5).ToListAsync(); ;
        return Ok(request);
    }
    /// <summary>
    /// Get method which return flight with max amount of clients
    /// </summary>
    /// <returns>Flight with max amount of clients</returns>
    [HttpGet("flight-with-max-amount-of-clients")]
    public async Task<ActionResult<List<FlightGetDto>>> FlightsWithMaxCountOfClient()
    {
        var ctx = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation("Flight with max amount of clients");
        var max = (from flight in ctx.Flights
                   select flight.Tickets.Count).Max();
        var request = await (from flight in ctx.Flights
                             where flight.Tickets.Count == max
                             select _mapper.Map<FlightGetDto>(flight)).ToListAsync();
        return Ok(request);
    }
    /// <summary>
    /// Get method which return clients statistics from flights with specific departure city
    /// </summary>
    /// <param name="departureCity">Departure city</param>
    /// <returns>Clients statistics from flights with specific departure city</returns>
    [HttpGet("clients-statistics-from-flights-with-specific-departure-city")]
    public async Task<ActionResult<Dictionary<string, double>>> ClientsStatisticsFromSpecifiedDepartureCity(string departureCity)
    {
        var ctx = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation("Clients statistics from flights with specific departure city");
        var flightWithCountOfTickets = await (from flight in ctx.Flights
                                              where flight.DepartureCity == departureCity
                                              select flight.Tickets.Count).ToListAsync();
        if (!flightWithCountOfTickets.Any())
        {
            _logger.LogInformation("Clients not found");
            return NotFound($"There are no clients with departure city {departureCity}");
        }
        else
        {
            var request = new Dictionary<string, double>()
            {
               { "Max = ", flightWithCountOfTickets.Max()},
               { "Min = ", flightWithCountOfTickets.Min()},
               { "Average  = ", flightWithCountOfTickets.Average()}
            };
            _logger.LogInformation("Get clients statistics with departure city: {departureCity}", departureCity);
            return Ok(request);
        }
    }
}