namespace Taxi.Server.Dto;

public class DriverSetDto
{
    /// <summary>
    ///     FirstName - first name of the driver
    /// </summary>
    public string FirstName { get; set; } = string.Empty;

    /// <summary>
    ///     LastName - last name of the driver
    /// </summary>
    public string LastName { get; set; } = string.Empty;

    /// <summary>
    ///     Patronymic - patronymic of the driver
    /// </summary>
    public string? Patronymic { get; set; }

    /// <summary>
    ///     Passport - a unique sequence of digits that are the series and number of the passport
    /// </summary>
    public string Passport { get; set; } = string.Empty;

    /// <summary>
    ///     PhoneNumber - mobile phone number registered to the driver
    /// </summary>
    public string PhoneNumber { get; set; } = string.Empty;
}