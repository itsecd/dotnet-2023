namespace School.Classes;

public class Grade
{
    /// <summary>
    /// ID
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Subject
    /// </summary>
    public Subject? Subject { get; set; }

    /// <summary>
    /// Student
    /// </summary>
    public Student? Student { get; set; }

    /// <summary>
    /// Mark
    /// </summary>
    public int Mark { get; set; }

    /// <summary>
    /// Date of assessment
    /// </summary>
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