﻿namespace HotelBookingSystem.Classes;
public class Lodger
{
    public int Id { get; set; }

    public int Passport { get; set; }

    public string Name { get; set; } = string.Empty;

    public DateTime Birthdate { get; set; }

    public List<BookedRooms> Brooms { get; set; } = null!;
}
