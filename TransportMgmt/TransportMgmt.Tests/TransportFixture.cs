namespace TransportMgmt.Tests;

using TransportMgmt.Domain;

public class TransportFixture
{
    /// <summary>
    /// List of transport type
    /// </summary>
    public List<TransportType> TransportType
    {
        get
        {
            return new List<TransportType>()
            {
                new TransportType { TypeId = 1, TypeName = "автобус" },
                new TransportType { TypeId = 2, TypeName = "троллейбус" },
                new TransportType { TypeId = 3, TypeName = "трамвай" }

            };
        }
    }
    /// <summary>
    /// List of models
    /// </summary>
    public List<Model> Models
    {
        get
        {
            return new List<Model>()
            {
                new Model {ModelId = 1, ModelName = "ГАЗель NN", FloorLevel = "Low", MaxCapacity = 20},
                new Model {ModelId = 2, ModelName = "MAN Lion's City", FloorLevel = "High", MaxCapacity = 35},
                new Model {ModelId = 3, ModelName = "ЗИЛ", FloorLevel = "Low", MaxCapacity = 15},
                new Model {ModelId = 4, ModelName = "ЛиАЗ-4292", FloorLevel = "High", MaxCapacity = 25},
                new Model {ModelId = 5, ModelName = "Ситирим-10", FloorLevel = "High", MaxCapacity = 40},
                new Model {ModelId = 6, ModelName = "МАЗ-232", FloorLevel = "Low", MaxCapacity = 20},
                new Model {ModelId = 7, ModelName = "Mercedes-Benz Sprinter", FloorLevel = "Low", MaxCapacity = 20},
            };

        }
    }
    /// <summary>
    /// List of routes
    /// </summary>
    public List<Route> Routes
    {
        get
        {
            return new List<Route>()
            {
                new Route { RouteId = 1, RouteNumber = "1"},
                new Route { RouteId = 2, RouteNumber = "2"},
                new Route { RouteId = 3, RouteNumber = "3"},
                new Route { RouteId = 4, RouteNumber = "4"},
                new Route { RouteId = 5, RouteNumber = "5Д"},
                new Route { RouteId = 6, RouteNumber = "67"},
                new Route { RouteId = 7, RouteNumber = "126с"},
                new Route { RouteId = 8, RouteNumber = "126ю"},
                new Route { RouteId = 9, RouteNumber = "20"},
                new Route { RouteId = 10, RouteNumber = "22"},
                new Route { RouteId = 11, RouteNumber = "5"},
                new Route { RouteId = 12, RouteNumber = "13"}

            };
        }
    }
    /// <summary>
    /// Default list of drivers
    /// </summary>
    public List<Driver> Drivers
    {
        get
        {
                return new List<Driver>()
            {
                 new Driver (1, "Степан", "Водянов", "Денисович", 270972, 1112, "22 Армии 412", "88005553535"),
                 new Driver (2, "Степан", "Арапенков", "Владимирович", 270973, 1113, "22 Армии 413", "88005553536"),
                 new Driver (3, "Михаил", "Борисычев", "Владиславович", 270974, 1114, "22 Армии 414", "88005553537"),
                 new Driver (4, "Владимир", "Гусев", "Андреевич", 270975, 1115, "22 Армии 415", "88005553538"),
                 new Driver (5, "Семён", "Денисов", "Владимирович", 270976, 1116, "22 Армии 416", "88005553539"),
                 new Driver (6, "Степан", "Денисов", "Владимирович", 270977, 1117, "22 Армии 417", "88005553540"),
            };
        }
    }
    /// <summary>
    /// List of transports
    /// </summary>
    public List<Transport> Transports
    {
        get
        {
            return new List<Transport>()
            {
                new Transport(1, TransportType[0], Models[0], new DateOnly(1990, 10, 23)),
                new Transport(2, TransportType[1], Models[1], new DateOnly(1992, 04, 18)),
                new Transport(3, TransportType[2], Models[2], new DateOnly(1985, 10, 15)),
                new Transport(4, TransportType[0], Models[3], new DateOnly(2010, 11, 13)),
                new Transport(5, TransportType[1], Models[4], new DateOnly(2015, 12, 09)),
                new Transport(6, TransportType[1], Models[5], new DateOnly(2007, 08, 12)),
                new Transport(7, TransportType[1], Models[6], new DateOnly(2009, 06, 07))
            };
        }
    }
    /// <summary>
    /// List of trips
    /// </summary>
    public List<Trip> Trips
    {
        get
        {
            return new List<Trip>()
            {
                new Trip(1, new DateOnly(2023, 03, 19), new DateTime(2023, 03, 19, 08, 00, 00), new DateTime(2023, 03, 19, 17, 30, 00), Routes[0], Transports[0], Drivers[0]),
                new Trip(2, new DateOnly(2023, 03, 19), new DateTime(2023, 03, 19, 08, 00, 00), new DateTime(2023, 03, 19, 17, 30, 00), Routes[1], Transports[1], Drivers[1]),
                new Trip(3, new DateOnly(2023, 03, 19), new DateTime(2023, 03, 19, 08, 00, 00), new DateTime(2023, 03, 19, 17, 30, 00), Routes[2], Transports[2], Drivers[2]),
                new Trip(4, new DateOnly(2023, 03, 19), new DateTime(2023, 03, 19, 08, 00, 00), new DateTime(2023, 03, 19, 17, 30, 00), Routes[3], Transports[3], Drivers[3]),
                new Trip(5, new DateOnly(2023, 03, 19), new DateTime(2023, 03, 19, 08, 00, 00), new DateTime(2023, 03, 19, 17, 30, 00), Routes[4], Transports[4], Drivers[4]),
                new Trip(6, new DateOnly(2023, 03, 19), new DateTime(2023, 03, 19, 08, 00, 00), new DateTime(2023, 03, 19, 17, 30, 00), Routes[5], Transports[5], Drivers[5]),
                new Trip(7, new DateOnly(2023, 03, 19), new DateTime(2023, 03, 19, 17, 30, 00), new DateTime(2023, 03, 19, 19, 30, 00), Routes[5], Transports[0], Drivers[0]),
                new Trip(8, new DateOnly(2023, 03, 19), new DateTime(2023, 03, 19, 19, 30, 00), new DateTime(2023, 03, 19, 21, 00, 00), Routes[3], Transports[2], Drivers[0]),
                new Trip(4, new DateOnly(2023, 03, 19), new DateTime(2023, 03, 19, 17, 30, 00), new DateTime(2023, 03, 19, 21, 00, 00), Routes[4], Transports[1], Drivers[3])
            };
        }
    }
}

