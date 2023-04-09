namespace Library.Domain;

/// <summary>
/// Class Department is used to store info about departments
/// </summary>
public class Department
{
    /// <summary>
    /// Id stores department's id
    /// </summary>
    public int Id { set; get; }
    /// <summary>
    /// Count stores count of books in department
    /// </summary>
    public int Count { set; get; }
    /// <summary>
    /// BooksId stores book's id
    /// </summary>
    public int BooksId { set; get; }
    /// <summary>
    /// Books stores list of books
    /// </summary>
    public List<Book> Books { set; get; } = new List<Book>();
    /// <summary>
    /// TypeDepartmentsId stores department's id
    /// </summary>
    public int TypeDepartmentsId { set; get; }
    /// <summary>
    /// TypeDepartments stores list of types department
    /// </summary>
    public List<TypeDepartment> TypeDepartments { set; get; } = new List<TypeDepartment>();
}
