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
    /// IdBooks stores list id of books
    /// </summary>
    public List<Book> IdBooks { set; get; } = new List<Book>();
    /// <summary>
    /// IdTypeDepartments stores list id of type department
    /// </summary>
    public List<TypeDepartment> IdTypeDepartments { set; get; } = new List<TypeDepartment>();
}
