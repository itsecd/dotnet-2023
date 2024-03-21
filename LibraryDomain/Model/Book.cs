namespace Library.Domain;

/// <summary>
/// Модель книги
/// </summary>
public class Book
{
    /// <summary>
    /// Идентификатор книги
    /// </summary>
    public int Id { set; get; }

    /// <summary>
    /// Шифр в алфавитном каталоге
    /// </summary>
    public string Cipher { set; get; } = string.Empty;
    
    /// <summary>
    /// Фамилия и инициалы
    /// </summary>
    public string Author { set; get; } = string.Empty;
    
    /// <summary>
    /// Название книги
    /// </summary>
    public string Name { set; get; } = string.Empty;
    
    /// <summary>
    /// Место издания
    /// </summary>
    public string PlaceEdition { set; get; } = string.Empty;
    
    /// <summary>
    /// Год издания
    /// </summary>
    public int YearEdition { set; get; }

    /// <summary>
    /// Идентификатор записи в таблице TypeEdition
    /// </summary>
    public int TypeEditionId { set; get; }
    
    /// <summary>
    /// Тип издания книги
    /// </summary>
    public TypeEdition TypeEdition { set; get; } = null!;
    
    /// <summary>
    /// Список карточек с информацией о книге
    /// </summary>
    public List<Card> Cards { set; get; } = new List<Card>();
    
    /// <summary>
    /// Список отделов, в которых хранится книга
    /// </summary>
    public List<Department> Departments { set; get; } = new List<Department>();
}
