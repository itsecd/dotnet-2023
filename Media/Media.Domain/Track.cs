namespace Media.Domain;

public class Track
{
	public int TrackId { get; set; }
	public int Number { get; set; }
	public string Name { get; set; } = string.Empty;
	public Albom Albom{ get; set; }
	public int Duration { get; set; }
}
