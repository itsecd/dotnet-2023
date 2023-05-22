namespace BikeRental.Server.Dto;

/// <summary>
/// Class CLientSetDto has the info about a client who rented bikes
/// </summary>
public class ClientSetDto
{
    /// <summary>
    /// A full name of a client
    /// </summary>
    public string FullName { get; set; } = string.Empty;

    /// <summary>
    /// Client's year of birth
    /// </summary>
    public int BirthYear { get; set; }

    /// <summary>
    /// Client's phone number
    /// </summary>
    public string PhoneNumber { get; set; } = string.Empty;
}
