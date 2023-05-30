using Microsoft.EntityFrameworkCore;

namespace HotelBookingSystem.Classes;
public class HotelBookingSystemDbContext : DbContext
{
    public DbSet<Hotel>? Hotels { get; set; }

    public DbSet<Room>? Rooms { get; set; }

    public DbSet<Lodger>? Lodgers { get; set; }

    public DbSet<BookedRooms>? Brooms { get; set; }

    public HotelBookingSystemDbContext(DbContextOptions options) : base(options)
    {
        Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        var hotels = new List<Hotel>()
        {
            new Hotel{Id = 1, Name = "Best Hotel", City = "Bali", Adress = "Moscow st, 34"},
            new Hotel{Id = 2, Name = "Worst Hotel", City = "Muhosransk", Adress = "Moscow st, 13"},
            new Hotel{Id = 3, Name = "Obshaga", City = "Samara", Adress = "Somewhere"},
            new Hotel{Id = 4, Name = "Plaza", City = "New York", Adress = "Chinatown"},
            new Hotel{Id = 5, Name = "Hostel", City = "Kazakhstan", Adress = "Center"},
            new Hotel{Id = 6, Name = "Pop", City = "Kuznetsk", Adress = "Lenin st, 35"},
        };

        modelBuilder.Entity<Hotel>().HasData(hotels);

        var rooms = new List<Room>()
        {
            new Room{Id = 1, TypeOfRoom = "Room 621", NumberOfRooms = 10, Cost = 1000, PlacementId = 1},
            new Room{Id = 2, TypeOfRoom = "Room 621", NumberOfRooms = 10, Cost = 1100, PlacementId = 2},
            new Room{Id = 3, TypeOfRoom = "Room 621", NumberOfRooms = 10, Cost = 1200, PlacementId = 3},
            new Room{Id = 4, TypeOfRoom = "Room 621", NumberOfRooms = 10, Cost = 1300, PlacementId = 4},
            new Room{Id = 5, TypeOfRoom = "Room 713", NumberOfRooms = 20, Cost = 2100, PlacementId = 2},
            new Room{Id = 6, TypeOfRoom = "Room 713", NumberOfRooms = 20, Cost = 2200, PlacementId = 6},
            new Room{Id = 7, TypeOfRoom = "Room 713", NumberOfRooms = 20, Cost = 2300, PlacementId = 1},
            new Room{Id = 8, TypeOfRoom = "Room 713", NumberOfRooms = 20, Cost = 2400, PlacementId = 2},
            new Room{Id = 9, TypeOfRoom = "Room 309", NumberOfRooms = 30, Cost = 3100, PlacementId = 3},
            new Room{Id = 10, TypeOfRoom = "Room 309", NumberOfRooms = 30, Cost = 3200, PlacementId = 4},
            new Room{Id = 11, TypeOfRoom = "Room 309", NumberOfRooms = 30, Cost = 3300, PlacementId = 5},
            new Room{Id = 12, TypeOfRoom = "Room 309", NumberOfRooms = 30, Cost = 3400, PlacementId = 6},
        };

        modelBuilder.Entity<Room>().HasData(rooms);

        var lodgers = new List<Lodger>()
        {
            new Lodger{Id = 1, Passport = 111, Name = "John Lennon", Birthdate = new DateTime(1940, 10, 09)},
            new Lodger{Id = 2, Passport = 222, Name = "Paul McCartney", Birthdate = new DateTime(1942, 07, 19)},
            new Lodger{Id = 3, Passport = 333, Name = "George Harrison", Birthdate = new DateTime(1943, 02, 25)},
            new Lodger{Id = 4, Passport = 444, Name = "Ringo Starr", Birthdate = new DateTime(1940, 08, 07)},
        };

        modelBuilder.Entity<Lodger>().HasData(lodgers);

        var brooms = new List<BookedRooms>()
        {
            new BookedRooms{Id = 1, ClientId = 1, BookedRoomId = 3,
                EntryDate = new DateTime(2001, 01, 01), BookingTerm = new DateTime(2021, 01, 01), DepartmentDate = new DateTime(2011, 01, 01)},
            new BookedRooms{Id = 2, ClientId = 2, BookedRoomId = 2,
                EntryDate = new DateTime(2002, 02, 02), BookingTerm = new DateTime(2022, 02, 02), DepartmentDate = new DateTime(2012, 02, 02)},
            new BookedRooms{Id = 3, ClientId = 3, BookedRoomId = 4,
                EntryDate = new DateTime(2003, 03, 02), BookingTerm = new DateTime(2024, 03, 02), DepartmentDate = new DateTime(2013, 03, 03)},
            new BookedRooms{Id = 4, ClientId = 4, BookedRoomId = 6,
                EntryDate = new DateTime(2004, 04, 02), BookingTerm = new DateTime(2024, 04, 02), DepartmentDate = new DateTime(2014, 04, 04)},
            new BookedRooms{Id = 5, ClientId = 5, BookedRoomId = 9,
                EntryDate = new DateTime(2005, 05, 02), BookingTerm = new DateTime(2025, 05, 02), DepartmentDate = new DateTime(2015, 05, 05)},
        };

        modelBuilder.Entity<BookedRooms>().HasData(brooms);
    }
}
