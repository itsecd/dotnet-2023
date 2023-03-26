using Taxi.Domain;

namespace Taxi.Server.Repository;

public class TaxiRepository: ITaxiRepository
{
    private readonly List<VehicleClassification> _vehicleClassifications;

    private readonly List<Driver> _drivers;

    private readonly List<Vehicle> _vehicles;

    private readonly List<Ride> _rides;

    private readonly List<Passenger> _passengers;

    public TaxiRepository()
    {
        _vehicleClassifications = new List<VehicleClassification>
        { 
            new VehicleClassification 
            {
                Id = 1,
                Brand = "Lada",
                Model = "Granta",
                Class = "B"
            },
            new VehicleClassification
            {
                Id = 2,
                Brand = "Skoda",
                Model = "Octavia",
                Class = "C"
            },
            new VehicleClassification
            {
                Id = 3,
                Brand = "Audi",
                Model = "A4",
                Class = "D"
            }
        };

        _drivers = new List<Driver>
        { 
            new Driver 
            {
                Id = 1,
                FirstName = "Сергей",
                LastName = "Петров",
                Patronymic = "Павлович",
                Passport = "3616099877",
                PhoneNumber = "79278990908"
            },
            new Driver
            {
                Id = 2,
                FirstName = "Михаил",
                LastName = "Шмелев",
                Patronymic = "Сергеевич",
                Passport = "3616201668",
                PhoneNumber = "79604515989"
            },
            new Driver
            {
                Id = 3,
                FirstName = "Алексей",
                LastName = "Логинов",
                Patronymic = "Иванович",
                Passport = "3616529576",
                PhoneNumber = "79041496150"
            },
            new Driver
            {
                Id = 4,
                FirstName = "Александр",
                LastName = "Самойлов",
                Patronymic = "Тимофеевич",
                Passport = "3616039857",
                PhoneNumber = "79041496150"
            },
            new Driver
            {
                Id = 5,
                FirstName = "Ярослав",
                LastName = "Соловьев",
                Patronymic = "Константинович",
                Passport = "3616222472",
                PhoneNumber = "79534563399"
            }
        };

        _vehicles = new List<Vehicle>
        {
            new Vehicle
            {
                Id = 1,
                RegistrationCarPlate = "Е555КХ163",
                Colour = "grey",
                VehicleClassificationId = 1,
                DriverId = 5
            },
            new Vehicle
            {
                Id = 2,
                RegistrationCarPlate = "А007МР163",
                Colour = "white",
                VehicleClassificationId = 1,
                DriverId = 4
            },
            new Vehicle
            {
                Id = 3,
                RegistrationCarPlate = "Х243КХ163",
                Colour = "white",
                VehicleClassificationId = 2,
                DriverId = 3
            },
            new Vehicle
            {
                Id = 4,
                RegistrationCarPlate = "В796ТМ116",
                Colour = "black",
                VehicleClassificationId = 2,
                DriverId = 2
            },
            new Vehicle
            {
                Id = 5,
                RegistrationCarPlate = "К005ТМ163",
                Colour = "black",
                VehicleClassificationId = 3,
                DriverId = 1
            }
        };

        _passengers = new List<Passenger>
        {
            new Passenger
            {
                Id = 1,
                FirstName = "Максим",
                LastName = "Кулешов",
                Patronymic = "Семёнович",
                PhoneNumber = "79610482450"
            },
            new Passenger
            {
                Id = 2,
                FirstName = "Анна",
                LastName = "Рыжова",
                Patronymic = "Марковна",
                PhoneNumber = "79031127350"
            },
            new Passenger
            {
                Id = 3,
                FirstName = "Злата",
                LastName = "Никольская",
                Patronymic = "Робертовна",
                PhoneNumber = "79029517723"
            },
            new Passenger
            {
                Id = 4,
                FirstName = "Елизавета",
                LastName = "Беляева",
                Patronymic = "Павловна",
                PhoneNumber = "79634132986"
            },
            new Passenger
            {
                Id = 5,
                FirstName = "Вадим",
                LastName = "Котов",
                Patronymic = "Денисович",
                PhoneNumber = "79664807986"
            },
            new Passenger
            {
                Id = 6,
                FirstName = "Иван",
                LastName = "Аксенов",
                Patronymic = "Леонидович",
                PhoneNumber = "79696086252"
            },
            new Passenger
            {
                Id = 7,
                FirstName = "Дарья",
                LastName = "Грачева",
                Patronymic = "Данииловна",
                PhoneNumber = "79023367578"
            }
        };
        
        _rides = new List<Ride>(20);
        var streets = new List<string> { "Советская", "Ульяновская", "Победы", "Володарского", "Дзержинского" };
        var dates = new List<DateTime>
        {
            new(2023, 02, 02, 11, 13, 11),
            new(2023, 02, 03, 12, 3, 34),
            new(2023, 02, 04, 12, 1, 21),
            new(2023, 02, 05, 13, 33, 51),
            new(2023, 02, 06, 15, 11, 31)
        };

        for (var i = 0; i < 20; i++)
        {
            var ride = new Ride
            {
                Id = (ulong)i,
                DeparturePoint = streets[i % 5] + " " + (i * 10),
                DestinationPoint = streets[(i + 2) % 5] + " " + (i * 5),
                RideDate = dates[i % 5],
                RideTime = new TimeOnly(0, (i * 2) + 10),
                Cost = (uint)(100 + (i * 20)),
                PassengerId = ((ulong)i % 7) + 1,
                VehicleId = ((ulong)i % 5) + 1
            };
            _rides.Add(ride);
        }
    }

    public List<VehicleClassification> VehicleClassifications => _vehicleClassifications;

    public List<Driver> Drivers => _drivers;

    public List<Vehicle> Vehicles => _vehicles;

    public List<Passenger> Passengers => _passengers;

    public List<Ride> Rides => _rides;

}