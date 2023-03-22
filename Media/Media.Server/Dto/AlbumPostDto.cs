using Media.Domain;

namespace Media.Server.Dto;

public class AlbumPostDto
{
    /// <summary>
    /// Name is used to store a name of Album
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Year is used to store the year the Album was created
    /// </summary>
    public int Year { get; set; }

    /// <summary>
    /// GenreId is used to store a identifier of genre
    /// </summary>
    public int GenreId { get; set; }

    /// <summary>
    /// ArtistId is used to store identifier of artist
    /// </summary>
    public int ArtistId { get; set; }
}
