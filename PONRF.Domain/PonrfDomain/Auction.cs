namespace PonrfDomain;
/// <summary>
/// BookedRoomType describes booked room in hotel
/// </summary>
public class Auction
{
    /// <summary>
    /// IDAuction is a identifier of auction
    /// </summary>
    public int IDAuction { get; set; } = int.MinValue;
    /// <summary>
    /// Date is date of holding of the auction
    /// </summary>
    public DateTime Date { get; set; } = DateTime.MinValue;
    /// <summary>
    /// Organizer is a auction company 
    /// </summary>
    public string Organizer { get; set; } = string.Empty;
    public List<Lot> Lot { set; get; } = new List<Lot>();

    public Auction() { }
    public Auction(int iDAuction, DateTime date, string organizer, List<Lot> lot)
    {
        IDAuction = iDAuction;
        Date = date;
        Organizer = organizer;
        Lot = lot;
    }
}