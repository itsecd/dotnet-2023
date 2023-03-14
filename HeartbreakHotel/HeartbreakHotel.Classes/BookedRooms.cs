namespace HeartbreakHotel;
public class BookedRooms
{
    public Hotel BookedHotel { get; set; }

    public Room BookedRoom { get; set; }

    public Lodger Booker { get; set; }

    public DateTime EntryDate { get; set; }

    public DateTime BookingTerm { get; set; }

    public DateTime DepartureDate { get; set; }

    public BookedRooms (Hotel bookedHotel, Room bookedRoom, Lodger booker, DateTime entryDate, DateTime bookingTerm, DateTime departureDate)
    {
        BookedHotel= bookedHotel;
        BookedRoom = bookedRoom;
        Booker = booker;
        EntryDate = entryDate;
        BookingTerm = bookingTerm;
        DepartureDate = departureDate;
    }
}
