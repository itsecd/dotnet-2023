using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Domain;

/// <summary>
/// Class Book is used to store info about the books
/// </summary>
[Table("book")]
public class Book
{
    /// <summary>
    /// Id stores book's id
    /// </summary>
    [Column("id")]
    public int Id { set; get; }
    /// <summary>
    /// Cipher stores cipher of the book
    /// </summary>
    [Column("cipher")]
    public string Cipher { set; get; } = string.Empty;
    /// <summary>
    /// Author stores last name and initials of the author
    /// </summary>
    [Column("author")]
    public string Author { set; get; } = string.Empty;
    /// <summary>
    /// Name stores name of the book
    /// </summary>
    [Column("name")]
    public string Name { set; get; } = string.Empty;
    /// <summary>
    /// PlaceEdition stores place where book was published
    /// </summary>
    [Column("place_edition")]
    public string PlaceEdition { set; get; } = string.Empty;
    /// <summary>
    /// YearEdition stores year of book's publication
    /// </summary>
    [Column("year_edition")]
    public int YearEdition { set; get; }
    /// <summary>
    /// TypeEditionId stores id of type book
    /// </summary>
    [Column("type_edition_id")]
    public int TypeEditionId { set; get; }
    /// <summary>
    /// IsIssued stores information about whether a book has been issued
    /// </summary>
    [Column("is_issued")]
    public bool IsIssued { set; get; }
    /// <summary>
    /// Cards stores list of cards about the book
    /// </summary>
    public List<Card> Cards { set; get; } = new List<Card>();
    /// <summary>
    /// Departments stores list of departments holding the book
    /// </summary>
    public List<Department> Departments { set; get; } = new List<Department>();
}
