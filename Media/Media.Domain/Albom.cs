namespace Media.Domain;


/// <summary>
/// Class Albom is used to store information of the albom
/// </summary>
public class Albom
{
    /// <summary>
    /// AlbomId is used to store a unique identifer
    /// </summary>
    public int AlbomId { get; set; }

    /// <summary>
    /// Name is used to store a name of albom
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Year is used to store the year the albom was created
    /// </summary>
    public int Year { get; set; }

    /// <summary>
    /// Artist is used to store the artist this albom belongs to
    /// </summary>
    public Artist Artist { get; set; }// = null;
}
