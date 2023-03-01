using Airlines.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airlines.Test;
public class AirlinesFixture

{
    public List<TicketClass> FixtureTickets
    {
        get
        {
            var tickets = new List<TicketClass>();
            for (var i = 0; i < 10; i++)
            {
                var firstticket = new TicketClass(i, "A" + i, i);
                tickets.Add(firstticket);
                var secondticket = new TicketClass(i + 10, "A" + i + 10, i + 10);
                tickets.Add(secondticket);
                if (i % 2 == 0)
                {
                    var thirdticket = new TicketClass(i + 20, "A" + i + 20, i + 20);
                    tickets.Add(thirdticket);
                    var fourthticket = new TicketClass(i + 30, "A" + i + 30, i + 30);
                    tickets.Add(fourthticket);
                }
                if (i > 6)
                {
                    var fifthticket = new TicketClass(i + 20, "A" + i + 20, i + 20);
                    tickets.Add(fifthticket);
                    var sixthticket = new TicketClass(i + 30, "A" + i + 30, i + 30);
                    tickets.Add(sixthticket);
                    var seventhticket = new TicketClass(i + 20, "A" + i + 20, i + 20);
                    tickets.Add(seventhticket);
                }
            }
            return tickets;
        }
    }


    public List<FlightCLass> FixtureFlights
    {
        get {
            var firstdate = new DateOnly(2023, 1, 1);
            var seconddate = new DateOnly(2023, 3, 3);
            var firstduration = 1.5;
            var secondduration = 1.1;
            var thirdduration = 1;
            var fourthduration = 2;
            var fifthduration = 1.25;
            var sixthduration = 3;
            var firstflight = new FlightCLass(1, "A1", "Moscow", "Samara", firstdate, firstdate, firstduration, "Passenger");
            var secondflight = new FlightCLass(2, "A2", "Moscow", "Kazan", firstdate, firstdate, firstduration, "Passenger");
            var thirdflight = new FlightCLass(3, "A3", "Samara", "Kazan", seconddate, seconddate, secondduration, "Cargo");
            var fourthflight = new FlightCLass(4, "A4", "Kazan", "Samara", seconddate, seconddate, thirdduration, "Cargo");
            var fifthflight = new FlightCLass(5, "A5", "Kazan", "Samara", firstdate, firstdate, fourthduration, "Cargo");
            var sixthflight = new FlightCLass(6, "A6", "Kazan", "Samara", firstdate, firstdate, fifthduration, "Cargo");
            var seventhflight = new FlightCLass(7, "A7", "Kazan", "Samara", firstdate, firstdate, sixthduration, "Cargo");
            for (var i = 0; i < 10; i++)
            {
                var firstticket = new TicketClass(i, "A" + i, i);
                firstflight.Tickets.Add(firstticket);
                var secondticket = new TicketClass(i + 10, "A" + i + 10, i + 10);
                secondflight.Tickets.Add(secondticket);
                if (i % 2 == 0)
                {
                    var thirdticket = new TicketClass(i + 20, "A" + i + 20, i + 20);
                    thirdflight.Tickets.Add(thirdticket);
                    var fourthticket = new TicketClass(i + 30, "A" + i + 30, i + 30);
                    fourthflight.Tickets.Add(fourthticket);
                }
                if (i > 6)
                {
                    var fifthticket = new TicketClass(i + 20, "A" + i + 20, i + 20);
                    fifthflight.Tickets.Add(fifthticket);
                    var sixthticket = new TicketClass(i + 30, "A" + i + 30, i + 30);
                    sixthflight.Tickets.Add(sixthticket);
                    var seventhticket = new TicketClass(i + 20, "A" + i + 20, i + 20);
                    seventhflight.Tickets.Add(seventhticket);
                }
            }
            var flights = new List<FlightCLass>
    {
        firstflight,
        secondflight,
        thirdflight,
        fourthflight,
        fifthflight,
        sixthflight,
        seventhflight
    };
            return flights;
        }
    }
    public List<PassengerClass> FixturePassengers
    {
        get{
            var firstticket = new TicketClass(0, "0A", 0);
            var secondticket = new TicketClass(101, "2A", 5);
            var thirdticket = new TicketClass(102, "3A", 5);
            var fourthticket = new TicketClass(103, "4A", 5);
            var firstpassenger = new PassengerClass(1234, "Paul Johnson");
            firstpassenger.Tickets.Add(firstticket);
            var secondpassenger = new PassengerClass(1235, "Sandra Cole");
            secondpassenger.Tickets.Add(secondticket);
            var thirdpassenger = new PassengerClass(1236, "Jack Spours");
            thirdpassenger.Tickets.Add(thirdticket);
            var fourthpassenger = new PassengerClass(1237, "Mike McKay");
            fourthpassenger.Tickets.Add(fourthticket);
            var passengers = new List<PassengerClass>
        {
            firstpassenger,
            secondpassenger,
            thirdpassenger,
            fourthpassenger
        };
            return passengers;
        }
    }
}