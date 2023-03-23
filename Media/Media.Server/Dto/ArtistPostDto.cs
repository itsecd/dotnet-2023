namespace Media.Server.Dto;

/// <summary>
/// Class ArtistPostDto is used to make POST and PUT HTTP-requests.
/// </summary>
public class ArtistPostDto
{
    /// <summary>
    /// Name is used to store a name of artist
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Description is used to store description of the artist
    /// </summary>
    public string Description { get; set; }
}
