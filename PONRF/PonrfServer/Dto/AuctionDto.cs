using PonrfDomain;

namespace PonrfServer.Dto;

public class AuctionDto
{
    public int Id { get; set; }
    public DateTime Date { get; set; } = DateTime.MinValue;
    public string Organizer { get; set; } = string.Empty;
}