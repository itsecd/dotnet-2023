namespace LibrarySchool;

///<summary>
/// ClassType - Class type group, where student studying 
///</summary>
public class ClassType
{
    ///<summary>
    /// ClassID - Id class 
    ///</summary>
    public int ClassID { get; set; }

    ///<summary>
    /// Number - number of class, example: 6312,...
    ///</summary>
    public int Number { get; set; }

    ///<summary>
    /// Letter - letter of speciality, example: 10-05-03D,...
    ///</summary>
    public string Letter { get; set; } = "";

    public ClassType(int classID, int number, string letter)
    {
        ClassID = classID;
        Number = number;
        Letter = letter;
    }

    public override bool Equals(object? obj)
    {
        if (obj == null) return false;
        if (obj is not ClassType) return false;
        var typeObj = (ClassType)obj;
        return (ClassID == typeObj.ClassID && Number == typeObj.Number && Letter == typeObj.Letter);
    }
    public override int GetHashCode()
    {
        return HashCode.Combine(ClassID, Number, Letter);
    }
}
