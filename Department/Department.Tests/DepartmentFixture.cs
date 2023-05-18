using Department.Domain;

namespace Department.Tests;
public class DepartmentFixture
{
    private readonly List<Course> _courses;

    private readonly List<Subject> _subjects;

    private readonly List<Group> _groups;

    private readonly List<Teacher> _teachers;

    public DepartmentFixture()
    {
        _subjects = new List<Subject>
        {
            new Subject {Name = "Математический Анализ", Semester = 1},
            new Subject {Name = "Промышленное программирование", Semester = 6},
            new Subject {Name = "Статистический анализ данных", Semester = 5},
            new Subject {Name = "Дискретная математика", Semester = 2},
            new Subject {Name = "Физкультура", Semester = 3}
        };

        _groups = new List<Group>
        {
            new Group {GroupNumber = 6311, StudentAmount = 25, EducationType = "D"},
            new Group {GroupNumber = 6312, StudentAmount = 16, EducationType = "D"},
            new Group {GroupNumber = 6295, StudentAmount = 25, EducationType = "V"}
        };

        _teachers = new List<Teacher>
        {
            new Teacher {FullName = "Максимова Людмила Александровна", Degree = "Профессор"},
            new Teacher {FullName = "Шашкова Татьяна Якубовна", Degree = "Доцент"},
            new Teacher {FullName = "Аввакумова Тамара Николаевна", Degree = "Профессор"}
        };

        _courses = new List<Course>
        {
            new Course {Subject = Subjects[0], CourseType = "Лекции", SemesterHours = 256, Group = Groups[0], Teacher = Teachers[0]},
            new Course {Subject = Subjects[1], CourseType = "Лекции", SemesterHours = 256, Group = Groups[1], Teacher = Teachers[1]},
            new Course {Subject = Subjects[2], CourseType = "Лекции", SemesterHours = 256, Group = Groups[2], Teacher = Teachers[2]},
            new Course {Subject = Subjects[0], CourseType = "Лекции", SemesterHours = 256, Group = Groups[0], Teacher = Teachers[1]}
        };
    }

    public List<Subject> Subjects => _subjects;

    public List<Group> Groups => _groups;

    public List<Teacher> Teachers => _teachers;

    public List<Course> Courses => _courses;
}
