using Xunit;
using AirlineClasses;
using System.Collections.Generic;
using System.Linq;
using System;

namespace AirlineClasses.Tests;

public class AirlineTest
{
    /// <summary>
    /// Initializes standart list of Airplanes for test
    /// </summary>
    /// <returns>
    /// List containing 5 different Airplanes
    /// </returns>
    private List<Airplane> Default_airplanes()
    {
        return new List<Airplane>()
        {
            new Airplane("Tu-134", 100, 50, 70),
            new Airplane("Tu-154", 150, 60, 90),
            new Airplane("SuperJet-100", 200, 90, 100),
            new Airplane("Boeing-777", 400, 70, 235),
            new Airplane("Boeing-747", 3500, 80, 320)
        };
    }

    /// <summary>
    /// Initializes standart list of flights for test
    /// </summary>
    /// <returns>
    /// List containing 3 different flights
    /// </returns>
    private List<Flight> Default_flights()
    {
        return new List<Flight>()
        {
            new Flight("BD-1120", "Moscow", "Budapest", new DateTime(2022, 11, 20, 19, 00, 00), new DateTime(2022, 11, 20, 23, 30, 00), new Airplane("Tu-134", 100, 50, 70), new List<Ticket>(){new Ticket(1000, "5A", 7.5), new Ticket(1320, "2B", 7.5), new Ticket(1001, "5B", 2.3), new Ticket(1231, "7C", 2.3)}),
            new Flight("CH-0510", "Pekin", "Samara", new DateTime(2022, 5, 10, 10, 00, 00), new DateTime(2022, 5, 10, 20, 05, 00), new Airplane("Tu-154", 150, 60, 90), new List<Ticket>(){new Ticket(1002, "10C", 0), new Ticket(1003, "7A", 0)}),
            new Flight("CZ-0321", "Samara", "Praha", new DateTime(2020, 03, 21, 12, 30, 00), new DateTime(2020, 03, 21, 17, 20, 00), new Airplane("Boeing-777", 400, 70, 235), new List<Ticket>(){new Ticket(1004, "13F", 5), new Ticket(1441, "5B", 5), new Ticket(1373, "6A", 5), new Ticket(1005, "9F", 1)}),
            new Flight("BD-1122", "Samara", "Budapest", new DateTime(2023, 11, 22, 19, 00, 00), new DateTime(2023, 11, 22, 22, 30, 00), new Airplane("Tu-134", 100, 50, 70), new List<Ticket>(){new Ticket(1020, "5A", 3.5), new Ticket(3320, "2B", 1.5), new Ticket(1021, "5B", 1.3), new Ticket(1431, "7C", 5.3)}),
            new Flight("TB-1130", "Praha", "Tambov", new DateTime(2021, 11, 30, 10, 00, 00), new DateTime(2021, 11, 30, 15, 30, 00), new Airplane("Tu-134", 100, 50, 70), new List<Ticket>(){new Ticket(1030, "5A", 2.5), new Ticket(1450, "2B", 13.5), new Ticket(1211, "5B", 2.1), new Ticket(1731, "7C", 2.4)}),
            new Flight("SP-0314", "Samara", "Saint-Peterburg", new DateTime(2022, 03, 14, 19, 00, 00), new DateTime(2022, 03, 14, 20, 30, 00), new Airplane("Tu-134", 100, 50, 70), new List<Ticket>(){new Ticket(1100, "5A", 7.5), new Ticket(1350, "2B", 4.5), new Ticket(1031, "5B", 1.3), new Ticket(1271, "7C", 1.5)})
        };
    }

    /// <summary>
    /// Initializes standart list of passengers for test
    /// </summary>
    /// <returns>
    /// List containing 6 different passengers
    /// </returns>
    private List<Passenger> Default_passengers()
    {
        return new List<Passenger>()
        {
            new Passenger(0001, "Petrovskaya Kira Viktorovna", new List<Ticket>(){new Ticket(1000, "5A", 7.5), new Ticket(1320, "2B", 7.5)}),
            new Passenger(0002, "Fedotov Saveliy Vladimirovich", new List<Ticket>(){new Ticket(1001, "5B", 2.3), new Ticket(1231, "7C", 2.3)}),
            new Passenger(0003, "Panov Timur Daniilovich", new List<Ticket>(){new Ticket(1002, "10C", 0)}),
            new Passenger(0004, "Karpova Daria Ivanovna", new List<Ticket>(){new Ticket(1003, "7A", 0)}),
            new Passenger(0005, "Eliseev Daniil Romanovich", new List<Ticket>(){new Ticket(1004, "13F", 5), new Ticket(1441, "5B", 5), new Ticket(1373, "6A", 5)}),
            new Passenger(0006, "Nikolaev David Alexandrovich", new List<Ticket>(){new Ticket(1005, "9F", 1)})
        };                                  
    }

    /// <summary>
    /// Create default airline with 5 airplanes, 3 flights, 6 passengers
    /// </summary>
    /// <returns>
    /// Filled airline object
    /// </returns>
    private Airline CreateDefAirline()
    {
        return new Airline(Default_airplanes(), Default_flights(), Default_passengers());
    }

    [Fact]
    public void Airplane_test()
    {
        Airline air = CreateDefAirline();
        List<Airplane> airplanes = air.Airplanes;
        Assert.Equal(5, airplanes.Count);
    }

    /// <summary>
    /// Product class constructor test
    /// </summary>
    [Fact]
    public void Airplane_constructor_test()
    {
        var plane = new Airplane("Tu-134", 100, 50, 70);
        Assert.Equal("Tu-134", plane.Model);
        Assert.Equal(100, plane.Load_Capacity);
        Assert.Equal(50, plane.Perfomance);
        Assert.Equal(70, plane.Passenger_Capacity);
    }

    [Fact]
    public void Ticket_constructor_test()
    {
        var ticket = new Ticket(1000, "5A", 7.5);
        Assert.Equal(1000, ticket.Number);
        Assert.Equal("5A", ticket.Seat_number);
        Assert.Equal(7.5, ticket.Baggage_weight);
    }

    [Fact]
    public void Flight_constructor_test()
    {
        var flight = new Flight("BD-1120", "Moscow", "Budapest", new DateTime(2022, 11, 20, 19, 00, 00), new DateTime(2022, 11, 20, 23, 30, 00), new Airplane("Tu-134", 100, 50, 70), new List<Ticket>() { new Ticket(1000, "5A", 7.5), new Ticket(1320, "2B", 7.5), new Ticket(1001, "5B", 2.3), new Ticket(1231, "7C", 2.3)});
        Assert.Equal("BD-1120", flight.Cipher);
        Assert.Equal("Moscow", flight.Departure_place);
        Assert.Equal("Budapest", flight.Destination);
        Assert.Equal(new DateTime(2022, 11, 20, 19, 00, 00), flight.Departure_date);
        Assert.Equal(new DateTime(2022, 11, 20, 23, 30, 00), flight.Arrival_date);
        Assert.Equal(new Airplane("Tu-134", 100, 50, 70), flight.Airplane);
        Assert.Equal(new List<Ticket>() { new Ticket(1000, "5A", 7.5), new Ticket(1320, "2B", 7.5), new Ticket(1001, "5B", 2.3), new Ticket(1231, "7C", 2.3) }, flight.Tickets);

    }

    [Fact]
    public void Passenger_constructor_test()
    {
        var passenger = new Passenger(0001, "Petrovskaya Kira Viktorovna", new List<Ticket>() { new Ticket(1000, "5A", 7.5), new Ticket(1320, "2B", 7.5)});
        Assert.Equal(0001, passenger.Passport_number);
        Assert.Equal("Petrovskaya Kira Viktorovna", passenger.Name);
        Assert.Equal(new List<Ticket>() { new Ticket(1000, "5A", 7.5), new Ticket(1320, "2B", 7.5) }, passenger.Tickets);
    }

    [Fact]
    public void Task1()
    {
        Airline air = CreateDefAirline();
        var request = (from flight in air.Flights
                       where (flight.Departure_place == "Moscow") && (flight.Destination == "Budapest")
                       select flight).Count();
        Assert.Equal(1, request);
    }


    [Fact]
    public void Task2()
    {
        Airline air = CreateDefAirline();
        var request = (from flight in air.Flights
                       from ticket in flight.Tickets
                       from passenger in air.Passengers
                       from t in passenger.Tickets
                       where (flight.Cipher == "CH-0510") && (ticket.Baggage_weight == 0) && (t.Number == ticket.Number)
                       select passenger).Count();
        Assert.Equal(2, request);
    }

    [Fact]
    public void Task3()
    {
        Airline air = CreateDefAirline();
        var first_date = new DateTime(2019, 5, 10, 00, 00, 00);
        var second_date = new DateTime(2024, 5, 11, 10, 00, 00);
        var plane = new Airplane("Boeing-777", 400, 70, 235);
        var request = (from flight in air.Flights
                       where (flight.Airplane.Equals(plane)) &&
                       (flight.Departure_date >= first_date) &&
                       (flight.Departure_date <= second_date)
                       select flight).Count();
        Assert.Equal(1, request);
    }

    [Fact]
    public void Task4()
    {
        Airline air = CreateDefAirline();
        var request = (from flight in air.Flights
                       where flight != null
                       select flight.Tickets.Count).Take(5).Count();
        Assert.Equal(5, request);
    }

    [Fact]
    public void Task5()
    {
        Airline air = CreateDefAirline();
        var min_time = (from flight in air.Flights
                        orderby flight.Flight_time
                        select flight.Flight_time).Min();
        var request = (from flight in air.Flights
                       where flight.Flight_time == min_time
                       select flight.Cipher).Count();
        Assert.Equal(1, request);
    }

    [Fact]
    public void Task6()
    {
        Airline air = CreateDefAirline();
        var request = (from flight in air.Flights
                       from ticket in flight.Tickets
                       where flight.Departure_place == "Moscow"
                       select ticket.Baggage_weight).ToList();
        var max = request.Max();
        var avg = request.Average();
        Assert.Equal(7.5, max);
        Assert.Equal(4.9, avg);
    }
}
