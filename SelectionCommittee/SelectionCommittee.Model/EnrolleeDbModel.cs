using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SelectionCommittee.Model;

/// <summary>
/// Абитуриент.
/// </summary>
[Table("enrollee")]
public class EnrolleeDbModel
{
    /// <summary>
    /// Идентификатор.
    /// </summary>
    [Column("id")]
    [Key]
    public int Id { get; set; }

    /// <summary>
    /// Имя.
    /// </summary>
    [Column("first_name")]
    [Required]
    public string FirstName { get; set; }

    /// <summary>
    /// Фамилия.
    /// </summary>
    [Column("last_name")]
    [Required]
    public string LastName { get; set; }

    /// <summary>
    /// Отчество.
    /// </summary>
    [Column("patronymic")]
    [Required]
    public string Patronymic { get; set; }

    /// <summary>
    /// Возраст.
    /// </summary>
    [Column("age")]
    [Required]
    public int Age { get; set; }

    /// <summary>
    /// Дата рождения.
    /// </summary>
    [Column("birth_date")]
    [Required]
    public DateTime BirthDate { get; set; }

    /// <summary>
    /// Страна.
    /// </summary>
    [Column("country")]
    [Required]
    public string Country { get; set; }

    /// <summary>
    /// Город.
    /// </summary>
    [Column("city")]
    [Required]
    public string City { get; set; }
}
