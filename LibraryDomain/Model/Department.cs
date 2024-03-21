namespace Library.Domain;

/// <summary>
/// Отделы библиотеки
/// </summary>
public class Department
{
    /// <summary>
    /// Идентификатор отдела
    /// </summary>
    public int Id { set; get; }

    /// <summary>
    /// Количество книг в отделе
    /// </summary>
    public int Count { set; get; }
    
    /// <summary>
    /// Идентификатор для привязки с таблицей книг
    /// </summary>
    public int BookId { set; get; }
    
    /// <summary>
    /// Внешний ключ для таблицы книг
    /// </summary>
    public Book? Book { set; get; }

    /// <summary>
    /// Идентификатор для записи в таблице типов отдела
    /// </summary>
    public int TypeDepartmentId { set; get; }
    
    /// <summary>
    /// Внешний ключ для таблицы типов отдела
    /// </summary>
    public TypeDepartment? TypeDepartment { set; get; }
}
