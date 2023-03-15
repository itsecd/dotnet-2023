using System.Xml.Linq;
using System;

namespace HotelBookingSystem.Tests;

public class Tests
{

    public List<Hotel> ListOfHotels()
    {
        return new List<Hotel>()
        {
            new Hotel("Best Hotel", "Bali", "Moscow st, 34"),
            new Hotel("Worst Hotel", "Muhosransk", "Moscow st, 13"),
            new Hotel("Obshaga", "Samara", "Somewhere"),
            new Hotel("Plaza", "New York", "Chinatown"),
            new Hotel("Hostel", "Kazakhstan", "Center"),
            new Hotel("Pop", "Kuznetsk", "Lenin st, 35"),
        };
    }

    public List<Room> ListOfRooms()
    {
        var hotels = ListOfHotels();
        return new List<Room>()
        {
            new Room("Room 621", 10, 1000, hotels[0]),
            new Room("Room 621", 10, 1100, hotels[1]),
            new Room("Room 621", 10, 1200, hotels[2]),
            new Room("Room 621", 10, 1300, hotels[3]),
            new Room("Room 713", 20, 2100, hotels[1]),
            new Room("Room 713", 20, 2200, hotels[5]),
            new Room("Room 713", 20, 2300, hotels[0]),
            new Room("Room 713", 20, 2400, hotels[1]),
            new Room("Room 309", 30, 3100, hotels[2]),
            new Room("Room 309", 30, 3200, hotels[3]),
            new Room("Room 309", 30, 3300, hotels[4]),
            new Room("Room 309", 30, 3400, hotels[5]),
        };
    }

    public List<Lodger> ListOfLodgers()
    {
        return new List<Lodger>()
        {
            new Lodger(111, "John Lennon", new DateTime(1940, 10, 09)),
            new Lodger(222, "Paul McCartney", new DateTime(1942, 07, 19)),
            new Lodger(333, "George Harrison", new DateTime(1943, 02, 25)),
            new Lodger(444, "Ringo Starr", new DateTime(1940, 08, 07)),
        };
    }

    public List<BookedRooms> ListOfBookedRooms()
    {
        var rooms = ListOfRooms();
        var lodgers = ListOfLodgers();
        return new List<BookedRooms>()
        {
            new BookedRooms(lodgers[0], rooms[2], new DateTime(2001, 01, 01), new DateTime(2021, 01, 01), new DateTime(2011, 01, 01)),
            new BookedRooms(lodgers[1], rooms[1], new DateTime(2002, 02, 02), new DateTime(2022, 02, 02), new DateTime(2012, 02, 02)),
            new BookedRooms(lodgers[2], rooms[3], new DateTime(2003, 03, 02), new DateTime(2024, 03, 02), new DateTime(2013, 03, 03)),
            new BookedRooms(lodgers[3], rooms[5], new DateTime(2004, 04, 02), new DateTime(2024, 04, 02), new DateTime(2014, 04, 04)),
            new BookedRooms(lodgers[0], rooms[8], new DateTime(2005, 05, 02), new DateTime(2025, 05, 02), new DateTime(2015, 05, 05)),
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
    public void Task6()
    {
        List<BookedRooms> brooms = ListOfBookedRooms();
        var min = (from broom in brooms
                   orderby broom.BookedRoom.Cost
                   group broom by broom.BookedRoom.Placement into minres
                   select minres.First().BookedRoom.Cost).ToList();

        var max = (from broom in brooms
                   orderby broom.BookedRoom.Cost descending
                   group broom by broom.BookedRoom.Placement into maxres
                   select maxres.First().BookedRoom.Cost).ToList();

        Assert.Equal(1100, min[0]);
        Assert.Equal(3100, max[0]);
    }
}