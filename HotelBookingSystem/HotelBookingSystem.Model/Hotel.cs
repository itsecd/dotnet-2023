using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBookingSystem.Model;

/// <summary>
/// Class that contains info about hotel
/// </summary>
[Table("hotel")]
public class Hotel
{
    /// <summary>
    /// Hotel id
    /// </summary>
    [Column("id")]
    public int Id { get; set; }

    /// <summary>
    /// The name of the hotel
    /// </summary>
    [Column("name")]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// The city where hotel is located
    /// </summary>
    [Column("city")]
    public string City { get; set; } = string.Empty;

    /// <summary>
    /// The adress where hotel is located
    /// </summary>
    [Column("adress")]
    public string Adress { get; set; } = string.Empty;

    /// <summary>
    /// The collection of Room objects
    /// </summary>
    public List<Room> RoomList { get; set; } = null!;
}
