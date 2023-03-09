namespace Library.Domain;

/// <summary>
/// Class Book is used to store info about the books
/// </summary>
public class Book
{
    /// <summary>
    /// Id stores book's id
    /// </summary>
    public int Id { set; get; }
    /// <summary>
    /// Cipher stores cipher of the book
    /// </summary>
    public string Cipher { set; get; } = string.Empty;
    /// <summary>
    /// Autor stores last name and initials of the author
    /// </summary>
    public string Autor { set; get; } = string.Empty;
    /// <summary>
    /// Name stores name of the book
    /// </summary>
    public string Name { set; get; } = string.Empty;
    /// <summary>
    /// PlaceEdition stores place where book was published
    /// </summary>
    public string PlaceEdition { set; get; } = string.Empty;
    /// <summary>
    /// YearEdition stores year of book's publication
    /// </summary>
    public int YearEdition { set; get; }
    /// <summary>
    /// IdTypeEdition stores list of id types book
    /// </summary>
    public List<TypeEdition> IdTypeEdition { set; get; } = new List<TypeEdition>();
}
