using System.ComponentModel.DataAnnotations;
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
    [Key]
    public int Id { set; get; }
    /// <summary>
    /// Count stores count of books in department
    /// </summary>
    [Column("count")]
    [Required]
    public int Count { set; get; }
    /// <summary>
    /// BooksId stores book's id
    /// </summary>
    [Column("book_id")]
    public int BookId { set; get; }
    /// <summary>
    /// Book is foreign key for Book table
    /// </summary>
    [ForeignKey("BookId")] public Book Book { set; get; } = null!;
    /// <summary>
    /// TypeDepartmentsId stores department's id
    /// </summary>
    [Column("type_department_id")]
    public int TypeDepartmentId { set; get; }
    /// <summary>
    /// TypeDepartment is foreign key for TypeDepartment table
    /// </summary>
    [ForeignKey("TypeDepartmentId")] public TypeDepartment TypeDepartment { set; get; } = null!;
}
