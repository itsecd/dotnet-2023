using School.Classes;

namespace SchoolServer.Repository;

/// <summary>
/// Класс для хранения и изменения данных
/// </summary>
public class SchoolRepository : ISchoolRepository
{
    private readonly List<Student> _students;

    private readonly List<Subject> _subjects;

    private readonly List<Grade> _grades;

    private readonly List<Class> _classes;

    /// <summary>
    /// Создание списков наших классов
    /// </summary>
    public SchoolRepository()
    {
        _subjects = new List<Subject>
        {
            new Subject(1, "Philosophy", 2008,null),
            new Subject(2, "Physics", 2020,null),
            new Subject(3, "Programming", 2023,null),
            new Subject(4, "Mathematical analysis", 2008,null),
            new Subject(5, "History", 2001,null),
            new Subject(6, "Fundamentals of life safety", 2008,null),
            new Subject(7, "Literature", 2008,null),
            new Subject(8, "Russian language", 2007,null)
        };

        _students = new List<Student>()
        {
            new Student(1, "Marizov", "Alexey", "Alexeevich", "2001-11111", new Class(1, 11, 'a',null), DateTime.Parse("2001/1/10"),null),
            new Student(2, "Voronin", "Konstantin", "Borisovich", "2001-11111", new Class(2, 10, 'b',null), DateTime.Parse("2000/1/11"),null),
            new Student(3, "Arshavin", "Andrey", "Alexeevich", "2001-11111", new Class(4, 9, 'c',null), DateTime.Parse("2001/2/16"),null),
            new Student(4, "Putilin", "Nikita", "Alexeevich", "2001-11111", new Class(3, 10, 'a',null), DateTime.Parse("1999/1/10"),null),
            new Student(5, "Sazonov", "Alexey", "Alexeevich", "2001-11111", new Class(1, 11, 'a',null), DateTime.Parse("2001/2/10"),null),
            new Student(6, "Yarmakov", "Alexey", "Alexeevich", "2001-11111", new Class(1, 11, 'a',null), DateTime.Parse("2003/4/10"),null),
            new Student(7, "Kareglazov", "Alexey", "Alexeevich", "2001-11111", new Class(5, 8, 'c',null), DateTime.Parse("2005/11/10"),null),
            new Student(8, "Privetov", "Alexey", "Alexeevich", "2001-11111", new Class(6, 9, 'd',null), DateTime.Parse("2008/1/10"),null)
        };

        _grades = new List<Grade>()
        {
            new Grade(16, _subjects[0], _students[0], 5, DateTime.Parse("2022/10/10")),
            new Grade(1, _subjects[0], _students[1], 5, DateTime.Parse("2022/10/10")),
            new Grade(2, _subjects[0], _students[2], 5, DateTime.Parse("2022/10/10")),
            new Grade(3, _subjects[0], _students[3], 5, DateTime.Parse("2022/10/10")),
            new Grade(4, _subjects[0], _students[4], 5, DateTime.Parse("2022/10/10")),

            new Grade(5, _subjects[0], _students[5], 2, DateTime.Parse("2022/12/12")),
            new Grade(6, _subjects[0], _students[6], 3, DateTime.Parse("2022/12/12")),
            new Grade(7, _subjects[0], _students[7], 4, DateTime.Parse("2022/12/12")),

            new Grade(8, _subjects[1], _students[0], 3, DateTime.Parse("2022/10/13")),
            new Grade(9, _subjects[1], _students[1], 4, DateTime.Parse("2022/10/13")),
            new Grade(10, _subjects[1], _students[2], 4, DateTime.Parse("2022/10/13")),
            new Grade(11, _subjects[1], _students[3], 4, DateTime.Parse("2022/10/13")),
            new Grade(12, _subjects[1], _students[4], 4, DateTime.Parse("2022/10/12")),
            new Grade(13, _subjects[0], _students[5], 1, DateTime.Parse("2022/10/13")),
            new Grade(14, _subjects[0], _students[6], 1, DateTime.Parse("2022/10/13")),
            new Grade(15, _subjects[0], _students[7], 1, DateTime.Parse("2022/10/13"))
        };

        _classes = new List<Class>()
        {
            new Class(1, 11, 'a',null),
            new Class(2, 10, 'b',null),
            new Class(4, 9, 'c',null),
            new Class(3, 10, 'a',null),
            new Class(7, 11, 'a',null),
            new Class(8, 11, 'a',null),
            new Class(5, 8, 'c',null),
            new Class(6, 9, 'd',null)
        };
    }

    /// <summary>
    /// Список оценок
    /// </summary>
    public List<Grade> Grades => _grades;

    /// <summary>
    /// Список Студентов
    /// </summary>
    public List<Student> Students => _students;

    /// <summary>
    /// Список предметов
    /// </summary>
    public List<Subject> Subjects => _subjects;
    
    /// <summary>
    /// Список классов
    /// </summary>
    public List<Class> Classes => _classes;

}
