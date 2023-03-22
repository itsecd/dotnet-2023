using Media.Domain;

namespace Media.Server.Dto;

/// <summary>
/// Class ArtistGetDto is used to make GET HTTP-requests.
/// </summary>
public class ArtistGetDto
{
    /// <summary>
    /// Id is used to store a unique identifier 
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Name is used to store a name of artist
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Description is used to store description of the artist
    /// </summary>
    public string Description { get; set; }
}
