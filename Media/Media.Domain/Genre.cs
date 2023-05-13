using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Media.Domain;

/// <summary>
/// Class Genre is used to store information of the genre
/// </summary>
public class Genre
{
    /// <summary>
    /// Id is used to store a unique identifier 
    /// </summary>
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    /// <summary>
    /// Name is used to store a name of genre
    /// </summary>
    [Required]
    public string Name { get; set; }
}
