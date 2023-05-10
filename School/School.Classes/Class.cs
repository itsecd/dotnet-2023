using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace School.Classes;

/// <summary>
/// Класс учебного заведения
/// </summary>
[Table("classes")]
public class Class
{
    /// <summary>
    /// Идентификатор класса
    /// </summary> 
    [Column("id")]
    [Key]
    public int Id { get; set; }

    /// <summary>
    /// Номер класса
    /// </summary>
    [Column("number")]
    [Required]
    public int Number { get; set; }

    /// <summary>
    /// Литера класса
    /// </summary>
    [Column("letter")]
    [Required]
    public char Letter { get; set; }

    /// <summary>
    /// Список студентов в данном классе
    /// </summary>
    public List<Student>? Students { get; set; }

    public Class() { }

    public Class(int id, int number, char letter, List<Student>? students)
    {
        Id = id;
        Number = number;
        Letter = letter;
        Students = students;
    }

    public override bool Equals(object? obj)
    {
        if (obj is not Class param)
            return false;
        return Letter == param.Letter && Number == param.Number;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Id,Number, Letter);
    }
}