using BicycleRentals;

namespace BicycleTests
{
    public class BicycleFixture
    {
        /// <summary>
        /// BicycleTests() :Database initialization and rental's collection
        /// </summary> 
        public BicycleFixture()
        {
            Types = new List<BicycleType>() {
                new BicycleType() { TypeId = 1, TypeName = "Mountain", RentalPricePerHour = 10},
                new BicycleType() { TypeId = 2, TypeName = "City", RentalPricePerHour = 8},
                new BicycleType() { TypeId = 3, TypeName = "Sport", RentalPricePerHour = 15}
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
        public List<BicycleType> Types { get; set; }
        public List<Bicycle> Bicycles { get; set; }
        public List<Customer> Customers { get; set; }
        public List<BicycleRental> Rentals { get; set; }        
    }
}
