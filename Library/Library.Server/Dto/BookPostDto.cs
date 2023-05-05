namespace Library.Server.Dto;
/// <summary>
/// Class BookPostDto is used to store info about the books
/// </summary>
public class BookPostDto
{
    /// <summary>
    /// Cipher stores cipher of the book
    /// </summary>
    public string Cipher { set; get; } = string.Empty;
    /// <summary>
    /// Author stores last name and initials of the author
    /// </summary>
    public string Author { set; get; } = string.Empty;
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
    /// TypeEditionId stores id of type book
    /// </summary>
    public int TypeEditionId { set; get; }
}