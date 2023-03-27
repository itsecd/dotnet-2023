namespace RentalService.Domain;

/// <summary>
/// the Client class stores information about the client
/// </summary>
public class Client
{
    /// <summary>
    /// Id - unique client ID
    /// </summary>
    public ulong Id { get; set; }

    /// <summary>
    /// LastName - information about the client's last name
    /// </summary>
    public string LastName { get; set; } = string.Empty;
    
    /// <summary>
    /// FirstName - information about the client's first name
    /// </summary>
    public string FirstName { get; set; } = string.Empty;
    
    /// <summary>
    /// Patronymic - information about the client's patronymic
    /// </summary>
    public string Patronymic { get; set; } = string.Empty;

    /// <summary>
    /// BirthDate - date and time of birth
    /// </summary>
    public DateTime BirthDate { get; set; } = DateTime.MinValue;

    /// <summary>
    /// Passport - passport series and number
    /// </summary>
    public string Passport { get; set; } = string.Empty;

    /// <summary>
    /// RentedCars stores all records of rented cars
    /// </summary>
    public List<IssuedCar> RentedCars { get; set; } = new();
}