using Airlines.Domain;
using Airlines.Server.Dto;
using Airlines.Server.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Immutable;

namespace Airlines.Server.Controllers;

/// <summary>
/// Controller for get methods which returns a specified data from airlines data base
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class AnalyticsController : ControllerBase
{
    private readonly ILogger<AnalyticsController> _logger;
    private readonly IDbContextFactory<AirlinesContext> _contextFactory;
    private readonly IAirlinesRepository _airlinesRepository;
    private readonly IMapper _mapper;
    public AnalyticsController(IDbContextFactory<AirlinesContext> contextFactory, ILogger<AnalyticsController> logger, IAirlinesRepository airlinesRepository, IMapper mapper)
    {
        _logger = logger;
        _airlinesRepository = airlinesRepository;
        _contextFactory = contextFactory;
        _mapper = mapper;
    }

    /// <summary>
    /// Get method which return a passengers without baggage
    /// </summary>
    /// <returns>Passengers without baggage</returns>
    [HttpGet("passengers-without-baggage")]
    public async Task<ActionResult<IEnumerable<PassengerGetDto>>> GetPassengersWithoutBaggage()
    {
        await using var ctx = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation("Get passengers without baggage");
        var specifiedFlightTickets = (from flight in ctx.Flights
                                      where flight.Id == 1
                                      select flight.Tickets);
        var ticketsWithoutBaggage = (from ticketlist in specifiedFlightTickets
                                     from ticket in ticketlist
                                     where ticket.BaggageWeight == 0
                                     select ticket);
        var passengersIdWithoutBaggage = (from ticket in ticketsWithoutBaggage select ticket.PassengerId);
        var passengersWithoutBaggage = await (from passenger in ctx.Passengers
                                            where passengersIdWithoutBaggage.Contains(passenger.Id)
                                            select _mapper.Map<PassengerGetDto>(passenger)).ToListAsync();
        return Ok(passengersWithoutBaggage);
    }

    /// <summary>
    /// Get method which return a flights with specified source and destination
    /// </summary>
    /// <returns>Flights with specified source and destination</returns>
    [HttpGet("flights-with-specified-source-and-destination")]
    public async Task<IEnumerable<FlightGetDto>> GetFlightsWithSpecifiedSourceAndDestination()
    {
        await using var ctx = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation("Get flights with specified source and destination");
        var flightsWithSpecifiedSourceAndDestination = await (from flight in ctx.Flights
                             where (flight.Source == "Moscow") && (flight.Destination == "Kazan")
                             select _mapper.Map<FlightGetDto>(flight)).ToListAsync();
        return flightsWithSpecifiedSourceAndDestination;
    }

    /// <summary>
    /// Get method which return a flights at specified period
    /// </summary>
    /// <returns>Flights at specified period</returns>
    [HttpGet("flights-at-specified-period")]
    public async Task<IEnumerable<FlightGetDto>> GetFlightsAtSpecifiedPeriod()
    {
        await using var ctx = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation("Get flights at specified period");
        var firstCompDate = new DateTime(2023, 3, 2);
        var secondCompDate = new DateTime(2023, 4, 2);
        var flightsAtSpecifiedPeriod = await (from flight in ctx.Flights
                             where (flight.AirplaneType == "Cargo") && (flight.DepartureDate.CompareTo(firstCompDate) > 0) &&
                             (flight.DepartureDate.CompareTo(secondCompDate) < 0)
                             select _mapper.Map<FlightGetDto>(flight)).ToListAsync();
        return flightsAtSpecifiedPeriod;
    }

    /// <summary>
    /// Get method which return a flights with max count of passengers
    /// </summary>
    /// <returns>Flights with max count of passengers</returns>
    [HttpGet("flights-with-max-count-of-passengers")]
    public async Task<IEnumerable<int>> GetFlightsWithMaxCountOfPassengers()
    {
        await using var ctx = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation("Get flights with max count of passengers");
        var flightsWithMaxCountOfPassengers = await (from flight in ctx.Flights
                             where flight != null
                             select flight.Tickets.Count).Take(5).ToListAsync();
        return flightsWithMaxCountOfPassengers;
    }

    /// <summary>
    /// Get method which return max and average baggage amount from specified source
    /// </summary>
    /// <returns>Max and average baggage amount from specified source</returns>
    [HttpGet("max-and-avg-baggage-amount-from-specified-source")]
    public async Task<IEnumerable<double>> GetMaxAndAvgBaggageAmountFromSpecifiedSource()
    {
        await using var ctx = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation("Get max and average baggage amount from specified source");
        var ticketsWithSpecifiedSource = (from flight in ctx.Flights
                       .Include(flight => flight.Tickets)
                                          where flight.Source == "Moscow"
                                          select flight.Tickets);
        var tickets = (from ticketList in ticketsWithSpecifiedSource
                       from ticket in ticketList
                       select ticket.BaggageWeight);
        var max = await tickets.MaxAsync();
        var avg = await tickets.AverageAsync();
        var maxAndAvgBaggageAmountFromSpecifiedSource = new List<double>() { max, avg };
        return maxAndAvgBaggageAmountFromSpecifiedSource;
    }

    /// <summary>
    /// Get method which return flights with minimal flight duration
    /// </summary>
    /// <returns>Flights with minimal flight duration</returns>
    [HttpGet("flights-with-min-flight-duration")]
    public async Task<IEnumerable<FlightGetDto>> GetFlightsWithMinFlightDuration()
    {
        await using var ctx = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation("Get flights with minimal flight duration");
        var durations = (from flight in ctx.Flights
                         orderby flight.FlightDuration
                         select flight.FlightDuration);
        var minDuration = await durations.MinAsync();
        var flightsWithMinFlightDuration = await (from flight in ctx.Flights
                             where flight.FlightDuration.CompareTo(minDuration) == 0
                             select _mapper.Map<FlightGetDto>(flight)).ToListAsync();
        return flightsWithMinFlightDuration;
    }
}