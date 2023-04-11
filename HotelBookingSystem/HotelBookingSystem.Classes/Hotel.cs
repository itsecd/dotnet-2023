﻿namespace HotelBookingSystem.Classes;
public class Hotel
{
    public int Id { get; set; }
    
    public string Name { get; set; } = string.Empty;

    public string City { get; set; } = string.Empty;

    public string Adress { get; set; } = string.Empty;

    public List<Room> RoomList { get; set; } = null!;
}
