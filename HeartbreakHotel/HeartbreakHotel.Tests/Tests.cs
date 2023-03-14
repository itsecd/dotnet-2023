using HeartbreakHotel;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace HeartbreakHotelTests;

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
        return new List<Room>()
        {
            new Room("Room 621", 10, 70),
            new Room("Room 813", 20, 80),
            new Room("Room 713", 30, 90),
            new Room("Room 411", 40, 100),
            new Room("Room 309", 50, 110),
            new Room("Room 308", 60, 120),
        };
    }

    public List<Lodger> ListOfLodgers()
    {
        return new List<Lodger>()
        {
            new Lodger(111, "John Lennon", new DateOnly(2001, 01, 01)),
            new Lodger(222, "Paul McCartney", new DateOnly(2002, 02, 02)),
            new Lodger(333, "Jimi Hendrix", new DateOnly(2003, 03, 03)),
            new Lodger(444, "David Bowie", new DateOnly(2004, 04, 04)),
            new Lodger(555, "Miles Davis", new DateOnly(2005, 05, 05)),
            new Lodger(666, "Morrisey", new DateOnly(2006, 06, 06)),
        };
    }

    public List<BookedRooms> ListOfBookedRooms() 
    {
        List<Lodger> tmplodgers = ListOfLodgers();
        List<Hotel> tmphotels = ListOfHotels();
        List<Room> tmprooms = ListOfRooms();
        return new List<BookedRooms>()
        {
            new BookedRooms(tmphotels[1], tmprooms[4], tmplodgers[0], new DateTime(2011, 01, 01), new DateTime(2021, 01, 01), new DateTime(2012, 01, 01)),
            new BookedRooms(tmphotels[1], tmprooms[2], tmplodgers[1], new DateTime(2012, 02, 02), new DateTime(2022, 02, 02), new DateTime(2013, 02, 02)),
            new BookedRooms(tmphotels[1], tmprooms[3], tmplodgers[2], new DateTime(2013, 03, 03), new DateTime(2023, 03, 03), new DateTime(2014, 03, 03)),
            new BookedRooms(tmphotels[1], tmprooms[3], tmplodgers[3], new DateTime(2014, 04, 04), new DateTime(2024, 04, 04), new DateTime(2015, 04, 04)),
            new BookedRooms(tmphotels[3], tmprooms[4], tmplodgers[4], new DateTime(2015, 05, 05), new DateTime(2026, 05, 05), new DateTime(2016, 05, 05)),
            new BookedRooms(tmphotels[4], tmprooms[4], tmplodgers[5], new DateTime(2016, 06, 06), new DateTime(2026, 06, 06), new DateTime(2017, 06, 06)),
            new BookedRooms(tmphotels[4], tmprooms[2], tmplodgers[3], new DateTime(2017, 04, 04), new DateTime(2039, 04, 04), new DateTime(2018, 04, 04)),
            new BookedRooms(tmphotels[4], tmprooms[3], tmplodgers[4], new DateTime(2018, 05, 05), new DateTime(2028, 05, 05), new DateTime(2019, 05, 05)),
            new BookedRooms(tmphotels[3], tmprooms[5], tmplodgers[5], new DateTime(2019, 06, 06), new DateTime(2029, 06, 06), new DateTime(2020, 06, 06)),
            new BookedRooms(tmphotels[0], tmprooms[5], tmplodgers[2], new DateTime(2020, 07, 07), new DateTime(2030, 07, 07), new DateTime(2021, 07, 07)),
            new BookedRooms(tmphotels[2], tmprooms[5], tmplodgers[5], new DateTime(2021, 08, 08), new DateTime(2031, 08, 08), new DateTime(2022, 08, 08)),
        };
    }
    /// <summary>
    /// Task 1 - Display information about all hotels
    /// </summary>
    [Fact]
    public void Task1()
    {
        List<Hotel> hotels = ListOfHotels();

        Assert.Equal("Best Hotel", hotels[0].Name);
        Assert.Equal("Worst Hotel", hotels[1].Name);
        Assert.Equal("Obshaga", hotels[2].Name);
        Assert.Equal("Plaza", hotels[3].Name);
        Assert.Equal("Hostel", hotels[4].Name);
        Assert.Equal("Pop", hotels[5].Name);
    }

    /// <summary>
    /// Task 2 - Display information about all clients 
    /// staying at the specified hotel
    /// arrange by full name
    /// </summary>
    [Fact]
    public void Task2()
    {
        List<BookedRooms> brooms = ListOfBookedRooms();
        var result = (from broom in brooms
                      where broom.BookedHotel.Name == "Worst Hotel"
                      orderby broom.Booker.Name
                      select broom.Booker).ToList();

        Assert.Equal("David Bowie", result[0].Name);
        Assert.Equal("Jimi Hendrix", result[1].Name);
        Assert.Equal("John Lennon", result[2].Name);
        Assert.Equal("Paul McCartney", result[3].Name);
        
    }

    /// <summary>
    /// Task 3 - Display information about the top 5 hotels 
    /// with the largest number of bookings.
    /// </summary>
    [Fact]
    public void Task3()
    {
        List<BookedRooms> brooms = ListOfBookedRooms();
        var result = brooms.GroupBy(x => x.BookedHotel)
                    .OrderByDescending(g => g.Count())
                    .Select(y => y.Key)
                    .Take(5)
                    .ToList();

        Assert.Equal("Worst Hotel", result[0].Name);
        Assert.Equal("Hostel", result[1].Name);
        Assert.Equal("Plaza", result[2].Name);
        Assert.Equal("Best Hotel", result[3].Name);
        Assert.Equal("Obshaga", result[4].Name);
    }

    /// <summary>
    /// Task 4 - Display information about available rooms 
    /// in all hotels of the selected city.
    /// </summary>
    [Fact]
    public void Task4()
    {
        List<Room> rooms = ListOfRooms();
        List<BookedRooms> brooms = ListOfBookedRooms();
        var tmp = (from broom in brooms
                   select broom.BookedRoom).ToList();
        var result = (from room in rooms
                      where !tmp.Contains(room)
                      select room).ToList();

        Assert.Equal("Room 621", result[0].TypeOfRoom);
        Assert.Equal("Room 813", result[1].TypeOfRoom);
    }

    /// <summary>
    /// Task 5 - Display information about customers 
    /// who have rented rooms for the largest number of days.
    /// </summary>
    [Fact]
    public void Task5()
    {
        List<BookedRooms> brooms = ListOfBookedRooms();
        var result = (from broom in brooms
                      orderby (broom.BookingTerm - broom.EntryDate).Days descending
                      select broom.Booker).ToList();
        
        Assert.Equal("David Bowie", result[0].Name);
        Assert.Equal("Miles Davis", result[1].Name);
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
                   group broom by broom.BookedHotel into minres
                   select minres.First().BookedRoom.Cost).ToList();

        var max = (from broom in brooms
                   orderby broom.BookedRoom.Cost descending
                   group broom by broom.BookedHotel into maxres
                   select maxres.First().BookedRoom.Cost).ToList();

        Assert.Equal(90, min[0]);
        Assert.Equal(120, max[0]);
    }
}