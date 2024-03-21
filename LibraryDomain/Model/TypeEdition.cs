namespace Library.Domain;

/// <summary>
/// Тип издания
/// </summary>
public class TypeEdition
{
    /// <summary>
    /// Идентификатор издания
    /// </summary>
    public int Id { set; get; }

    /// <summary>
    /// Название вида издания
    /// </summary>
    public string Name { set; get; } = string.Empty;
    
    /// <summary>
    /// Список книг данного вида
    /// </summary>
    public List<Book> Books { set; get; } = new List<Book>();
}
