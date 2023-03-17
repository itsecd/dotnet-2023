using BicycleRentals;

namespace BicycleTests
{
    public class BicycleTests
    {
        BicycleFixture Fixture = new BicycleFixture();
        /// <summary>
        /// 1.Test information about all sports bikes.
        /// </summary>         
        [Fact]
        public void TestGetSportBicycles()
        {
            // Act
            var sportBikes = Fixture.Bicycles.Where((Func<Bicycle, bool>)(b => b.Type.TypeName == "Sport"));
            // Assert
            Assert.Equal(2, sportBikes.Count());
        }
        /// <summary>
        /// 2.Test information about all clients who rented mountain bikes, sort by full name
        /// </summary>       
        [Fact]
        public void TestGetCustomersWhoRentedMountainBikes()
        {
            // Arrange        
            var mountainBikes = Fixture.Bicycles.Where((Func<Bicycle, bool>)(b => b.Type.TypeName == "Mountain"));
            // Act
            var customerNames = from c in Fixture.Customers
                                join r in Fixture.Rentals on c.Id equals r.Customer.Id
                                join b in mountainBikes on r.Bicycle.SerialNumber equals b.SerialNumber
                                orderby c.FullName ascending
                                select c.FullName;
            // Assert
            Assert.Equal(new List<string> { "Kozlov Dmitry Igorevich", "Ivanov Ivan Ivanovich" }, customerNames.ToList());
        }
        /// <summary>
        /// 3.Test the total rental time for each type of bike.
        /// </summary>        
        [Fact]
        public void TestGetTotalRentalTimePerBicycleType()
        {
            // Act
            var totalRentalTime = Fixture.Rentals.GroupBy(r => r.Bicycle.Type.TypeName)
                                             .Select(g => new { BikeType = g.Key, TotalTime = g.Sum(br => br.RentalDurationHours) });
            // Assert
            Assert.Equal(new List<object> { new { BikeType = "Mountain", TotalTime = 5.5 },
                                             new { BikeType = "City", TotalTime = 7.5 },
                                             new { BikeType = "Sports", TotalTime = 4 } },
                         totalRentalTime.ToList());
        }
        /// <summary>
        /// 4.Test information about customers who have rented bikes the most times.
        /// </summary>        
        [Fact]
        public void TestGetCustomersWithMostRentals_ReturnsCorrectCount()
        {
            // Act
            var customerRentalCounts = Fixture.Rentals.GroupBy(br => br.Customer.Id)
                                                 .Select(g => new { CustomerId = g.Key, RentalCount = g.Count() })
                                                 .OrderByDescending(c => c.RentalCount);
            var mostRentedCustomers = from c in Fixture.Customers
                                      join crc in customerRentalCounts on c.Id equals crc.CustomerId
                                      where crc.RentalCount == customerRentalCounts.First().RentalCount
                                      select c.FullName;
            // Assert
            Assert.Single(mostRentedCustomers);
            Assert.Equal("John Doe", mostRentedCustomers.First());
        }

        /// <summary>
        /// 5. Test information about the top 5 most frequently rented bikes
        /// </summary>
        [Fact]
        public void TestTop5MostRentedBikes()
        {
            // Arrange - get the top 5 most rented bikes from the data context           
            var top5Bikes = Fixture.Rentals
                .GroupBy(r => r.Bicycle.SerialNumber)
                .OrderByDescending(g => g.Count())
                .Take(5)
                .Select(g => g.Key)
                .ToList();
            // Act
            // ... nothing to do here since we already got the data in the Arrange step
            // Assert - verify that we got the correct bikes
            Assert.Equal(5, top5Bikes.Count);
            Assert.Equal(1, top5Bikes[0]);
            Assert.Equal(1, top5Bikes[1]);
            Assert.Equal(2, top5Bikes[2]);
            Assert.Equal(3, top5Bikes[3]);
            Assert.Equal(2, top5Bikes[4]);
        }
        /// <summary>
        /// 6.Test information about the minimum, maximum and average bike rental time.
        /// </summary>        
        [Fact]
        public void TestMinMaxAvgRentalTime()
        {
            // Arrange - get the minimum, maximum, and average rental times for all bikes 
            var rentalTimes = Fixture.Rentals
                .GroupBy(r => r.Bicycle.Type.TypeName)
                .Select(g => new
                {
                    TypeName = g.Key,
                    minRentalTime = g.Min(br => br.RentalDurationHours),
                    maxRentalTime = g.Max(br => br.RentalDurationHours),
                    avgRentalTime = g.Average(br => br.RentalDurationHours)
                })
                .ToList();
            // Assert - verify that we got the correct results
            Assert.Equal(0.5, rentalTimes[0].minRentalTime);
            Assert.Equal(2, rentalTimes[0].maxRentalTime);
            Assert.Equal(1.375, rentalTimes[0].avgRentalTime);
        }
    }
}