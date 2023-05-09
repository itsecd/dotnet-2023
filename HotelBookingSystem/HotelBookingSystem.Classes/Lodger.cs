using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBookingSystem.Classes;

/// <summary>
/// Class that contains info about hotel
/// </summary>
[Table("lodger")]
public class Lodger
{
    /// <summary>
    /// Lodger id
    /// </summary>
    [Column("id")]
    public int Id { get; set; }

    /// <summary>
    /// The number of passport of the lodger
    /// </summary>
    [Column("passport")]
    public int Passport { get; set; }

    /// <summary>
    /// The name of the lodger
    /// </summary>
    [Column("name")]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// The bithdate of the lodger
    /// </summary>
    [Column("birthdate")]
    public DateTime Birthdate { get; set; }

    /// <summary>
    /// The collection of BookedRooms objects
    /// </summary>
    public List<BookedRooms> Brooms { get; set; } = null!;
}
