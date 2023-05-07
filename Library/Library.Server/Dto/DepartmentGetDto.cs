namespace Library.Server.Dto;
/// <summary>
/// Class DepartmentGetDto is used to store info about departments
/// </summary>
public class DepartmentGetDto
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
    public int BookId { set; get; }
    /// <summary>
    /// TypeDepartmentsId stores department's id
    /// </summary>
    public int TypeDepartmentId { set; get; }
}
