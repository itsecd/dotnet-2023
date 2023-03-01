namespace Media.Domain;

public class Albom
{
    public int AlbomId { get; set; }

    public string Name { get; set; } = string.Empty;

    public int Year { get; set; }

    public Artist Artist { get; set; }// = null;
}
