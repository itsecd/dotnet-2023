namespace Taxi.Domain;

/// <summary>
///     Driver - a class that stores information about the driver of the vehicle
/// </summary>
public class Driver
{
    /// <summary>
    ///     Id - unique identifier of the driver
    /// </summary>
    public UInt64 Id { get; set; }

    /// <summary>
    ///     FirstName - first name of the driver
    /// </summary>
    public string FirstName { get; set; } = String.Empty;

    /// <summary>
    ///     LastName - last name of the driver
    /// </summary>
    public string LastName { get; set; } = String.Empty;

    /// <summary>
    ///     Patronymic - patronymic of the driver
    /// </summary>
    public string? Patronymic { get; set; }

    /// <summary>
    ///     Passport - a unique sequence of digits that are the series and number of the passport
    /// </summary>
    public string Passport { get; set; } = String.Empty;

    /// <summary>
    ///     PhoneNumber - mobile phone number registered to the driver
    /// </summary>
    public string PhoneNumber { get; set; } = String.Empty;
}