namespace Media.Domain;

/// <summary>
/// Class Track is used to store information of the track
/// </summary>
public class Track
{
    /// <summary>
    /// Id is used to store a unique identifer
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Number is used to store the track number in the album
    /// </summary>
    public int Number { get; set; }

    /// <summary>
    /// Name is used to store a name of track
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// AlbumId is used to store the id of the album this track is in
    /// </summary>
    public int AlbumId { get; set; }

    /// <summary>
    /// Duration is used to store the duration of this track
    /// </summary>
    public int Duration { get; set; }
}
