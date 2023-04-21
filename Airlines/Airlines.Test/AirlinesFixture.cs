namespace Airlines.Test;

using Airlines.Domain;

public class AirlinesFixture
{
    private readonly List<Airplane> _airplanes;
    private readonly List<Ticket> _tickets;
    private readonly List<Flight> _flights;
    private readonly List<Passenger> _passengers;
    public AirlinesFixture()
    {
        var firstPassenger = new Passenger("1234", "Paul Johnson") { Id = 1 };
        var secondPassenger = new Passenger("1235", "Sandra Cole") { Id = 2 };
        var thirdPassenger = new Passenger("1236", "Jack Spours") { Id = 3 };
        var fourthPassenger = new Passenger("1237", "Mike McKay") { Id = 4 };
        var fifthPassenger = new Passenger("1237", "Mike Tyson") { Id = 5 };
        var sixthPassenger = new Passenger("1237", "Maria Dowson") { Id = 6 };
        var seventhPassenger = new Passenger("1237", "Jim Hopkins") { Id = 7 };
        var passengers = new List<Passenger>
            {
                firstPassenger,
                secondPassenger,
                thirdPassenger,
                fourthPassenger,
                fifthPassenger,
                sixthPassenger,
                seventhPassenger

            };


        var firstDate = new DateTime(2023, 1, 1);
        var secondDate = new DateTime(2023, 3, 3);
        var firstDuration = 1.5;
        var secondDuration = 1.1;
        var thirdDuration = 1;
        var fourthDuration = 2;
        var fifthDuration = 1.25;
        var sixthDuration = 3;
        var firstFlight = new Flight(1, "A1", "Moscow", "Samara", firstDate, firstDate, firstDuration, "Passenger");
        var secondFlight = new Flight(2, "A2", "Moscow", "Kazan", firstDate, firstDate, firstDuration, "Passenger");
        var thirdFlight = new Flight(3, "A3", "Samara", "Kazan", secondDate, secondDate, secondDuration, "Cargo");
        var fourthFlight = new Flight(4, "A4", "Kazan", "Samara", secondDate, secondDate, thirdDuration, "Cargo");
        var fifthFlight = new Flight(5, "A5", "Kazan", "Samara", firstDate, firstDate, fourthDuration, "Cargo");
        var sixthFlight = new Flight(6, "A6", "Kazan", "Samara", firstDate, firstDate, fifthDuration, "Cargo");
        var seventhFlight = new Flight(7, "A7", "Kazan", "Samara", firstDate, firstDate, sixthDuration, "Cargo");
        var flights = new List<Flight>
            {
                firstFlight,
                secondFlight,
                thirdFlight,
                fourthFlight,
                fifthFlight,
                sixthFlight,
                seventhFlight
            };

        var tickets = new List<Ticket>();
        for (var i = 0; i < 10; i++)
        {
            var firstTicket = new Ticket(i, "A" + i, i) { Id = i };
            tickets.Add(firstTicket);
            firstPassenger.Tickets.Add(firstTicket);
            firstFlight.Tickets.Add(firstTicket);
            var secondTicket = new Ticket(i + 10, "A" + i + 10, i + 10) { Id = i + 10 };
            tickets.Add(secondTicket);
            secondFlight.Tickets.Add(secondTicket);
            secondPassenger.Tickets.Add(secondTicket);
            if (i % 2 == 0)
            {
                var thirdTicket = new Ticket(i + 20, "A" + i + 20, i + 20) { Id = i + 20 };
                tickets.Add(thirdTicket);
                thirdPassenger.Tickets.Add(thirdTicket);
                thirdFlight.Tickets.Add(thirdTicket);
                thirdPassenger.Tickets.Add(thirdTicket);
                var fourthTicket = new Ticket(i + 30, "A" + i + 30, i + 30) { Id = i + 30 };
                tickets.Add(fourthTicket);
                fourthFlight.Tickets.Add(fourthTicket);
                fourthPassenger.Tickets.Add(fourthTicket);
                fourthPassenger.Tickets.Add(fourthTicket);
            }
            if (i > 6)
            {
                var fifthTicket = new Ticket(i + 20, "A" + i + 20, i + 20) { Id = i + 40 };
                tickets.Add(fifthTicket);
                fifthFlight.Tickets.Add(fifthTicket);
                fifthPassenger.Tickets.Add(fifthTicket);
                var sixthTicket = new Ticket(i + 30, "A" + i + 30, i + 30) { Id = i + 50 };
                tickets.Add(sixthTicket);
                sixthFlight.Tickets.Add(sixthTicket);
                sixthPassenger.Tickets.Add(sixthTicket);
                var seventhTicket = new Ticket(i + 20, "A" + i + 20, i + 20) { Id = i + 60 };
                tickets.Add(seventhTicket);
                seventhFlight.Tickets.Add(seventhTicket);
                seventhPassenger.Tickets.Add(seventhTicket);
            }
        }
        var firstAirplane = new Airplane() { Id = 1, Model = "Boeing 777", SeatingCapacity = 100, Capability = 6200, CarryingCapacity = 100 };
        firstAirplane.Flights.Add(firstFlight);
        firstAirplane.Flights.Add(secondFlight);
        var secondAirplane = new Airplane() { Id = 2, Model = "Boeing 767", SeatingCapacity = 110, Capability = 6200, CarryingCapacity = 110 };
        secondAirplane.Flights.Add(thirdFlight);
        secondAirplane.Flights.Add(fourthFlight);
        var thirdAirplane = new Airplane() { Id = 3, Model = "Boeing 747", SeatingCapacity = 120, Capability = 6200, CarryingCapacity = 120 };
        thirdAirplane.Flights.Add(fifthFlight);
        thirdAirplane.Flights.Add(sixthFlight);
        var fourthAirplane = new Airplane() { Id = 4, Model = "Boeing 737", SeatingCapacity = 130, Capability = 6200, CarryingCapacity = 130 };
        fourthAirplane.Flights.Add(seventhFlight);
        var airplanes = new List<Airplane>
        {
            firstAirplane, secondAirplane, thirdAirplane,fourthAirplane
        };

        _airplanes = airplanes;
        _tickets = tickets;
        _flights = flights;
        _passengers = passengers;
    }
    public List<Ticket> Tickets => _tickets;
    public List<Flight> Flights => _flights;
    public List<Passenger> Passengers => _passengers;
    public List<Airplane> Airplanes => _airplanes;
}