namespace Library.Domain;
public class Book
{
    public int Id { set; get; }

    public string Chiper { set; get; } = string.Empty;

    public string Autor { set; get; } = string.Empty;

    public string Name { set; get; } = string.Empty;

    public string PlaceEdition { set; get; } = string.Empty;

    public int YearEdition { set; get; }

    public List<TypeEdition> IdEdition { set; get; } = new List<TypeEdition>();
}
