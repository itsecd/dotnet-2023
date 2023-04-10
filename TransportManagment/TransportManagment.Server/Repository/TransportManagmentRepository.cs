using TransportManagment.Classes;

namespace TransportManagment.Server.Repository;
public class TransportManagmentRepository : ITransportManagmentRepository
{
    private readonly List<Transport> _transports;
    private readonly List<Driver> _drivers;
    private readonly List<Classes.Route> _routes;
    public TransportManagmentRepository()
    {
        _transports = new List<Transport>()
        {
            new Transport(1, "bus", "Mercedes", new DateTime(1990, 10, 23), new List<int> {100}),
            new Transport(2, "bus", "Audi", new DateTime(1992, 04, 18), new List<int> {111, 112}),
            new Transport(3, "trolleybus", "VAZ", new DateTime(1985, 10, 23), new List<int> {123}),
            new Transport(4, "trolleybus", "VAZ", new DateTime(2010, 11, 01), new List < int > {133}),
            new Transport(5, "tram", "Samtram", new DateTime(1990, 10, 13), new List < int > {144}),
            new Transport(6, "tram", "Mostram", new DateTime(1989, 08, 02), new List < int > {155}),
        };
        _drivers = new List<Driver>()
        {
             new Driver (11, "Igor", "Gudzenko", "Nicolaevich", 290865, 2434, 2568090, new List<int> { 100 }),
             new Driver (12, "Oleg", "Fursov", "Igorevich", 292365, 2211, 2578090, new List < int > { 111 }),
             new Driver (13, "Evpatiy", "Kage", "Niconorovich", 129561, 3081, 2568430, new List < int > { 112 }),
             new Driver (14, "Egor", "Abramov", "Danilovich", 280123, 2411, 2568123, new List < int > {123, 133}),
             new Driver (15, "Adry", "Tarasov", "Sergeivich", 199321, 2784, 2522290, new List < int > { 144 }),
             new Driver (16, "Bill", "Pechorin", "Andeivich", 300965, 1234, 3668090, new List < int > { 155 }),
        };
        _routes = new List<Classes.Route>()
        {
            new Classes.Route(100, new DateTime(2022, 02, 11), new DateTime(2022, 02, 11, 08, 00, 00), new DateTime(2022, 02, 11, 17, 30, 00), _transports[0], _drivers[0], 1, 11),
            new Classes.Route(111, new DateTime(2022, 02, 11), new DateTime(2022, 02, 11, 09, 00, 00), new DateTime(2022, 02, 11, 16, 00, 00), _transports[1], _drivers[1], 2, 12),
            new Classes.Route(112, new DateTime(2022, 02, 11), new DateTime(2022, 02, 11, 16, 30, 00), new DateTime(2022, 02, 11, 22, 30, 00), _transports[1], _drivers[2], 2, 13),
            new Classes.Route(123, new DateTime(2022, 02, 11), new DateTime(2022, 02, 11, 07, 30, 00), new DateTime(2022, 02, 11, 14, 30, 00), _transports[2], _drivers[3], 3, 14),
            new Classes.Route(133, new DateTime(2022, 02, 11), new DateTime(2022, 02, 11, 15, 00, 00), new DateTime(2022, 02, 11, 23, 00, 00), _transports[3], _drivers[3], 4, 14),
            new Classes.Route(144, new DateTime(2022, 02, 11), new DateTime(2022, 02, 11, 06, 00, 00), new DateTime(2022, 02, 11, 18, 00, 00), _transports[4], _drivers[4], 5, 15),
            new Classes.Route(155, new DateTime(2022, 02, 12), new DateTime(2022, 02, 12, 06, 30, 00), new DateTime(2022, 02, 11, 18, 00, 00), _transports[5], _drivers[5], 6, 16),
        };
    }
    public List<Transport> Transports => _transports;
    public List<Driver> Drivers => _drivers;
    public List<Classes.Route> Routes => _routes;
}