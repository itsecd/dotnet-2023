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
    public DateOnly DateOfIssue { set; get; }
    /// <summary>
    /// DateOfReturn stores date of returning the book
    /// </summary>
    public DateOnly DateOfReturn { set; get; }
    /// <summary>
    /// DayCount stores the number of days for which the book was taken
    /// </summary>
    public int DayCount { set; get; }
    /// <summary>
    /// BooksId stores book's id
    /// </summary>
    public int BooksId { set; get; }
    /// <summary>
    /// Books stores list of books
    /// </summary>
    public List<Book> Books { set; get; } = new List<Book>();
    /// <summary>
    /// ReaderId stores reader's id
    /// </summary>
    public int ReaderId { set; get; }
    /// <summary>
    /// Reader stores list of readers
    /// </summary>
    public List<Reader> Reader { set; get; } = new List<Reader>();
}
