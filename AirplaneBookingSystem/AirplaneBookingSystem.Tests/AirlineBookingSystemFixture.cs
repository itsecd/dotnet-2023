namespace AirplaneBookingSystem.Tests;

using AirplaneBookingSystem.Model;

public class AirlineBookingSystemFixture
{
    public List<Client> FixtureClient
    {
        get
        {
            var firstAirplane = new Airplane(500, "Boing-717");
            var secondAirplane = new Airplane(562, "Boing-777");
            var thirdAirplane = new Airplane(554, "ATR 42/72");
            var fourthAirplane = new Airplane(571, "Embraer ERJ");

            var firstFlight = new Flight(1, 1, "Kurumoch", "Astana", new DateTime(2023, 8, 28), new DateTime(2023, 8, 29), firstAirplane);
            var secondFlight = new Flight(2, 2, "Astana", "Kurumoch", new DateTime(2023, 10, 17), new DateTime(2023, 10, 18), secondAirplane);
            var thirdFlight = new Flight(3, 3, "Kurumoch", "Sochi", new DateTime(2023, 8, 28), new DateTime(2023, 8, 28), thirdAirplane);
            var fourthFlight = new Flight(4, 4, "Los Angeles", "Tokyo", new DateTime(2023, 10, 2), new DateTime(2023, 10, 3), fourthAirplane);
            var fifthFlight = new Flight(5, 5, "Chiko", "Kem", new DateTime(2023, 6, 6), new DateTime(2023, 6, 7), fourthAirplane);

            var firstClient = new Client(1, "738096", new DateTime(1969, 8, 15), "Samoylov A. K.");
            firstClient.Tickets.Add(new Ticket(1, 100, firstClient, firstFlight));
            firstFlight.Tickets.Add(new Ticket(1, 100, firstClient, firstFlight));

            var secondClient = new Client(2, "258204", new DateTime(2002, 6, 4), "Shestakov N. D.");
            secondClient.Tickets.Add(new Ticket(2, 101, secondClient, firstFlight));
            secondClient.Tickets.Add(new Ticket(3, 200, secondClient, secondFlight));
            firstFlight.Tickets.Add(new Ticket(2, 101, secondClient, firstFlight));
            secondFlight.Tickets.Add(new Ticket(3, 200, secondClient, secondFlight));

            var thirdClient = new Client(3, "211702", new DateTime(1984, 10, 28), "Fomina M. D.");
            thirdClient.Tickets.Add(new Ticket(4, 01, thirdClient, secondFlight));
            secondFlight.Tickets.Add(new Ticket(4, 201, thirdClient, secondFlight));

            var fourthClient = new Client(4, "783469", new DateTime(1978, 10, 17), "Novikov Y. M.");
            fourthClient.Tickets.Add(new Ticket(5, 202, fourthClient, secondFlight));
            secondFlight.Tickets.Add(new Ticket(5, 202, fourthClient, secondFlight));

            var fifthClient = new Client(5, "481761", new DateTime(2013, 12, 7), "Myasnikov S. I.");
            fifthClient.Tickets.Add(new Ticket(6, 300, fifthClient, thirdFlight));
            fifthClient.Tickets.Add(new Ticket(7, 500, fifthClient, fifthFlight));
            thirdFlight.Tickets.Add(new Ticket(6, 300, fifthClient, thirdFlight));
            fifthFlight.Tickets.Add(new Ticket(7, 500, fifthClient, fifthFlight));

            var sixthClient = new Client(6, "154590", new DateTime(1993, 3, 21), "Kapustina D. F.");
            sixthClient.Tickets.Add(new Ticket(8, 400, sixthClient, fourthFlight));
            fourthFlight.Tickets.Add(new Ticket(8, 400, sixthClient, fourthFlight));

            var seventhClient = new Client(7, "303386", new DateTime(2013, 4, 3), "Panfilova K. T.");
            seventhClient.Tickets.Add(new Ticket(9, 401, seventhClient, fourthFlight));
            fourthFlight.Tickets.Add(new Ticket(9, 401, seventhClient, fourthFlight));

            var eighthClient = new Client(8, "240348", new DateTime(1966, 8, 17), "Birukov D. M.");
            eighthClient.Tickets.Add(new Ticket(10, 402, eighthClient, fourthFlight));
            fourthFlight.Tickets.Add(new Ticket(10, 402, eighthClient, fourthFlight));

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