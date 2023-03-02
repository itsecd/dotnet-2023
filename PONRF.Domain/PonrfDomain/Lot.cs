namespace PonrfDomain;

/// <summary>
/// Class Lot describes connection between building and auction
/// </summary>
public class Lot
{
    public Auction? Auction { get; set; } = new();
    public Building? Building { get; set; }  = new();
}