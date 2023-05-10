using Airline.Server.Dto;
using AirlineClasses;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Airlines.Server.Controllers;

/// <summary>
/// Controller for get methods which returns a specified data from airlines data base
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class AnalyticsController : ControllerBase
{
    private readonly IDbContextFactory<AirlineContext> _contextFactory;
    private readonly ILogger<AnalyticsController> _logger;
    private readonly IMapper _mapper;
    public AnalyticsController(IDbContextFactory<AirlineContext> contextFactory, ILogger<AnalyticsController> logger, IMapper mapper)
    {
        _contextFactory = contextFactory;
        _logger = logger;
        _mapper = mapper;
    }

    /// <summary>
    /// Get method which return a passengers without baggage from specific flight
    /// </summary>
    /// <param name="chipher"> Chipher specific flight</param>
    /// <returns>Passengers without baggage</returns>
    [HttpGet("PassengersWithoutWaggage")]
    public async Task<ActionResult<IEnumerable<PassengerGetDto>>> GetPassengersWithoutBaggage(string cipher)
    {
        var context = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation("Get passengers without baggage");
        /* var request = await (from passenger in context.Passengers
                              join ticket in context.Tickets on passenger.Id equals ticket.PassengerId
                              join flightAirplaneTicket in context.FlightAirplaneTickets on ticket.Id equals flightAirplaneTicket.TicketId
                              join flight in context.Flights on flight.Id equals flightAirplaneTicket.FlightId
                              where flight.Cipher == "BD-1120" && Ticket.BaggageWeight == 0
                              select _mapper.Map<PassengerGetDto>(passenger)).ToListAsync();*/

        var result = await (from passenger in context.Passengers
                            join ticket in context.Tickets on passenger.Id equals ticket.PassengerId
                            join flightAirplaneTicket in context.FlightAirplaneTickets on ticket.Id equals flightAirplaneTicket.TicketId
                            join flight in context.Flights on flightAirplaneTicket.FlightId equals flight.Id
                            where flight.Cipher == cipher && ticket.BaggageWeight == 0
                            orderby passenger.Name
                            select new
                            {
                                passenger.Name,
                                flight.DeparturePlace,
                                flight.Destination,
                                flight.DepartureDate,
                                flight.ArrivalDate
                            }).ToListAsync();

        return Ok(result);
    }

    /// <summary>
    /// Get method which return a flights with specified source and destination
    /// </summary>
    /// <param name="source">Departure place</param>
    /// <param name="destination">Destination</param>
    /// <returns>Flights with specified source and destination</returns>
    [HttpGet("FlightsWithSpecifiedSourceAndDestination")]
    public async Task<ActionResult<IEnumerable<FlightGetDto>>> GetFlightsWithSpecifiedSourceAndDestination(string source, string destination)
    {
        var context = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation("Get flights with specified source and destination");
        /*var result = await (from flight in context.Flights
                       where (flight.DeparturePlace == source) && (flight.Destination == destination)
                       select _mapper.Map<FlightGetDto>(flight)).ToListAsync();     */

        var result = await (from flight in context.Flights
                            where flight.DeparturePlace == source && flight.Destination == destination
                            select _mapper.Map<FlightGetDto>(flight)).ToListAsync(); 

        return Ok(result);
    }

    /// <summary>
    /// Get method which return a flights at specified period
    /// </summary>
    /// <param name="start"></param>
    /// <param name="finish"></param>
    /// <param name="airplaneType"></param>
    /// <returns>Flights at specified period</returns>
    [HttpGet("FlightsAtSpecifiedPeriod")]
    public async Task<ActionResult<IEnumerable<FlightGetDto>>> GetFlightsAtSpecifiedPeriod(DateTime start, DateTime finish, string airplaneType)
    {
        var context = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation("Get flights at specified period");
        /*var result = await (from flight in context.Flights
                       where (flight.Airplane.Model.Equals(airplaneType)) &&
                       (flight.DepartureDate >= start) &&
                       (flight.DepartureDate <= finish)
                       select _mapper.Map<FlightGetDto>(flight)).ToListAsync();
        return Ok(result); */

        var result = await (from flight in context.Flights
                            join airplane in context.Airplanes on flight.Id equals airplane.Id
                            where airplane.Model == airplaneType
                            && flight.DepartureDate >= start
                            && flight.DepartureDate <= finish
                            group flight by airplane.Model into g
                            select new
                            {
                                Model = g.Key,
                                FlightCount = g.Count(),
                                TotalFlightTime = g.Sum(f => f.FlightTime.Ticks)
                            }).ToListAsync();

        return Ok(result);
    }

    /// <summary>
    /// Get method which return a flights with max count of passengers
    /// </summary>
    /// <returns>Flights with max count of passengers</returns>
    [HttpGet("FlightsWithMaxCountOfPassengers")]
    public async Task<ActionResult<IEnumerable<int>>> GetFlightsWithMaxCountOfPassengers()
    {
        var context = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation("Get flights with max count of passengers");
        /*var result = await (from flight in context.Flights
                       where flight != null
                       orderby flight.Tickets.Count descending
                       select flight.Tickets.Count).Take(5).ToListAsync();*/

        var result = await (from flight in context.Flights
                            join flightAirplaneTicket in context.FlightAirplaneTickets on flight.Id equals flightAirplaneTicket.FlightId
                            group flightAirplaneTicket by flight.Id into g
                            orderby g.Count() descending
                            select new
                            {
                                FlightId = g.Key,
                                PassengersCount = g.Count()
                            }).Take(5).ToListAsync();

        return Ok(result);
    }

    /// <summary>
    /// Get method which return max and average baggage amount from specified source
    /// </summary>
    /// <param name="source">Departure place</param>
    /// <returns>Max and average baggage amount from specified source</returns>
    [HttpGet("MaxAndAvgBaggageAmountFromSpecifiedSource")]
    public async Task<ActionResult<IEnumerable<string>>> GetMaxAndAvgBaggageAmountFromSpecifiedSource(string source)
    {
        var context = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation("Get max and average baggage amount from specified source");
        /*var tickets = (from flight in context.Flights
                       from ticket in flight.Tickets
                       where flight.DeparturePlace == source
                       select ticket.BaggageWeight).ToList();
        var result = new List<string>() { $"max: {tickets.Max()}", $"avg: {tickets.Average()}" };*/

        var result = await (from flight in context.Flights
                            join flightAirplaneTicket in context.FlightAirplaneTickets on flight.Id equals flightAirplaneTicket.FlightId
                            join ticket in context.Tickets on flightAirplaneTicket.TicketId equals ticket.Id
                            where flight.DeparturePlace == source
                            select ticket.PassengerId into passengers
                            group passengers by passengers into g
                            select new
                            {
                                AverageLoad = g.Count(),
                                MaxLoad = g.Count()
                            }).ToListAsync();

        return Ok(result);
    }

    /// <summary>
    /// Get method which return flights with minimal flight duration
    /// </summary>
    /// <returns>Flights with minimal flight duration</returns>
    [HttpGet("FlightsWithMinFlightDuration")]
    public async Task<ActionResult<IEnumerable<FlightGetDto>>> GetFlightsWithMinFlightDuration()
    {
        var context = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation("Get flights with minimal flight duration");
        /*var min_time = (from flight in context.Flights
                        orderby flight.FlightTime
                        select flight.FlightTime).Min();
        var result = await (from flight in context.Flights
               where flight.FlightTime == min_time
               select _mapper.Map<FlightGetDto>(flight)).ToListAsync();         */

        var minFlightTime = context.Flights.Min(f => f.FlightTime);
        var result = await (from flight in context.Flights
                            where flight.FlightTime == minFlightTime
                            select _mapper.Map<FlightGetDto>(flight)).ToListAsync();

        return Ok(result);
    }
}