namespace HotelBookingSystem.Server.Dto;

/// <summary>
/// DTO for using GET methods for the BookedRooms class
/// </summary>
public class BookedRoomsGetDto
{
    /// <summary>
    /// BookedRooms id
    /// </summary>
    public int Id { get; set; }

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
    public DateTime EntryDate { get; set; }

    /// <summary>
    /// The date on which booking ends
    /// </summary>
    public DateTime BookingTerm { get; set; }

    /// <summary>
    /// The date on which the lodger departed from the room
    /// </summary>
    public DateTime DepartmentDate { get; set; }
}
