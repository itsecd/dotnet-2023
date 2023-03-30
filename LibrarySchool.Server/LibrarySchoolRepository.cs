using LibrarySchool;
using Microsoft.AspNetCore.Mvc;

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
        _marks = CreateListMark();
        _students = CreateListStudent();
        _classes = CreateListClass();
        _subjects = CreateListSubject();
    }

    /// <summary>
    /// Add new student
    /// </summary>
    /// <param name="student"></param>
    /// <exception cref="Exception"></exception>
    public void AddStudent(Student student)
    {
        var foundClass = _classes.FirstOrDefault(x => x.ClassId == student.ClassId);
        student.StudentId = _students.Select(x => x.StudentId).Max() + 1;
        if (foundClass == null)
            return;
        foundClass.Students.Add(student);
        _students.Add(student);
    }

    /// <summary>
    /// Delete student by Id
    /// </summary>
    /// <param name="id"></param>
    /// <exception cref="Exception"></exception>
    public bool DeleteStudent(int id)
    {
        var foundStudent = _students.FirstOrDefault(x => x.StudentId == id);
        if (foundStudent == null)
            return false;
        _students.Remove(foundStudent);
        _marks.RemoveAll(x => x.StudentId == id);
        return true;
    }

    /// <summary>
    /// Change information of student
    /// </summary>
    /// <param name="id"></param>
    /// <param name="newStudent"></param>
    /// <returns></returns>
    public bool ChangeStudent(int id, [FromBody]Student newStudent)
    {
        var foundStudent = _students.FirstOrDefault(x => x.StudentId == id);

        if (foundStudent == null)
            return false;
        var foundClass = _classes.FirstOrDefault(x => x.ClassId == foundStudent.ClassId);
        var newClass = _classes.FirstOrDefault(x => x.ClassId == newStudent.ClassId);

        if (foundClass == null || newClass == null) 
            return false;

        foundClass.Students.RemoveAll(x => x.StudentId == id);
        newClass.Students.Add(newStudent);

        foundStudent.StudentName = newStudent.StudentName;
        foundStudent.StudentId = newStudent.StudentId;
        foundStudent.DateOfBirth = newStudent.DateOfBirth;
        foundStudent.Passport = newStudent.Passport;
        foundStudent.ClassId = newStudent.ClassId;

        return true;
    }

    /// <summary>
    /// All new class
    /// </summary>
    /// <param name="classType"></param>
    public void AddClass(ClassType classType)
    {
        classType.ClassId = _classes.Select(x => x.ClassId).Max() + 1;  
        _classes.Add(classType);
    }

    /// <summary>
    /// All new class
    /// </summary>
    /// <param name="classId"></param>
    public bool DeleteClass(int classId)
    {
        var foundClass = _classes.FirstOrDefault(classType => classType.ClassId == classId);
        if (foundClass == null) return false;
        _classes.Remove(foundClass);
        return true;
    }

    /// <summary>
    /// Change information of class
    /// </summary>
    /// <param name="classId"></param>
    /// <param name="newClass"></param>
    /// <returns></returns>
    public bool ChangeClass(int classId, ClassType newClass)
    {
        var foundClass = _classes.FirstOrDefault(x => x.ClassId == classId);
        if (foundClass == null) return false;
        foundClass.Letter = newClass.Letter;
        foundClass.Number = newClass.Number;
        return true;
    }

    /// <summary>
    /// Add new mark
    /// </summary>
    /// <param name="mark"></param>
    public void AddMark(Mark mark)
    {
        mark.MarkId = _marks.Select(x => x.MarkId).Max() + 1;
        _marks.Add(mark);
        
        var foundStudent = _students.Where(x => x.StudentId == mark.StudentId).FirstOrDefault();
        if (foundStudent == null) return;
        foundStudent.Marks.Add(mark);
    }

    /// <summary>
    /// Delete mark
    /// </summary>
    /// <param name="markId"></param>
    /// <returns></returns>
    public bool DeleteMark(int markId)
    {
        var foundMark = _marks.FirstOrDefault(x => x.MarkId == markId);
        if (foundMark == null) return false;
        _marks.Remove(foundMark);
        var foundStudent = _students.Where(x => x.StudentId == foundMark.StudentId).FirstOrDefault();
        if (foundStudent != null) 
            foundStudent.Marks.RemoveAll(mark => mark.MarkId == markId);    
        return true;
    }

    /// <summary>
    /// Change Mark information
    /// </summary>
    /// <param name="markId"></param>
    /// <param name="newMark"></param>
    /// <returns></returns>
    public bool ChangeMark(int markId, Mark newMark)
    {
        var foundMark = _marks.FirstOrDefault(x => x.MarkId == markId);
        if (foundMark == null) return false;
        var foundStudent = _students.FirstOrDefault(x => x.StudentId == foundMark.StudentId);
        var newStudent = _students.FirstOrDefault(x=> x.StudentId == newMark.StudentId);
        if (foundStudent == null || newStudent == null) return false;
        foundStudent.Marks.RemoveAll(x=>x.MarkId == markId);
        newStudent.Marks.Add(newMark);

        foundMark.StudentId = newMark.StudentId;
        foundMark.SubjectId = newMark.SubjectId;
        foundMark.MarkValue = newMark.MarkValue;
        foundMark.TimeReceive= newMark.TimeReceive;
        return true;
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