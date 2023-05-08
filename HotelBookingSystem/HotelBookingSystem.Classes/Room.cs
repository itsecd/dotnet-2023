using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBookingSystem.Classes;

[Table("room")]
public class Room
{
    [Column("id")]
    public int Id { get; set; }

    [Column("typeOfRoom")]
    public string TypeOfRoom { get; set; } = string.Empty;

    [Column("numberOfRooms")]
    public int NumberOfRooms { get; set; }

    [Column("cost")]
    public int Cost { get; set; }

    public Hotel Placement { get; set; } = null!;

    [Column("placementId")]
    public int PlacementId { get; set; }

    public List<BookedRooms> Brooms { get; set; } = null!;
}
