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
                       select flight).Count();
        Assert.Equal(5, request);
    }
}