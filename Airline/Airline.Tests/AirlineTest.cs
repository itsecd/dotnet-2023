using AirLine.Model;
using Org.BouncyCastle.Asn1.X509;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace AirlineModel.Tests;

public class AirlineTest
{
    /// <summary>
    /// Initializes standart list of Airplanes for test
    /// </summary>
    /// <returns>
    /// List containing 5 different Airplanes
    /// </returns>
    private List<Airplane> DefaultAirplanes()
    {
        return new List<Airplane>()
        {
            new Airplane(1, "Tu-134", 100, 50, 70),
            new Airplane(2, "Tu-154", 150, 60, 90),
            new Airplane(3, "SuperJet-100", 200, 90, 100),
            new Airplane(4, "Boeing-777", 400, 70, 235),
            new Airplane(5, "Boeing-747", 3500, 80, 320)
        };
    }

    /// <summary>
    /// Initializes standart list of flights for test
    /// </summary>
    /// <returns>
    /// List containing 3 different flights
    /// </returns>
    private List<Flight> DefaultFlights()
    {
        return new List<Flight>()
        {
            new Flight(1, "BD-1120", "Moscow", "Budapest", new DateTime(2022, 11, 20, 19, 00, 00), new DateTime(2022, 11, 20, 23, 30, 00)),
            new Flight(2, "CH-0510", "Pekin", "Samara", new DateTime(2022, 5, 10, 10, 00, 00), new DateTime(2022, 5, 10, 20, 05, 00)),
            new Flight(3, "CZ-0321", "Samara", "Praha", new DateTime(2020, 03, 21, 12, 30, 00), new DateTime(2020, 03, 21, 17, 20, 00)),
            new Flight(4, "BD-1122", "Samara", "Budapest", new DateTime(2023, 11, 22, 19, 00, 00), new DateTime(2023, 11, 22, 22, 30, 00)),
            new Flight(5, "TB-1130", "Praha", "Tambov", new DateTime(2021, 11, 30, 10, 00, 00), new DateTime(2021, 11, 30, 15, 30, 00)),
            new Flight(6, "SP-0314", "Samara", "Saint-Peterburg", new DateTime(2022, 03, 14, 19, 00, 00), new DateTime(2022, 03, 14, 20, 30, 00))
        };
    }

    /// <summary>
    /// Initializes standart list of passengers for test
    /// </summary>
    /// <returns>
    /// List containing 6 different passengers
    /// </returns>
    private List<Passenger> DefaultPassengers()
    {
        return new List<Passenger>()
        {
            new Passenger(1, 0001, "Petrovskaya Kira Viktorovna"),
            new Passenger(2, 0002, "Fedotov Saveliy Vladimirovich"),
            new Passenger(3, 0003, "Panov Timur Daniilovich"),
            new Passenger(4, 0004, "Karpova Daria Ivanovna"),
            new Passenger(5, 0005, "Eliseev Daniil Romanovich"),
            new Passenger(6, 0006, "Nikolaev David Alexandrovich")
        };
    }


    /// <summary>
    /// Initializes standart list of Ticket objects
    /// </summary>
    private List<Ticket> DefaultTickets()
    {
        return new List<Ticket>()
        {
            new Ticket(1, 1000, "5A", 7.5, 1),
            new Ticket(2, 1320, "2B", 7.5, 1),
            new Ticket(3, 1001, "5B", 2.3, 2),
            new Ticket(4, 1231, "7C", 2.3, 2),
            new Ticket(5, 1002, "10C", 0, 3),
            new Ticket(6, 1003, "7A", 0, 3),
            new Ticket(7, 1004, "13F", 5, 4),
            new Ticket(8, 1441, "5B", 5, 4),
            new Ticket(9, 1373, "6A", 5, 5),
            new Ticket(10, 1005, "9F", 1, 6)
        };
    }
   

    /// <summary>
    /// Initializes standart list of FlightAirplaneTicket objects
    /// </summary>
    private List<FlightAirplaneTicket> DefaultFlightAirplaneTickets()
    {
        return new List<FlightAirplaneTicket>()
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

    /// <summary>
    /// Create default airline with 5 airplanes, 3 flights, 6 passengers
    /// </summary>
    /// <returns>
    /// Filled airline object
    /// </returns>
    private Airline CreateDefaultAirline()
    {
        return new Airline(1, DefaultAirplanes(), DefaultFlights(), DefaultPassengers(), DefaultFlightAirplaneTickets(), DefaultTickets());
    }

    /// <summary>
    /// testing airplanes in airline
    /// </summary>
    [Fact]
    public void AirplaneTest()
    {
        Airline air = CreateDefaultAirline();
        List<Airplane> airplanes = air.Airplanes;
        Assert.Equal(5, airplanes.Count);
    }

    /// <summary>
    /// Product class constructor test
    /// </summary>
    [Fact]
    public void AirplaneConstructorTest()
    {
        var plane = new Airplane(1, "Tu-134", 100, 50, 70);
        Assert.Equal("Tu-134", plane.Model);
        Assert.Equal(100, plane.LoadCapacity);
        Assert.Equal(50, plane.Perfomance);
        Assert.Equal(70, plane.PassengerCapacity);
    }

    /// <summary>
    /// Ticket class constructor test
    /// </summary>
    [Fact]
    public void TicketConstructorCest()
    {
        var ticket = new Ticket(1, 1000, "5A", 7.5);
        Assert.Equal(1, ticket.Id);
        Assert.Equal(1000, ticket.Number);
        Assert.Equal("5A", ticket.SeatNumber);
        Assert.Equal(7.5, ticket.BaggageWeight);
    }

    /// <summary>
    /// Flight class constructor test
    /// </summary>
    [Fact]
    public void FlightConstructorTest()
    {
        var flight = new Flight(1, "BD-1120", "Moscow", "Budapest", new DateTime(2022, 11, 20, 19, 00, 00), new DateTime(2022, 11, 20, 23, 30, 00));
        Assert.Equal("BD-1120", flight.Cipher);
        Assert.Equal("Moscow", flight.DeparturePlace);
        Assert.Equal("Budapest", flight.Destination);
        Assert.Equal(new DateTime(2022, 11, 20, 19, 00, 00), flight.DepartureDate);
        Assert.Equal(new DateTime(2022, 11, 20, 23, 30, 00), flight.ArrivalDate);

    }

    /// <summary>
    /// Passenger class constructor test
    /// </summary>
    [Fact]
    public void PassengerConstructorTest()
    {
        var passenger = new Passenger(1, 0001, "Petrovskaya Kira Viktorovna");
        Assert.Equal(0001, passenger.PassportNumber);
        Assert.Equal("Petrovskaya Kira Viktorovna", passenger.Name);
    }


    /// <summary>
    /// Test task 1
    /// </summary>
    [Fact]
    public void AllFlightsWithSpecificPlaces()
    {
        Airline air = CreateDefaultAirline();
        var request = (from flight in air.Flights
                       where (flight.DeparturePlace == "Moscow") && (flight.Destination == "Budapest")
                       select flight).Count();
        Assert.Equal(1, request);
    }



    /// <summary>
    /// Test task 2
    /// </summary>
    [Fact]
    public void CountPassengersWithoutBaggage()
    {
        Airline air = CreateDefaultAirline();

        var request = (from flight in air.Flights
                       from passenger in air.Passengers
                       from ticket in air.Tickets
                       from FAT in air.FlightAirplaneTickets
                       where (flight.Cipher == "CH-0510") && (ticket.BaggageWeight == 0) && (FAT.TicketId == ticket.Id)
                       select passenger).Count();
        Assert.Equal(2, request);                     
    }


    /// <summary>
    /// Test task 3
    /// </summary>
    [Fact]
    public void FlightWithSpecificDate()
    {
        Airline air = CreateDefaultAirline();

        var first_date = new DateTime(2019, 5, 10, 00, 00, 00);
        var second_date = new DateTime(2024, 5, 11, 10, 00, 00);
        var plane = new Airplane(1, "Boeing-777", 400, 70, 235);
        var request = (from flight in air.Flights
                       where(flight.DepartureDate >= first_date) &&
                       (flight.DepartureDate <= second_date)
                       select flight).Count();
        Assert.Equal(1, request);
    }


    /// <summary>
    /// Test task 4
    /// </summary>
    [Fact]
    public void TopFiveFlights()
    {
         Airline air = CreateDefaultAirline();
         var request = (from flight in air.Flights
                        from ticket in air.Tickets
                        where flight != null
                        select air.Tickets.Count).Take(5).Count();
         Assert.Equal(5, request);      
    }


    /// <summary>
    /// Test task 5
    /// </summary>
    [Fact]
    public void FlightWithMinFlightTime()
    {
        Airline air = CreateDefaultAirline();
         var min_time = (from flight in air.Flights
                         orderby flight.FlightTime
                         select flight.FlightTime).Min();
         var request = (from flight in air.Flights
                        where flight.FlightTime == min_time
                        select flight.Cipher).Count();
         Assert.Equal(1, request);    
    }


    /// <summary>
    /// Test task 6
    /// </summary>
    [Fact]
    public void MaxAverageBaggageWeight()
    {
         Airline air = CreateDefaultAirline();
         var request = (from flight in air.Flights
                        from ticket in air.Tickets
                        where flight.DeparturePlace == "Moscow"
                        select ticket.BaggageWeight).ToList();
         var max = request.Max();
         var avg = request.Average();
         Assert.Equal(7.5, max);
         Assert.Equal(4.9, avg);   
    }
}
