namespace Library.Server.Dto;
/// <summary>
/// Class CardGetDto is used to store info about the cards on the books
/// </summary>
public class CardGetDto
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
    /// BooksId stores book's id
    /// </summary>
    public int BookId { set; get; }
    /// <summary>
    /// ReaderId stores reader's id
    /// </summary>
    public int ReaderId { set; get; }
}