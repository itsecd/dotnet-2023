using LibrarySchool;

namespace LibrarySchoolServer;
/// <summary>
/// Class stores data of server
/// </summary>
public class LibrarySchoolRepository : ILibrarySchoolRepository
{
    private readonly List<Student> _students;
    private readonly List<ClassType> _classes;
    private readonly List<Subject> _subjects;
    private readonly List<Mark> _marks;

    /// <summary>
    /// Initializes list of marks.
    /// </summary>
    /// <returns>
    /// List containing 32 types of marks
    /// </returns>
    private List<Mark> CreateListMark()
    {
        return new List<Mark>()
        {
            new Mark(0,  0, 4, 0, new DateTime(2023, 06, 23)),
            new Mark(1,  0, 5, 1, new DateTime(2023, 06, 20)),
            new Mark(2,  0, 5, 2, new DateTime(2023, 06, 26)),
            new Mark(3,  0, 4, 3, new DateTime(2023, 05, 21)),
            new Mark(4,  1, 5, 0, new DateTime(2023, 06, 22)),
            new Mark(5,  1, 5, 1, new DateTime(2023, 06, 22)),
            new Mark(6,  1, 4, 2, new DateTime(2023, 06, 20)),
            new Mark(7,  1, 5, 3, new DateTime(2023, 05, 12)),
            new Mark(8,  2, 3, 0, new DateTime(2023, 06, 03)),
            new Mark(9,  2, 4, 1, new DateTime(2023, 06, 11)),
            new Mark(10, 2, 5, 2, new DateTime(2023, 06, 23)),
            new Mark(11, 2, 4, 3, new DateTime(2023, 05, 23)),
            new Mark(12, 3, 4, 0, new DateTime(2023, 06, 22)),
            new Mark(13, 3, 3, 1, new DateTime(2023, 06, 21)),
            new Mark(14, 3, 5, 2, new DateTime(2023, 06, 23)),
            new Mark(15, 3, 5, 3, new DateTime(2023, 05, 13)),
            new Mark(16, 4, 3, 0, new DateTime(2023, 06, 30)),
            new Mark(17, 4, 5, 1, new DateTime(2023, 06, 21)),
            new Mark(18, 4, 5, 2, new DateTime(2023, 06, 17)),
            new Mark(19, 4, 3, 3, new DateTime(2023, 05, 19)),
            new Mark(20, 5, 5, 0, new DateTime(2023, 06, 20)),
            new Mark(21, 5, 5, 1, new DateTime(2023, 06, 21)),
            new Mark(22, 5, 4, 2, new DateTime(2023, 06, 23)),
            new Mark(23, 5, 3, 3, new DateTime(2023, 05, 23)),
            new Mark(24, 6, 3, 0, new DateTime(2023, 06, 22)),
            new Mark(25, 6, 4, 1, new DateTime(2023, 06, 22)),
            new Mark(26, 6, 5, 2, new DateTime(2023, 06, 21)),
            new Mark(27, 6, 5, 3, new DateTime(2023, 05, 20)),
            new Mark(28, 7, 4, 0, new DateTime(2023, 06, 21)),
            new Mark(29, 7, 5, 1, new DateTime(2023, 06, 24)),
            new Mark(30, 7, 2, 2, new DateTime(2023, 06, 21)),
            new Mark(31, 7, 5, 3, new DateTime(2023, 05, 20))
        };
    }

    /// <summary>
    /// Initializes example list of student for testing
    /// </summary>
    /// <returns>
    /// List containing 8 types of student
    /// </returns>
    private List<Student> CreateListStudent()
    {
        var listMark = CreateListMark();

        return new List<Student>() {
            new Student(0, "12343C", "Pham Ngoc Hung", new DateTime(2000, 01, 04), 1
                         , listMark.Where(mark=> mark.StudentId == 0).ToList()),
            new Student(1, "32342C", "La Hoang Anh", new DateTime(1998, 12, 12), 2
                         , listMark.Where(mark=> mark.StudentId == 1).ToList()),
            new Student(2, "32231C", "Nguyen Van Hoang", new DateTime(1999, 06, 29), 2
                         , listMark.Where(mark=> mark.StudentId == 2).ToList()),
            new Student(3, "11231C", "Kyle Roydon", new DateTime(1999, 06, 29), 2
                         , listMark.Where(mark=> mark.StudentId == 3).ToList()),
            new Student(4, "11231C", "Nevil Mimi", new DateTime(1999, 06, 29), 1
                         , listMark.Where(mark=> mark.StudentId == 4).ToList()),
            new Student(5, "16431C", "Mercia Gabriella", new DateTime(1999, 06, 29), 2
                         , listMark.Where(mark=> mark.StudentId == 5).ToList()),
            new Student(6, "13431C", "Angelia Jerrard", new DateTime(1999, 06, 29), 2
                         , listMark.Where(mark=> mark.StudentId == 6).ToList()),
            new Student(7, "12031C", "Happy Remy", new DateTime(1999, 06, 29), 1
                         , listMark.Where(mark=> mark.StudentId == 7).ToList()),
        };
    }

    /// <summary>
    /// Initializes list of class for testing
    /// </summary>
    /// <returns>
    /// List containing 3 classes
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
    /// List containing 4 subjects
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

    /// <summary>
    /// Constructor to create data
    /// </summary>

    public LibrarySchoolRepository()
    {
        _students = CreateListStudent();
        _classes = CreateListClass();
        _subjects = CreateListSubject();
        _marks = CreateListMark();
    }
    /// <summary>
    /// Property list students in data
    /// </summary>
    public List<Student> Students => _students;

    /// <summary>
    /// Property list class in data
    /// </summary>
    public List<ClassType> ClassTypes => _classes;

    /// <summary>
    /// Property list subject in data
    /// </summary>
    public List<Subject> Subjects => _subjects;

    /// <summary>
    /// Property list mark in data
    /// </summary>
    public List<Mark> Marks => _marks;
}