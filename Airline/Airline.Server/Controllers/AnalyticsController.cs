using AirLine.Domain;
using Airline.Server.Dto;
using Airline.Server.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Airlines.Server.Controllers;

/// <summary>
/// Controller for get methods which returns a specified data from airlines data base
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class AnalyticsController : ControllerBase
{
    private readonly ILogger<AnalyticsController> _logger;
    private readonly IAirlineRepository _airlineRepository;
    private readonly IMapper _mapper;
    public AnalyticsController(ILogger<AnalyticsController> logger, IAirlineRepository airlineRepository, IMapper mapper)
    {
        _logger = logger;
        _airlineRepository = airlineRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Get method which return a passengers without baggage from specific flight
    /// </summary>
    /// <param name="chipher"> Chipher specific flight</param>
    /// <returns>Passengers without baggage</returns>
    [HttpGet("passengers-without-baggage")]
    public IEnumerable<PassengerGetDto> GetPassengersWithoutBaggage(string chipher)
    {
        _logger.LogInformation("Get passengers without baggage");
        var request = (from flight in _airlineRepository.Flights
                       from ticket in _airlineRepository.Tickets
                       from passenger in _airlineRepository.Passengers
                       from t in passenger.Tickets
                       where (flight.Cipher == chipher) && (ticket.BaggageWeight == 0) && (t.Number == ticket.Number)
                       select _mapper.Map<PassengerGetDto>(passenger));
        return request;


    }

    /// <summary>
    /// Get method which return a flights with specified source and destination
    /// </summary>
    /// <param name="source">Departure place</param>
    /// <param name="destination">Destination</param>
    /// <returns>Flights with specified source and destination</returns>
    [HttpGet("flights-with-specified-source-and-destination")]
    public IEnumerable<FlightGetDto> GetFlightsWithSpecifiedSourceAndDestination(string source, string destination)
    {
        _logger.LogInformation("Get flights with specified source and destination");
        var request = (from flight in _airlineRepository.Flights
                       where (flight.DeparturePlace == source) && (flight.Destination == destination)
                       select _mapper.Map<FlightGetDto>(flight));
        return request;

    }

    /// <summary>
    /// Get method which return a flights at specified period
    /// </summary>
    /// <returns>Flights at specified period</returns>

    /// <summary>
    /// Get method which return a flights at specified period
    /// </summary>
    /// <param name="start"></param>
    /// <param name="finish"></param>
    /// <param name="airplaneType"></param>
    /// <returns>Flights at specified period</returns>
    [HttpGet("flights-at-specified-period")]
    public IEnumerable<FlightGetDto> GetFlightsAtSpecifiedPeriod(DateTime start, DateTime finish, string airplaneType)
    {
        _logger.LogInformation("Get flights at specified period");
        var first_date = start;
        var second_date = finish;
        var request = (from flight in _airlineRepository.Flights
                       where (flight.Airplane.Model.Equals(airplaneType)) &&
                       (flight.DepartureDate >= first_date) &&
                       (flight.DepartureDate <= second_date)
                       select _mapper.Map<FlightGetDto>(flight));
        return request;

    }

    /// <summary>
    /// Get method which return a flights with max count of passengers
    /// </summary>
    /// <returns>Flights with max count of passengers</returns>
    [HttpGet("flights-with-max-count-of-passengers")]
    public IEnumerable<int> GetFlightsWithMaxCountOfPassengers()
    {
        _logger.LogInformation("Get flights with max count of passengers");
        var request = (from flight in _airlineRepository.Flights
                       where flight != null
                       orderby flight.Tickets.Count descending
                       select flight.Tickets.Count).Take(5);
        return request;

    }

    /// <summary>
    /// Get method which return max and average baggage amount from specified source
    /// </summary>
    /// <param name="source">Departure place</param>
    /// <returns>Max and average baggage amount from specified source</returns>
    [HttpGet("max-and-avg-baggage-amount-from-specified-source")]
    public IEnumerable<string> GetMaxAndAvgBaggageAmountFromSpecifiedSource(string source)
    {
        _logger.LogInformation("Get max and average baggage amount from specified source");
        var tickets = (from flight in _airlineRepository.Flights
                       from ticket in flight.Tickets
                       where flight.DeparturePlace == source
                       select ticket.BaggageWeight).ToList();
        var max = tickets.Max();
        var avg = tickets.Average();

        var request = new List<string>() { $"max: {max}", $"avg: {avg}"};
        return request;
    }

    /// <summary>
    /// Get method which return flights with minimal flight duration
    /// </summary>
    /// <returns>Flights with minimal flight duration</returns>
    [HttpGet("flights-with-min-flight-duration")]
    public IEnumerable<FlightGetDto> GetFlightsWithMinFlightDuration()
    {
        _logger.LogInformation("Get flights with minimal flight duration");
        var min_time = (from flight in _airlineRepository.Flights
                        orderby flight.FlightTime
                        select flight.FlightTime).Min();
        var request = (from flight in _airlineRepository.Flights
                       where flight.FlightTime == min_time
                       select _mapper.Map<FlightGetDto>(flight));
        return request;
    }
}