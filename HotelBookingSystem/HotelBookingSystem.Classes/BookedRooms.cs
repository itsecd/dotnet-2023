﻿namespace HotelBookingSystem.Classes;
public class BookedRooms
{
    public int Id { get; set; }

    public Lodger Client { get; set; } = null!;

    public int ClientId { get; set; }

    public Room BookedRoom { get; set; } = null!;

    public int BookedRoomId { get; set; }

    public DateTime EntryDate { get; set; }

    public DateTime BookingTerm { get; set; }

    public DateTime DepartmentDate { get; set; }
}
