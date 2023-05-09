using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBookingSystem.Classes;

/// <summary>
/// Class that contains info about booked room
/// </summary>
[Table("booked_room")]
public class BookedRooms
{
    /// <summary>
    /// BookedRooms id
    /// </summary>
    [Column("id")]
    public int Id { get; set; }

    /// <summary>
    /// Lodger stored in BookedRooms class
    /// </summary>
    public Lodger Client { get; set; } = null!;

    /// <summary>
    /// Lodger id stored in BookedRooms class
    /// </summary>
    [Column("clientId")]
    public int ClientId { get; set; }

    /// <summary>
    /// Room stored in BookedRooms class
    /// </summary>
    public Room BookedRoom { get; set; } = null!;

    /// <summary>
    /// Room id stored in BookedRooms class
    /// </summary>
    [Column("bookedRoomId")]
    public int BookedRoomId { get; set; }

    /// <summary>
    /// The date on which the lodger booked the room
    /// </summary>
    [Column("entryDate")]
    public DateTime EntryDate { get; set; }

    /// <summary>
    /// The date on which booking ends
    /// </summary>
    [Column("bookingTerm")]
    public DateTime BookingTerm { get; set; }

    /// <summary>
    /// The date on which the lodger departed from the room
    /// </summary>
    [Column("departmentDate")]
    public DateTime DepartmentDate { get; set; }
}
