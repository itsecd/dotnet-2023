using Airlines.Server.Dto;
using Airlines.Server.Repository;
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
    private readonly IAirlinesRepository _airlinesRepository;
    private readonly IMapper _mapper;
    public AnalyticsController(ILogger<AnalyticsController> logger, IAirlinesRepository airlinesRepository, IMapper mapper)
    {
        _logger = logger;
        _airlinesRepository = airlinesRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Get method which return a passengers without baggage
    /// </summary>
    /// <returns>Passengers without baggage</returns>
    [HttpGet("passengers-without-baggage")]
    public IEnumerable<PassengerGetDto> GetPassengersWithoutBaggage()
    {
        _logger.LogInformation("Get passengers without baggage");
        var request = (from flight in _airlinesRepository.Flights
                       from ticket in _airlinesRepository.Tickets
                       from passenger in _airlinesRepository.Passengers
                       from t in passenger.Tickets
                       where (flight.Id == 1) && (ticket.BaggageWeight == 0) && (t.TicketNumber == ticket.TicketNumber)
                       select _mapper.Map<PassengerGetDto>(passenger));
        return request;


    }

    /// <summary>
    /// Get method which return a flights with specified source and destination
    /// </summary>
    /// <returns>Flights with specified source and destination</returns>
    [HttpGet("flights-with-specified-source-and-destination")]
    public IEnumerable<FlightGetDto> GetFlightsWithSpecifiedSourceAndDestination()
    {
        _logger.LogInformation("Get flights with specified source and destination");
        var request = (from flight in _airlinesRepository.Flights
                       where (flight.Source == "Moscow") && (flight.Destination == "Kazan")
                       select _mapper.Map<FlightGetDto>(flight));
        return request;

    }

    /// <summary>
    /// Get method which return a flights at specified period
    /// </summary>
    /// <returns>Flights at specified period</returns>
    [HttpGet("flights-at-specified-period")]
    public IEnumerable<FlightGetDto> GetFlightsAtSpecifiedPeriod()
    {
        _logger.LogInformation("Get flights at specified period");
        var firstCompDate = new DateTime(2023, 3, 2);
        var secondCompDate = new DateTime(2023, 4, 2);
        var request = (from flight in _airlinesRepository.Flights
                       where (flight.AirplaneType == "Cargo") && (flight.DepartureDate.CompareTo(firstCompDate) > 0) &&
                       (flight.DepartureDate.CompareTo(secondCompDate) < 0)
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
        var request = (from flight in _airlinesRepository.Flights
                       where flight != null
                       select flight.Tickets.Count).Take(5);
        return request;

    }

    /// <summary>
    /// Get method which return max and average baggage amount from specified source
    /// </summary>
    /// <returns>Max and average baggage amount from specified source</returns>
    [HttpGet("max-and-avg-baggage-amount-from-specified-source")]
    public IEnumerable<double> GetMaxAndAvgBaggageAmountFromSpecifiedSource()
    {
        _logger.LogInformation("Get max and average baggage amount from specified source");
        var tickets = (from flight in _airlinesRepository.Flights
                       from ticket in flight.Tickets
                       where flight.Source == "Moscow"
                       select ticket.BaggageWeight).ToList();
        var max = tickets.Max();
        var avg = tickets.Average();
        var request = new List<double>() { max, avg };
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
        var minDuration = (from flight in _airlinesRepository.Flights
                           orderby flight.FlightDuration
                           select flight.FlightDuration).Min();
        var request = (from flight in _airlinesRepository.Flights
                       where flight.FlightDuration.CompareTo(minDuration) == 0
                       select _mapper.Map<FlightGetDto>(flight));
        return request;
    }
}