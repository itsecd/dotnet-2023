using BicycleRentals;
namespace BicycleTests;
public class BicycleFixture
{
    /// <summary>
    /// BicycleTests() :Database initialization and rental's collection
    /// </summary> 
    public BicycleFixture()
    {
        FixTypes = new List<BicycleType>() {
            new BicycleType() { TypeId = 1, TypeName = "Mountain", RentalPricePerHour = 10,
                Bicycles = new List<Bicycle>(){ FixBicycles[0], FixBicycles[3], FixBicycles[6], FixBicycles[7] }},
            new BicycleType() { TypeId = 2, TypeName = "City", RentalPricePerHour = 8,
                Bicycles = new List<Bicycle>(){ FixBicycles[1], FixBicycles[4], FixBicycles[5], FixBicycles[9] }},
            new BicycleType() { TypeId = 3, TypeName = "Sport", RentalPricePerHour = 15,
                Bicycles = new List<Bicycle>(){ FixBicycles[2], FixBicycles[8] }}
        };
        FixBicycles = new List<Bicycle>()
        {
            new Bicycle() { SerialNumber = 1, Type = FixTypes[0], Model = "Trek X-Caliber 7", Color = "Black",
                Rentals= new List<BicycleRental>(){ FixRentals[0],FixRentals[4]}},
            new Bicycle() { SerialNumber = 2, Type = FixTypes[1], Model = "Specialized Sirrus 2.0", Color = "Red",
                Rentals= new List<BicycleRental>(){ }},
            new Bicycle() { SerialNumber = 3, Type = FixTypes[2], Model = "Cannondale Synapse Carbon Disc 105", Color = "White",
                Rentals= new List<BicycleRental>(){ FixRentals[1]}},
            new Bicycle() { SerialNumber = 4, Type = FixTypes[0], Model = "Giant Talon 3", Color = "Green",
                Rentals= new List<BicycleRental>(){ FixRentals[2],FixRentals[5]}},
            new Bicycle() { SerialNumber = 5, Type = FixTypes[1], Model = "Raleigh Detour 2", Color = "Blue",
                Rentals= new List<BicycleRental>(){ FixRentals[3],FixRentals[9]}},
            new Bicycle() { SerialNumber = 6, Type = FixTypes[1], Model = "Giant Escape 3", Color = "Grey",
                Rentals= new List<BicycleRental>(){ FixRentals[8]}},
            new Bicycle() { SerialNumber = 7, Type = FixTypes[0], Model = "Norco Storm", Color = "Blue",
                Rentals= new List<BicycleRental>(){ }},
            new Bicycle() { SerialNumber = 8, Type = FixTypes[0], Model = "Scott Aspect", Color = "White",
                Rentals= new List<BicycleRental>(){ }},
            new Bicycle() { SerialNumber = 9, Type = FixTypes[2], Model = "Giant TCR", Color = "Black",
                Rentals= new List<BicycleRental>(){ FixRentals[6]}},
            new Bicycle() { SerialNumber = 10, Type = FixTypes[1], Model = "Schwinn Discover", Color = "Blue",
                Rentals= new List<BicycleRental>(){ FixRentals[7]}}
        };
        FixCustomers = new List<Customer>() {
             new Customer() { FullName = "Ivanov Ivan Ivanovich", BirthYear = 1980, Phone = "+79123456789",
                Rentals= new List<BicycleRental>(){ FixRentals[0],FixRentals[9]} },
             new Customer() { FullName = "Petrov Petr Petrovich", BirthYear = 1995, Phone = "+79234567890" ,
                Rentals= new List<BicycleRental>(){ FixRentals[1],FixRentals[8]}},
             new Customer() { FullName = "Sidorova Olga Vladimirovna", BirthYear = 1987, Phone = "+79345678901",
                Rentals= new List<BicycleRental>(){ FixRentals[2],FixRentals[6]} },
             new Customer() { FullName = "Kozlov Dmitry Igorevich", BirthYear = 1978, Phone = "+79456789012" ,
                Rentals= new List<BicycleRental>(){ FixRentals[3],FixRentals[5],FixRentals[7]}},
             new Customer() { FullName = "Makarov Alexey Andreevich", BirthYear = 1990, Phone = "+79567890123",
                Rentals= new List<BicycleRental>(){ FixRentals[4]} }
        };
        FixRentals = new List<BicycleRental>() {
            new BicycleRental() { Bicycle = FixBicycles[0], Customer = FixCustomers[0], RentalStartTime = new DateTime(2022, 3, 1, 9, 0, 0), RentalEndTime = new DateTime(2022, 3, 1, 10, 0, 0) },
            new BicycleRental() { Bicycle = FixBicycles[2], Customer = FixCustomers[1], RentalStartTime = new DateTime(2023, 3, 2, 10, 0, 0), RentalEndTime = new DateTime(2023, 3, 2, 12, 0, 0) },
            new BicycleRental() { Bicycle = FixBicycles[3], Customer = FixCustomers[2], RentalStartTime = new DateTime(2022, 3, 3, 11, 0, 0), RentalEndTime = new DateTime(2022, 3, 3, 11, 30, 0) },
            new BicycleRental() { Bicycle = FixBicycles[4], Customer = FixCustomers[3], RentalStartTime = new DateTime(2023, 3, 4, 12, 0, 0), RentalEndTime = new DateTime(2023, 3, 4, 14, 0, 0) },
            new BicycleRental() { Bicycle = FixBicycles[0], Customer = FixCustomers[4], RentalStartTime = new DateTime(2022, 3, 5, 13, 0, 0), RentalEndTime = new DateTime(2022, 3, 5, 15, 0, 0) },
            new BicycleRental() { Bicycle = FixBicycles[3], Customer = FixCustomers[3], RentalStartTime = new DateTime(2023, 3, 2, 10, 0, 0), RentalEndTime = new DateTime(2023, 3, 2, 12, 0, 0) },
            new BicycleRental() { Bicycle = FixBicycles[8], Customer = FixCustomers[2], RentalStartTime = new DateTime(2022, 3, 3, 14, 0, 0), RentalEndTime = new DateTime(2022, 3, 3, 16, 0, 0) },
            new BicycleRental() { Bicycle = FixBicycles[9], Customer = FixCustomers[3], RentalStartTime = new DateTime(2023, 3, 4, 16, 0, 0), RentalEndTime = new DateTime(2023, 3, 4, 18, 0, 0) },
            new BicycleRental() { Bicycle = FixBicycles[5], Customer = FixCustomers[1], RentalStartTime = new DateTime(2022, 3, 5, 11, 0, 0), RentalEndTime = new DateTime(2022, 3, 5, 12, 0, 0) },
            new BicycleRental() { Bicycle = FixBicycles[4], Customer = FixCustomers[0], RentalStartTime = new DateTime(2023, 3, 6, 13, 0, 0), RentalEndTime = new DateTime(2023, 3, 6, 15, 0, 0) }
        };
    }
    public List<BicycleType> FixTypes { get; set; }
    public List<Bicycle> FixBicycles { get; set; }
    public List<Customer> FixCustomers { get; set; }
    public List<BicycleRental> FixRentals { get; set; }        
}
