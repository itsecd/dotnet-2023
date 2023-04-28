using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace AirplaneBookingSystem.Domain;
public class AirplaneBookingSystemDbContext : DbContext
{
    public DbSet<Client>? Clients { get; set; }
    public DbSet<Flight>? Flights { get; set; }
    public DbSet<Ticket>? Tickets { get; set; }
    public DbSet<Airplane>? Airplanes { get; set; }
    public AirplaneBookingSystemDbContext(DbContextOptions options) : base(options)
    {
        Database.EnsureCreated();
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        var firstAirplane = new Airplane { Id = 500, Model = "Boing-717" };
        var secondAirplane = new Airplane { Id = 562, Model = "Boing-777" };
        var thirdAirplane = new Airplane{ Id = 554, Model = "ATR 42/72" };
        var fourthAirplane = new Airplane{ Id = 571, Model = "Embraer ERJ" };

        var firstFlight = new Flight { Id = 1, NumberOfFlight= 1, DepartureCity = "Kurumoch", ArrivalCity = "Astana", DepartureDate = new DateTime(2023, 8, 28), ArrivalDate = new DateTime(2023, 8, 29), AirplaneId = 500 };
        var secondFlight = new Flight { Id = 2, NumberOfFlight = 2, DepartureCity = "Astana", ArrivalCity = "Kurumoch", DepartureDate =  new DateTime(2023, 10, 17), ArrivalDate = new DateTime(2023, 10, 18),  AirplaneId = 562 };
        var thirdFlight = new Flight{ Id = 3, NumberOfFlight = 3, DepartureCity = "Kurumoch", ArrivalCity = "Sochi", DepartureDate = new DateTime(2023, 8, 28), ArrivalDate = new DateTime(2023, 8, 28),  AirplaneId = 554 };
        var fourthFlight = new Flight{ Id = 4, NumberOfFlight = 4, DepartureCity = "Los Angeles", ArrivalCity = "Tokyo", DepartureDate = new DateTime(2023, 10, 2), ArrivalDate = new DateTime(2023, 10, 3), AirplaneId = 571 };
        var fifthFlight = new Flight{ Id = 5, NumberOfFlight = 5, DepartureCity = "Chiko", ArrivalCity = "Kem", DepartureDate = new DateTime(2023, 6, 6), ArrivalDate = new DateTime(2023, 6, 7), AirplaneId = 571 };

        var firstClient = new Client { Id = 1, PassportNumber = "738096", BirthdayData = new DateTime(1969, 8, 15), Name = "Samoylov A. K." };
        var firstTicket = new Ticket{Id = 1, TicketNumber = 100, ClientId = 1, FlightId = 1 };
        //firstClient.Tickets.Add(firstTicket);
        //firstFlight.Tickets.Add(firstTicket);

        var secondClient = new Client { Id = 2, PassportNumber = "258204", BirthdayData = new DateTime(2002, 6, 4), Name = "Shestakov N. D." };
        var secondTicket = new Ticket { Id = 2, TicketNumber = 101, ClientId = 2, FlightId = 1 };
        var thirdTicket = new Ticket { Id = 3, TicketNumber = 200, ClientId = 2, FlightId = 2 };
        //secondClient.Tickets.Add(secondTicket);
        //secondClient.Tickets.Add(thirdTicket);
        //firstFlight.Tickets.Add(secondTicket);
        //secondFlight.Tickets.Add(thirdTicket);

        var thirdClient = new Client { Id = 3, PassportNumber = "211702", BirthdayData = new DateTime(1984, 10, 28), Name = "Fomina M. D." };
        var fourthTicket = new Ticket{ Id = 4, TicketNumber = 01, ClientId = 3, FlightId = 2 };
        //thirdClient.Tickets.Add(fourthTicket);
        //secondFlight.Tickets.Add(fourthTicket);

        var fourthClient = new Client { Id = 4, PassportNumber = "783469", BirthdayData = new DateTime(1978, 10, 17), Name = "Novikov Y. M." };
        var fifthTicket = new Ticket{ Id = 5, TicketNumber = 202, ClientId = 4, FlightId = 2 };
        //fourthClient.Tickets.Add(fifthTicket);
        //secondFlight.Tickets.Add(fifthTicket);

        var fifthClient = new Client { Id = 5, PassportNumber = "481761", BirthdayData = new DateTime(2013, 12, 7), Name = "Myasnikov S. I." };
        var sixtTicket = new Ticket{ Id = 6, TicketNumber = 300, ClientId = 5, FlightId = 3 };
        var seventhTicket = new Ticket{ Id = 7, TicketNumber = 500, ClientId = 5, FlightId = 5 };
        //fifthClient.Tickets.Add(sixtTicket);
        //fifthClient.Tickets.Add(seventhTicket);
        //thirdFlight.Tickets.Add(sixtTicket);
        //fifthFlight.Tickets.Add(seventhTicket);

        var sixthClient = new Client{ Id = 6, PassportNumber = "154590", BirthdayData = new DateTime(1993, 3, 21), Name = "Kapustina D. F." };
        var eighthTicket = new Ticket{ Id = 8, TicketNumber = 400, ClientId = 6, FlightId = 4 };
        //sixthClient.Tickets.Add(eighthTicket);
        //fourthFlight.Tickets.Add(eighthTicket);

        var seventhClient = new Client{ Id = 7, PassportNumber = "303386", BirthdayData = new DateTime(2013, 4, 3), Name = "Panfilova K. T." };
        var ninthTicket = new Ticket{ Id = 9, TicketNumber = 401, ClientId = 7, FlightId = 4 };
        //seventhClient.Tickets.Add(ninthTicket);
        //fourthFlight.Tickets.Add(ninthTicket);

        var eighthClient = new Client{ Id = 8, PassportNumber = "240348", BirthdayData = new DateTime(1966, 8, 17), Name = "Birukov D. M." };
        var tenthTicket = new Ticket{ Id = 10, TicketNumber = 402, ClientId = 8, FlightId = 4 };
        //eighthClient.Tickets.Add(tenthTicket);
        //fourthFlight.Tickets.Add(tenthTicket);

        modelBuilder.Entity<Ticket>()
            .HasOne(ticket => ticket.Client)
            .WithMany(client => client.Tickets)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Ticket>()
            .HasOne(ticket => ticket.Flight)
            .WithMany(flight => flight.Tickets)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Flight>()
            .HasOne(ticket => ticket.Airplane)
            .WithMany(airplane => airplane.Flights)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Client>().HasData(new List<Client> { firstClient, secondClient, thirdClient, fourthClient, fifthClient, sixthClient, seventhClient, eighthClient });
        modelBuilder.Entity<Airplane>().HasData(new List<Airplane> { firstAirplane, secondAirplane, thirdAirplane, fourthAirplane});
        modelBuilder.Entity<Flight>().HasData(new List<Flight> {firstFlight,secondFlight, thirdFlight, fourthFlight,fifthFlight });
        modelBuilder.Entity<Ticket>().HasData(new List<Ticket> {firstTicket, secondTicket, thirdTicket, fourthTicket, fifthTicket, sixtTicket, seventhTicket, eighthTicket, ninthTicket, tenthTicket });
    }
}
