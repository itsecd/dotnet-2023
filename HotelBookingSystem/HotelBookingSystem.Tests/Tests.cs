using HotelBookingSystem.Classes;
using Microsoft.EntityFrameworkCore;

namespace HotelBookingSystem.Tests;

public class Tests
{
    public List<Hotel> ListOfHotels()
    {
        return new List<Hotel>()
        {
            new Hotel{Id = 0, Name = "Best Hotel", City = "Bali", Adress = "Moscow st, 34"},
            new Hotel{Id = 1, Name = "Worst Hotel", City = "Muhosransk", Adress = "Moscow st, 13"},
            new Hotel{Id = 2, Name = "Obshaga", City = "Samara", Adress = "Somewhere"},
            new Hotel{Id = 3, Name = "Plaza", City = "New York", Adress = "Chinatown"},
            new Hotel{Id = 4, Name = "Hostel", City = "Kazakhstan", Adress = "Center"},
            new Hotel{Id = 5, Name = "Pop", City = "Kuznetsk", Adress = "Lenin st, 35"},
        };
    }

    public List<Room> ListOfRooms()
    {
        var hotels = ListOfHotels();
        return new List<Room>()
        {
            new Room{Id = 0, TypeOfRoom = "Room 621", NumberOfRooms = 10, Cost = 1000, Placement = hotels[0], PlacementId = 0},
            new Room{Id = 1, TypeOfRoom = "Room 621", NumberOfRooms = 10, Cost = 1100, Placement = hotels[1], PlacementId = 1},
            new Room{Id = 2, TypeOfRoom = "Room 621", NumberOfRooms = 10, Cost = 1200, Placement = hotels[2], PlacementId = 2},
            new Room{Id = 3, TypeOfRoom = "Room 621", NumberOfRooms = 10, Cost = 1300, Placement = hotels[3], PlacementId = 3},
            new Room{Id = 4, TypeOfRoom = "Room 713", NumberOfRooms = 20, Cost = 2100, Placement = hotels[1], PlacementId = 1},
            new Room{Id = 5, TypeOfRoom = "Room 713", NumberOfRooms = 20, Cost = 2200, Placement = hotels[5], PlacementId = 5},
            new Room{Id = 6, TypeOfRoom = "Room 713", NumberOfRooms = 20, Cost = 2300, Placement = hotels[0], PlacementId = 0},
            new Room{Id = 7, TypeOfRoom = "Room 713", NumberOfRooms = 20, Cost = 2400, Placement = hotels[1], PlacementId = 1},
            new Room{Id = 8, TypeOfRoom = "Room 309", NumberOfRooms = 30, Cost = 3100, Placement = hotels[2], PlacementId = 2},
            new Room{Id = 9, TypeOfRoom = "Room 309", NumberOfRooms = 30, Cost = 3200, Placement = hotels[3], PlacementId = 3},
            new Room{Id = 10, TypeOfRoom = "Room 309", NumberOfRooms = 30, Cost = 3300, Placement = hotels[4], PlacementId = 4},
            new Room{Id = 11, TypeOfRoom = "Room 309", NumberOfRooms = 30, Cost = 3400, Placement = hotels[5], PlacementId = 5},
        };
    }

    public List<Lodger> ListOfLodgers()
    {
        return new List<Lodger>()
        {
            new Lodger{Id = 0, Passport = 111, Name = "John Lennon", Birthdate = new DateTime(1940, 10, 09) },
            new Lodger{Id = 1, Passport = 222, Name = "Paul McCartney", Birthdate = new DateTime(1942, 07, 19)},
            new Lodger{Id = 2, Passport = 333, Name = "George Harrison", Birthdate = new DateTime(1943, 02, 25)},
            new Lodger{Id = 3, Passport = 444, Name = "Ringo Starr", Birthdate = new DateTime(1940, 08, 07)},
        };
    }

    public List<BookedRooms> ListOfBookedRooms()
    {
        var rooms = ListOfRooms();
        var lodgers = ListOfLodgers();
        return new List<BookedRooms>()
        {
            new BookedRooms{Id = 0, Client = lodgers[0], BookedRoom = rooms[2], ClientId = 0, BookedRoomId = 2,
                EntryDate = new DateTime(2001, 01, 01), BookingTerm = new DateTime(2021, 01, 01), DepartmentDate = new DateTime(2011, 01, 01)},
            new BookedRooms{Id = 1, Client = lodgers[1], BookedRoom = rooms[1], ClientId = 1, BookedRoomId = 1,
                EntryDate = new DateTime(2002, 02, 02), BookingTerm = new DateTime(2022, 02, 02), DepartmentDate = new DateTime(2012, 02, 02)},
            new BookedRooms{Id = 2, Client = lodgers[2], BookedRoom = rooms[3], ClientId = 2, BookedRoomId = 3,
                EntryDate = new DateTime(2003, 03, 02), BookingTerm = new DateTime(2024, 03, 02), DepartmentDate = new DateTime(2013, 03, 03)},
            new BookedRooms{Id = 3, Client = lodgers[3], BookedRoom = rooms[5], ClientId = 3, BookedRoomId = 5,
                EntryDate = new DateTime(2004, 04, 02), BookingTerm = new DateTime(2024, 04, 02), DepartmentDate = new DateTime(2014, 04, 04)},
            new BookedRooms{Id = 4, Client = lodgers[0], BookedRoom = rooms[8], ClientId = 4, BookedRoomId = 8,
                EntryDate = new DateTime(2005, 05, 02), BookingTerm = new DateTime(2025, 05, 02), DepartmentDate = new DateTime(2015, 05, 05)},
        };
    }

    /// <summary>
    /// Task 1 - Display information about all hotels.
    /// </summary>
    [Fact]
    public void InfoHotels()
    {
        var result = ListOfHotels();

        Assert.Equal("Best Hotel", result[0].Name);
        Assert.Equal("Worst Hotel", result[1].Name);
        Assert.Equal("Obshaga", result[2].Name);
        Assert.Equal("Plaza", result[3].Name);
        Assert.Equal("Hostel", result[4].Name);
        Assert.Equal("Pop", result[5].Name);
    }

    /// <summary>
    /// Task 2 - Display information about all clients 
    /// staying at the specified hotel, arrange by full name.
    /// </summary>
    [Fact]
    public void InfoClientsInHotels()
    {
        var brooms = ListOfBookedRooms();
        var result = (from broom in brooms
                      where broom.BookedRoom.Placement.Name == "Worst Hotel"
                      select broom.Client).ToList();

        Assert.Equal("Paul McCartney", result[0].Name);
    }

    /// <summary>
    /// Task 3 - Display information about the top 5 
    /// hotels with the largest number of bookings.
    /// </summary>
    [Fact]
    public void Top5MostBooked()
    {
        var brooms = ListOfBookedRooms();
        var result = brooms.GroupBy(x => x.BookedRoom.Placement)
                    .OrderByDescending(g => g.Count())
                    .Select(y => y.Key)
                    .Take(5)
                    .ToList();

        Assert.Equal("Obshaga", result[0].Name);
        Assert.Equal("Worst Hotel", result[1].Name);
        Assert.Equal("Plaza", result[2].Name);
    }

    /// <summary>
    /// Task 4 - Display information about available 
    /// rooms in all hotels of the selected city.
    /// </summary>
    [Fact]
    public void AvailableRooms()
    {
        var rooms = ListOfRooms();
        var brooms = ListOfBookedRooms();
        var tmp = (from broom in brooms
                   select broom.BookedRoom).ToList();
        var result = (from room in rooms
                      where !tmp.Contains(room)
                      select room).ToList();

        Assert.Equal("Room 621", result[0].TypeOfRoom);
    }

    /// <summary>
    /// Task 5 - Display information about customers 
    /// who have rented rooms for the largest number of days.
    /// </summary>
    [Fact]
    public void ClientsWithMostDays()
    {
        List<BookedRooms> brooms = ListOfBookedRooms();
        var result = (from broom in brooms
                      orderby (broom.BookingTerm - broom.EntryDate).Days descending
                      select broom.Client).ToList();

        Assert.Equal("George Harrison", result[0].Name);
        Assert.Equal("John Lennon", result[1].Name);
    }

    /// <summary>
    /// Task 6 - Display information about the minimum 
    /// and maximum room cost in each hotel.
    /// </summary>
    [Fact]
    public void MinMaxCost()
    {
        List<BookedRooms> brooms = ListOfBookedRooms();
        var rooms = ListOfRooms();

        var result = rooms.GroupBy(b => b.Placement)
        .Select(g => new
        {
            hotel = g.First().Placement.Name,
            min = g.Min(b => b.Cost),
            avg = g.Average(b => b.Cost),
            max = g.Max(b => b.Cost),
        }).ToList();

        Assert.Equal(1000, result.First().min);
        Assert.Equal(2300, result.First().max);
    }
}