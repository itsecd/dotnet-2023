namespace HotelBookingSystem.Server.Dto;

public class RoomGetDto
{
    public int Id { get; set; }

    public string TypeOfRoom { get; set; } = string.Empty;

    public int NumberOfRooms { get; set; }

    public int Cost { get; set; }

    public int PlacementId { get; set; }
}
