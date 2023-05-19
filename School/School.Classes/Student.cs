using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace School.Classes;

/// <summary>
/// Класс Студент
/// </summary>
[Table("students")]
public class Student
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    [Column("id")]
    [Key]
    public int Id { get; set; }

    /// <summary>	
    /// Имя
    /// </summary>	
    [Column("first_name")]
    [Required]
    public string FirstName { get; set; } = string.Empty;

    /// <summary>	
    /// Фамилия	
    /// </summary>	
    [Column("last_name")]
    [Required]
    public string LastName { get; set; } = string.Empty;

    /// <summary>	
    /// Отчество
    /// </summary>
    [Column("patronymic")]
    public string Patronymic { get; set; } = string.Empty;

    /// <summary>
    /// Паспортные данные
    /// </summary>
    [Column("passport")]
    [Required]
    public string Passport { get; set; } = string.Empty;

    /// <summary>
    /// Класс студента
    /// </summary>
    [Column("class_id")]
    [Required]
    public int ClassId { get; set; }

    /// <summary>
    /// Класс для внешнего ключа
    /// </summary>
    [ForeignKey("ClassId")]
    public Class Class { get; set; }

    /// <summary>
    /// Дата рождения
    /// </summary>
    [Column("date_birth")]
    [Required]
    public DateTime BirthDate { get; set; }

    /// <summary>
    /// Список оценок у студента
    /// </summary>
    public List<Grade>? Grades { get; set; }

    public Student() { }

    public Student(int id,string firstName, string lastName, string patronymic, string passport, Class @class, DateTime birthDate, List<Grade>? grades)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Patronymic = patronymic;
        Passport = passport;
        Class = @class;
        BirthDate = birthDate;
        Grades = grades;
    }

    public override bool Equals(object? obj)
    {
        if (obj is not Student param)
            return false;

        return Passport == param.Passport && FirstName == param.FirstName;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Id, FirstName, LastName, Patronymic, Passport, Class, BirthDate);
    }
}