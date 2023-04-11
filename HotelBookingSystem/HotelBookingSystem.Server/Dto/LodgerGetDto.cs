namespace HotelBookingSystem.Server.Dto;

public class LodgerGetDto
{
    public int Id { get; set; }

    public int Passport { get; set; }

    public string Name { get; set; } = string.Empty;

    public DateTime Birthdate { get; set; }
}
