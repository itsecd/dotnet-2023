using Airlines.Domain;

namespace Airlines.Server.Repository;

/// <summary>
/// Class to store a Airlines data base
/// </summary>
public class AirlinesRepository : IAirlinesRepository
{
    private readonly List<AirplaneClass> _airplanes;
    private readonly List<TicketClass> _tickets;
    private readonly List<FlightCLass> _flights;
    private readonly List<PassengerClass> _passengers;
    public AirlinesRepository()
    {
        var firstPassenger = new PassengerClass("1234", "Paul Johnson") { Id = 1 };
        var secondPassenger = new PassengerClass("1235", "Sandra Cole") { Id = 2 };
        var thirdPassenger = new PassengerClass("1236", "Jack Spours") { Id = 3 };
        var fourthPassenger = new PassengerClass("1237", "Mike McKay") { Id = 4 };
        var fifthPassenger = new PassengerClass("1237", "Mike Tyson") { Id = 5 };
        var sixthPassenger = new PassengerClass("1237", "Maria Dowson") { Id = 6 };
        var seventhPassenger = new PassengerClass("1237", "Jim Hopkins") { Id = 7 };
        var passengers = new List<PassengerClass>
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
        var firstFlight = new FlightCLass(1, "A1", "Moscow", "Samara", firstDate, firstDate, firstDuration, "Passenger");
        var secondFlight = new FlightCLass(2, "A2", "Moscow", "Kazan", firstDate, firstDate, firstDuration, "Passenger");
        var thirdFlight = new FlightCLass(3, "A3", "Samara", "Kazan", secondDate, secondDate, secondDuration, "Cargo");
        var fourthFlight = new FlightCLass(4, "A4", "Kazan", "Samara", secondDate, secondDate, thirdDuration, "Cargo");
        var fifthFlight = new FlightCLass(5, "A5", "Kazan", "Samara", firstDate, firstDate, fourthDuration, "Cargo");
        var sixthFlight = new FlightCLass(6, "A6", "Kazan", "Samara", firstDate, firstDate, fifthDuration, "Cargo");
        var seventhFlight = new FlightCLass(7, "A7", "Kazan", "Samara", firstDate, firstDate, sixthDuration, "Cargo");
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
        var tickets = new List<TicketClass>();
        for (var i = 0; i < 10; i++)
        {
            var firstTicket = new TicketClass(i, "A" + i, i) { Id = i };
            tickets.Add(firstTicket);
            firstPassenger.Tickets.Add(firstTicket);
            firstFlight.Tickets.Add(firstTicket);
            var secondTicket = new TicketClass(i + 10, "A" + i + 10, i + 10) { Id = i + 10 };
            tickets.Add(secondTicket);
            secondFlight.Tickets.Add(secondTicket);
            secondPassenger.Tickets.Add(secondTicket);
            if (i % 2 == 0)
            {
                var thirdTicket = new TicketClass(i + 20, "A" + i + 20, i + 20) { Id = i + 20 };
                tickets.Add(thirdTicket);
                thirdPassenger.Tickets.Add(thirdTicket);
                thirdFlight.Tickets.Add(thirdTicket);
                thirdPassenger.Tickets.Add(thirdTicket);
                var fourthTicket = new TicketClass(i + 30, "A" + i + 30, i + 30) { Id = i + 30 };
                tickets.Add(fourthTicket);
                fourthFlight.Tickets.Add(fourthTicket);
                fourthPassenger.Tickets.Add(fourthTicket);
                fourthPassenger.Tickets.Add(fourthTicket);
            }
            if (i > 6)
            {
                var fifthTicket = new TicketClass(i + 20, "A" + i + 20, i + 20) { Id = i + 40 };
                tickets.Add(fifthTicket);
                fifthFlight.Tickets.Add(fifthTicket);
                fifthPassenger.Tickets.Add(fifthTicket);
                var sixthTicket = new TicketClass(i + 30, "A" + i + 30, i + 30) { Id = i + 50 };
                tickets.Add(sixthTicket);
                sixthFlight.Tickets.Add(sixthTicket);
                sixthPassenger.Tickets.Add(sixthTicket);
                var seventhTicket = new TicketClass(i + 20, "A" + i + 20, i + 20) { Id = i + 60 };
                tickets.Add(seventhTicket);
                seventhFlight.Tickets.Add(seventhTicket);
                seventhPassenger.Tickets.Add(seventhTicket);
            }
        }
        var firstAirplane = new AirplaneClass() { Id = 1, Model = "Boeing 777", SeatingCapacity = 100, Capability = 6200, CarryingCapacity = 100 };
        firstAirplane.Flights.Add(firstFlight);
        firstAirplane.Flights.Add(secondFlight);
        var secondAirplane = new AirplaneClass() { Id = 2, Model = "Boeing 767", SeatingCapacity = 110, Capability = 6200, CarryingCapacity = 110 };
        secondAirplane.Flights.Add(thirdFlight);
        secondAirplane.Flights.Add(fourthFlight);
        var thirdAirplane = new AirplaneClass() { Id = 3, Model = "Boeing 747", SeatingCapacity = 120, Capability = 6200, CarryingCapacity = 120 };
        thirdAirplane.Flights.Add(fifthFlight);
        thirdAirplane.Flights.Add(sixthFlight);
        var fourthAirplane = new AirplaneClass() { Id = 4, Model = "Boeing 737", SeatingCapacity = 130, Capability = 6200, CarryingCapacity = 130 };
        fourthAirplane.Flights.Add(seventhFlight);
        var airplanes = new List<AirplaneClass>
        {
            firstAirplane, secondAirplane, thirdAirplane,fourthAirplane
        };

        _airplanes = airplanes;
        _tickets = tickets;
        _flights = flights;
        _passengers = passengers;
    }
    public List<TicketClass> Tickets => _tickets;
    public List<FlightCLass> Flights => _flights;
    public List<PassengerClass> Passengers => _passengers;
    public List<AirplaneClass> Airplanes => _airplanes;
}