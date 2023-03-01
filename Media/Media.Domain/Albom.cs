namespace Media.Domain;

/// <summary>
/// Class Album is used to store information of the Album
/// </summary>
public class Album
{
    /// <summary>
    /// AlbumId is used to store a unique identifer
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
    /// Artist is used to store the artist this Album belongs to
    /// </summary>
    public Artist Artist { get; set; }// = null;
}
