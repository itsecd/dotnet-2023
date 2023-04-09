namespace PonrfServer.Dto;

/// <summary>
/// AuctionPostDto for HTTP POST request
/// </summary>
public class CustomerPostDto
{
    /// <summary>
    /// Passport contains information about passport's number of customer
    /// </summary>
    public string Passport { get; set; } = string.Empty;
    /// <summary>
    /// FIO contains information about full name of customer
    /// </summary>  
    public string Fio { get; set; } = string.Empty;
    /// <summary>
    /// Address contains information about home address of customer
    /// </summary>
    public string Address { get; set; } = string.Empty;
}