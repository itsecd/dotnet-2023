namespace LibrarySchool;
/// <summary>
/// Student type in university
/// </summary>

public class Student
{

    ///<summary>
    /// StudentId - guid typed value for storing Id of the student
    ///</summary>
    public int StudentId { get; set; }

    /// <summary>
    /// Passport - string type number passport of the student
    /// </summary>
    public string Passport { get; set; } = "";

    /// <summary>
    /// StudentName - string type name of the student
    /// </summary>
    public string StudentName { get; set; } = "";

    /// <summary>
    /// DateOfBirth - student's date of birth
    /// </summary>
    public DateOnly DateOfBirth { get; set; } = new DateOnly(1, 1, 1);

    /// <summary>
    /// ClassID - Id of the class where student studing
    /// </summary>
    public int ClassID { get; set; }

    public Student(int studentId, string passport, string studentName, DateOnly dateOfBirth, int classID)
    {
        StudentId = studentId;
        Passport = passport;
        StudentName = studentName;
        DateOfBirth = dateOfBirth;
        ClassID = classID;
    }

    public override bool Equals(object? obj)
    {
        if (obj == null) return false;
        if (obj is not Student) return false;
        var s = (Student)obj;
        return (s.StudentName == StudentName && s.StudentId == StudentId && s.ClassID == ClassID && s.Passport == Passport && s.DateOfBirth == DateOfBirth);
    }
    public override int GetHashCode()
    {
        return HashCode.Combine(StudentId, Passport, StudentName, DateOfBirth, ClassID);
    }

}