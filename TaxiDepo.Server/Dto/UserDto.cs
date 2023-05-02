namespace TaxiDepo.Server.Dto;

/// <summary>
/// Dto user class
/// </summary>
public class UserDto
{
    /// <summary>
    /// User id
    /// </summary>
    public int Id { get; set; } = 0;

    /// <summary>
    /// User surname
    /// </summary>
    public string UserSurname { get; set; } = string.Empty;

    /// <summary>
    /// User name
    /// </summary>
    public string UserName { get; set; } = string.Empty;

    /// <summary>
    /// User patronymic
    /// </summary>
    public string UserPatronymic { get; set; } = string.Empty;

    /// <summary>
    /// User phone number
    /// </summary>
    public string UserPhoneNumber { get; set; } = string.Empty;
}