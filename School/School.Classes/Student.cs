namespace School.Classes;

public class Student
{
    /// <summary>
    /// ID
    /// </summary>
    public int Id { get; set; }

    /// <summary>	
    /// Name
    /// </summary>	
    public string FirstName { get; set; } = string.Empty;

    /// <summary>	
    /// Surname	
    /// </summary>	
    public string LastName { get; set; } = string.Empty;

    /// <summary>	
    /// Patronymic
    /// </summary>
    public string Patronymic { get; set; } = string.Empty;

    /// <summary>
    /// Passport data
    /// </summary>
    public string Passport { get; set; } = string.Empty;

    /// <summary>
    /// Student class
    /// </summary>
    public Class? Class { get; set; }

    /// <summary>
    /// Date of birth
    /// </summary>
    public DateTime BirthDate { get; set; }

    /// <summary>
    /// List of student's grades
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