namespace AirplaneBookingSystem.Tests;

using AirplaneBookingSystem.Domain;

public class AirlineBookingSystemFixture
{
    public List<Client> FixtureClient
    {
        get
        {
            var firstFlight = new Flight(1, "Kurumoch", "Astana", new DateTime(2023, 8, 28), new DateTime(2023, 8, 29));
            var secondFlight = new Flight(2, "Astana", "Kurumoch", new DateTime(2023, 10, 17), new DateTime(2023, 10, 18));
            var thirdFlight = new Flight(3, "Kurumoch", "Sochi", new DateTime(2023, 8, 28), new DateTime(2023, 8, 28));
            var fourthFlight = new Flight(4, "Los Angeles", "Tokyo", new DateTime(2023, 10, 2), new DateTime(2023, 10, 3));
            var fifthFlight = new Flight(5, "Chiko", "Kem", new DateTime(2023, 6, 6), new DateTime(2023, 6, 7));

            var firstClient = new Client(738096, new DateTime(1969, 8, 15), "Samoylov A. K.");
            firstClient.Tickets.Add(new Ticket(100, firstClient, firstFlight));
            firstFlight.Tickets.Add(new Ticket(100, firstClient, firstFlight));

            var secondClient = new Client(258204, new DateTime(2002, 6, 4), "Shestakov N. D.");
            secondClient.Tickets.Add(new Ticket(101, secondClient, firstFlight));
            secondClient.Tickets.Add(new Ticket(200, secondClient, secondFlight));
            firstFlight.Tickets.Add(new Ticket(101, secondClient, firstFlight));
            secondFlight.Tickets.Add(new Ticket(200, secondClient, secondFlight));

            var thirdClient = new Client(211702, new DateTime(1984, 10, 28), "Fomina M. D.");
            thirdClient.Tickets.Add(new Ticket(201, thirdClient, secondFlight));
            secondFlight.Tickets.Add(new Ticket(201, thirdClient, secondFlight));

            var fourthClient = new Client(783469, new DateTime(1978, 10, 17), "Novikov Y. M.");
            fourthClient.Tickets.Add(new Ticket(202, fourthClient, secondFlight));
            secondFlight.Tickets.Add(new Ticket(202, fourthClient, secondFlight));

            var fifthClient = new Client(481761, new DateTime(2013, 12, 7), "Myasnikov S. I.");
            fifthClient.Tickets.Add(new Ticket(300, fifthClient, thirdFlight));
            fifthClient.Tickets.Add(new Ticket(500, fifthClient, fifthFlight));
            thirdFlight.Tickets.Add(new Ticket(300, fifthClient, thirdFlight));
            fifthFlight.Tickets.Add(new Ticket(500, fifthClient, fifthFlight));

            var sixthClient = new Client(154590, new DateTime(1993, 3, 21), "Kapustina D. F.");
            sixthClient.Tickets.Add(new Ticket(400, sixthClient, fourthFlight));
            fourthFlight.Tickets.Add(new Ticket(400, sixthClient, fourthFlight));

            var seventhClient = new Client(303386, new DateTime(2013, 4, 3), "Panfilova K. T.");
            seventhClient.Tickets.Add(new Ticket(401, seventhClient, fourthFlight));
            fourthFlight.Tickets.Add(new Ticket(401, seventhClient, fourthFlight));

            var eighthClient = new Client(240348, new DateTime(1966, 8, 17), "Birukov D. M.");
            eighthClient.Tickets.Add(new Ticket(402, eighthClient, fourthFlight));
            fourthFlight.Tickets.Add(new Ticket(402, eighthClient, fourthFlight));

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