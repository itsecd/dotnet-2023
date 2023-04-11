using HotelBookingSystem.Classes;
using Microsoft.Extensions.Hosting;
using System.Xml.Linq;

namespace HotelBookingSystem.Server.Repository;

public class HotelBookingSystemRepository : IHotelBookingSystemRepository
{
    private readonly List<Hotel> _hotels;
    private readonly List<Room> _rooms;
    private readonly List<Lodger> _lodgers;
    private readonly List<BookedRooms> _brooms;

    public HotelBookingSystemRepository()
    {
        _hotels = new List<Hotel>()
        {
            new Hotel{Id = 0, Name = "Best Hotel", City = "Bali", Adress = "Moscow st, 34"},
            new Hotel{Id = 1, Name = "Worst Hotel", City = "Muhosransk", Adress = "Moscow st, 13"},
            new Hotel{Id = 2, Name = "Obshaga", City = "Samara", Adress = "Somewhere"},
            new Hotel{Id = 3, Name = "Plaza", City = "New York", Adress = "Chinatown"},
            new Hotel{Id = 4, Name = "Hostel", City = "Kazakhstan", Adress = "Center"},
            new Hotel{Id = 5, Name = "Pop", City = "Kuznetsk", Adress = "Lenin st, 35"},
        };

        _rooms = new List<Room>()
        {
            new Room{Id = 0, TypeOfRoom = "Room 621", NumberOfRooms = 10, Cost = 1000, Placement = _hotels[0], PlacementId = 0},
            new Room{Id = 1, TypeOfRoom = "Room 621", NumberOfRooms = 10, Cost = 1100, Placement = _hotels[1], PlacementId = 1},
            new Room{Id = 2, TypeOfRoom = "Room 621", NumberOfRooms = 10, Cost = 1200, Placement = _hotels[2], PlacementId = 2},
            new Room{Id = 3, TypeOfRoom = "Room 621", NumberOfRooms = 10, Cost = 1300, Placement = _hotels[3], PlacementId = 3},
            new Room{Id = 4, TypeOfRoom = "Room 713", NumberOfRooms = 20, Cost = 2100, Placement = _hotels[1], PlacementId = 1},
            new Room{Id = 5, TypeOfRoom = "Room 713", NumberOfRooms = 20, Cost = 2200, Placement = _hotels[5], PlacementId = 5},
            new Room{Id = 6, TypeOfRoom = "Room 713", NumberOfRooms = 20, Cost = 2300, Placement = _hotels[0], PlacementId = 0},
            new Room{Id = 7, TypeOfRoom = "Room 713", NumberOfRooms = 20, Cost = 2400, Placement = _hotels[1], PlacementId = 1},
            new Room{Id = 8, TypeOfRoom = "Room 309", NumberOfRooms = 30, Cost = 3100, Placement = _hotels[2], PlacementId = 2},
            new Room{Id = 9, TypeOfRoom = "Room 309", NumberOfRooms = 30, Cost = 3200, Placement = _hotels[3], PlacementId = 3},
            new Room{Id = 10, TypeOfRoom = "Room 309", NumberOfRooms = 30, Cost = 3300, Placement = _hotels[4], PlacementId = 4},
            new Room{Id = 11, TypeOfRoom = "Room 309", NumberOfRooms = 30, Cost = 3400, Placement = _hotels[5], PlacementId = 5},
        };

        _lodgers = new List<Lodger>()
        {
            new Lodger{Id = 0, Passport = 111, Name = "John Lennon", Birthdate = new DateTime(1940, 10, 09) },
            new Lodger{Id = 1, Passport = 222, Name = "Paul McCartney", Birthdate = new DateTime(1942, 07, 19)},
            new Lodger{Id = 2, Passport = 333, Name = "George Harrison", Birthdate = new DateTime(1943, 02, 25)},
            new Lodger{Id = 3, Passport = 444, Name = "Ringo Starr", Birthdate = new DateTime(1940, 08, 07)},
        };

        _brooms = new List<BookedRooms>()
        {
            new BookedRooms{Id = 0, Client = _lodgers[0], BookedRoom = _rooms[2], ClientId = 0, BookedRoomId = 2,
                EntryDate = new DateTime(2001, 01, 01), BookingTerm = new DateTime(2021, 01, 01), DepartmentDate = new DateTime(2011, 01, 01)},
            new BookedRooms{Id = 1, Client = _lodgers[1], BookedRoom = _rooms[1], ClientId = 1, BookedRoomId = 1,
                EntryDate = new DateTime(2002, 02, 02), BookingTerm = new DateTime(2022, 02, 02), DepartmentDate = new DateTime(2012, 02, 02)},
            new BookedRooms{Id = 2, Client = _lodgers[2], BookedRoom = _rooms[3], ClientId = 2, BookedRoomId = 3,
                EntryDate = new DateTime(2003, 03, 02), BookingTerm = new DateTime(2024, 03, 02), DepartmentDate = new DateTime(2013, 03, 03)},
            new BookedRooms{Id = 3, Client = _lodgers[3], BookedRoom = _rooms[5], ClientId = 3, BookedRoomId = 5,
                EntryDate = new DateTime(2004, 04, 02), BookingTerm = new DateTime(2024, 04, 02), DepartmentDate = new DateTime(2014, 04, 04)},
            new BookedRooms{Id = 4, Client = _lodgers[0], BookedRoom = _rooms[8], ClientId = 4, BookedRoomId = 8,
                EntryDate = new DateTime(2005, 05, 02), BookingTerm = new DateTime(2025, 05, 02), DepartmentDate = new DateTime(2015, 05, 05)},
        };
    }

    public List<Hotel> ListOfHotels => _hotels;
    public List<Room> ListOfRooms => _rooms;
    public List<Lodger> ListOfLodgers => _lodgers;
    public List<BookedRooms> ListOfBookedRooms => _brooms;
}
