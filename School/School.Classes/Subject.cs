namespace School.Classes;


public class Subject
{
    /// <summary>
    /// Наименование предмета
    /// </summary>
    public string Name { get; set; } = string.Empty;


    /// <summary>
    /// Год обучения
    /// </summary>
    public int Year { get; set; }

    public Subject() { }

    public Subject(string name, int year)
    {
        Name = name;
        Year = year;
    }
}