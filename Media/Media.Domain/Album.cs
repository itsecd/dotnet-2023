using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Media.Domain;

/// <summary>
/// Class Album is used to store information of the Album
/// </summary>
public class Album
{
    /// <summary>
    /// Id is used to store a unique identifier
    /// </summary>
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    /// <summary>
    /// Name is used to store a name of Album
    /// </summary>
    [Required]
    public string Name{ get; set; }

    /// <summary>
    /// Year is used to store the year the Album was created
    /// </summary>
    [Required]
    public int Year { get; set; }

    /// <summary>
    /// Tracks is used to store a list of tracks
    /// </summary>
    public List<Track> Tracks { get; set; }

    /// <summary>
    /// Genre is used to store information of the genre of the album
    /// </summary>
    public Genre Genre { get; set; }

    /// <summary>
    /// GenreId is used to store identifier of genre
    /// </summary>
    [ForeignKey("Genre")]
    public int GenreId { get; set; }

    /// <summary>
    /// ArtistId is used to store identifier of artist
    /// </summary>
    [ForeignKey("Artist")]
    public int ArtistId { get; set; }
}
