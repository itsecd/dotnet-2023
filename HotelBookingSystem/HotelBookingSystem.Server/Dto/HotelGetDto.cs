using HotelBookingSystem.Classes;

namespace HotelBookingSystem.Server.Dto;

public class HotelGetDto
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string City { get; set; } = string.Empty;

    public string Adress { get; set; } = string.Empty;

}
