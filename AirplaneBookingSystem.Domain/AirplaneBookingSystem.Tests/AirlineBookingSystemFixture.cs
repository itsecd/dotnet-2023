namespace AirplaneBookingSystem.Tests;


using AirplaneBookingSystem.Domain;

public class AirlineBookingSystemFixture
{
    public List<Ticket> FixtureTickets
    {
        get
        {
            var tickets = new List<Ticket>();
            var firstTicket = new Ticket(100);
            var secondTicket = new Ticket(101);
            var thirdTicket = new Ticket(200);
            var fourthTicket = new Ticket(201);
            var fifthTicket = new Ticket(202);
            var sixthTicket = new Ticket(300);
            var seventhTicket = new Ticket(400);
            var eighthTicket = new Ticket(401);
            var ninthTicket = new Ticket(402);
            var tenthTicket = new Ticket(500);
            tickets.Add(firstTicket);
            tickets.Add(secondTicket);
            tickets.Add(thirdTicket);
            tickets.Add(fourthTicket);
            tickets.Add(fifthTicket);
            tickets.Add(sixthTicket);
            tickets.Add(seventhTicket);
            tickets.Add(eighthTicket);
            tickets.Add(ninthTicket);
            tickets.Add(tenthTicket);
            return tickets;
        }
    }
    public List<Flight> FixtureFlights
    {
        get
        {
            var firstFlight = new Flight(1, "Kurumoch", "Astana", new DateTime(2023, 8, 28), new DateTime(2023, 8, 29));
            var secondFlight = new Flight(2, "Astana", "Kurumoch", new DateTime(2023, 10, 17), new DateTime(2023, 10, 18));
            var thirdFlight = new Flight(3, "Kurumoch", "Sochi", new DateTime(2023, 8, 28), new DateTime(2023, 8, 28));
            var fourthFlight = new Flight(4, "Los Angeles", "Tokyo", new DateTime(2023, 10, 2), new DateTime(2023, 10, 3));
            var fifthFlight = new Flight(5, "Chiko", "Kem", new DateTime(2023, 6, 6), new DateTime(2023, 6, 7));

            var firstTicket = new Ticket(100);
            var secondTicket = new Ticket(101);
            firstFlight.Tickets.Add(firstTicket);
            firstFlight.Tickets.Add(secondTicket);

            var thirdTicket = new Ticket(200);
            var fourthTicket = new Ticket(201);
            var fifthTicket = new Ticket(202);
            secondFlight.Tickets.Add(thirdTicket);
            secondFlight.Tickets.Add(fourthTicket);
            secondFlight.Tickets.Add(fifthTicket);

            var sixthTicket = new Ticket(300);
            thirdFlight.Tickets.Add(sixthTicket);

            var seventhTicket = new Ticket(400);
            var eighthTicket = new Ticket(401);
            var ninthTicket = new Ticket(402);
            fourthFlight.Tickets.Add(seventhTicket);
            fourthFlight.Tickets.Add(eighthTicket);
            fourthFlight.Tickets.Add(ninthTicket);

            var tenthTicket = new Ticket(500);
            fifthFlight.Tickets.Add(tenthTicket);

            var flights = new List<Flight>
            {
                firstFlight,
                secondFlight,
                thirdFlight,
                fourthFlight,
                fifthFlight
            };
            return flights;
        }
    }

    public List<Client> FixtureClient
    {
        get
        {
            var firstTicket = new Ticket(100);
            var secondTicket = new Ticket(101);

            var thirdTicket = new Ticket(200);
            var fourthTicket = new Ticket(201);
            var fifthTicket = new Ticket(202);

            var sixthTicket = new Ticket(300);

            var seventhTicket = new Ticket(400);
            var eighthTicket = new Ticket(401);
            var ninthTicket = new Ticket(402);

            var tenthTicket = new Ticket(500);

            var firstClient = new Client(738096, new DateTime(1969, 8, 15), "Samoylov A. K.");
            firstClient.Tickets.Add(firstTicket);

            var secondClient = new Client(258204, new DateTime(2002, 6, 4), "Shestakov N. D.");
            secondClient.Tickets.Add(secondTicket);
            secondClient.Tickets.Add(thirdTicket);

            var thirdClient = new Client(211702, new DateTime(1984, 10, 28), "Fomina M. D.");
            thirdClient.Tickets.Add(fourthTicket);

            var fourthClient = new Client(783469, new DateTime(1978, 10, 17), "Novikov Y. M.");
            fourthClient.Tickets.Add(fifthTicket);

            var fifthClient = new Client(481761, new DateTime(2013, 12, 7), "Myasnikov S. I.");
            fifthClient.Tickets.Add(sixthTicket);
            fifthClient.Tickets.Add(tenthTicket);

            var sixthClient = new Client(154590, new DateTime(1993, 3, 21), "Kapustina D. F.");
            sixthClient.Tickets.Add(seventhTicket);

            var seventhClient = new Client(303386, new DateTime(2013, 4, 3), "Panfilova K. T.");
            seventhClient.Tickets.Add(eighthTicket);

            var eighthClient = new Client(240348, new DateTime(1966, 8, 17), "Birukov D. M.");
            eighthClient.Tickets.Add(ninthTicket);


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
            return client;
        }
    }
}