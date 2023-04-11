﻿namespace HotelBookingSystem.Classes;
public class Room
{
    public int Id { get; set; }

    public string TypeOfRoom { get; set; } = string.Empty;

    public int NumberOfRooms { get; set; }

    public int Cost { get; set; }

    public Hotel Placement { get; set; } = null!;

    public int PlacementId { get; set; }

    public List<BookedRooms> Brooms { get; set; } = null!;
}
