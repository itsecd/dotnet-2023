using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Domain;

/// <summary>
/// Class Card is used to store info about the cards on the books
/// </summary>
[Table("card")]
public class Card
{
    /// <summary>
    /// Id stores card's id
    /// </summary>
    [Column("id")]
    public int Id { set; get; }
    /// <summary>
    /// DateOfIssue stores date of taking the book
    /// </summary>
    [Column("date_of_issue")]
    public DateTime DateOfIssue { set; get; }
    /// <summary>
    /// DateOfReturn stores date of returning the book
    /// </summary>
    [Column("date_of_return")]
    public DateTime DateOfReturn { set; get; }
    /// <summary>
    /// DayCount stores the number of days for which the book was taken
    /// </summary>
    [Column("day_count")]
    public int DayCount { set; get; }
    /// <summary>
    /// BooksId stores book's id
    /// </summary>
    [Column("book_id")]
    public int BookId { set; get; }
    /// <summary>
    /// ReaderId stores reader's id
    /// </summary>
    [Column("reader_id")]
    public int ReaderId { set; get; }
}
