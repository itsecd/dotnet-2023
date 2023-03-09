namespace Library.Domain;

/// <summary>
/// Class Card is used to store info about the cards on the books
/// </summary>
public class Card
{
    /// <summary>
    /// Id stores card's id
    /// </summary>
    public int Id { set; get; }
    /// <summary>
    /// DateOfIssue stores date of taking the book
    /// </summary>
    public DateTime DateOfIssue { set; get; }
    /// <summary>
    /// DateOfReturn stores date of returning the book
    /// </summary>
    public DateTime DateOfReturn { set; get; }
    /// <summary>
    /// DayCount stores the number of days for which the book was taken
    /// </summary>
    public int DayCount { set; get; }
    /// <summary>
    /// IdBooks stores list of book's id
    /// </summary>
    public List<Book> IdBooks { set; get; } = new List<Book>();
    /// <summary>
    /// IdReader stores list of reader's id
    /// </summary>
    public List<Reader> IdReader { set; get; } = new List<Reader>();
}
