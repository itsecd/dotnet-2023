namespace Taxi.Server.Dto;

public class PassengerGetDto
{
    /// <summary>
    ///     Id - unique identifier of the passenger
    /// </summary>
    public ulong Id { get; set; }

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