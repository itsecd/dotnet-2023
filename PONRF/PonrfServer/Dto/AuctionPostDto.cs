namespace PonrfServer.Dto;

/// <summary>
/// AuctionPostDto for HTTP POST request
/// </summary>
public class AuctionPostDto
{
    /// <summary>
    /// Date is date of holding of the auction
    /// </summary>
    public DateTime Date { get; set; } = DateTime.MinValue;
    /// <summary>
    /// Organizer is a auction company 
    /// </summary>
    public string Organizer { get; set; } = string.Empty;
}