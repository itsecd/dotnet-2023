namespace HotelBookingSystem.Server.Dto;

/// <summary>
/// DTO for using GET methods for the Hotel class
/// </summary>
public class HotelGetDto
{
    /// <summary>
    /// Hotel id
    /// </summary>
    public int Id { get; set; }

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
