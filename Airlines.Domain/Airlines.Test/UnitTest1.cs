using Airlines.Domain;

namespace Airplane.Test;
using System.Linq;
using System.Security.Cryptography;

public class ClassesTest
{
    [Fact]
    public void FirstRequest()
    {
        var date_1 = new DateOnly(2023, 1, 1);
        var duration_1 = 50;
        var flight_1 = new FlightCLass(1, "A1", "Moscow", "Samara", date_1, date_1, duration_1, "Passenger");
        var flight_2 = new FlightCLass(2, "A2", "Moscow", "Kazan", date_1, date_1, duration_1, "Passenger");
        var flights = new List<FlightCLass>
        {
            flight_1,
            flight_2
        };
        var request = (from flight in flights
                       where (flight.Source == "Moscow") && (flight.Destination == "Kazan")
                       select flight).Count();
        Assert.Equal(1, request);
    }
    [Fact]
    public void SecondRequest()
    {
        var ticket_1 = new TicketClass(100, "1A", 0);
        var ticket_2 = new TicketClass(101, "2A", 5);
        var ticket_3 = new TicketClass(102, "3A", 5);
        var ticket_4 = new TicketClass(103, "4A", 5);
        var passenger_1 = new PassengerClass(1234,"Paul Johnson");
        passenger_1.Tickets.Add(ticket_1);
        var passenger_2= new PassengerClass(1235, "Sandra Cole");
        passenger_2.Tickets.Add(ticket_2);
        var passenger_3 = new PassengerClass(1236, "Jack Spours");
        passenger_3.Tickets.Add(ticket_3);
        var passenger_4 = new PassengerClass(1237, "Mike McKay");
        passenger_4.Tickets.Add(ticket_4);
        var date_1 = new DateOnly(2023, 1, 1);
        var duration_1 = 50;
        var flight_1 = new FlightCLass(1, "A1", "Moscow", "Samara", date_1, date_1, duration_1, "Passenger");
        flight_1.Tickets.Add(ticket_1);
        flight_1.Tickets.Add(ticket_2);
        var flight_2 = new FlightCLass(2, "A2", "Moscow", "Kazan", date_1, date_1, duration_1, "Passenger");
        flight_2.Tickets.Add(ticket_3);
        flight_2.Tickets.Add(ticket_4);
        var airplane_1 = new AirplaneClass("Boing", 9, 4000, 162);
        airplane_1.Flights.Add(flight_1);
        airplane_1.Flights.Add(flight_2);
        var flights = new List<FlightCLass>
        {
            flight_1,
            flight_2
        };
        var passengers = new List<PassengerClass>
        {
            passenger_1,
            passenger_2,
            passenger_3,
            passenger_4
        };
        var tickets = new List<TicketClass>
        { 
            ticket_1,
            ticket_2,
            ticket_3,
            ticket_4
        };
        var request = (from flight in flights
                       from ticket in flight.Tickets
                       from passenger in passengers
                       from t in passenger.Tickets 
                       where (flight.Number == 1) && (ticket.BaggageWeight == 0) && (t.TicketNumber == ticket.TicketNumber)
                       select passenger).Count();
        Assert.Equal(1, request);
    }
    [Fact]
    public void ThirdRequest()
    {
        var date_1 = new DateOnly(2023, 1, 1);
        var duration_1 =50;
        var date_2 = new DateOnly(2023, 2, 1);
        var date_3 = new DateOnly(2023, 3, 1);
        var date_4 = new DateOnly(2023, 4, 1);
        var flight_1 = new FlightCLass(1, "A1", "Moscow", "Samara", date_1, date_1, duration_1, "Passenger");
        var flight_2 = new FlightCLass(2, "A2", "Moscow", "Kazan", date_2, date_2, duration_1, "Passenger");
        var flight_3 = new FlightCLass(3, "A3", "Samara", "Kazan", date_3, date_3, duration_1, "Cargo");
        var flight_4 = new FlightCLass(4, "A4", "Kazan", "Samara", date_4, date_4, duration_1, "Cargo");
        var flights = new List<FlightCLass>
        {
            flight_1,
            flight_2,
            flight_3,
            flight_4
        };
        var comp_date = new DateOnly(2023, 3, 2);
        var request = (from flight in flights
                       where (flight.AirplaneType == "Cargo") && (flight.DepartureDate.CompareTo(comp_date) >0)
                       select flight).Count();
        Assert.Equal(1, request);
    }
    [Fact]
    public void FourthRequest()
    {
        var date_1 = new DateOnly(2023, 1, 1);
        var duration_1 = 50;
        var date_2 = new DateOnly(2023, 2, 1);
        var date_3 = new DateOnly(2023, 3, 1);
        var date_4 = new DateOnly(2023, 4, 1);
        var flight_1 = new FlightCLass(1, "A1", "Moscow", "Samara", date_1, date_1, duration_1, "Passenger");
        var flight_2 = new FlightCLass(2, "A2", "Moscow", "Kazan", date_2, date_2, duration_1, "Passenger");
        var flight_3 = new FlightCLass(3, "A3", "Samara", "Kazan", date_3, date_3, duration_1, "Cargo");
        var flight_4 = new FlightCLass(4, "A4", "Kazan", "Samara", date_4, date_4, duration_1, "Cargo");
        var flight_5 = new FlightCLass(5, "A5", "Kazan", "Samara", date_4, date_4, duration_1, "Cargo");
        var flight_6 = new FlightCLass(6, "A6", "Kazan", "Samara", date_4, date_4, duration_1, "Cargo");
        var flight_7 = new FlightCLass(7, "A7", "Kazan", "Samara", date_4, date_4, duration_1, "Cargo");
        for (var i = 0; i < 10; i++)
        {
            var temp_1 = new TicketClass(i, "A"+i, i);
            flight_1.Tickets.Add(temp_1);
            var temp_2 = new TicketClass(i+10, "A" + i+10, i+10);
            flight_2.Tickets.Add(temp_2);
            if (i % 2 == 0)
            {
                var temp_3 = new TicketClass(i+20, "A" + i+20, i+20);
                flight_3.Tickets.Add(temp_3);
                var temp_4 = new TicketClass(i + 30, "A" + i + 30, i + 30);
                flight_4.Tickets.Add(temp_4);
            }
            if (i > 6)
            {
                var temp_5 = new TicketClass(i + 20, "A" + i + 20, i + 20);
                flight_5.Tickets.Add(temp_5);
                var temp_6 = new TicketClass(i + 30, "A" + i + 30, i + 30);
                flight_6.Tickets.Add(temp_6);
                var temp_7 = new TicketClass(i + 20, "A" + i + 20, i + 20);
                flight_7.Tickets.Add(temp_7);
            }
        }
        var flights = new List<FlightCLass>
        {
            flight_1,
            flight_2,
            flight_3,
            flight_4,
            flight_5,
            flight_6,
            flight_7
        };
        var request = (from flight in flights
                       where flight != null
                        select flight.Tickets.Count).Take(5).Count();
        Assert.Equal(5, request);
    }
    [Fact]
    public void FifthRequest()
    { 
    var date_1 = new DateOnly(2023, 1, 1);
    var duration_1 = 50;
    var duration_2 = 90;
    var duration_3 = 60;
    var duration_4 = 70;
    var duration_5 = 80;
    var duration_6 = 120;
    var flight_1 = new FlightCLass(1, "A1", "Moscow", "Samara", date_1, date_1, duration_1, "Passenger");
    var flight_2 = new FlightCLass(2, "A2", "Moscow", "Kazan", date_1, date_1, duration_1, "Passenger");
    var flight_3 = new FlightCLass(3, "A3", "Samara", "Kazan", date_1, date_1, duration_2, "Cargo");
    var flight_4 = new FlightCLass(4, "A4", "Kazan", "Samara", date_1, date_1, duration_3, "Cargo");
    var flight_5 = new FlightCLass(5, "A5", "Kazan", "Samara", date_1, date_1, duration_4, "Cargo");
    var flight_6 = new FlightCLass(6, "A6", "Kazan", "Samara", date_1, date_1, duration_5, "Cargo");
    var flight_7 = new FlightCLass(7, "A7", "Kazan", "Samara", date_1, date_1, duration_6, "Cargo");
    var flights = new List<FlightCLass>
    {
        flight_1,
        flight_2,
        flight_3,
        flight_4,
        flight_5,
        flight_6,
        flight_7
    };
        var request = (from flight in flights
                      where flight.FlightDuration.CompareTo( (from fli in flights
                                                            orderby fli.FlightDuration ascending
                                                            select fli.FlightDuration).Take(1).First()) == 0
                      select flight.Number).Count();
        Assert.Equal(2, request);
    }

}