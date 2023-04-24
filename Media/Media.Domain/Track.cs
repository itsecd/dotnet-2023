using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Media.Domain;

/// <summary>
/// Class Track is used to store information of the track
/// </summary>
public class Track
{
    /// <summary>
    /// Id is used to store a unique identifier
    /// </summary>
    [Key]
    public int Id { get; set; }

    /// <summary>
    /// Number is used to store the track number in the album
    /// </summary>
    [Required]
    public int Number { get; set; }

    /// <summary>
    /// Name is used to store a name of track
    /// </summary>
    [Required]
    public string Name { get; set; }

    /// <summary>
    /// AlbumId is used to store the id of the album this track is in
    /// </summary>
    [ForeignKey("Album")]
    public int AlbumId { get; set; }

    /// <summary>
    /// Duration is used to store the duration of this track
    /// </summary>
    [Required]
    public int Duration { get; set; }
}
