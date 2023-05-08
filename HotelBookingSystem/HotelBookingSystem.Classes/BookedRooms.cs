using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBookingSystem.Classes;

[Table("booked_room")]
public class BookedRooms
{
    [Column("id")]
    public int Id { get; set; }

    public Lodger Client { get; set; } = null!;

    [Column("clientId")]
    public int ClientId { get; set; }

    public Room BookedRoom { get; set; } = null!;

    [Column("bookedRoomId")]
    public int BookedRoomId { get; set; }

    [Column("entryDate")]
    public DateTime EntryDate { get; set; }

    [Column("bookingTerm")]
    public DateTime BookingTerm { get; set; }

    [Column("departmentDate")]
    public DateTime DepartmentDate { get; set; }
}
