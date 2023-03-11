namespace PonrfDomain;

/// <summary>
/// Class Lot describes connection between building and auction
/// </summary>
public class Lot
{
    public int Id { get; set; } = int.MinValue;
    public Auction? Auction { get; set; } = new();
    public Building? Building { get; set; }  = new();

    public Lot() { }
    public Lot(int id, Auction? auction, Building? building)
    {
        Id = id;
        Auction = auction;
        Building = building;
    }
}