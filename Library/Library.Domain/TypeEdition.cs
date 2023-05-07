using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Domain;

/// <summary>
/// Class TypeEdition is used to store info about types of books
/// </summary>
[Table("type_edition")]
public class TypeEdition
{
    /// <summary>
    /// Id stores type's id
    /// </summary>
    [Column("id")]
    [Key]
    public int Id { set; get; }
    /// <summary>
    /// Name stores name of the type
    /// </summary>
    [Column("name")]
    [Required]
    public string Name { set; get; } = string.Empty;
    /// <summary>
    /// Books stores list of books
    /// </summary>
    public List<Book> Books { set; get; } = new List<Book>();
}
