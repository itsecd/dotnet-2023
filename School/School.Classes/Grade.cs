namespace School.Classes;

public class Grade
{
    /// <summary>
    /// Предмет
    /// </summary>
    public Subject? Subject { get; set; }

    /// <summary>
    /// Студент
    /// </summary>
    public Students? Student { get; set; }

    /// <summary>
    /// Оценка
    /// </summary>
    public int Mark { get; set; }

    /// <summary>
    /// Дата оценки
    /// </summary>
    public DateTime Date { get; set; }

    public Grade() { }

    public Grade(Subject subject, Students student, int mark, DateTime dateTime)
    {
        Subject = subject;
        Student = student;
        Mark = mark;
        Date = dateTime;
    }
}