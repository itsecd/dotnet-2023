namespace Media.Domain;

public class Genre
{
	public int GenreId { get; set; }
	public string Name { get; set; } = string.Empty;
	public List<Track> Tracks { get; set; } 
}
