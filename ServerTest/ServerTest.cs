using LibrarySchool;
using Xunit;

namespace ServerTest;

public class ServerTest
{
    private List<Student> _students;
    private List<ClassType> _classes;
    private List<Subject> _subjects;
    private List<Mark> _marks;

    /// <summary>
    /// Initializes list of marks.
    /// </summary>
    /// <returns>
    /// List containing 4 types of marks
    /// </returns>
    private List<Mark> CreateListMark()
    {
        return new List<Mark>()
        {
            new Mark(0,  0, 4, 0, new DateOnly(2023, 06, 23)),
            new Mark(1,  0, 5, 1, new DateOnly(2023, 06, 20)),
            new Mark(2,  0, 5, 2, new DateOnly(2023, 06, 26)),
            new Mark(3,  0, 4, 3, new DateOnly(2022, 05, 23)),
            new Mark(4,  1, 5, 0, new DateOnly(2023, 06, 22)),
            new Mark(5,  1, 5, 1, new DateOnly(2023, 06, 21)),
            new Mark(6,  1, 4, 2, new DateOnly(2023, 06, 23)),
            new Mark(7,  1, 5, 3, new DateOnly(2022, 05, 23)),
            new Mark(8,  2, 3, 0, new DateOnly(2023, 06, 22)),
            new Mark(9,  2, 4, 1, new DateOnly(2023, 06, 21)),
            new Mark(10, 2, 5, 2, new DateOnly(2023, 06, 23)),
            new Mark(11, 2, 5, 3, new DateOnly(2022, 05, 23))
        };
    }

    /// <summary>
    /// Initializes example list of student for testing
    /// </summary>
    /// <returns>
    /// List containing 2 types of student
    /// </returns>
    private List<Student> CreateListStudent()
    {
        var listMark = CreateListMark();

        return new List<Student>() {
            new Student(0, "12343C", "Pham Ngoc Hung", new DateOnly(2000, 01, 04), 1
                         , listMark.Where(mark=> mark.StudentId == 0).ToList()),
            new Student(1, "32342C", "La Hoang Anh", new DateOnly(1998, 12, 12), 2
                         , listMark.Where(mark=> mark.StudentId == 1).ToList()),

            new Student(2, "32231C", "Nguyen Van Hoang", new DateOnly(1999, 06, 29), 2
                         , listMark.Where(mark=> mark.StudentId == 2).ToList())
        };
    }

    /// <summary>
    /// Initializes list of class for testing
    /// </summary>
    /// <returns>
    /// List containing 4 classes
    /// </returns>
    private List<ClassType> CreateListClass()
    {
        var listStudent = CreateListStudent();
        return new List<ClassType>()
        {
            new ClassType(0, 6311, "10-05-03D", listStudent.Where(classList => classList.ClassId == 0).ToList()),
            new ClassType(1, 6312, "10-05-03D", listStudent.Where(classList => classList.ClassId == 1).ToList()),
            new ClassType(2, 6411, "10-05-03D", listStudent.Where(classList => classList.ClassId == 2).ToList()),
        };
    }

    /// <summary>
    /// Initializes list of subjects for testing
    /// </summary>
    /// <returns>
    /// List containing 6 subjects
    /// </returns>
    private List<Subject> CreateListSubject()
    {
        return new List<Subject>()
        {
            new Subject(0, "Industrial programming", 2023),
            new Subject(1, "Database", 2023),
            new Subject(2, "Computer algebra", 2023),
            new Subject(3, "Information theory", 2023),
        };
    }

    public ServerTest()
    {
        _students = CreateListStudent();
        _classes = CreateListClass();
        _subjects = CreateListSubject();
        _marks = CreateListMark();
    }
    [Fact]

    public void TestListStudent()
    {
        Assert.Equal("Pham Ngoc Hung", _students.ElementAt(0).StudentName);
        Assert.Equal(0, _students.ElementAt(0).StudentId);
        Assert.Equal("12343C", _students.ElementAt(0).Passport);
        Assert.Equal(1, _students.ElementAt(0).ClassId);
       
    }

    [Fact]
    public void TestListClass()
    {
        Assert.Equal(6311, _classes.ElementAt(0).Number);
        Assert.Equal(6312, _classes.ElementAt(1).Number);
        Assert.Equal("10-05-03D", _classes.ElementAt(0).Letter);
    }

    [Fact]
    public void TestListMark()
    {
        Assert.Equal(0, _marks.ElementAt(0).StudentId);
        Assert.Equal(4, _marks.ElementAt(0).MarkValue);
        Assert.Equal(0, _marks.ElementAt(0).SubjectId);
    }

    [Fact]
    ///Test list subject
    public void TestListSubject()
    {
        Assert.Equal("Computer algebra", _subjects.ElementAt(2).SubjectName);
        Assert.Equal("Industrial programming", _subjects.ElementAt(0).SubjectName);
    }

    [Fact]
    ///Test for student and their class using LINQ
    ///Student Pham Ngoc Hung in class with ClassId is 1 and Class number is 6312
    public void TestStudentInClass()
    {
        ClassType classToFindWithId = _classes.Where(anyClass => anyClass.ClassId == 1)
                                              .Single<ClassType>();
        var studentFoundInId = classToFindWithId.Students.Find(student => student.StudentName == "Pham Ngoc Hung");


        ClassType classToFindWithNumber = _classes.Where(anyClass => anyClass.Number == 6312)
                                                  .Single<ClassType>();
        var studentFoundInNumber = classToFindWithNumber.Students.Find(student => student.StudentName == "Pham Ngoc Hung");

        Assert.True(studentFoundInId != null);
        Assert.True(studentFoundInNumber != null);
    }

    [Fact]
    ///Test for certain student reiceved all mark using LINQ
    /// Student Pham Ngoc Hung received 4, 5, 5, 4 
    public void TestStudentReceiveMark()
    {
        var indexStudent = _students.Find(student => student.StudentName == "Pham Ngoc Hung")!.StudentId;
        var queryStudentMark = _marks.Where(mark => mark.StudentId == indexStudent).ToList()
                                     .Select(mark => mark.MarkValue);

        var listTrueMarkValue = new List<int> {4, 5, 5, 4};
        Assert.Equal(listTrueMarkValue, queryStudentMark);
    }

    [Fact]
    /// Test for certain student reiceved mark in certain subject uisng LINQ
    /// Student Pham Ngoc Hung received 4 in subject Industrial programming
    public void TestStudentReceiveMarkInSubject()
    {
        var indexStudent = _students.Find(student => student.StudentName == "Pham Ngoc Hung")!.StudentId;
        var indexSubject = _subjects.Find(subject => subject.SubjectName == "Industrial programming")!.SubjectId;
        var queryStudentMark = _marks.Find(mark => mark.StudentId == indexStudent && mark.SubjectId == indexSubject);

        Assert.Equal(4, queryStudentMark!.MarkValue);
    }
}