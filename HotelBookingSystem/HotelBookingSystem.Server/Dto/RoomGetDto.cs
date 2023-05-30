namespace HotelBookingSystem.Server.Dto;

/// <summary>
/// DTO for using GET methods for the Room class
/// </summary>
public class RoomGetDto
{
    /// <summary>
    /// Room id
    /// </summary>
    public int Id { get; set; }

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
