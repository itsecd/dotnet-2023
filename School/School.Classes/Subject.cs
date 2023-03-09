namespace School.Classes;

public class Subject
{
    /// <summary>
    /// ID
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Name of the subject
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Year of study
    /// </summary>
    public int Year { get; set; }

    /// <summary>
    /// List of grades in this subject
    /// </summary>
    public List<Grade>? Grades { get; set; }

    public Subject() { }

    public Subject(int id,string name, int year, List<Grade>? grades)
    {
        Id = id;
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