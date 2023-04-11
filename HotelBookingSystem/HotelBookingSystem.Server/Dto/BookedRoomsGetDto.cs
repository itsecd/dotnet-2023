namespace HotelBookingSystem.Server.Dto;

public class BookedRoomsGetDto
{
    public int Id { get; set; }

    public int ClientId { get; set; }

    public int BookedRoomId { get; set; }

    public DateTime EntryDate { get; set; }

    public DateTime BookingTerm { get; set; }

    public DateTime DepartmentDate { get; set; }
}
