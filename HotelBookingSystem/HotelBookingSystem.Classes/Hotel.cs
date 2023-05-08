using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBookingSystem.Classes;

[Table("hotel")]
public class Hotel
{
    [Column("id")]
    public int Id { get; set; }

    [Column("name")]
    public string Name { get; set; } = string.Empty;

    [Column("city")]
    public string City { get; set; } = string.Empty;

    [Column("adress")]
    public string Adress { get; set; } = string.Empty;

    public List<Room> RoomList { get; set; } = null!;
}
