namespace BicycleRentals.Domain.Test;
public class BicycleFixture
{
    public List<BicycleType> FixTypes
    {
        get => new()
            {
            new BicycleType() { TypeId = 1, TypeName = "Mountain", RentalPricePerHour = 10,
                Bicycles = new List<Bicycle>(){ FixBicycles[0], FixBicycles[3], FixBicycles[6], FixBicycles[7] }},
            new BicycleType() { TypeId = 2, TypeName = "City", RentalPricePerHour = 8,
                Bicycles = new List<Bicycle>(){ FixBicycles[1], FixBicycles[4], FixBicycles[5], FixBicycles[9] }},
            new BicycleType() { TypeId = 3, TypeName = "Sport", RentalPricePerHour = 15,
                Bicycles = new List<Bicycle>(){ FixBicycles[2], FixBicycles[8] }}
            };

    }
    public List<Bicycle> FixBicycles
    {
        get => new()
            {
            new Bicycle() { SerialNumber = 1,TypeId = 1, Model = "Trek X-Caliber 7", Color = "Black",
                Rentals= new List<BicycleRental>(){ FixRentals[0],FixRentals[4]}},
            new Bicycle() { SerialNumber = 2,TypeId = 2,  Model = "Specialized Sirrus 2.0", Color = "Red",
                Rentals= new List<BicycleRental>(){ }},
            new Bicycle() { SerialNumber = 3,TypeId = 3,  Model = "Cannondale Synapse Carbon Disc 105", Color = "White",
                Rentals= new List<BicycleRental>(){ FixRentals[1]}},
            new Bicycle() { SerialNumber = 4,TypeId = 1,  Model = "Giant Talon 3", Color = "Green",
                Rentals= new List<BicycleRental>(){ FixRentals[2],FixRentals[5]}},
            new Bicycle() { SerialNumber = 5,TypeId = 2,  Model = "Raleigh Detour 2", Color = "Blue",
                Rentals= new List<BicycleRental>(){ FixRentals[3],FixRentals[9]}},
            new Bicycle() { SerialNumber = 6,TypeId = 2,  Model = "Giant Escape 3", Color = "Grey",
                Rentals= new List<BicycleRental>(){ FixRentals[8]}},
            new Bicycle() { SerialNumber = 7,TypeId = 1,  Model = "Norco Storm", Color = "Blue",
                Rentals= new List<BicycleRental>(){ }},
            new Bicycle() { SerialNumber = 8,TypeId = 1,  Model = "Scott Aspect", Color = "White",
                Rentals= new List<BicycleRental>(){ }},
            new Bicycle() { SerialNumber = 9,TypeId = 3,  Model = "Giant TCR", Color = "Black",
                Rentals= new List<BicycleRental>(){ FixRentals[6]}},
            new Bicycle() { SerialNumber = 10,TypeId =2 , Model = "Schwinn Discover", Color = "Blue",
                Rentals= new List<BicycleRental>(){ FixRentals[7]}}
            };
    }
    public List<Customer> FixCustomers
    {
        get => new()
            {
             new Customer() {Id = 1, FullName = "Ivanov Ivan Ivanovich", BirthYear = 1980, Phone = "+79123456789",
                Rentals= new List<BicycleRental>(){ FixRentals[0],FixRentals[9]} },
             new Customer() { Id = 2,FullName = "Petrov Petr Petrovich", BirthYear = 1995, Phone = "+79234567890" ,
                Rentals= new List<BicycleRental>(){ FixRentals[1],FixRentals[8]}},
             new Customer() {Id = 3, FullName = "Sidorova Olga Vladimirovna", BirthYear = 1987, Phone = "+79345678901",
                Rentals= new List<BicycleRental>(){ FixRentals[2],FixRentals[6]} },
             new Customer() {Id = 4, FullName = "Kozlov Dmitry Igorevich", BirthYear = 1978, Phone = "+79456789012" ,
                Rentals= new List<BicycleRental>(){ FixRentals[3],FixRentals[5],FixRentals[7]}},
             new Customer() {Id = 5, FullName = "Makarov Alexey Andreevich", BirthYear = 1990, Phone = "+79567890123",
                Rentals= new List<BicycleRental>(){ FixRentals[4]} }
            };
    }
    public List<BicycleRental> FixRentals
    {
        get => new()
            {
            new BicycleRental() {SerialNumber = 1,CustomerId = 1, RentalStartTime = new DateTime(2022, 3, 1, 9, 0, 0), RentalEndTime = new DateTime(2022, 3, 1, 10, 0, 0) },
            new BicycleRental() {SerialNumber = 3,CustomerId = 2, RentalStartTime = new DateTime(2023, 3, 2, 10, 0, 0), RentalEndTime = new DateTime(2023, 3, 2, 12, 0, 0) },
            new BicycleRental() {SerialNumber = 4,CustomerId = 3,RentalStartTime = new DateTime(2022, 3, 3, 11, 0, 0), RentalEndTime = new DateTime(2022, 3, 3, 11, 30, 0) },
            new BicycleRental() {SerialNumber = 5,CustomerId = 4,RentalStartTime = new DateTime(2023, 3, 4, 12, 0, 0), RentalEndTime = new DateTime(2023, 3, 4, 14, 0, 0) },
            new BicycleRental() {SerialNumber = 1,CustomerId = 5, RentalStartTime = new DateTime(2022, 3, 5, 13, 0, 0), RentalEndTime = new DateTime(2022, 3, 5, 15, 0, 0) },
            new BicycleRental() {SerialNumber = 4,CustomerId = 4,RentalStartTime = new DateTime(2023, 3, 2, 10, 0, 0), RentalEndTime = new DateTime(2023, 3, 2, 12, 0, 0) },
            new BicycleRental() {SerialNumber = 9,CustomerId = 3, RentalStartTime = new DateTime(2022, 3, 3, 14, 0, 0), RentalEndTime = new DateTime(2022, 3, 3, 16, 0, 0) },
            new BicycleRental() {SerialNumber = 10,CustomerId = 4, RentalStartTime = new DateTime(2023, 3, 4, 16, 0, 0), RentalEndTime = new DateTime(2023, 3, 4, 18, 0, 0) },
            new BicycleRental() {SerialNumber = 6,CustomerId = 2, RentalStartTime = new DateTime(2022, 3, 5, 11, 0, 0), RentalEndTime = new DateTime(2022, 3, 5, 12, 0, 0) },
            new BicycleRental() {SerialNumber = 5,CustomerId = 1, RentalStartTime = new DateTime(2023, 3, 6, 13, 0, 0), RentalEndTime = new DateTime(2023, 3, 6, 15, 0, 0) }
            };
    }
}
