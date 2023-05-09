namespace HotelBookingSystem.Server.Dto;

/// <summary>
/// DTO for using POST methods for the Room class
/// </summary>
public class RoomPostDto
{
    /// <summary>
    /// The type of room
    /// </summary>
    public string TypeOfRoom { get; set; } = string.Empty;

    /// <summary>
    /// The number of rooms of this type
    /// </summary>
    public int NumberOfRooms { get; set; }

    /// <summary>
    /// The cost of the room
    /// </summary>
    public int Cost { get; set; }

    /// <summary>
    /// Hotel id stored in Room class
    /// </summary>
    public int PlacementId { get; set; }
}
