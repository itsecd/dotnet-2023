namespace AirplaneBookingSystem.Tests;

public class ClassesTest : IClassFixture<AirlineBookingSystemFixture>
{
    private readonly AirlineBookingSystemFixture _fixture;
    public ClassesTest(AirlineBookingSystemFixture fixture)
    {
        _fixture = fixture;
    }
    [Fact]
    public void AllFlights()
    {
        var request = (from flight in _fixture.FixtureFlights
                       select flight).ToList();
        Assert.Equal(5, request.Count);
    }
    [Fact]
    public void ClientsWithSpecificFlight()
    {
        var request = (from flight in _fixture.FixtureFlights
                       from ticket in flight.Tickets
                       from client in _fixture.FixtureClient
                       from ti in client.Tickets
                       where (flight.NumberOfFlight == 2) && (ti.TicketNumber == ticket.TicketNumber)
                       orderby client.Name
                       select client.Name).ToList();
        Assert.Equal("Fomina M. D.", request[0]);
        Assert.Equal("Novikov Y. M.", request[1]);
        Assert.Equal("Shestakov N. D.", request[2]);
    }
    [Fact]
    public void FlightsWithSpecifiedDepartureCityAndData()
    {
        var specifiedDate = new DateTime(2023, 8, 28);
        var request = (from flight in _fixture.FixtureFlights
                       where (flight.DepartureCity == "Kurumoch") && (flight.DepartureDate == specifiedDate)
                       select flight).ToList();
        Assert.Equal(2, request.Count);
    }
    [Fact]
    public void FlightsWithMaxCountOfClient()
    {
        var request = (from flight in _fixture.FixtureFlights
                        where flight != null
                        orderby flight.Tickets.Count() descending
                        select flight).Take(5).ToList();
        Assert.Equal(2, request[0].NumberOfFlight);
        Assert.Equal(4, request[1].NumberOfFlight);
        Assert.Equal(1, request[2].NumberOfFlight);
        Assert.Equal(3, request[3].NumberOfFlight);
        Assert.Equal(5, request[4].NumberOfFlight);
    }
    [Fact]
    public void MaxClientsAmount()
    {
        var maxClients = (from flight in _fixture.FixtureFlights
                          orderby flight.Tickets.Count
                          select flight.Tickets.Count).Max();
        var request = (from flight in _fixture.FixtureFlights
                       where flight.Tickets.Count.CompareTo(maxClients) == 0
                       select flight.NumberOfFlight).ToList();

        Assert.Equal(2, request.Count);
    }
    [Fact]
    public void MaxAndMinAndAvgClientsAmountFromSpecifiedDepartureCity()
    {
        var maxClients = (from flight in _fixture.FixtureFlights
                          where (flight.DepartureCity == "Kurumoch")
                          orderby flight.Tickets.Count
                          select flight.Tickets.Count).Max();
        var minClients = (from flight in _fixture.FixtureFlights
                          where (flight.DepartureCity == "Kurumoch")
                          orderby flight.Tickets.Count
                          select flight.Tickets.Count).Min();
        var avgClients = (from flight in _fixture.FixtureFlights
                          where (flight.DepartureCity == "Kurumoch")
                          orderby flight.Tickets.Count
                          select flight.Tickets.Count).Average();
        Assert.Equal(2, maxClients);
        Assert.Equal(1, minClients);
        Assert.Equal(1.5, avgClients);
    }
}