using System.ComponentModel.DataAnnotations;

namespace PonrfDomain;
/// <summary>
/// Class Auction describes an auction
/// </summary>
public class Auction
{
    /// <summary>
    /// Id is an identifier of auction
    /// </summary>
    [Key]
    public int Id { get; set; }
    /// <summary>
    /// Date is date of holding of the auction
    /// </summary>
    [Required]
    public DateTime Date { get; set; } = DateTime.MinValue;
    /// <summary>
    /// Organizer is a auction company 
    /// </summary>
    [Required]
    public string Organizer { get; set; } = string.Empty;
    /// <summary>
    /// List of all buildings on auction (lots)
    /// </summary>
    public List<PrivatizedBuilding> PrivatizedBuilding { get; set; }
}