namespace HotelBookingSystem.Server.Dto;

public class LodgerPostDto
{
    public int Passport { get; set; }

    public string Name { get; set; } = string.Empty;

    public DateTime Birthdate { get; set; }
}
