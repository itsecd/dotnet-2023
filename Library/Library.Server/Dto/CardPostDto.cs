namespace Library.Server.Dto;
/// <summary>
/// Class CardPostDto is used to store info about the cards on the books
/// </summary>
public class CardPostDto
{
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
    public int BooksId { set; get; }
    /// <summary>
    /// ReaderId stores reader's id
    /// </summary>
    public int ReaderId { set; get; }
}