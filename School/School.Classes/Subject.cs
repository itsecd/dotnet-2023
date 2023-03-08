namespace School.Classes;
public class Subject
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Наименование предмета
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Год обучения
    /// </summary>
    public int Year { get; set; }

    /// <summary>
    /// Список оценок по данному предмету
    /// </summary>
    public List<Grade>? Grades { get; set; }

    public Subject() { }

    public Subject(string name, int year, List<Grade>? grades)
    {
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