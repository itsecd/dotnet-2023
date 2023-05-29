using TaxiDepo.Model;

namespace TaxiDepo.Server.Dto;

/// <summary>
/// Driver car pair dto
/// </summary>
public class CarAndDriverDto
{
    /// <summary>
    /// Car id
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Car colour
    /// </summary>
    public string CarColour { get; set; } = string.Empty;

    /// <summary>
    /// Car number
    /// </summary>
    public string CarNumber { get; set; } = string.Empty;

    /// <summary>
    /// Car model
    /// </summary>
    public string CarModel { get; set; } = string.Empty;

    /// <summary>
    /// Driver id
    /// </summary>
    public int DriverId { get; set; }

    // <summary>
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
    public string? DriverPatronymic { get; set; }

    /// <summary>
    /// Driver passport id
    /// </summary>
    public string DriverPassportId { get; set; } = string.Empty;

    /// <summary>
    /// Driver phone number
    /// </summary>
    public string DriverPhoneNumber { get; set; } = string.Empty;

    /// <summary>
    /// Driver address
    /// </summary>
    public string DriverAddress { get; set; } = string.Empty;
}