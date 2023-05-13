using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Media.Domain;

/// <summary>
/// Class Artist is used to store information of the artist
/// </summary>
public class Artist
{
    /// <summary>
    /// Id is used to store a unique identifier 
    /// </summary>
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    /// <summary>
    /// Name is used to store a name of artist
    /// </summary>
    [Required]
    public string Name { get; set; }

    /// <summary>
    /// Description is used to store description of the artist
    /// </summary>
    [Required]
    public string Description { get; set; }

    /// <summary>
    /// Albums is used to store a list of albums of this artist
    /// </summary>
    public List<Album> Albums { get; set; }
}
