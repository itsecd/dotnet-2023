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
            new Subject {Name = "Math", Semester = 1, Id = 1},
            new Subject {Name = "Industrial programming", Semester = 6, Id = 2},
            new Subject {Name = "Data analytics", Semester = 5, Id = 3},
            new Subject {Name = "Algebra", Semester = 2, Id = 4},
            new Subject {Name = "Physics", Semester = 3, Id = 4}
        };

        _groups = new List<Group>
        {
            new Group {Id = 1, GroupNumber = 6311, StudentAmount = 25, EducationType = "D"},
            new Group {Id = 2, GroupNumber = 6312, StudentAmount = 16, EducationType = "D"},
            new Group {Id = 3, GroupNumber = 6295, StudentAmount = 25, EducationType = "V"}
        };

        _teachers = new List<Teacher>
        {
            new Teacher {FullName = "Maksimova Lyudmila", Degree = "Professor", Id = 1},
            new Teacher {FullName = "Shashkova Tatiana", Degree = "Assistant professor", Id = 2},
            new Teacher {FullName = "Belov Alexander", Degree = "Professor", Id = 3}
        };

        _courses = new List<Course>
        {
            new Course {SubjectName = "Math", CourseType = "Lectures", SemesterHours = 256, GroupId = 2, TeachersName = "Maksimova Lyudmila", Id = 1, SubjectId = 1, TeacherId = 1},
            new Course {SubjectName = "Industrial programming", CourseType = "Course project", SemesterHours = 123, GroupId = 1, TeachersName = "Shashkova Tatiana", Id = 2, TeacherId = 2, SubjectId = 2},
            new Course {SubjectName = "Physics", CourseType = "Course project", SemesterHours = 14, GroupId = 3, TeachersName = "Maksimova Lyudmila", Id = 3, SubjectId = 4, TeacherId = 1 },
            new Course {SubjectName = "Math", CourseType = "Lectures", SemesterHours = 500, GroupId = 1, TeachersName = "Shashkova Tatiana", Id = 4, SubjectId = 1, TeacherId = 2}
        };
    }

    public List<Subject> Subjects => _subjects;

    public List<Group> Groups => _groups;

    public List<Teacher> Teachers => _teachers;

    public List<Course> Courses => _courses;
}
