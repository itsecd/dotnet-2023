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
        var request = (from client in _fixture.FixtureClient
                       from ticket in client.Tickets
                       select ticket.Flight.NumberOfFlight).Distinct().ToList();
        Assert.Equal(5, request.Count);
    }
    [Fact]
    public void ClientsWithSpecificFlight()
    {
        var request = (from client in _fixture.FixtureClient
                       from ticket in client.Tickets
                       where ticket.Flight.NumberOfFlight == 2
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
        var request = (from client in _fixture.FixtureClient
                       from ticket in client.Tickets
                       where (ticket.Flight.DepartureCity == "Kurumoch") && (ticket.Flight.DepartureDate == specifiedDate)
                       select ticket.Flight).Distinct().ToList();
        Assert.Equal(2, request.Count);
    }
    [Fact]
    public void TopFiveFlights()
    {
        var request = (from client in _fixture.FixtureClient
                       from ticket in client.Tickets
                       group ticket by ticket.Flight into flight
                       orderby flight.Key.Tickets.Count descending
                       select new
                       {
                           flight.Key.DepartureCity,
                           flight.Key.ArrivalCity,
                           flight.Key.Tickets,
                           flight.Key.NumberOfFlight
                       }
                      ).Take(5).ToList();
        Assert.Equal(2, request[0].NumberOfFlight);
        Assert.Equal(4, request[1].NumberOfFlight);
        Assert.Equal(1, request[2].NumberOfFlight);
        Assert.Equal(3, request[3].NumberOfFlight);
        Assert.Equal(5, request[4].NumberOfFlight);
    }
    [Fact]
    public void FlightsWithMaxCountOfClient()
    {
        var maxClients = (from client in _fixture.FixtureClient
                          from ticket in client.Tickets
                          group ticket by ticket.Flight into flight
                          orderby flight.Key.Tickets.Count descending
                          select flight.Key.Tickets.Count).Max();
        var request = (from client in _fixture.FixtureClient
                       from ticket in client.Tickets
                       group ticket by ticket.Flight into flight
                       where flight.Key.Tickets.Count == maxClients
                       select flight.Key.NumberOfFlight).ToList();
        Assert.Equal(2, request.Count);
    }
    [Fact]
    public void MaxAndMinAndAvgClientsAmountFromSpecifiedDepartureCity()
    {
        var maxClients = (from client in _fixture.FixtureClient
                          from ticket in client.Tickets
                          group ticket by ticket.Flight into flight
                          where flight.Key.DepartureCity == "Kurumoch"
                          orderby flight.Key.Tickets.Count descending
                          select flight.Key.Tickets.Count).Max();
        var minClients = (from client in _fixture.FixtureClient
                          from ticket in client.Tickets
                          group ticket by ticket.Flight into flight
                          where flight.Key.DepartureCity == "Kurumoch"
                          orderby flight.Key.Tickets.Count descending
                          select flight.Key.Tickets.Count).Min();
        var avgClients = (from client in _fixture.FixtureClient
                          from ticket in client.Tickets
                          group ticket by ticket.Flight into flight
                          where flight.Key.DepartureCity == "Kurumoch"
                          orderby flight.Key.Tickets.Count descending
                          select flight.Key.Tickets.Count).Average();
        Assert.Equal(2, maxClients);
        Assert.Equal(1, minClients);
        Assert.Equal(1.5, avgClients);
    }
}