namespace Airlines.Test;

using Airlines.Domain;

public class AirlinesFixture
{
    public List<TicketClass> FixtureTickets
    {
        get
        {
            var tickets = new List<TicketClass>();
            for (var i = 0; i < 10; i++)
            {
                var firstTicket = new TicketClass(i, "A" + i, i);
                tickets.Add(firstTicket);
                var secondTicket = new TicketClass(i + 10, "A" + i + 10, i + 10);
                tickets.Add(secondTicket);
                if (i % 2 == 0)
                {
                    var thirdTicket = new TicketClass(i + 20, "A" + i + 20, i + 20);
                    tickets.Add(thirdTicket);
                    var fourthTicket = new TicketClass(i + 30, "A" + i + 30, i + 30);
                    tickets.Add(fourthTicket);
                }
                if (i > 6)
                {
                    var fifthTicket = new TicketClass(i + 20, "A" + i + 20, i + 20);
                    tickets.Add(fifthTicket);
                    var sixthTicket = new TicketClass(i + 30, "A" + i + 30, i + 30);
                    tickets.Add(sixthTicket);
                    var seventhTicket = new TicketClass(i + 20, "A" + i + 20, i + 20);
                    tickets.Add(seventhTicket);
                }
            }
            return tickets;
        }
    }
    public List<FlightCLass> FixtureFlights
    {
        get
        {
            var firstDate = new DateOnly(2023, 1, 1);
            var secondDate = new DateOnly(2023, 3, 3);
            var firstDuration = 1.5;
            var secondDuration = 1.1;
            var thirdDuration = 1;
            var fourthDuration = 2;
            var fifthDuration = 1.25;
            var sixthDuration = 3;
            var firstFlight = new FlightCLass(1, "A1", "Moscow", "Samara", firstDate, firstDate, firstDuration, "Passenger");
            var secondFlight = new FlightCLass(2, "A2", "Moscow", "Kazan", firstDate, firstDate, firstDuration, "Passenger");
            var thirdFlight = new FlightCLass(3, "A3", "Samara", "Kazan", secondDate, secondDate, secondDuration, "Cargo");
            var fourthFlight = new FlightCLass(4, "A4", "Kazan", "Samara", secondDate, secondDate, thirdDuration, "Cargo");
            var fifthFlight = new FlightCLass(5, "A5", "Kazan", "Samara", firstDate, firstDate, fourthDuration, "Cargo");
            var sixthFlight = new FlightCLass(6, "A6", "Kazan", "Samara", firstDate, firstDate, fifthDuration, "Cargo");
            var seventhFlight = new FlightCLass(7, "A7", "Kazan", "Samara", firstDate, firstDate, sixthDuration, "Cargo");
            for (var i = 0; i < 10; i++)
            {
                var firstTicket = new TicketClass(i, "A" + i, i);
                firstFlight.Tickets.Add(firstTicket);
                var secondTicket = new TicketClass(i + 10, "A" + i + 10, i + 10);
                secondFlight.Tickets.Add(secondTicket);
                if (i % 2 == 0)
                {
                    var thirdTicket = new TicketClass(i + 20, "A" + i + 20, i + 20);
                    thirdFlight.Tickets.Add(thirdTicket);
                    var fourthTicket = new TicketClass(i + 30, "A" + i + 30, i + 30);
                    fourthFlight.Tickets.Add(fourthTicket);
                }
                if (i > 6)
                {
                    var fifthTicket = new TicketClass(i + 20, "A" + i + 20, i + 20);
                    fifthFlight.Tickets.Add(fifthTicket);
                    var sixthTicket = new TicketClass(i + 30, "A" + i + 30, i + 30);
                    sixthFlight.Tickets.Add(sixthTicket);
                    var seventhTicket = new TicketClass(i + 20, "A" + i + 20, i + 20);
                    seventhFlight.Tickets.Add(seventhTicket);
                }
            }
            var flights = new List<FlightCLass>
            {
                firstFlight,
                secondFlight,
                thirdFlight,
                fourthFlight,
                fifthFlight,
                sixthFlight,
                seventhFlight
            };
            return flights;
        }
    }
    public List<PassengerClass> FixturePassengers
    {
        get
        {
            var firstTicket = new TicketClass(0, "0A", 0);
            var secondTicket = new TicketClass(101, "2A", 5);
            var thirdTicket = new TicketClass(102, "3A", 5);
            var fourthTicket = new TicketClass(103, "4A", 5);
            var firstPassenger = new PassengerClass(1234, "Paul Johnson");
            firstPassenger.Tickets.Add(firstTicket);
            var secondPassenger = new PassengerClass(1235, "Sandra Cole");
            secondPassenger.Tickets.Add(secondTicket);
            var thirdPassenger = new PassengerClass(1236, "Jack Spours");
            thirdPassenger.Tickets.Add(thirdTicket);
            var fourthPassenger = new PassengerClass(1237, "Mike McKay");
            fourthPassenger.Tickets.Add(fourthTicket);
            var passengers = new List<PassengerClass>
            {
                firstPassenger,
                secondPassenger,
                thirdPassenger,
                fourthPassenger
            };
            return passengers;
        }
    }
}