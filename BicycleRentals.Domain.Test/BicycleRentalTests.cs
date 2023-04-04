namespace BicycleRentals.Domain.Test;

public class BicycleRentalTests
{
    private readonly BicycleFixture _fixture = new();
    /// <summary>
    /// 1.Test information about all sports bikes.
    /// </summary>         
    [Fact]
    public void TestGetSportBicycles()
    {
        var sportBikes = _fixture.FixTypes[2].Bicycles;
        // Assert
        Assert.Equal(2, sportBikes.Count());
        Assert.Equal(3, sportBikes[0].SerialNumber);
        Assert.Equal(9, sportBikes[1].SerialNumber);
    }

    /// <summary>
    /// 2.Test information about all clients who rented mountain bikes, sort by full name
    /// </summary>       
    [Fact]
    public void TestGetCustomersWhoRentedMountainBikes()
    {
        // Arrange        
        var mountainBikes = _fixture.FixTypes[0].Bicycles;
        // Act
        var customerNames = (from c in _fixture.FixCustomers
                             join r in _fixture.FixRentals on c.Id equals r.CustomerId
                             join b in mountainBikes on r.SerialNumber equals b.SerialNumber
                             orderby c.FullName ascending
                             select c.FullName)
                            .ToList();
        // Assert
        Assert.Equal("Kozlov Dmitry Igorevich", customerNames[1]);
        Assert.Equal("Ivanov Ivan Ivanovich", customerNames[0]);
    }

    /// <summary>
    /// 3.Test the total rental time for each type of bike.
    /// </summary>        
    [Fact]
    public void TestGetTotalRentalTimePerBicycleType()
    {
        // Act       
        var totalRentalTime = (from r in _fixture.FixRentals
                               join b in _fixture.FixBicycles on r.SerialNumber equals b.SerialNumber
                               group r by b.TypeId into g
                               select new
                               {
                                   TypeId = g.Key,
                                   TotalTime =g.Sum(br => br.RentalDurationHours)
                               }).ToList();
        // Assert       
        Assert.Equal(new { TypeId = 1, TotalTime = 5.5 },totalRentalTime[0]);
    }

    /// <summary>
    /// 4.Test information about customers who have rented bikes the most times.
    /// </summary>        
    [Fact]
    public void TestGetCustomersWithMostRentals_ReturnsCorrectCount()
    {

        // Act
        var customerRentalCounts = _fixture.FixRentals.GroupBy(br => br.CustomerId)
                                             .Select(g => new { CustomerId = g.Key, RentalCount = g.Count() })
                                             .OrderByDescending(c => c.RentalCount);
        var mostRentedCustomers = from c in _fixture.FixCustomers
                                  where c.Id == customerRentalCounts.First().CustomerId
                                  select c.FullName;
        // Assert
        Assert.Single(mostRentedCustomers);//test only 1 element
        Assert.Equal("Kozlov Dmitry Igorevich", mostRentedCustomers.First());
    }

    /// <summary>
    /// 5. Test information about the top 5 most frequently rented bikes
    /// </summary>
    [Fact]
    public void TestTop5MostRentedBikes()
    {
        // Arrange - get the top 5 most rented bikes from the data context           
        var top5Bikes = _fixture.FixRentals
            .GroupBy(r => r.SerialNumber)
            .OrderByDescending(g => g.Count())
            .Take(5)
            .Select(g => g.Key)
            .ToList();
        // Act
        // ... nothing to do here since we already got the data in the Arrange step
        // Assert - verify that we got the correct bikes
        Assert.Equal(5, top5Bikes.Count);
    }

    /// <summary>
    /// 6.Test information about the minimum, maximum and average bike rental time.
    /// </summary>        
    [Fact]
    public void TestMinMaxAvgRentalTime()
    {
        // Arrange - get the minimum, maximum, and average rental times for all bikes 
        var rentalTimes = (from r in _fixture.FixRentals
                           join b in _fixture.FixBicycles on r.SerialNumber equals b.SerialNumber
                           group r by b.TypeId into g
                           select new
                           {
                               TypeId = g.Key,
                               minRentalTime = g.Min(br => br.RentalDurationHours),
                               maxRentalTime = g.Max(br => br.RentalDurationHours),
                               avgRentalTime = g.Average(br => br.RentalDurationHours)
                           }).ToList();
        // Assert - verify that we got the correct results
        Assert.Equal(0.5, rentalTimes[0].minRentalTime);
        Assert.Equal(2, rentalTimes[0].maxRentalTime);
        Assert.Equal(1.375, rentalTimes[0].avgRentalTime);
    }
}