namespace Taxi.Domain;

/// <summary>
/// Passenger - a class that stores information about passenger 
/// </summary>
public class Passenger
{
    /// <summary>
    /// Id - unique identifier of the passenger
    /// </summary>
    public UInt64 Id { get; set; } 

    /// <summary>
    /// FirstName - first name of the passenger
    /// </summary>
    public string FirstName { get; set; } = String.Empty;
    
    /// <summary>
    /// LastName - last name of the passenger
    /// </summary>
    public string LastName { get; set; } = String.Empty;

    /// <summary>
    /// Patronymic - patronymic of the passenger
    /// </summary>
    public string? Patronymic { get; set; }
    
    /// <summary>
    /// PhoneNumber - mobile phone number registered to the passenger
    /// </summary>
    public string PhoneNumber { get; set; } = String.Empty;

    /// <summary>
    /// Rides - a list of the current passenger's rides
    /// </summary>
    public List<Ride> Rides { get; set; } = new List<Ride>();
    
}
