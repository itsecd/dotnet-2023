namespace School.Classes;

public class Student
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public int Id { get; set; }

    /// <summary>	
    /// Имя
    /// </summary>	
    public string FirstName { get; set; } = string.Empty;

    /// <summary>	
    /// Фамилия	
    /// </summary>	
    public string LastName { get; set; } = string.Empty;

    /// <summary>	
    /// Отчество
    /// </summary>
    public string Patronymic { get; set; } = string.Empty;

    /// <summary>
    /// Паспортные данные
    /// </summary>
    public string Passport { get; set; } = string.Empty;

    /// <summary>
    /// Класс студента
    /// </summary>
    public Class? Class { get; set; }

    /// <summary>
    /// Дата рождения
    /// </summary>
    public DateTime BirthDate { get; set; }

    /// <summary>
    /// Список оценок у студента
    /// </summary>
    public List<Grade>? Grades { get; set; }

    public Student() { }

    public Student(string firstName, string lastName, string patronymic, string passport, Class @class, DateTime birthDate, List<Grade>? grades)
    {
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