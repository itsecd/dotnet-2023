namespace PonrfDomain;
/// <summary>
/// Class Auction describes an auction
/// </summary>
public class Auction
{
    /// <summary>
    /// Id is a identifier of auction
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
    public List<PrivatizedBuilding> PrivatizedBuilding { set; get; } = new List<PrivatizedBuilding>();

    public Auction() { }
    public Auction(int id, DateTime date, string organizer, List<PrivatizedBuilding> privatizedBuilding)
    {
        Id = id;
        Date = date;
        Organizer = organizer;
        PrivatizedBuilding = privatizedBuilding;
    }
}