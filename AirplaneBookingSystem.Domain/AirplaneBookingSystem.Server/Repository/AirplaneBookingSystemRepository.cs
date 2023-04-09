using AirplaneBookingSystem.Domain;
namespace AirplaneBookingSystem.Server.Repository;

public class AirplaneBookingSystemRepository : IAirplaneBookingSystemRepository
{
    private readonly List<Ticket> _ticket;
    private readonly List<Client> _client;
    private readonly List<Flight> _flight;
    private readonly List<Airplane> _airplane;
    public AirplaneBookingSystemRepository()
    {
        var firstAirplane = new Airplane(500, "Boing-717");
        var secondAirplane = new Airplane(562, "Boing-777");
        var thirdAirplane = new Airplane(554, "ATR 42/72");
        var fourthAirplane = new Airplane(571, "Embraer ERJ");

        var firstFlight = new Flight(1, 1, "Kurumoch", "Astana", new DateTime(2023, 8, 28), new DateTime(2023, 8, 29), firstAirplane) { AirplaneId = 1 };
        var secondFlight = new Flight(2, 2, "Astana", "Kurumoch", new DateTime(2023, 10, 17), new DateTime(2023, 10, 18), secondAirplane) { AirplaneId = 2 };
        var thirdFlight = new Flight(3, 3, "Kurumoch", "Sochi", new DateTime(2023, 8, 28), new DateTime(2023, 8, 28), thirdAirplane) { AirplaneId = 3 };
        var fourthFlight = new Flight(4, 4, "Los Angeles", "Tokyo", new DateTime(2023, 10, 2), new DateTime(2023, 10, 3), fourthAirplane) { AirplaneId = 4 };
        var fifthFlight = new Flight(5, 5, "Chiko", "Kem", new DateTime(2023, 6, 6), new DateTime(2023, 6, 7), fourthAirplane) { AirplaneId = 4 };

        var firstClient = new Client(1, "738096", new DateTime(1969, 8, 15), "Samoylov A. K.");
        var firstTicket = new Ticket(1, 100, firstClient, firstFlight) { ClientId =1, FlightId = 1};
        firstClient.Tickets.Add(firstTicket);
        firstFlight.Tickets.Add(firstTicket);

        var secondClient = new Client(2, "258204", new DateTime(2002, 6, 4), "Shestakov N. D.");
        var secondTicket = new Ticket(2, 101, secondClient, firstFlight) { ClientId = 2, FlightId = 1 };
        var thirdTicket = new Ticket(3, 200, secondClient, secondFlight) { ClientId = 2, FlightId = 2 };
        secondClient.Tickets.Add(secondTicket);
        secondClient.Tickets.Add(thirdTicket);
        firstFlight.Tickets.Add(secondTicket);
        secondFlight.Tickets.Add(thirdTicket);

        var thirdClient = new Client(3, "211702", new DateTime(1984, 10, 28), "Fomina M. D.");
        var fourthTicket = new Ticket(4, 01, thirdClient, secondFlight) { ClientId = 3, FlightId = 2 };
        thirdClient.Tickets.Add(fourthTicket);
        secondFlight.Tickets.Add(fourthTicket);

        var fourthClient = new Client(4, "783469", new DateTime(1978, 10, 17), "Novikov Y. M.");
        var fifthTicket = new Ticket(5, 202, fourthClient, secondFlight) { ClientId = 4, FlightId = 2 };
        fourthClient.Tickets.Add(fifthTicket);
        secondFlight.Tickets.Add(fifthTicket);

        var fifthClient = new Client(5, "481761", new DateTime(2013, 12, 7), "Myasnikov S. I.");
        var sixtTicket = new Ticket(6, 300, fifthClient, thirdFlight) { ClientId = 5, FlightId = 3 };
        var seventhTicket = new Ticket(7, 500, fifthClient, fifthFlight) { ClientId = 5, FlightId = 5 };
        fifthClient.Tickets.Add(sixtTicket);
        fifthClient.Tickets.Add(seventhTicket);
        thirdFlight.Tickets.Add(sixtTicket);
        fifthFlight.Tickets.Add(seventhTicket);

        var sixthClient = new Client(6, "154590", new DateTime(1993, 3, 21), "Kapustina D. F.");
        var eighthTicket = new Ticket(8, 400, sixthClient, fourthFlight) { ClientId = 6, FlightId = 4 };
        sixthClient.Tickets.Add(eighthTicket);
        fourthFlight.Tickets.Add(eighthTicket);

        var seventhClient = new Client(7, "303386", new DateTime(2013, 4, 3), "Panfilova K. T.");
        var ninthTicket = new Ticket(9, 401, seventhClient, fourthFlight) { ClientId = 7, FlightId = 4 };
        seventhClient.Tickets.Add(ninthTicket);
        fourthFlight.Tickets.Add(ninthTicket);

        var eighthClient = new Client(8, "240348", new DateTime(1966, 8, 17), "Birukov D. M.");
        var tenthTicket = new Ticket(10, 402, eighthClient, fourthFlight) { ClientId = 8, FlightId = 4 };
        eighthClient.Tickets.Add(tenthTicket);
        fourthFlight.Tickets.Add(tenthTicket);

        var client = new List<Client>
            {
                firstClient,
                secondClient,
                thirdClient,
                fourthClient,
                fifthClient,
                sixthClient,
                seventhClient,
                eighthClient
            };
        var flight = new List<Flight>
            {
            firstFlight,
            secondFlight,
            thirdFlight,
            fourthFlight,
            fifthFlight
            };
        var airplane = new List<Airplane>
            {
            firstAirplane,
            secondAirplane,
            thirdAirplane,
            fourthAirplane
            };
        var ticket = new List<Ticket>
            {
            fifthTicket,
            secondTicket,
            thirdTicket,
            fourthTicket,
            fifthTicket,
            sixtTicket,
            seventhTicket,
            eighthTicket,
            ninthTicket,
            tenthTicket
            };
        _client = client;
        _flight = flight;
        _airplane = airplane;
        _ticket = ticket;
    }
    public List<Ticket> Tickets => _ticket;
    public List<Flight> Flights => _flight;
    public List<Client> Client => _client;
    public List<Airplane> Airplanes => _airplane;
}