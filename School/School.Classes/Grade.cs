namespace School.Classes;

public class Grade
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Предмет
    /// </summary>
    public Subject? Subject { get; set; }

    /// <summary>
    /// Студент
    /// </summary>
    public Student? Student { get; set; }

    /// <summary>
    /// Оценка
    /// </summary>
    public int Mark { get; set; }

    /// <summary>
    /// Дата оценки
    /// </summary>
    public DateTime Date { get; set; }

    public Grade() { }

    public Grade(Subject subject, Student student, int mark, DateTime dateTime)
    {
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