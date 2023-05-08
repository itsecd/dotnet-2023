namespace BikeRental.Domain;

/// <summary>
/// Class CLient has the info about a client who rented bikes
/// </summary>
public class Client
{
    /// <summary>
    /// Id of a client
    /// </summary>
    public int Id { get; set; }

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
