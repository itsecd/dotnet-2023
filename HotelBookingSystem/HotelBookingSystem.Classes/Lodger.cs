using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBookingSystem.Classes;

[Table("lodger")]
public class Lodger
{
    [Column("id")]
    public int Id { get; set; }

    [Column("passport")]
    public int Passport { get; set; }

    [Column("name")]
    public string Name { get; set; } = string.Empty;

    [Column("birthdate")]
    public DateTime Birthdate { get; set; }

    public List<BookedRooms> Brooms { get; set; } = null!;
}
