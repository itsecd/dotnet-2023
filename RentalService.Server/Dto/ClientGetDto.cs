namespace RentalService.Server.Dto;

public class ClientGetDto
{
    /// <summary>
    ///     Id - unique client identifier
    /// </summary>
    public ulong Id { get; set; }

    /// <summary>
    ///     LastName - information about the client's last name
    /// </summary>
    public string LastName { get; set; } = string.Empty;

    /// <summary>
    ///     FirstName - information about the client's first name
    /// </summary>
    public string FirstName { get; set; } = string.Empty;

    /// <summary>
    ///     Patronymic - information about the client's patronymic
    /// </summary>
    public string Patronymic { get; set; } = string.Empty;

    /// <summary>
    ///     BirthDate - date and time of birth
    /// </summary>
    public DateTime BirthDate { get; set; } = DateTime.MinValue;

    /// <summary>
    ///     Passport - passport series and number
    /// </summary>
    public string Passport { get; set; } = string.Empty;
}