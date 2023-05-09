namespace HotelBookingSystem.Server.Dto;

/// <summary>
/// DTO for using POST methods for the Lodger class
/// </summary>
public class LodgerPostDto
{
    /// <summary>
    /// The number of passport of the lodger
    /// </summary>
    public int Passport { get; set; }

    /// <summary>
    /// The name of the lodger
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// The bithdate of the lodger
    /// </summary>
    public DateTime Birthdate { get; set; }
}
