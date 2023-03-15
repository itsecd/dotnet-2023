namespace HotelBookingSystem.Classes;
public class BookedRooms
{
    public Lodger Client { get; set; }

    public Room BookedRoom { get; set; }

    public DateTime EntryDate { get; set; }

    public DateTime BookingTerm { get; set; }

    public DateTime DepartmentDate { get; set; }

    public BookedRooms (Lodger client, Room bookedRoom, DateTime entryDate, DateTime bookingTerm, DateTime departmentDate)
    {
        Client = client;
        BookedRoom = bookedRoom;
        EntryDate = entryDate;
        BookingTerm = bookingTerm;
        DepartmentDate = departmentDate;
        Client = client;
        BookedRoom = bookedRoom;
    }
}
