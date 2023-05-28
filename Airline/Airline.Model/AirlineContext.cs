using AirLine.Model;
using Microsoft.EntityFrameworkCore;

namespace AirlineModel;

/// <summary>
/// Class AirlineContext connecting with database
/// </summary>
public class AirlineContext : DbContext
{
    /// <summary>
    /// Ticket data set
    /// </summary>
    public DbSet<Ticket> Tickets { get; set; }
    /// <summary>
    /// Passenger data set
    /// </summary>
    public DbSet<Passenger> Passengers { get; set; }
    /// <summary>
    /// Flight data set
    /// </summary>
    public DbSet<Flight> Flights { get; set; }
    /// <summary>
    /// Airplane data set
    /// </summary>
    public DbSet<Airplane> Airplanes { get; set; }
    /// <summary>
    /// Airline data set
    /// </summary>
    public DbSet<Airline> Airlines { get; set; }
    /// <summary>
    /// FlightAirplaneTicket data set
    /// </summary>
    public DbSet<FlightAirplaneTicket> FlightAirplaneTickets { get; set; }

    /// <summary>
    /// Database creating
    /// </summary>
    /// <param name="options"></param>
    public AirlineContext(DbContextOptions options) : base(options)
    {
        Database.EnsureCreated();
    }

    /// <summary>
    /// Values to the database
    /// </summary>
    /// <param name="modelBuilder"></param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      //  base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Airplane>().HasData(
            new Airplane(1, "Tu-134", 100, 50, 70),
            new Airplane(2, "Tu-154", 150, 60, 90),
            new Airplane(3, "SuperJet-100", 200, 90, 100),
            new Airplane(4, "Boeing-777", 400, 70, 235),
            new Airplane(5, "Boeing-747", 3500, 80, 320));

        modelBuilder.Entity<Flight>().HasData(
            new Flight(1, "BD-1120", "Moscow", "Budapest", new DateTime(2022, 11, 20, 19, 00, 00), new DateTime(2022, 11, 20, 23, 30, 00)),
            new Flight(2, "CH-0510", "Pekin", "Samara", new DateTime(2022, 5, 10, 10, 00, 00), new DateTime(2022, 5, 10, 20, 05, 00)),
            new Flight(3, "CZ-0321", "Samara", "Praha", new DateTime(2020, 03, 21, 12, 30, 00), new DateTime(2020, 03, 21, 17, 20, 00)),
            new Flight(4, "BD-1122", "Samara", "Budapest", new DateTime(2023, 11, 22, 19, 00, 00), new DateTime(2023, 11, 22, 22, 30, 00)),
            new Flight(5, "TB-1130", "Praha", "Tambov", new DateTime(2021, 11, 30, 10, 00, 00), new DateTime(2021, 11, 30, 15, 30, 00)),
            new Flight(6, "SP-0314", "Samara", "Saint-Peterburg", new DateTime(2022, 03, 14, 19, 00, 00), new DateTime(2022, 03, 14, 20, 30, 00)));

        modelBuilder.Entity<FlightAirplaneTicket>().HasData(
            new FlightAirplaneTicket(1, 1, 1, 1),
            new FlightAirplaneTicket(2, 1, 2, 1),
            new FlightAirplaneTicket(3, 1, 3, 4),
            new FlightAirplaneTicket(4, 1, 4, 4),
            new FlightAirplaneTicket(5, 2, 5, 2),
            new FlightAirplaneTicket(6, 2, 6, 2),
            new FlightAirplaneTicket(7, 4, 7, 3),
            new FlightAirplaneTicket(8, 4, 8, 3),
            new FlightAirplaneTicket(9, 4, 9, 5),
            new FlightAirplaneTicket(10, 4, 10, 6));

        modelBuilder.Entity<Ticket>().HasData(
            new Ticket(1, 1000, "5A", 7.5, 1),
            new Ticket(2, 1320, "2B", 7.5, 1),
            new Ticket(3, 1001, "5B", 2.3, 2),
            new Ticket(4, 1231, "7C", 2.3, 2),
            new Ticket(5, 1002, "10C", 0, 3),
            new Ticket(6, 1003, "7A", 0, 3),
            new Ticket(7, 1004, "13F", 5, 4),
            new Ticket(8, 1441, "5B", 5, 4),
            new Ticket(9, 1373, "6A", 5, 5),
            new Ticket(10, 1005, "9F", 1, 6));

        modelBuilder.Entity<Passenger>().HasData(
            new Passenger(1, 0001, "KiraPetrovskaya"),
            new Passenger(2, 0002, "SaveliyFedotov"),
            new Passenger(3, 0003, "TimurPanov"),
            new Passenger(4, 0004, "DariaKarpova"),
            new Passenger(5, 0005, "DaniilEliseev"),
            new Passenger(6, 0006, "DavidNikolaev"));
    }
}