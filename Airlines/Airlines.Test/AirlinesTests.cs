namespace Airlines.Test;

public class ClassesTest : IClassFixture<AirlinesFixture>
{
    private readonly AirlinesFixture _fixture;
    public ClassesTest(AirlinesFixture fixture)
    {
        _fixture = fixture;
    }
    [Fact]
    public void FlightsWthSpecifiedSourceAndDestination()
    {
        var request = (from flight in _fixture.Flights
                       where (flight.Source == "Moscow") && (flight.Destination == "Kazan")
                       select flight).Count();
        Assert.Equal(1, request);
    }
    [Fact]
    public void PassengersWithoutBaggage()
    {
        var request = (from flight in _fixture.Flights
                       from ticket in _fixture.Tickets
                       from passenger in _fixture.Passengers
                       from t in passenger.Tickets
                       where (flight.Id == 1) && (ticket.BaggageWeight == 0) && (t.TicketNumber == ticket.TicketNumber)
                       select passenger).Count();
        Assert.Equal(1, request);
    }
    [Fact]
    public void FlightsAtSpecifiedPeriod()
    {
        var firstCompDate = new DateTime(2023, 3, 2);
        var secondCompDate = new DateTime(2023, 4, 2);
        var request = (from flight in _fixture.Flights
                       where (flight.AirplaneType == "Cargo") && (flight.DepartureDate.CompareTo(firstCompDate) > 0) &&
                       (flight.DepartureDate.CompareTo(secondCompDate) < 0)
                       select flight).Count();
        Assert.Equal(2, request);
    }
    [Fact]
    public void FlightsWithMaxCountOfPassengers()
    {
        var request = (from flight in _fixture.Flights
                       where flight != null
                       select flight.Tickets.Count).Take(5).Count();
        Assert.Equal(5, request);
    }
    [Fact]
    public void FlightsWithMinFlightDuration()
    {
        var minDuration = (from flight in _fixture.Flights
                           orderby flight.FlightDuration
                           select flight.FlightDuration).Min();
        var request = (from flight in _fixture.Flights
                       where flight.FlightDuration.CompareTo(minDuration) == 0
                       select flight.Id).Count();
        Assert.Equal(1, request);
    }
    [Fact]
    public void MaxAndAvgBaggageAmountFromSpecifiedSource()
    {
        var tickets = (from flight in _fixture.Flights
                       from ticket in flight.Tickets
                       where flight.Source == "Moscow"
                       select ticket.BaggageWeight).ToList();
        var max = tickets.Max();
        var avg = tickets.Average();
        Assert.Equal(19, max);
        Assert.Equal(9.5, avg);
    }
}