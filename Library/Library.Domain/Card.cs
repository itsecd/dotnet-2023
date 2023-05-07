using System.ComponentModel.DataAnnotations;
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
    [Key]
    public int Id { set; get; }
    /// <summary>
    /// DateOfIssue stores date of taking the book
    /// </summary>
    [Column("date_of_issue")]
    [Required]
    public DateTime DateOfIssue { set; get; }
    /// <summary>
    /// DateOfReturn stores date of returning the book
    /// </summary>
    [Column("date_of_return")]
    [Required]
    public DateTime DateOfReturn { set; get; }
    /// <summary>
    /// DayCount stores the number of days for which the book was taken
    /// </summary>
    [Column("day_count")]
    [Required]
    public int DayCount { set; get; }
    /// <summary>
    /// BooksId stores book's id
    /// </summary>
    [Column("book_id")]
    public int BookId { set; get; }
    /// <summary>
    /// Book is foreign key for Book table
    /// </summary>
    [ForeignKey("BookId")] public Book Book { set; get; } = null!;
    /// <summary>
    /// ReaderId stores reader's id
    /// </summary>
    [Column("reader_id")]
    public int ReaderId { set; get; }
    /// <summary>
    /// Reader is foreign key for Reader table
    /// </summary>
    [ForeignKey("ReaderId")] public Reader Reader { set; get; } = null!;
}
