namespace PonrfServer.Dto;

/// <summary>
/// TopAuctionGetDto for request MostProfitableAuctions
/// </summary>
public class TopAuctionGetDto
{
    /// <summary>
    /// Organizer is a auction company 
    /// </summary>
    public string Organizer { get; set; } = string.Empty;
    /// <summary>
    /// Profit is a difference between the amount auction spent in buying and the amount earned 
    /// </summary>
    public int Profit { get; set; }
}
