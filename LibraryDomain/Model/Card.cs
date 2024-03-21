namespace Library.Domain;

/// <summary>
/// Карточка книги
/// </summary>
public class Card
{
    /// <summary>
    /// Идентификатор карточки
    /// </summary>
    public int Id { set; get; }
    
    /// <summary>
    /// Дата выдачи книги
    /// </summary>
    public DateTime DateIssue { set; get; }
    
    /// <summary>
    /// Дата возврата книги
    /// </summary>
    public DateTime DateReturn { set; get; }

    /// <summary>
    /// Количество дней, на которые выдана книга
    /// </summary>
    public int DayCount { set; get; }
    
    /// <summary>
    /// Идентификатор книги
    /// </summary>
    public int BookId { set; get; }
    
    /// <summary>
    /// Внешний ключ для таблицы книг
    /// </summary>
    public Book Book { set; get; } = null!;
    
    /// <summary>
    /// Идентификатор для связи с записью таблицы читателей
    /// </summary>
    public int ReaderId { set; get; }
    
    /// <summary>
    /// Внешний ключ для таблицы читателей
    /// </summary>
    public Reader Reader { set; get; } = null!;
}
