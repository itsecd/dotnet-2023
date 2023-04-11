namespace HotelBookingSystem.Server.Dto;

public class BookedRoomsPostDto
{
    public int ClientId { get; set; }

    public int BookedRoomId { get; set; }

    public DateTime EntryDate { get; set; }

    public DateTime BookingTerm { get; set; }

    public DateTime DepartmentDate { get; set; }
}
