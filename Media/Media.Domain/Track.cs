namespace Media.Domain;

public class Track
{
	public int Number { get; set; }
	public string Name { get; set; } = "";
	public Albom Albom{ get; set; }
	public int Duration { get; set; }
}
