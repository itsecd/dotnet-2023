using AirplaneBookingSystem.Server.Dto;
using AirplaneBookingSystem.Server.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AirplaneBookingSystem.Server.Controllers;

/// <summary>
/// Controller for get methods which returns a specified data from Airplane Booking System data base
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class AnalyticsController : ControllerBase
{
    private readonly ILogger<AnalyticsController> _logger;
    private readonly IAirplaneBookingSystemRepository _airplaneBookingSystemRepository;
    private readonly IMapper _mapper;
    public AnalyticsController(ILogger<AnalyticsController> logger, IAirplaneBookingSystemRepository airplaneBookingSystemRepository, IMapper mapper)
    {
        _logger = logger;
        _airplaneBookingSystemRepository = airplaneBookingSystemRepository;
        _mapper = mapper;
    }
    /// <summary>
    /// Get method which return all flight
    /// </summary>
    /// <returns>All flight</returns>
    [HttpGet("all-flight")]
    public IEnumerable<FlightGetDto> GetAllFlight()
    {
        _logger.LogInformation("Get all flight");
        var request = (from flight in _airplaneBookingSystemRepository.Flights
                       select _mapper.Map<FlightGetDto>(flight));
        return request;
    }
    /// <summary>
    /// Get method which return clients with specific flight
    /// </summary>
    /// <returns>Clients with specific flight</returns>
    [HttpGet("clients-with-specific-flight")]
    public IEnumerable<ClientGetDto> ClientsWithSpecificFlight()
    {
        _logger.LogInformation("Get clients with specific flight");
        var request = (from client in _airplaneBookingSystemRepository.Client
                       from ticket in client.Tickets
                       where ticket.Flight.NumberOfFlight == 2
                       orderby client.Name
                       select _mapper.Map<ClientGetDto>(client));
        return request;
    }
    /// <summary>
    /// Get method which return flight with specific departure city and data
    /// </summary>
    /// <returns>Flight with specific departure city and data</returns>
    [HttpGet("flight-with-specific-departure-city-and-data")]
    public IEnumerable<FlightGetDto> FlightWithSpecificDepartureCityAndData()
    {
        _logger.LogInformation("Flight with specific departure city and data");
        var specifiedDate = new DateTime(2023, 8, 28);
        var request = (from flight in _airplaneBookingSystemRepository.Flights
                       where (flight.DepartureCity == "Kurumoch") && (flight.DepartureDate == specifiedDate)
                       select _mapper.Map<FlightGetDto>(flight));
        return request;
    }
    /// <summary>
    /// Get method which return top five flight 
    /// </summary>
    /// <returns>Top five flight</returns>
    [HttpGet("top-five-flight")]
    public IEnumerable<FlightGetDto> TopFiveFlight()
    {
        _logger.LogInformation("Top five flight");
        var specifiedDate = new DateTime(2023, 8, 28);
        var request = (from flight in _airplaneBookingSystemRepository.Flights
                       orderby flight.Tickets.Count descending
                       select _mapper.Map<FlightGetDto>(flight)).Take(5);
        return request;
    }
    /// <summary>
    /// Get method which return flight with max amount of clients
    /// </summary>
    /// <returns>Flight with max amount of clients</returns>
    [HttpGet("flight-with-max-amount-of-clients")]
    public IEnumerable<FlightGetDto> FlightsWithMaxCountOfClient()
    {
        _logger.LogInformation("Flight with max amount of clients");
        var max = (from flight in _airplaneBookingSystemRepository.Flights
                   select flight.Tickets.Count).Max();
        var request = (from flight in _airplaneBookingSystemRepository.Flights
                       where flight.Tickets.Count == max
                       select _mapper.Map<FlightGetDto>(flight));
        return request;
    }
    /// <summary>
    /// Get method which return flight with max, min, avg amount of clients and with specific departure city
    /// </summary>
    /// <returns>Flight with max, min, avg amount of clients and with specific departure city</returns>
    [HttpGet("flight-with-max-min-avg-amount-of-clients-and-specific-departure-city")]
    public IEnumerable<double> MaxAndMinAndAvgClientsAmountFromSpecifiedDepartureCity()
    {
        _logger.LogInformation("Flight with max, min, avg amount of clients and with specific departure city");
        var flightWithCountOfTickets = (from flight in _airplaneBookingSystemRepository.Flights
                                        where flight.DepartureCity == "Kurumoch"
                                        select flight.Tickets.Count);
        var max = flightWithCountOfTickets.Max();
        var min = flightWithCountOfTickets.Min();
        var avg = flightWithCountOfTickets.Average();
        var request = new List<double>() { max, min, avg };
        return request;
    }
}