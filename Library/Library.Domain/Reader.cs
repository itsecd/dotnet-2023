using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Domain;

/// <summary>
/// Class Reader is used to store info about readers
/// </summary>
[Table("reader")]
public class Reader
{
    /// <summary>
    /// Id stores reader's id
    /// </summary>
    [Column("id")]
    public int Id { set; get; }
    /// <summary>
    /// FullName stores reader's fullname
    /// </summary>
    [Column("full_name")]
    public string FullName { set; get; } = string.Empty;
    /// <summary>
    /// Address stores reader's address
    /// </summary>
    [Column("address")]
    public string Address { set; get; } = string.Empty;
    /// <summary>
    /// Phone stores reader's phone number
    /// </summary>
    [Column("phone")]
    public string Phone { set; get; } = string.Empty;
    /// <summary>
    /// RegistrationDate stores reader's registration date
    /// </summary>
    [Column("registration_date")]
    public DateTime RegistrationDate { set; get; }
    /// <summary>
    /// Cards stores list of cards
    /// </summary>
    public List<Card> Cards { set; get; } = new List<Card>();
}
