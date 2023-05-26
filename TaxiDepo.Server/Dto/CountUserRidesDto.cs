using TaxiDepo.Model;

namespace TaxiDepo.Server.Dto;

public class CountUserRidesDto
{
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
    public string? UserPatronymic { get; set; }

    /// <summary>
    /// Amount user rides
    /// </summary>
    public int AmountRides { get; set; }
}