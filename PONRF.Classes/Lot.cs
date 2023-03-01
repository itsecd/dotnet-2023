namespace PONRF.Classes;

/// <summary>
/// Class Lot describes connection between building and auction
/// </summary>
public class Lot
{
    public Auction? Auction { get; set; } = None;
    public RegistNumber? RegistNumber { get; set; } = None;
}