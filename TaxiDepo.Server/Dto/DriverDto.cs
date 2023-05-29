namespace TaxiDepo.Server.Dto;

/// <summary>
/// Dto driver class
/// </summary>
public class DriverDto
{
    /// <summary>
    /// Driver id
    /// </summary>
    public int Id { get; set; } = 0;

    /// <summary>
    /// Driver surname
    /// </summary>
    public string DriverSurname { get; set; } = string.Empty;

    /// <summary>
    /// Driver name
    /// </summary>
    public string DriverName { get; set; } = string.Empty;

    /// <summary>
    /// Driver patronymic
    /// </summary>
    public string DriverPatronymic { get; set; } = string.Empty;

    /// <summary>
    /// Driver passport ID
    /// </summary>
    public int DriverPassportId { get; set; } = 0;

    /// <summary>
    /// Driver address
    /// </summary>
    public string DriverAddress { get; set; } = string.Empty;

    /// <summary>
    /// Driver phone number
    /// </summary>
    public string DriverPhoneNumber { get; set; } = string.Empty;

    /// <summary>
    /// Driver amount rides  
    /// </summary>
    public int AmountRides { get; set; }
}

