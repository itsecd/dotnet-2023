namespace Taxi.Server.Dto;

public class InfosAboutRidesGetDto
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
    ///     Count - count driver rides
    /// </summary>
    public int Count { get; set; }
    
    /// <summary>
    ///     AverageTime - average time of driver's rides
    /// </summary>
    public string AverageTime { get; set; } = string.Empty;
    
    /// <summary>
    ///     MaxTime - max time of driver's rides
    /// </summary>
    public string MaxTime { get; set; } = string.Empty;
}