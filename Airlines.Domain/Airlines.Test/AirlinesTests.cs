using Airlines.Domain;
using Airlines.Test;
using System.Linq;
using System.Security.Cryptography;

namespace Airplane.Test;

public class ClassesTest : IClassFixture<AirlinesFixture>
{
    private readonly AirlinesFixture _fixture;
    public ClassesTest(AirlinesFixture fixture) {
        _fixture = fixture;
    }
    [Fact]
    public void FirstRequest()
    {
        var request = (from flight in _fixture.FixtureFlights
                       where (flight.Source == "Moscow") && (flight.Destination == "Kazan")
                       select flight).Count();
        Assert.Equal(1, request);
    }
    [Fact]
    public void SecondRequest()
    {
        var request = (from flight in _fixture.FixtureFlights
                       from ticket in _fixture.FixtureTickets
                       from passenger in _fixture.FixturePassengers
                       from t in passenger.Tickets 
                       where (flight.Number == 1) && (ticket.BaggageWeight == 0) && (t.TicketNumber == ticket.TicketNumber)
                       select passenger).Count();
        Assert.Equal(1, request);
    }
    [Fact]
    public void ThirdRequest()
    {
        var comp_date = new DateOnly(2023, 3, 2);
        var request = (from flight in _fixture.FixtureFlights
                       where (flight.AirplaneType == "Cargo") && (flight.DepartureDate.CompareTo(comp_date) >0)
                       select flight).Count();
        Assert.Equal(2, request);
    }
    [Fact]
    public void FourthRequest()
    {
        var request = (from flight in _fixture.FixtureFlights
                       where flight != null
                        select flight.Tickets.Count).Take(5).Count();
        Assert.Equal(5, request);
    }
    [Fact]
    public void FifthRequest()
    { 
        var request = (from flight in _fixture.FixtureFlights
                      where flight.FlightDuration.CompareTo( (from fli in _fixture.FixtureFlights
                                                              orderby fli.FlightDuration ascending
                                                            select fli.FlightDuration).Take(1).First()) == 0
                      select flight.Number).Count();
        Assert.Equal(1, request);
    }
    [Fact]
    public void SixthRequest()
    {
        var tickets = from flight in _fixture.FixtureFlights
                       from ticket in flight.Tickets
                       where flight.Source == "Moscow"
                       select ticket.BaggageWeight;
        var max = tickets.Max();
        var avg = tickets.Average();
        Assert.Equal(19,max);
        Assert.Equal(9.5, avg);
    }
}