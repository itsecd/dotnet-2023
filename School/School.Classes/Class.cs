namespace School.Classes;

public class Class
{
    /// <summary>
    /// Class ID
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Number of class
    /// </summary>
    public int Number { get; set; }

    /// <summary>
    /// Class letter
    /// </summary>
    public char Letter { get; set; }

    /// <summary>
    /// List of students in this class
    /// </summary>
    public List<Student>? Students { get; set; }

    public Class() { }

    public Class(int id, int number, char letter, List<Student>? students)
    {
        Id = id;
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