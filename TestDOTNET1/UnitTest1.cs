using System;
using Xunit;
using System.Collections.Generic;
using System.Linq;
using DOTNET_1;

namespace TestDOTNET1
{
    public class UnitTest
    {
        private List<DOTNET_1.Type> Types { get; set; }
        private List<Price> Prices { get; set; }
        private List<Bicycle> Bicycles { get; set; }
        private List<Customer> Customers { get; set; }
        private List<BicycleRental> Rentals { get; set; }

        // ������������� ���� ������
        public UnitTest()
        {
            Types = new List<Type>() {
                new Type() { Type_Id = 1, Type_name = "������"},
                new Type() { Type_Id = 2, Type_name = "�����������"},
                new Type() { Type_Id = 3, Type_name = "����������"}
            };

            Prices = new List<Price>()
            {
                new Price() { Type = Types[0], RentalPricePerHour = 10},
                new Price() { Type = Types[1], RentalPricePerHour = 8},
                new Price() { Type = Types[2], RentalPricePerHour = 15}
            };

            Bicycles = new List<Bicycle>()
            {
                new Bicycle() { SerialNumber = 1, Type = Types[0], Model = "Trek", Color = "������"},
                new Bicycle() { SerialNumber = 2, Type = Types[1], Model = "Giant", Color = "�������"},
                new Bicycle() { SerialNumber = 3, Type = Types[2], Model = "Specialized", Color = "�����"},
                new Bicycle() { SerialNumber = 4, Type = Types[0], Model = "Scott", Color = "�������"},
                new Bicycle() { SerialNumber = 5, Type = Types[1], Model = "Schwinn", Color = "�����"},
                new Bicycle() { SerialNumber = 6, Type = Types[1], Model = "Giant Escape 3", Color = "�����"},
                new Bicycle() { SerialNumber = 7, Type = Types[0], Model = "Norco Storm", Color = "�����"},
                new Bicycle() { SerialNumber = 8, Type = Types[0], Model = "Scott Aspect", Color = "�����"},
                new Bicycle() { SerialNumber = 9, Type = Types[2], Model = "Giant TCR", Color = "������"},
                new Bicycle() { SerialNumber = 10, Type = Types[1], Model = "Schwinn Discover", Color = "�����"}
            };

            Customers = new List<Customer>() {
                 new Customer() { FullName = "������ ���� ��������", BirthYear = 1980, Phone = "+79123456789" },
                 new Customer() { FullName = "������ ���� ��������", BirthYear = 1995, Phone = "+79234567890" },
                 new Customer() { FullName = "�������� ����� ������������", BirthYear = 1987, Phone = "+79345678901" },
                 new Customer() { FullName = "������ ������� ��������", BirthYear = 1978, Phone = "+79456789012" },
                 new Customer() { FullName = "������� ������� ���������", BirthYear = 1990, Phone = "+79567890123" }
            };

            Rentals = new List<BicycleRental>() {
                new BicycleRental() { Bicycle = Bicycles[0], Customer = Customers[0], RentalStartTime = new DateTime(2022, 3, 1, 9, 0, 0), RentalEndTime = new DateTime(2022, 3, 1, 11, 0, 0) },
                new BicycleRental() { Bicycle = Bicycles[2], Customer = Customers[1], RentalStartTime = new DateTime(2023, 3, 2, 10, 0, 0), RentalEndTime = new DateTime(2023, 3, 2, 12, 0, 0) },
                new BicycleRental() { Bicycle = Bicycles[3], Customer = Customers[2], RentalStartTime = new DateTime(2022, 3, 3, 11, 0, 0), RentalEndTime = new DateTime(2022, 3, 3, 13, 0, 0) },
                new BicycleRental() { Bicycle = Bicycles[4], Customer = Customers[3], RentalStartTime = new DateTime(2023, 3, 4, 12, 0, 0), RentalEndTime = new DateTime(2023, 3, 4, 14, 0, 0) },
                new BicycleRental() { Bicycle = Bicycles[0], Customer = Customers[4], RentalStartTime = new DateTime(2022, 3, 5, 13, 0, 0), RentalEndTime = new DateTime(2022, 3, 5, 15, 0, 0) },
                new BicycleRental() { Bicycle = Bicycles[3], Customer = Customers[3], RentalStartTime = new DateTime(2023, 3, 2, 10, 0, 0), RentalEndTime = new DateTime(2023, 3, 2, 12, 0, 0) },
                new BicycleRental() { Bicycle = Bicycles[8], Customer = Customers[2], RentalStartTime = new DateTime(2022, 3, 3, 14, 0, 0), RentalEndTime = new DateTime(2022, 3, 3, 16, 0, 0) },
                new BicycleRental() { Bicycle = Bicycles[9], Customer = Customers[3], RentalStartTime = new DateTime(2023, 3, 4, 16, 0, 0), RentalEndTime = new DateTime(2023, 3, 4, 18, 0, 0) },
                new BicycleRental() { Bicycle = Bicycles[5], Customer = Customers[1], RentalStartTime = new DateTime(2022, 3, 5, 11, 0, 0), RentalEndTime = new DateTime(2022, 3, 5, 12, 0, 0) },
                new BicycleRental() { Bicycle = Bicycles[4], Customer = Customers[0], RentalStartTime = new DateTime(2023, 3, 6, 13, 0, 0), RentalEndTime = new DateTime(2023, 3, 6, 15, 0, 0) }
            };
        }

        //1.������� ���������� ��� ���� ���������� �����������.
        [Fact]
        public void Test_GetSportBicycles()
        {
            // Act
            var sportBikes = Bicycles.Where(b => b.Type.Type_name == "����������");

            // Assert
            //'Assert.Equal(2, sportBikes.Count());
            Assert.True(sportBikes.Count() == 2, "OK");
        }

        //2.������� ���������� ��� ���� ��������, ������� ����� � ������ ������ ����������, ����������� �� ���
        [Fact]
        public void Test_GetCustomersWhoRentedMountainBikes()
        {
            // Arrange        
            var mountainBikes = Bicycles.Where(b => b.Type.Type_name == "������");

            // Act
            var customerNames = from c in Customers
                                join r in Rentals on c.Id equals r.Customer.Id
                                join b in mountainBikes on r.Bicycle.SerialNumber equals b.SerialNumber
                                orderby c.FullName ascending
                                select c.FullName;

            // Assert
            Assert.Equal(new List<string> { "Anna Smith", "John Doe" }, customerNames.ToList());
        }

        //3.������� ��������� ����� ������ ����������� ������� ����.
        [Fact]
        public void Test_GetTotalRentalTimePerBicycleType()
        {
            // Act
            var totalRentalTime = Rentals.GroupBy(r => r.Bicycle.Type.Type_name)
                                             .Select(g => new { BikeType = g.Key, TotalTime = g.Sum(br => br.RentalDurationHours) });

            // Assert
            Assert.Equal(new List<object> { new { BikeType = "������", TotalTime = 5 },
                                             new { BikeType = "�����������", TotalTime = 2 },
                                             new { BikeType = "����������", TotalTime = 4 } },
                         totalRentalTime.ToList());
        }


        //4.������� ���������� � ��������, ������� ���������� �� ������ ������ ����� ���.

        [Fact]
        public void Test_GetCustomersWithMostRentals_ReturnsCorrectCount()
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


        //5.������� ���������� � ��� 5 �������� ����� ���������� �����������
        [Fact]
        public void Test_Top5MostRentedBikes()
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
            Assert.Equal(3, top5Bikes[0]);
            Assert.Equal(5, top5Bikes[1]);
            Assert.Equal(4, top5Bikes[2]);
            Assert.Equal(2, top5Bikes[3]);
            Assert.Equal(6, top5Bikes[4]);
        }

        //6.������� ���������� � �����������, ������������ � ������� ������� ������ �����������.
        [Fact]
        public void Test_MinMaxAvgRentalTime()
        {
            // Arrange - get the minimum, maximum, and average rental times for all bikes 
            var rentalTimes = Rentals
                .GroupBy(r => r.Bicycle.Type.Type_name)
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

