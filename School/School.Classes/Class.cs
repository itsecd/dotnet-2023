namespace School.Classes;

public class Class
{
    /// <summary>
    /// Идентификатор класса
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Номер класса
    /// </summary>
    public int Number { get; set; }

    /// <summary>
    /// Литера класса
    /// </summary>
    public char Letter { get; set; }

    /// <summary>
    /// Список студентов в данном классе
    /// </summary>
    public List<Student>? Students { get; set; }

    public Class() { }

    public Class(int number, char letter, List<Student>? students)
    {
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