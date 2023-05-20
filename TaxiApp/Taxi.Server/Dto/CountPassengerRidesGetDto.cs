namespace Taxi.Server.Dto;

public class CountPassengerRidesGetDto
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
    ///     Count - count passenger rides
    /// </summary>
    public int Count { get; set; }
}