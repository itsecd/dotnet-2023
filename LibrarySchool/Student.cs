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
    /// ClassId - Id of the class where student studing
    /// </summary>
    public int ClassId { get; set; }

    /// <summary>
    /// Marks - list mark that student received
    /// </summary>
    public List<Mark> Marks { get; set; } = new List<Mark>();

    public Student(int studentId, string passport, string studentName, DateOnly dateOfBirth, int classId, List<Mark> marks)
    {
        StudentId = studentId;
        Passport = passport;
        StudentName = studentName;
        DateOfBirth = dateOfBirth;
        ClassId = classId;
        Marks = marks;
    }

    public override bool Equals(object? obj)
    {
        if (obj == null) return false;
        if (obj is not Student) return false;
        var s = (Student)obj;
        return (s.StudentName == StudentName && s.StudentId == StudentId && s.ClassId == ClassId && s.Passport == Passport && s.DateOfBirth == DateOfBirth);
    }
    public override int GetHashCode()
    {
        return HashCode.Combine(StudentId, Passport, StudentName, DateOfBirth, ClassId);
    }

}