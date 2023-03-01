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
    /// Initializes example list of student for testing
    /// </summary>
    /// <returns>
    /// List containing 8 types of student
    /// </returns>
    private List<Student> CreateListStudent()
    {
        return new List<Student>() {
            new Student(0, "12343C", "Фам Нгок Хунг", new DateOnly(2000, 01, 04), 1),
            new Student(1, "32543C", "Ла Хоанг Ань", new DateOnly(1998, 12, 12), 2),
            new Student(2, "23421D", "Нгуен Ван Хоанг", new DateOnly(1999, 06, 29), 2),
            new Student(3, "32540D", "Данилов Артем", new DateOnly(2002, 05, 05), 1),
            new Student(4, "34135D", "Куляков Артем", new DateOnly(2002, 06, 21), 0),
            new Student(5, "23122C", "Гудзенко Игорь", new DateOnly(2002, 04, 17), 0),
            new Student(6, "32112C", "Никифрова Дарья", new DateOnly(2002, 4, 2), 1),
            new Student(7, "21223C", "Иванова Юлиана", new DateOnly(2001, 3,6), 1)
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
        return new List<ClassType>()
        {
            new ClassType(0, 6311, "10-05-03D"),
            new ClassType(1, 6312, "10-05-03D"),
            new ClassType(2, 6411, "10-05-03D"),
            new ClassType(3, 6412, "10-05-03D")
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
            new Subject(0, "Промышленное программирование", 2023),
            new Subject(1, "База данных", 2023),
            new Subject(2, "Компьютерная альгебра", 2023),
            new Subject(3, "Теория информации", 2023),
            new Subject(4, "Системное программирование", 2022),
            new Subject(5, "Схемотехника", 2022)
        };
    }

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
            new Mark(0, 0, 4, 0, new DateOnly(2023, 06, 23)),
            new Mark(1, 0, 5, 1, new DateOnly(2023, 06, 20)),
            new Mark(2, 0, 5, 2, new DateOnly(2023, 06, 26)),
            new Mark(3, 0, 4, 3, new DateOnly(2022, 05, 23)),
            new Mark(4, 1, 5, 0, new DateOnly(2023, 06, 22)),
            new Mark(5, 1, 5, 1, new DateOnly(2023, 06, 21)),
            new Mark(6, 1, 4, 2, new DateOnly(2023, 06, 23)),
            new Mark(7, 1, 5, 3, new DateOnly(2022, 05, 23))
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
        Assert.Equal("Фам Нгок Хунг", _students.ElementAt(0).StudentName);
        Assert.Equal(0, _students.ElementAt(0).StudentId);
        Assert.Equal("12343C", _students.ElementAt(0).Passport);
        Assert.Equal(1, _students.ElementAt(0).ClassID);
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
        Assert.Equal(0, _marks.ElementAt(0).StudentID);
        Assert.Equal(4, _marks.ElementAt(0).MarkValue);
        Assert.Equal(0, _marks.ElementAt(0).SubjectID);
    }

    [Fact]
    //Test list subject
    public void TestListSubject()
    {
        Assert.Equal("Системное программирование", _subjects.ElementAt(4).SubjectName);
        Assert.Equal("Промышленное программирование", _subjects.ElementAt(0).SubjectName);
    }

    [Fact]
    //Test for student and their class using LINQ
    public void TestStudentInClass()
    {
        var queryStudentClass = from s in _students
                           join c in _classes on s.ClassID equals c.ClassID
                           select new { Student = s.StudentName, NumberClass = c.Number, LetterClass = c.Letter };

        Assert.Equal("Фам Нгок Хунг", queryStudentClass.ElementAt(0).Student);
        Assert.Equal(6312, queryStudentClass.ElementAt(0).NumberClass);
        Assert.Equal(6411, queryStudentClass.Where(student => student.Student == "Ла Хоанг Ань").Select(student => student.NumberClass).ElementAt(0));
        Assert.Equal(6311, queryStudentClass.Where(student => student.Student == "Гудзенко Игорь").Select(student => student.NumberClass).ElementAt(0));
    }

    [Fact]
    //Test for сertain student reiceved all mark using LINQ
    // Student Фам Нгок Хунг received 4, 5, 4, 5 
    public void TestStudentReceiveMark()
    {
        var queryStudentMark = from student in _students where student.StudentName == "Фам Нгок Хунг"
                          join mark in _marks on student.StudentId equals mark.StudentID
                          join subject in _subjects on mark.SubjectID equals subject.SubjectID
                          select new { StudentName = student.StudentName, MarkValue = mark.MarkValue, SubjectName = subject.SubjectName };
        
        Assert.Equal("Фам Нгок Хунг", queryStudentMark.ElementAt(0).StudentName);
        Assert.Equal(4, queryStudentMark.ElementAt(0).MarkValue);
        Assert.Equal("Промышленное программирование", queryStudentMark.ElementAt(0).SubjectName);
        Assert.Equal(5, queryStudentMark.ElementAt(1).MarkValue);
        Assert.Equal("База данных", queryStudentMark.ElementAt(1).SubjectName);
    }
}