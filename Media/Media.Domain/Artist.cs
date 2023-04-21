using System.ComponentModel.DataAnnotations;

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
    public int Id { get; set; }

    /// <summary>
    /// Name is used to store a name of artist
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Description is used to store description of the artist
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// Albums is used to store a list of albums of this artist
    /// </summary>
    public List<Album> Albums { get; set; }
}
