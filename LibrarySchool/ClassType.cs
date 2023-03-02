namespace LibrarySchool;

///<summary>
/// ClassType - Class type group, where student studying 
///</summary>
public class ClassType
{
    ///<summary>
    /// ClassId - Id class 
    ///</summary>
    public int ClassId { get; set; }

    ///<summary>
    /// Number - number of class, example: 6312,...
    ///</summary>
    public int Number { get; set; }

    ///<summary>
    /// Letter - letter of speciality, example: 10-05-03D,...
    ///</summary>
    public string Letter { get; set; } = "";

    ///<summary>
    /// Students - List student in class
    ///</summary>
    public List<Student> Students { get; set; } = new List<Student>();

    public ClassType(int classId, int number, string letter, List<Student> students)
    {
        ClassId = classId;
        Number = number;
        Letter = letter;
        Students = students;
    }

    public override bool Equals(object? obj)
    {
        if (obj == null) return false;
        if (obj is not ClassType) return false;
        var typeObj = (ClassType)obj;
        return (ClassId == typeObj.ClassId && Number == typeObj.Number && Letter == typeObj.Letter);
    }
    public override int GetHashCode()
    {
        return HashCode.Combine(ClassId, Number, Letter, Students);
    }
}
