using RentalService.Domain;

namespace RentalService.Tests;

public class RentalServiceFixture
{
    public List<Client> FixtureClient
    {
        get
        {
            var firstClient = new Client
            {
                Id = 1,
                LastName = "Яруллин",
                FirstName = "Лаврентий",
                Patronymic = "Никитьевич",
                BirthDate = new DateTime(1967, 11, 17, 11,34,1),
                Passport = "4939 153040"
            };
            var secondClient = new Client
            {
                Id = 2,
                LastName = "Аникин",
                FirstName = "Степан",
                Patronymic = "Валерьевич",
                BirthDate = new DateTime(1971, 12, 16, 13,09,1),
                Passport = "4599 723567"
            };
            var thirdClient = new Client
            {
                Id = 3,
                LastName = "Щербинина",
                FirstName = "Таисия",
                Patronymic = "Фадеевна",
                BirthDate = new DateTime(1993, 09, 24, 16,12,1),
                Passport = "4796 806443"
            };
            var fourthClient = new Client
            {
                Id = 4,
                LastName = "Горева",
                FirstName = "Алиса",
                Patronymic = "Федоровна",
                BirthDate = new DateTime(1966, 09, 27, 12,12,1),
                Passport = "4439 510590"
            };
            var fifthClient = new Client
            {
                Id = 5,
                LastName = "Лапидус",
                FirstName = "Григорий",
                Patronymic = "Федорович",
                BirthDate = new DateTime(1983, 08, 21, 16,02,1),
                Passport = "4896 462655"
            };
            return new List<Client> { firstClient, secondClient, thirdClient, fourthClient, fifthClient };
        }
    }

    public List<RentalPoint> FixtureRentalPoint
    {
        get
        {
            var firstRentalPoint = new RentalPoint
            {
                Id = 1,
                Title = "Бумеранг-Авто",
                Address = "г.Самара, Московское ш., 163Б"
            };
            var secondRentalPoint = new RentalPoint
            {
                Id = 2,
                Title = "Конкур-Аренда-авто",
                Address = "г.Самара, Олимпийская ул., 68"
            };
            var thirdRentalPoint = new RentalPoint
            {
                Id = 3,
                Title = "Wrc Motors",
                Address = "г.Самара, 6-я просека, 149"
            };
            var fourthRentalPoint = new RentalPoint
            {
                Id = 4,
                Title = "Luxury Time",
                Address = "г.Самара, Ново-Садовая ул., 162Д"
            };
            var fifthRentalPoint = new RentalPoint
            {
                Id = 5,
                Title = "Соло",
                Address = "г.Самара, ул. 22 Партсъезда, 207"
            };
            return new List<RentalPoint> 
                { firstRentalPoint, secondRentalPoint, thirdRentalPoint, fourthRentalPoint, fifthRentalPoint };
        }
    }

    public List<VehicleModel> FixtureVehicleModel
    {
        get
        {
            var firstVehicleModel = new VehicleModel
            {
                Id = 1,
                Model = "X3 M",
                Brand = "Honda"
            };
            var secondVehicleModel = new VehicleModel
            {
                Id = 2,
                Model = "A2",
                Brand = "Infiniti"
            };
            var thirdVehicleModel = new VehicleModel
            {
                Id = 3,
                Model = "ix35",
                Brand = "Geely"
            };
            var fourthVehicleModel = new VehicleModel
            {
                Id = 4,
                Model = "X6",
                Brand = "BMW"
            };
            var fifthVehicleModel = new VehicleModel
            {
                Id = 5,
                Model = "Emgrand",
                Brand = "Geely"
            };
            return new List<VehicleModel>
                { firstVehicleModel, secondVehicleModel, thirdVehicleModel, fourthVehicleModel, fifthVehicleModel };
        }
    }
    
    public List<Vehicle> FixtureVehicle
    {
        get
        {
            var firstVehicle = new Vehicle
            {
                Id = 1,
                Number = "К622КА39",
                ModelId = 1,
                Colour = "Тёмно-синий"
            };
            var secondVehicle= new Vehicle
            {
                Id = 2,
                Number = "Х547ХМ18",
                ModelId = 3,
                Colour = "Серо-зелёный"
            };
            var thirdVehicle = new Vehicle
            {
                Id = 3,
                Number = "М018ЕС73",
                ModelId = 3,
                Colour = "Серебристо-серо-зеленоватый"
            };
            var fourthVehicle = new Vehicle
            {
                Id = 4,
                Number = "Н728МН81",
                ModelId = 2,
                Colour = "Цвет морской волны"
            };
            var fifthVehicle = new Vehicle
            {
                Id = 5,
                Number = "Н818ОО35",
                ModelId = 5,
                Colour = "Зелёный"
            };
            return new List<Vehicle>
                { firstVehicle, secondVehicle, thirdVehicle, fourthVehicle, fifthVehicle };
        }
    }
    
    public List<RefundInformation> FixtureRefundInformation
    {
        get
        {
            var firstRefundInformation = new RefundInformation
            {
                Id = 1,
                RefundPointId = 1,
                RefundDate = new DateTime(2019, 05, 20, 11, 11, 11)
            };
            var secondRefundInformation = new RefundInformation
            {
                Id = 2,
                RefundPointId = 2,
                RefundDate = new DateTime(2019, 03, 14, 14, 14, 14)
            };
            var thirdRefundInformation = new RefundInformation
            {
                Id = 3,
                RefundPointId = 3,
                RefundDate = new DateTime(2022, 07, 16, 09, 15, 12)
            };
            var fourthRefundInformation = new RefundInformation
            {
                Id = 4,
                RefundPointId = 4,
                RefundDate = new DateTime(2022, 02, 04, 07, 09, 12)
            };
            var fifthRefundInformation = new RefundInformation
            {
                Id = 5,
                RefundPointId = 5,
                RefundDate = new DateTime(2013, 04, 24, 12, 12, 12)
            };
            return new List<RefundInformation> { firstRefundInformation, secondRefundInformation, 
                thirdRefundInformation, fourthRefundInformation, fifthRefundInformation };
        }
    }
    
    public List<RentalInformation> FixtureRentalInformation
    {
        get
        {
            var firstRentalInformation = new RentalInformation
            {
                Id = 1,
                RentalPointId = 1,
                RentalDate = new DateTime(2019, 05, 15, 11, 11, 11),
                RentalPeriod = 5
            };
            var secondRentalInformation = new RentalInformation
            {
                Id = 2,
                RentalPointId = 2,
                RentalDate = new DateTime(2019, 03, 04, 14, 14, 14),
                RentalPeriod = 10
            };
            var thirdRentalInformation = new RentalInformation
            {
                Id = 3,
                RentalPointId = 3,
                RentalDate = new DateTime(2022, 07, 01, 09, 15, 12),
                RentalPeriod = 15
            };
            var fourthRentalInformation = new RentalInformation
            {
                Id = 4,
                RentalPointId = 4,
                RentalDate = new DateTime(2022, 02, 02, 07, 09, 12),
                RentalPeriod = 2
            };
            var fifthRentalInformation = new RentalInformation
            {
                Id = 5,
                RentalPointId = 5,
                RentalDate = new DateTime(2013, 04, 19, 12, 12, 12),
                RentalPeriod = 5
            };
            return new List<RentalInformation> { firstRentalInformation, secondRentalInformation, 
                thirdRentalInformation, fourthRentalInformation, fifthRentalInformation };
        }
    }
    
    public List<IssuedCar> FixtureIssuedCar
    {
        get
        {
            var firstIssuedCar = new IssuedCar
            {
                Id = 1,
                ClientId = 1,
                VehicleId = 1,
                RefundInformationId = 1,
                RentalInformationId = 1
            };
            var secondIssuedCar = new IssuedCar
            {
                Id = 2,
                ClientId = 2,
                VehicleId = 2,
                RefundInformationId = 2,
                RentalInformationId = 2
            };
            var thirdIssuedCar = new IssuedCar
            {
                Id = 3,
                ClientId = 3,
                VehicleId = 3,
                RefundInformationId = 3,
                RentalInformationId = 3
            };
            var fourthIssuedCar = new IssuedCar
            {
                Id = 4,
                ClientId = 4,
                VehicleId = 4,
                RefundInformationId = 4,
                RentalInformationId = 4
            };
            var fifthIssuedCar = new IssuedCar
            {
                Id = 5,
                ClientId = 5,
                VehicleId = 5,
                RefundInformationId = 5,
                RentalInformationId = 5
            };
            return new List<IssuedCar> { firstIssuedCar, secondIssuedCar, 
                thirdIssuedCar, fourthIssuedCar, fifthIssuedCar };
        }
    }
}