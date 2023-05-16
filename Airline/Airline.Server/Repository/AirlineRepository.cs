using AirLine.Model;
using AirlineModel;

namespace Airline.Server.Repository;

public class AirlineRepository : IAirlineRepository
{
    //private readonly List<Airline> _airlines;
    private readonly List<Airplane> _airplanes;
    private readonly List<Flight> _flights;
    private readonly List<Passenger> _passengers;
    private readonly List<Ticket> _tickets;
    private readonly List<FlightAirplaneTicket> _flightAirplaneTickets;

    public AirlineRepository()
    {
        _airplanes = new List<Airplane>()
        {
            new Airplane(1, "Tu-134", 100, 50, 70),
            new Airplane(2, "Tu-154", 150, 60, 90),
            new Airplane(3, "SuperJet-100", 200, 90, 100),
            new Airplane(4, "Boeing-777", 400, 70, 235),
            new Airplane(5, "Boeing-747", 3500, 80, 320)
        };
        _flights = new List<Flight>()
        {
            new Flight(1, "BD-1120", "Moscow", "Budapest", new DateTime(2022, 11, 20, 19, 00, 00), new DateTime(2022, 11, 20, 23, 30, 00)),
            new Flight(2, "CH-0510", "Pekin", "Samara", new DateTime(2022, 5, 10, 10, 00, 00), new DateTime(2022, 5, 10, 20, 05, 00)),
            new Flight(3, "CZ-0321", "Samara", "Praha", new DateTime(2020, 03, 21, 12, 30, 00), new DateTime(2020, 03, 21, 17, 20, 00)),
            new Flight(4, "BD-1122", "Samara", "Budapest", new DateTime(2023, 11, 22, 19, 00, 00), new DateTime(2023, 11, 22, 22, 30, 00)),
            new Flight(5, "TB-1130", "Praha", "Tambov", new DateTime(2021, 11, 30, 10, 00, 00), new DateTime(2021, 11, 30, 15, 30, 00)),
            new Flight(6, "SP-0314", "Samara", "Saint-Peterburg", new DateTime(2022, 03, 14, 19, 00, 00), new DateTime(2022, 03, 14, 20, 30, 00))

        };
        _passengers = new List<Passenger>()
        {
            new Passenger(1, 0001, "Petrovskaya Kira Viktorovna"),
            new Passenger(2, 0002, "Fedotov Saveliy Vladimirovich"),
            new Passenger(3, 0003, "Panov Timur Daniilovich"),
            new Passenger(4, 0004, "Karpova Daria Ivanovna"),
            new Passenger(5, 0005, "Eliseev Daniil Romanovich"),
            new Passenger(6, 0006, "Nikolaev David Alexandrovich")
        };
        _tickets = new List<Ticket>()
        {
            new Ticket(1, 1000, "5A", 7.5),
            new Ticket(2, 1320, "2B", 7.5),
            new Ticket(3, 1001, "5B", 2.3),
            new Ticket(4, 1231, "7C", 2.3),
            new Ticket(5, 1002, "10C", 0),
            new Ticket(6, 1003, "7A", 0),
            new Ticket(7, 1004, "13F", 5),
            new Ticket(8, 1441, "5B", 5),
            new Ticket(9, 1373, "6A", 5),
            new Ticket(10, 1005, "9F", 1)
        };
        _flightAirplaneTickets = new List<FlightAirplaneTicket>()
        {
            new FlightAirplaneTicket(1, 1, 1, 1),
            new FlightAirplaneTicket(2, 1, 2, 1),
            new FlightAirplaneTicket(3, 1, 3, 4),
            new FlightAirplaneTicket(4, 1, 4, 4),
            new FlightAirplaneTicket(5, 2, 5, 2),
            new FlightAirplaneTicket(6, 2, 6, 2),
            new FlightAirplaneTicket(7, 4, 7, 3),
            new FlightAirplaneTicket(8, 4, 8, 3),
            new FlightAirplaneTicket(9, 4, 9, 5),
            new FlightAirplaneTicket(10, 4, 10, 6)
    };
    }
    public List<Ticket> Tickets => _tickets;
    public List<Flight> Flights => _flights;
    public List<Passenger> Passengers => _passengers;
    public List<Airplane> Airplanes => _airplanes;
    public List<FlightAirplaneTicket> FlightAirplaneTickets => _flightAirplaneTickets;


}
