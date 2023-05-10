using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace School.Classes;

/// <summary>
/// Предметы
/// </summary>
[Table("subjects")]
public class Subject
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    [Column("id")]
    [Key]
    public int Id { get; set; }

    /// <summary>
    /// Наименование предмета
    /// </summary>
    [Column("name")]
    [Required]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Год обучения
    /// </summary>
    [Column("year")]
    [Required]
    public int Year { get; set; }

    /// <summary>
    /// Список оценок по данному предмету
    /// </summary>
    public List<Grade>? Grades { get; set; }

    public Subject() { }

    public Subject(int id,string name, int year, List<Grade>? grades)
    {
        Id = id;
        Name = name;
        Year = year;
        Grades = grades;
    }

    public override bool Equals(object? obj)
    {
        if (obj is not Subject param)
            return false;
        return Name == param.Name && Year == param.Year;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Id, Year, Name);
    }
}