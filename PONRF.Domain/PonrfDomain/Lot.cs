namespace PonrfDomain;

/// <summary>
/// Class Lot describes connection between building and auction
/// </summary>
public class Lot
{
    public int Auction { get; set; } = new();
    public int Building { get; set; }  = new();

    public Lot() { }
    public Lot( int auction, int building)
    {
        Auction = auction;
        Building = building;
    }
}