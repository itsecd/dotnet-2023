using System.ComponentModel.DataAnnotations;
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
    [Key]
    public int Id { set; get; }
    /// <summary>
    /// Cipher stores cipher of the book
    /// </summary>
    [Column("cipher")]
    [Required]
    public string Cipher { set; get; } = string.Empty;
    /// <summary>
    /// Author stores last name and initials of the author
    /// </summary>
    [Column("author")]
    [Required]
    public string Author { set; get; } = string.Empty;
    /// <summary>
    /// Name stores name of the book
    /// </summary>
    [Column("name")]
    [Required]
    public string Name { set; get; } = string.Empty;
    /// <summary>
    /// PlaceEdition stores place where book was published
    /// </summary>
    [Column("place_edition")]
    [Required]
    public string PlaceEdition { set; get; } = string.Empty;
    /// <summary>
    /// YearEdition stores year of book's publication
    /// </summary>
    [Column("year_edition")]
    [Required]
    public int YearEdition { set; get; }
    /// <summary>
    /// TypeEditionId stores id of type book
    /// </summary>
    [Column("type_edition_id")]
    public int TypeEditionId { set; get; }
    /// <summary>
    /// TypeEdition is foreign key for TypeEdition table
    /// </summary>
    [ForeignKey("TypeEditionId")] public TypeEdition TypeEdition { set; get; } = null!;
    /// <summary>
    /// Cards stores list of cards about the book
    /// </summary>
    public List<Card> Cards { set; get; } = new List<Card>();
    /// <summary>
    /// Departments stores list of departments holding the book
    /// </summary>
    public List<Department> Departments { set; get; } = new List<Department>();
}
