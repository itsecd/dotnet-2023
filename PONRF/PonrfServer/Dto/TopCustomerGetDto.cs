namespace PonrfServer.Dto;

/// <summary>
/// TopCustomerGetDto for request TopFiveCustomers
/// </summary>
public class TopCustomerGetDto
{
    /// <summary>
    /// FIO contains information about full name of customer
    /// </summary>  
    public string Fio { get; set; } = string.Empty;
    /// <summary>
    /// Total is amount of all purchased buildings
    /// </summary>
    public int Total { get; set; }
}
