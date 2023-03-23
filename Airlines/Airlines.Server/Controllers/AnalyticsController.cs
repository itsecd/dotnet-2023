using Airlines.Server.Dto;
using Airlines.Server.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Airlines.Server.Controllers;

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
    [HttpGet("PassengersWithoutBaggage")]
    public IEnumerable<PassengerGetDto> GetPassengersWithoutBaggage()
    {
        var request = (from flight in _airlinesRepository.Flights
                       from ticket in _airlinesRepository.Tickets
                       from passenger in _airlinesRepository.Passengers
                       from t in passenger.Tickets
                       where (flight.Id == 1) && (ticket.BaggageWeight == 0) && (t.TicketNumber == ticket.TicketNumber)
                       select _mapper.Map<PassengerGetDto>(passenger));
        return request;


    }
    [HttpGet("FlightsWthSpecifiedSourceAndDestination")]
    public IEnumerable<FlightGetDto> GetFlightsWthSpecifiedSourceAndDestination()
    {
        var request = (from flight in _airlinesRepository.Flights
                       where (flight.Source == "Moscow") && (flight.Destination == "Kazan")
                       select _mapper.Map<FlightGetDto>(flight));
        return request;

    }
    [HttpGet("FlightsAtSpecifiedPeriod")]
    public IEnumerable<FlightGetDto> GetFlightsAtSpecifiedPeriod()
    {
        var firstCompDate = new DateTime(2023, 3, 2);
        var secondCompDate = new DateTime(2023, 4, 2);
        var request = (from flight in _airlinesRepository.Flights
                       where (flight.AirplaneType == "Cargo") && (flight.DepartureDate.CompareTo(firstCompDate) > 0) &&
                       (flight.DepartureDate.CompareTo(secondCompDate) < 0)
                       select _mapper.Map<FlightGetDto>(flight));
        return request;

    }
    [HttpGet("FlightsWithMaxCountOfPassengers")]
    public IEnumerable<int> GetFlightsWithMaxCountOfPassengers()
    {
        var request = (from flight in _airlinesRepository.Flights
                       where flight != null
                       select flight.Tickets.Count).Take(5);
        return request;

    }
    [HttpGet("MaxAndAvgBaggageAmountFromSpecifiedSource")]
    public IEnumerable<double> GetMaxAndAvgBaggageAmountFromSpecifiedSource()
    {
        var tickets = (from flight in _airlinesRepository.Flights
                       from ticket in flight.Tickets
                       where flight.Source == "Moscow"
                       select ticket.BaggageWeight).ToList();
        var max = tickets.Max();
        var avg = tickets.Average();
        var request = new List<double>() { max, avg };
        return request;
    }
    [HttpGet("FlightsWithMinFlightDuration")]
    public IEnumerable<FlightGetDto> GetFlightsWithMinFlightDuration()
    {
        var minDuration = (from flight in _airlinesRepository.Flights
                           orderby flight.FlightDuration
                           select flight.FlightDuration).Min();
        var request = (from flight in _airlinesRepository.Flights
                       where flight.FlightDuration.CompareTo(minDuration) == 0
                       select _mapper.Map<FlightGetDto>(flight));
        return request;
    }
}
