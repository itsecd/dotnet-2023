namespace PonrfServer.Dto;

/// <summary>
/// AuctionPostDto for HTTP GET request
/// </summary>
public class AuctionGetDto
{
    /// <summary>
    /// Id is an identifier of auction
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// Date is date of holding of the auction
    /// </summary>
    public DateTime Date { get; set; } = DateTime.MinValue;
    /// <summary>
    /// Organizer is a auction company 
    /// </summary>
    public string Organizer { get; set; } = string.Empty;
}