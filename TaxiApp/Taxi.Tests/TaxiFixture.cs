using Taxi.Domain;

namespace Taxi.Tests;

public class TaxiFixture
{
    public List<VehicleClassification> FixtureVehicleClassifications
    {
        get
        {
            var vehicleClassB = new VehicleClassification()
            {
                Id = 1,
                Brand = "Lada",
                Model = "Granta",
                Class = "B"
            };
            
            var vehicleClassC = new VehicleClassification()
            {
                Id = 2,
                Brand = "Skoda",
                Model = "Octavia",
                Class = "C"
            };
            var vehicleClassD = new VehicleClassification()
            {
                Id = 3,
                Brand = "Audi",
                Model = "A4",
                Class = "D"
            };
            
            return new List<VehicleClassification>() {vehicleClassB, vehicleClassC, vehicleClassD};
        }
    }

    public List<Driver> FixtureDrivers
    {
        get
        {
            var firstDriver = new Driver() 
            { 
                Id = 1, 
                FirstName = "Сергей", 
                LastName = "Петров",
                Patronymic = "Павлович", 
                Passport = "3616099877", 
                PhoneNumber = "79278990908"
            };
            var secondDriver = new Driver() 
            { 
                Id = 2, 
                FirstName = "Михаил", 
                LastName = "Шмелев",
                Patronymic = "Сергеевич", 
                Passport = "3616201668", 
                PhoneNumber = "79604515989"
            };
            var thirdDriver = new Driver() 
            { 
                Id = 3, 
                FirstName = "Алексей", 
                LastName = "Логинов",
                Patronymic = "Иванович", 
                Passport = "3616529576", 
                PhoneNumber = "79041496150"
            };
            var fourthDriver = new Driver() 
            { 
                Id = 4, 
                FirstName = "Александр", 
                LastName = "Самойлов",
                Patronymic = "Тимофеевич", 
                Passport = "3616039857", 
                PhoneNumber = "79041496150"
            };
            var fifthDriver = new Driver() 
            { 
                Id = 5, 
                FirstName = "Ярослав", 
                LastName = "Соловьев",
                Patronymic = "Константинович", 
                Passport = "3616222472", 
                PhoneNumber = "79534563399"
            };
            
            return new List<Driver>() { firstDriver, secondDriver, thirdDriver, fourthDriver, fifthDriver };
        }
    }
    
    public List<Vehicle> FixtureVehicles
    {
        get
        {
            var firstVehicle = new Vehicle()
            {
                Id = 1,
                RegistrationCarPlate = "Е555КХ163",
                Colour = "grey",
                VehicleClassificationId = 1,
                DriverId = 5
            };
            var secondVehicle = new Vehicle()
            {
                Id = 2,
                RegistrationCarPlate = "А007МР163",
                Colour = "white",
                VehicleClassificationId = 1,
                DriverId = 4
            };
            var thirdVehicle = new Vehicle()
            {
                Id = 3,
                RegistrationCarPlate = "Х243КХ163",
                Colour = "white",
                VehicleClassificationId = 2,
                DriverId = 3
            };
            var fourthVehicle = new Vehicle()
            {
                Id = 4,
                RegistrationCarPlate = "В796ТМ116",
                Colour = "black",
                VehicleClassificationId = 2,
                DriverId = 2
            };
            var fifthVehicle = new Vehicle()
            {
                Id = 5,
                RegistrationCarPlate = "К005ТМ163",
                Colour = "black",
                VehicleClassificationId = 3,
                DriverId = 1
            };
            
            return new List<Vehicle>() { firstVehicle, secondVehicle, thirdVehicle, fourthVehicle, fifthVehicle };
        }
    }

    public List<Passenger> FixturePassengers
    {
        get
        {
            var firstPassenger = new Passenger()
            {
                Id = 1, 
                FirstName = "Максим", 
                LastName = "Кулешов", 
                Patronymic = "Семёнович", 
                PhoneNumber = "79610482450"
            };
            var secondPassenger = new Passenger()
            {
                Id = 2, 
                FirstName = "Анна", 
                LastName = "Рыжова", 
                Patronymic = "Марковна", 
                PhoneNumber = "79031127350"
            };
            var thirdPassenger = new Passenger()
            {
                Id = 3, 
                FirstName = "Злата", 
                LastName = "Никольская", 
                Patronymic = "Робертовна", 
                PhoneNumber = "79029517723"
            };
            var fourthPassenger = new Passenger()
            {
                Id = 4, 
                FirstName = "Елизавета", 
                LastName = "Беляева", 
                Patronymic = "Павловна", 
                PhoneNumber = "79634132986"
            };
            var fifthPassenger = new Passenger()
            {
                Id = 5, 
                FirstName = "Вадим", 
                LastName = "Котов", 
                Patronymic = "Денисович", 
                PhoneNumber = "79664807986"
            };
            var sixthPassenger = new Passenger()
            {
                Id = 6, 
                FirstName = "Иван", 
                LastName = "Аксенов", 
                Patronymic = "Леонидович", 
                PhoneNumber = "79696086252"
            };
            var seventhPassenger = new Passenger()
            {
                Id = 7, 
                FirstName = "Дарья", 
                LastName = "Грачева", 
                Patronymic = "Данииловна", 
                PhoneNumber = "79023367578"
            };
            
            return new List<Passenger>() { firstPassenger, secondPassenger, thirdPassenger, fourthPassenger, fifthPassenger, sixthPassenger, seventhPassenger};
        }
    }

    public List<Ride> FixtureRides
    {
        get
        {
            var rides = new List<Ride>(20);
            var streets = new List<string>() { "Советская", "Ульяновская", "Победы", "Володарского", "Дзержинского" };
            var dates = new List<DateTime>()
            {
                new DateTime(2023, 02, 02, 11, 13, 11),
                new DateTime(2023, 02, 03, 12, 3, 34),
                new DateTime(2023, 02, 04, 12, 1, 21),
                new DateTime(2023, 02, 05, 13, 33, 51),
                new DateTime(2023, 02, 06, 15, 11, 31)
            };

            for (var i = 0; i < 20; i++)
            {

                var ride = new Ride()
                {
                    Id = (UInt64)i,
                    DeparturePoint = streets[i % 5] + " " + (i*10).ToString(),
                    DestinationPoint = streets[(i + 2) % 5] + " " + (i*5).ToString(),
                    RideDate = dates[i % 5],
                    RideTime = new TimeOnly(0, i*2 + 10),
                    Cost = (UInt32)(100 + i * 20),
                    PassengerId = (UInt64)i % 7 + 1,
                    VehicleId = (UInt64)i % 5 + 1
                };
                rides.Add(ride);
            }
            
            return rides;
        }
    }

}