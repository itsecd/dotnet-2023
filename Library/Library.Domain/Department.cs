using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Domain;

/// <summary>
/// Class Department is used to store info about departments
/// </summary>
[Table("department")]
public class Department
{
    /// <summary>
    /// Id stores department's id
    /// </summary>
    [Column("id")]
    public int Id { set; get; }
    /// <summary>
    /// Count stores count of books in department
    /// </summary>
    [Column("count")]
    public int Count { set; get; }
    /// <summary>
    /// BooksId stores book's id
    /// </summary>
    [Column("book_id")]
    public int BookId { set; get; }
    /// <summary>
    /// TypeDepartmentsId stores department's id
    /// </summary>
    [Column("type_departments_id")]
    public int TypeDepartmentsId { set; get; }
}
