using Taxi.Domain;

namespace Taxi.Tests;

public class TaxiFixture
{
    public List<VehicleClassification> FixtureVehicleClassifications
    {
        get
        {
            var vehicleClassB = new VehicleClassification(1, "Lada", "Granta", "B");
            var vehicleClassC = new VehicleClassification(2, "Skoda", "Octavia", "C");
            var vehicleClassD = new VehicleClassification(3, "Audi", "A4", "D");
            
            return new List<VehicleClassification>() {vehicleClassB, vehicleClassC, vehicleClassD};
        }
    }

    public List<Driver> FixtureDrivers
    {
        get
        {
            var firstDriver = new Driver(1, "Сергей", "Петров", "Павлович", "3616099877", "79278990908");
            var secondDriver = new Driver(2, "Михаил", "Шмелев", "Сергеевич", "3616201668", "79278990908");
            var thirdDriver = new Driver(3, "Алексей", "Логинов", "Иванович", "3616529576", "79278990908");
            var fourthDriver = new Driver(4, "Александр", "Самойлов", "Тимофеевич", "3616039857", "79278990908");
            var fifthDriver = new Driver(5, "Ярослав", "Соловьев", "Константинович", "3616222472", "79278990908");
            
            return new List<Driver>() { firstDriver, secondDriver, thirdDriver, fourthDriver, fifthDriver };
        }
    }
    public List<Vehicle> FixtureVehicles
    {
        get
        {
            var firstVehicle = new Vehicle(1, "Е555КХ163", "grey", 1, 1);
            var secondVehicle = new Vehicle(2, "А007МР163", "white", 1, 5);
            var thirdVehicle = new Vehicle(3, "Х243КХ163", "white", 2, 2);
            var fourthVehicle = new Vehicle(4, "В796ТМ116", "black", 2, 4);
            var fifthVehicle = new Vehicle(5, "К005ТМ163", "black", 3, 3);
            
            return new List<Vehicle>() { firstVehicle, secondVehicle, thirdVehicle, fourthVehicle, fifthVehicle };
        }
    }

    public List<Passenger> FixturePassengers
    {
        get
        {
            var firstPassenger = new Passenger(1, "Максим", "Кулешов", "Семёнович", "79610482450");
            var secondPassenger= new Passenger(2, "Анна", "Рыжова", "Марковна", "79031127350");
            var thirdPassenger = new Passenger(3, "Злата", "Никольская", "Робертовна", "79029517723");
            var fourthPassenger = new Passenger(4, "Елизавета", "Беляева", "Павловна", "79634132986");
            var fifthPassenger = new Passenger(5, "Вадим", "Котов", "Денисович", "79664807986");
            var sixthPassenger = new Passenger(6, "Иван", "Аксенов", "Леонидович", "79696086252");
            var seventhPassenger = new Passenger(7, "Дарья", "Грачева", "Данииловна", "79023367578");

            return new List<Passenger>() { firstPassenger, secondPassenger, thirdPassenger, fourthPassenger, fifthPassenger, sixthPassenger, seventhPassenger};
        }
    }

    public List<Ride> FixtureDrives
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

            for (var i = 0; i < 10; i++)
            {
                var ride = new Ride(UInt64.Parse((i + 1).ToString()), streets[i % 5], streets[(i + 1) % 5], dates[i%5],
                    new TimeOnly(0, 20, 20), 400, UInt64.Parse((i % 7 + 1).ToString()), UInt64.Parse((i % 5 + 1).ToString()));
                rides.Add(ride);
            }
            
            return rides;
        }
    }

}