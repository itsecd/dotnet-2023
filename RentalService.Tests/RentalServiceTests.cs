using Microsoft.VisualBasic;
using RentalService.Domain;

namespace RentalService.Tests;

public class RentalServiceTests : IClassFixture<RentalServiceFixture>
{
    private readonly RentalServiceFixture _fixture;

    public RentalServiceTests(RentalServiceFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public void InformationAboutVehicles()
    {
        var query = (from vehicle in _fixture.FixtureVehicle
            select new
            {
                vehicle.Id,
                vehicle.Number,
                vehicle.ModelId,
                vehicle.Colour
            }).ToList();
        Assert.Contains(query, elem => elem.Number == "Х547ХМ18");
    }
}