namespace Media.Domain;

/// <summary>
/// Class Album is used to store information of the Album
/// </summary>
public class Album
{
    /// <summary>
    /// Id is used to store a unique identifer
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Name is used to store a name of Album
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Year is used to store the year the Album was created
    /// </summary>
    public int Year { get; set; }

    /// <summary>
    /// Tracks is used to store a list of tracks
    /// </summary>
    public List<Track> Tracks { get; set; } = new List<Track>();

    /// <summary>
    /// Genre is used to store information of the genre of the album
    /// </summary>
    public Genre Genre { get; set; } = new Genre();
}
