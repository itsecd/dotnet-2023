namespace TransportMgmtServer.Dto;

public class DriverPostDto
{
    /// <summary>
    /// First name of driver
    /// </summary>
    public string FirstName { get; set; } = string.Empty;
    /// <summary>
    /// Last name of driver
    /// </summary>
    public string LastName { get; set; } = string.Empty;
    /// <summary>
    /// Middle name of driver
    /// </summary>
    public string MiddleName { get; set; } = string.Empty;
    /// <summary>
    /// Driver's passport number
    /// </summary>
    public int Passport { get; set; } = 0;
    /// <summary>
    /// Driver's license number
    /// </summary>
    public int DriverLicense { get; set; } = 0;
    /// <summary>
    /// Driver's address
    /// </summary>
    public string Address { get; set; } = string.Empty;
    /// <summary>
    /// Driver's phone number
    /// </summary>
    public string PhoneNumber { get; set; } = string.Empty;
}
