namespace TransportManagment.Server.Dto;
/// <summary>
/// Class of drivers for method Get
/// </summary>
public class DriverGetDto
{
    /// <summary>
    /// Id of driver
    /// </summary>
    public int DriverId { get; set; } = 0;
    /// <summary>
    /// First name of driver
    /// </summary>
    public string FirstName { get; set; } = string.Empty;
    /// <summary>
    /// Last name of driver
    /// </summary>
    public string LastName { get; set; } = string.Empty;
    /// <summary>
    /// Patronymic of driver
    /// </summary>
    public string Patronymic { get; set; } = string.Empty;
    /// <summary>
    /// Number of passport driver
    /// </summary>
    public int Passport { get; set; } = 0;
    /// <summary>
    /// Number of driver's card
    /// </summary>
    public int DriverCard { get; set; } = 0;
    /// <summary>
    /// Telephon number of driver
    /// </summary>
    public int Number { get; set; } = 0;
}
