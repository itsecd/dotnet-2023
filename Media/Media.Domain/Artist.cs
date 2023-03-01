namespace Media.Domain;


/// <summary>
/// Class Artist is used to store information of the artist
/// </summary>
public class Artist
{
    /// <summary>
    /// ArtistId is used to store a unique identifier 
    /// </summary>
    public int ArtistId { get; set; }

    /// <summary>
    /// Name is used to store a name of artist
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Description is used to store description of the artist
    /// </summary>
    public string Description { get; set; } = string.Empty; //{ get; init; }
}
