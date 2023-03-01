namespace Media.Domain;

/// <summary>
/// Class Genre is used to store information of the genre
/// </summary>
public class Genre
{
    /// <summary>
    /// GenreId is used to store a unique identifier 
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Name is used to store a name of genre
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Tracks is used to store a list of tracks of that genre
    /// </summary>
	public List<Track> Tracks { get; set; }
}
