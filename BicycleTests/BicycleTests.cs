using BicycleTests.BicycleModels;

namespace BicycleTests
{
    public class BicycleTests
    {
        private List<BicycleType> Types { get; set; }
        private List<Price> Prices { get; set; }
        private List<Bicycle> Bicycles { get; set; }
        private List<Customer> Customers { get; set; }
        private List<BicycleRental> Rentals { get; set; }

        // Database initialization
        public BicycleTests()
        {
            Types = new List<BicycleType>() {
                new BicycleType() { TypeId = 1, TypeName = "Горный"},
                new BicycleType() { TypeId = 2, TypeName = "Прогулочный"},
                new BicycleType() { TypeId = 3, TypeName = "Спортивный"}
            };

            Prices = new List<Price>()
            {
                new Price() { Type = Types[0], RentalPricePerHour = 10},
                new Price() { Type = Types[1], RentalPricePerHour = 8},
                new Price() { Type = Types[2], RentalPricePerHour = 15}
            };

            Bicycles = new List<Bicycle>()
            {
                new Bicycle() { SerialNumber = 1, Type = Types[0], Model = "Trek X-Caliber 7", Color = "Black"},
                new Bicycle() { SerialNumber = 2, Type = Types[1], Model = "Specialized Sirrus 2.0", Color = "Red"},
                new Bicycle() { SerialNumber = 3, Type = Types[2], Model = "Cannondale Synapse Carbon Disc 105", Color = "White"},
                new Bicycle() { SerialNumber = 4, Type = Types[0], Model = "Giant Talon 3", Color = "Green"},
                new Bicycle() { SerialNumber = 5, Type = Types[1], Model = "Raleigh Detour 2", Color = "Blue"},
                new Bicycle() { SerialNumber = 6, Type = Types[1], Model = "Giant Escape 3", Color = "Grey"},
                new Bicycle() { SerialNumber = 7, Type = Types[0], Model = "Norco Storm", Color = "Blue"},
                new Bicycle() { SerialNumber = 8, Type = Types[0], Model = "Scott Aspect", Color = "White"},
                new Bicycle() { SerialNumber = 9, Type = Types[2], Model = "Giant TCR", Color = "Black"},
                new Bicycle() { SerialNumber = 10, Type = Types[1], Model = "Schwinn Discover", Color = "Blue"}
            };

            Customers = new List<Customer>() {
                 new Customer() { FullName = "Ivanov Ivan Ivanovich", BirthYear = 1980, Phone = "+79123456789" },
                 new Customer() { FullName = "Petrov Petr Petrovich", BirthYear = 1995, Phone = "+79234567890" },
                 new Customer() { FullName = "Sidorova Olga Vladimirovna", BirthYear = 1987, Phone = "+79345678901" },
                 new Customer() { FullName = "Kozlov Dmitry Igorevich", BirthYear = 1978, Phone = "+79456789012" },
                 new Customer() { FullName = "Makarov Alexey Andreevich", BirthYear = 1990, Phone = "+79567890123" }
            };

            Rentals = new List<BicycleRental>() {
                new BicycleRental() { Bicycle = Bicycles[0], Customer = Customers[0], RentalStartTime = new DateTime(2022, 3, 1, 9, 0, 0), RentalEndTime = new DateTime(2022, 3, 1, 10, 0, 0) },
                new BicycleRental() { Bicycle = Bicycles[2], Customer = Customers[1], RentalStartTime = new DateTime(2023, 3, 2, 10, 0, 0), RentalEndTime = new DateTime(2023, 3, 2, 12, 0, 0) },
                new BicycleRental() { Bicycle = Bicycles[3], Customer = Customers[2], RentalStartTime = new DateTime(2022, 3, 3, 11, 0, 0), RentalEndTime = new DateTime(2022, 3, 3, 11, 30, 0) },
                new BicycleRental() { Bicycle = Bicycles[4], Customer = Customers[3], RentalStartTime = new DateTime(2023, 3, 4, 12, 0, 0), RentalEndTime = new DateTime(2023, 3, 4, 14, 0, 0) },
                new BicycleRental() { Bicycle = Bicycles[0], Customer = Customers[4], RentalStartTime = new DateTime(2022, 3, 5, 13, 0, 0), RentalEndTime = new DateTime(2022, 3, 5, 15, 0, 0) },
                new BicycleRental() { Bicycle = Bicycles[3], Customer = Customers[3], RentalStartTime = new DateTime(2023, 3, 2, 10, 0, 0), RentalEndTime = new DateTime(2023, 3, 2, 12, 0, 0) },
                new BicycleRental() { Bicycle = Bicycles[8], Customer = Customers[2], RentalStartTime = new DateTime(2022, 3, 3, 14, 0, 0), RentalEndTime = new DateTime(2022, 3, 3, 16, 0, 0) },
                new BicycleRental() { Bicycle = Bicycles[9], Customer = Customers[3], RentalStartTime = new DateTime(2023, 3, 4, 16, 0, 0), RentalEndTime = new DateTime(2023, 3, 4, 18, 0, 0) },
                new BicycleRental() { Bicycle = Bicycles[5], Customer = Customers[1], RentalStartTime = new DateTime(2022, 3, 5, 11, 0, 0), RentalEndTime = new DateTime(2022, 3, 5, 12, 0, 0) },
                new BicycleRental() { Bicycle = Bicycles[4], Customer = Customers[0], RentalStartTime = new DateTime(2023, 3, 6, 13, 0, 0), RentalEndTime = new DateTime(2023, 3, 6, 15, 0, 0) }
            };
        }

        //1.Display information about all sports bikes.
        [Fact]
        public void TestGetSportBicycles()
        {
            // Act
            var sportBikes = Bicycles.Where((Func<Bicycle, bool>)(b => b.Type.TypeName == "Спортивный"));

            // Assert
            Assert.Equal(2, sportBikes.Count());
        }

        //2.Display information about all clients who rented mountain bikes, sort by full name
        [Fact]
        public void TestGetCustomersWhoRentedMountainBikes()
        {
            // Arrange        
            var mountainBikes = Bicycles.Where((Func<Bicycle, bool>)(b => b.Type.TypeName == "Горный"));

            // Act
            var customerNames = from c in Customers
                                join r in Rentals on c.Id equals r.Customer.Id
                                join b in mountainBikes on r.Bicycle.SerialNumber equals b.SerialNumber
                                orderby c.FullName ascending
                                select c.FullName;

            // Assert
            Assert.Equal(new List<string> { "Kozlov Dmitry Igorevich", "Ivanov Ivan Ivanovich" }, customerNames.ToList());
        }

        //3.Display the total rental time for each type of bike.
        [Fact]
        public void TestGetTotalRentalTimePerBicycleType()
        {
            // Act
            var totalRentalTime = Rentals.GroupBy(r => r.Bicycle.Type.TypeName)
                                             .Select(g => new { BikeType = g.Key, TotalTime = g.Sum(br => br.RentalDurationHours) });

            // Assert
            Assert.Equal(new List<object> { new { BikeType = "Горный", TotalTime = 5.5 },
                                             new { BikeType = "Прогулочный", TotalTime = 7.5 },
                                             new { BikeType = "Спортивный", TotalTime = 4 } },
                         totalRentalTime.ToList());
        }


        //4.Display information about customers who have rented bikes the most times.

        [Fact]
        public void TestGetCustomersWithMostRentals_ReturnsCorrectCount()
        {
            // Act
            var customerRentalCounts = Rentals.GroupBy(br => br.Customer.Id)
                                                 .Select(g => new { CustomerId = g.Key, RentalCount = g.Count() })
                                                 .OrderByDescending(c => c.RentalCount);

            var mostRentedCustomers = from c in Customers
                                      join crc in customerRentalCounts on c.Id equals crc.CustomerId
                                      where crc.RentalCount == customerRentalCounts.First().RentalCount
                                      select c.FullName;

            // Assert
            Assert.Single(mostRentedCustomers);
            Assert.Equal("John Doe", mostRentedCustomers.First());
        }


        //5. Display information about the top 5 most frequently rented bikes
        [Fact]
        public void TestTop5MostRentedBikes()
        {
            // Arrange - get the top 5 most rented bikes from the data context           
            var top5Bikes = Rentals
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

        //6.Display information about the minimum, maximum and average bike rental time.
        [Fact]
        public void TestMinMaxAvgRentalTime()
        {
            // Arrange - get the minimum, maximum, and average rental times for all bikes 
            var rentalTimes = Rentals
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