using TransportMgmt.Domain;

namespace TransportMgmtServer.Repository;
/// <summary>
/// A class for storing and modifying table data
/// </summary>
public class TransportMgmtRepository : ITransportMgmtRepository
{
    private readonly List<TransportType> _transportType;
    private readonly List<Model> _models;
    private readonly List<Routes> _routes;
    private readonly List<Driver> _drivers;
    private readonly List<Transport> _transport;
    private readonly List<Trip> _trips;
    /// <summary>
    /// A constructor that adds some default values for tables
    /// </summary>
    public TransportMgmtRepository()
    {
        _transportType = new List<TransportType>()
            {
                new TransportType { Id = 1, TypeName = "автобус" },
                new TransportType { Id = 2, TypeName = "троллейбус" },
                new TransportType { Id = 3, TypeName = "трамвай" }

            };

        _models = new List<Model>()
            {
                new Model {Id = 1, ModelName = "ГАЗель NN", FloorLevel = "Low", MaxCapacity = 20},
                new Model {Id = 2, ModelName = "MAN Lion's City", FloorLevel = "High", MaxCapacity = 35},
                new Model {Id = 3, ModelName = "ЗИЛ", FloorLevel = "Low", MaxCapacity = 15},
                new Model {Id = 4, ModelName = "ЛиАЗ-4292", FloorLevel = "High", MaxCapacity = 25},
                new Model {Id = 5, ModelName = "Ситирим-10", FloorLevel = "High", MaxCapacity = 40},
                new Model {Id = 6, ModelName = "МАЗ-232", FloorLevel = "Low", MaxCapacity = 20},
                new Model {Id = 7, ModelName = "Mercedes-Benz Sprinter", FloorLevel = "Low", MaxCapacity = 20},
            };

        _routes = new List<Routes>()
            {
                new Routes { Id = 1, RouteNumber = "1"},
                new Routes { Id = 2, RouteNumber = "2"},
                new Routes { Id = 3, RouteNumber = "3"},
                new Routes { Id = 4, RouteNumber = "4"},
                new Routes { Id = 5, RouteNumber = "5Д"},
                new Routes { Id = 6, RouteNumber = "67"},
                new Routes { Id = 7, RouteNumber = "126с"},
                new Routes { Id = 8, RouteNumber = "126ю"},
                new Routes { Id = 9, RouteNumber = "20"},
                new Routes { Id = 10, RouteNumber = "22"},
                new Routes { Id = 11, RouteNumber = "5"},
                new Routes { Id = 12, RouteNumber = "13"}
            };

        _drivers = new List<Driver>()
            {
                 new Driver (1, "Степан", "Водянов", "Денисович", 270972, 1112, "22 Армии 412", "88005553535"),
                 new Driver (2, "Степан", "Арапенков", "Владимирович", 270973, 1113, "22 Армии 413", "88005553536"),
                 new Driver (3, "Семён", "Денисов", "Владимирович", 270976, 1116, "22 Армии 416", "88005553539"),
                 new Driver (4, "Михаил", "Борисычев", "Владиславович", 270974, 1114, "22 Армии 414", "88005553537"),
                 new Driver (5, "Владимир", "Гусев", "Андреевич", 270975, 1115, "22 Армии 415", "88005553538"),
                 new Driver (6, "Степан", "Денисов", "Владимирович", 270977, 1117, "22 Армии 417", "88005553540"),
            };

        _transport = new List<Transport>()
            {
                new Transport(1, "A001AA163", _transportType[0], _models[0], new DateTime(1990, 10, 23)),
                new Transport(2, "A002AA163", _transportType[1], _models[1], new DateTime(1992, 04, 18)),
                new Transport(3, "A003AA163", _transportType[2], _models[2], new DateTime(1985, 10, 15)),
                new Transport(4, "A004AA163", _transportType[0], _models[3], new DateTime(2010, 11, 13)),
                new Transport(5, "A005AA163", _transportType[1], _models[4], new DateTime(2015, 12, 09)),
                new Transport(6, "A006AA163", _transportType[2], _models[5], new DateTime(2007, 08, 12)),
                new Transport(7, "A007AA163", _transportType[1], _models[6], new DateTime(2009, 06, 07))
            };

        _trips = new List<Trip>()
            {
                new Trip(1, new DateTime(2023, 03, 19), new DateTime(2023, 03, 19, 08, 00, 00), new DateTime(2023, 03, 19, 17, 30, 00), _routes[0], _transport[0], _drivers[0]),
                new Trip(2, new DateTime(2023, 03, 19), new DateTime(2023, 03, 19, 08, 00, 00), new DateTime(2023, 03, 19, 17, 30, 00), _routes[1], _transport[1], _drivers[1]),
                new Trip(3, new DateTime(2023, 03, 19), new DateTime(2023, 03, 19, 08, 00, 00), new DateTime(2023, 03, 19, 17, 30, 00), _routes[2], _transport[2], _drivers[2]),
                new Trip(4, new DateTime(2023, 03, 19), new DateTime(2023, 03, 19, 08, 00, 00), new DateTime(2023, 03, 19, 17, 30, 00), _routes[3], _transport[3], _drivers[3]),
                new Trip(5, new DateTime(2023, 03, 19), new DateTime(2023, 03, 19, 08, 00, 00), new DateTime(2023, 03, 19, 17, 30, 00), _routes[4], _transport[4], _drivers[4]),
                new Trip(6, new DateTime(2023, 03, 19), new DateTime(2023, 03, 19, 08, 00, 00), new DateTime(2023, 03, 19, 17, 30, 00), _routes[5], _transport[5], _drivers[2]),
                new Trip(7, new DateTime(2023, 03, 19), new DateTime(2023, 03, 19, 17, 30, 00), new DateTime(2023, 03, 19, 19, 30, 00), _routes[5], _transport[0], _drivers[0]),
                new Trip(8, new DateTime(2023, 03, 19), new DateTime(2023, 03, 19, 19, 30, 00), new DateTime(2023, 03, 19, 21, 00, 00), _routes[3], _transport[2], _drivers[0]),
                new Trip(4, new DateTime(2023, 03, 19), new DateTime(2023, 03, 19, 17, 30, 00), new DateTime(2023, 03, 19, 21, 00, 00), _routes[4], _transport[1], _drivers[3]),
                new Trip(9, new DateTime(2023, 03, 19), new DateTime(2023, 03, 19, 08, 00, 00), new DateTime(2023, 03, 19, 17, 30, 00), _routes[2], _transport[6], _drivers[2]),
                new Trip(10, new DateTime(2023, 03, 19), new DateTime(2023, 03, 19, 21, 00, 00), new DateTime(2023, 03, 19, 21, 30, 00), _routes[0], _transport[1], _drivers[0])
            };
    }
    /// <summary>
    /// A list of transport types that will change by methods
    /// </summary>
    public List<TransportType> TransportType => _transportType;
    /// <summary>
    /// A list of models that will change by methods
    /// </summary>
    public List<Model> Models => _models;
    /// <summary>
    /// A list of routes that will change by methods
    /// </summary>
    public List<Routes> Routes => _routes;
    /// <summary>
    /// A list of drivers that will change by methods
    /// </summary>
    public List<Driver> Drivers => _drivers;
    /// <summary>
    /// A list of transport that will change by methods
    /// </summary>
    public List<Transport> Transports => _transport;
    /// <summary>
    /// A list of trips that will change by methods
    /// </summary>
    public List<Trip> Trips => _trips;

}
