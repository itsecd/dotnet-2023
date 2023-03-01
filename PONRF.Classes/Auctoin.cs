namespace PONRF.Classes;

/// <summary>
/// BookedRoomType describes booked room in hotel
/// </summary>
public class Auctoin
{
    /// <summary>
    /// Auction is a identifier of auction
    /// </summary>
    public guid Auction { get; set; } = guid.Empty;
    /// <summary>
    /// Date is date of holding of the auction
    /// </summary>
    public DateTime Date { get; set; } = DateTime.MinValue;
    /// <summary>
    /// Organizer is a auction company 
    /// </summary>
    public string Organizer { get; set; } = string.Empty;
    public List<Lot> Lot { set; get; };

    public Auction() { }
}