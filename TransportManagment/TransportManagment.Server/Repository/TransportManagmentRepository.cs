using TransportManagment.Model;

namespace TransportManagment.Server.Repository;

public class TransportManagmentRepository : ITransportManagmentRepository
{
    private readonly List<Transport> _transports;
    private readonly List<Driver> _drivers;
    private readonly List<Model.Route> _routes;
    public TransportManagmentRepository()
    {
        _transports = new List<Transport>()
        {
            new Transport(1, "bus", "Mercedes", new DateTime(1990, 10, 23)),
            new Transport(2, "bus", "Audi", new DateTime(1992, 04, 18)),
            new Transport(3, "trolleybus", "VAZ", new DateTime(1985, 10, 23)),
            new Transport(4, "trolleybus", "VAZ", new DateTime(2010, 11, 01)),
            new Transport(5, "tram", "Samtram", new DateTime(1990, 10, 13)),
            new Transport(6, "tram", "Mostram", new DateTime(1989, 08, 02)),
        };
        _drivers = new List<Driver>()
        {
             new Driver (11, "Igor", "Gudzenko", "Nicolaevich", 290865, 2434, 2568090),
             new Driver (12, "Oleg", "Fursov", "Igorevich", 292365, 2211, 2578090),
             new Driver (13, "Evpatiy", "Kage", "Niconorovich", 129561, 3081, 2568430),
             new Driver (14, "Egor", "Abramov", "Danilovich", 280123, 2411, 2568123),
             new Driver (15, "Adry", "Tarasov", "Sergeivich", 199321, 2784, 2522290),
             new Driver (16, "Bill", "Pechorin", "Andeivich", 300965, 1234, 3668090),
        };
        _routes = new List<Model.Route>()
        {
            new Classes.Route(100, new DateTime(2022, 02, 11), 480, 1050, 1, 11),
            new Classes.Route(111, new DateTime(2022, 02, 11), 540, 960, 2, 12),
            new Classes.Route(112, new DateTime(2022, 02, 11), 960, 1350, 2, 13),
            new Classes.Route(123, new DateTime(2022, 02, 11), 450, 870, 3, 14),
            new Classes.Route(133, new DateTime(2022, 02, 11), 900, 1380, 4, 14),
            new Classes.Route(144, new DateTime(2022, 02, 11), 360, 1080, 5, 15),
            new Classes.Route(155, new DateTime(2022, 02, 12), 390, 1080, 6, 16),
        };
        _routes[0].Driver = _drivers[0];
        _routes[0].Transport = _transports[0];
        _routes[1].Driver = _drivers[1];
        _routes[1].Transport = _transports[1];
        _routes[2].Driver = _drivers[2];
        _routes[2].Transport = _transports[1];
        _routes[3].Driver = _drivers[3];
        _routes[3].Transport = _transports[2];
        _routes[4].Driver = _drivers[3];
        _routes[4].Transport = _transports[3];
        _routes[5].Driver = _drivers[4];
        _routes[5].Transport = _transports[4];
        _routes[6].Driver = _drivers[5];
        _routes[6].Transport = _transports[5];
        _drivers[0].Routes.Add(_routes[0]);
        _drivers[1].Routes.Add(_routes[1]);
        _drivers[2].Routes.Add(_routes[2]);
        _drivers[3].Routes.Add(_routes[3]);
        _drivers[3].Routes.Add(_routes[4]);
        _drivers[4].Routes.Add(_routes[5]);
        _drivers[5].Routes.Add(_routes[6]);
        _transports[0].Routes.Add(_routes[0]);
        _transports[1].Routes.Add(_routes[1]);
        _transports[1].Routes.Add(_routes[2]);
        _transports[2].Routes.Add(_routes[3]);
        _transports[3].Routes.Add(_routes[4]);
        _transports[4].Routes.Add(_routes[5]);
        _transports[5].Routes.Add(_routes[6]);
    }
    public List<Transport> Transports => _transports;
    public List<Driver> Drivers => _drivers;
    public List<Model.Route> Routes => _routes;
}