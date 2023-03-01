namespace Media.Domain;

/// <summary>
/// Class Track is used to store information of the track
/// </summary>
public class Track
{
    /// <summary>
    /// TrackId is used to store a unique identifer
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
    /// Album is used to store the album this track is in
    /// </summary>
    public Album Album { get; set; }

    /// <summary>
    /// Duration is used to store the duration of this track
    /// </summary>
    public int Duration { get; set; }
}
