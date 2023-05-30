namespace HotelBookingSystem.Server.Dto;

/// <summary>
/// DTO for using POST methods for the BookedRooms class
/// </summary>
public class BookedRoomsPostDto
{
    /// <summary>
    /// Lodger id stored in BookedRooms class
    /// </summary>
    public int ClientId { get; set; }

    /// <summary>
    /// Room id stored in BookedRooms class
    /// </summary>
    public int BookedRoomId { get; set; }

    /// <summary>
    /// The date on which the lodger booked the room
    /// </summary>
    public DateTimeOffset EntryDate { get; set; }

    /// <summary>
    /// The date on which booking ends
    /// </summary>
    public DateTimeOffset BookingTerm { get; set; }

    /// <summary>
    /// The date on which the lodger departed from the room
    /// </summary>
    public DateTimeOffset DepartmentDate { get; set; }
}
