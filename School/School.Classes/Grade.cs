using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace School.Classes;

/// <summary>
/// Класс содержащий информацию об оценке
/// </summary>
[Table("grades")]
public class Grade
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    [Column("id")]
    [Key]
    public int Id { get; set; }

    /// <summary>
    /// Идентификатор предмета
    /// </summary>
    [Column("subject_id")]
    public int SubjectId { get; set; }

    /// <summary>
    /// Предмет для внешнего ключа
    /// </summary>
    [ForeignKey("SubjectId")]
    public Subject Subject { get; set; }

    /// <summary>
    /// Идентификатор студента с данной оценкой
    /// </summary>
    [Column("student_id")]
    public int StudentId { set; get; }

    /// <summary>
    /// Студент для внешнего ключа
    /// </summary>
    [ForeignKey("StudentId")]
    public Student Student { get; set; }

    /// <summary>
    /// Оценка
    /// </summary>
    [Column("mark")]
    [Required]
    public int Mark { get; set; }

    /// <summary>
    /// Дата выставления оценки
    /// </summary>
    [Column("date")]
    [Required]
    public DateTime Date { get; set; }

    public Grade() { }

    public Grade(int id,Subject subject, Student student, int mark, DateTime dateTime)
    {
        Id = id;
        Subject = subject;
        Student = student;
        Mark = mark;
        Date = dateTime;
    }
     
    public override bool Equals(object? obj)
    {
        if (obj is not Grade param)
            return false;

        return Student == param.Student && Subject == param.Subject && Date == param.Date;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Id, Student, Subject, Date);
    }
}