namespace Taxi.Server.Dto;

public class PassengerPostDto
{
    /// <summary>
    ///     FirstName - first name of the passenger
    /// </summary>
    public string FirstName { get; set; } = string.Empty;

    /// <summary>
    ///     LastName - last name of the passenger
    /// </summary>
    public string LastName { get; set; } = string.Empty;

    /// <summary>
    ///     Patronymic - patronymic of the passenger
    /// </summary>
    public string? Patronymic { get; set; }

    /// <summary>
    ///     PhoneNumber - mobile phone number registered to the passenger
    /// </summary>
    public string PhoneNumber { get; set; } = string.Empty;
}