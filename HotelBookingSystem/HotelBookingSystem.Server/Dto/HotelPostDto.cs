namespace HotelBookingSystem.Server.Dto;

/// <summary>
/// DTO for using POST methods for the Hotel class
/// </summary>
public class HotelPostDto
{
    /// <summary>
    /// The name of the hotel
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// The city where hotel is located
    /// </summary>
    public string City { get; set; } = string.Empty;

    /// <summary>
    /// The adress where hotel is located
    /// </summary>
    public string Adress { get; set; } = string.Empty;
}
