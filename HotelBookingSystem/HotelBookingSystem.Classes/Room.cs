using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBookingSystem.Classes;

[Table("room")]
public class Room
{
    /// <summary>
    /// Room id
    /// </summary>
    [Column("id")]
    public int Id { get; set; }

    /// <summary>
    /// The type of room
    /// </summary>
    [Column("typeOfRoom")]
    public string TypeOfRoom { get; set; } = string.Empty;

    /// <summary>
    /// The number of rooms of this type
    /// </summary>
    [Column("numberOfRooms")]
    public int NumberOfRooms { get; set; }

    /// <summary>
    /// The cost of the room
    /// </summary>
    [Column("cost")]
    public int Cost { get; set; }

    /// <summary>
    /// Hotel stored in Room class
    /// </summary>
    public Hotel Placement { get; set; } = null!;

    /// <summary>
    /// Hotel id stored in Room class
    /// </summary>
    [Column("placementId")]
    public int PlacementId { get; set; }

    /// <summary>
    /// The collection of BookedRooms objects
    /// </summary>
    public List<BookedRooms> Brooms { get; set; } = null!;
}
