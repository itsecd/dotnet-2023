namespace School.Classes;

public class Class
{
    /// <summary>
    /// Номер класса
    /// </summary>
    public int Number { get; set; }

    /// <summary>
    /// Литера класса
    /// </summary>
    public char Letter { get; set; }

    public Class() { }

    public Class(int number, char letter)
    {
        Number = number;
        Letter = letter;
    }

    public override bool Equals(object? obj)
    {
        if (obj is not Class param)
            return false;
        return Letter == param.Letter && Number == param.Number;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Number, Letter);
    }
}