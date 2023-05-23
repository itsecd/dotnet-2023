﻿using Department.Domain;

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
            new Subject {Name = "Математический анализ", Semester = 1},
            new Subject {Name = "Промышленное программирование", Semester = 6},
            new Subject {Name = "Статистический анализ данных", Semester = 5},
            new Subject {Name = "Дискретная математика", Semester = 2},
            new Subject {Name = "Физкультура", Semester = 3}
        };

        _groups = new List<Group>
        {
            new Group {Id = 6311, StudentAmount = 25, EducationType = "D"},
            new Group {Id = 6312, StudentAmount = 16, EducationType = "D"},
            new Group {Id = 6295, StudentAmount = 25, EducationType = "V"}
        };

        _teachers = new List<Teacher>
        {
            new Teacher {FullName = "Максимова Людмила Александровна", Degree = "Профессор"},
            new Teacher {FullName = "Шашкова Татьяна Якубовна", Degree = "Доцент"},
            new Teacher {FullName = "Аввакумова Тамара Николаевна", Degree = "Профессор"}
        };

        _courses = new List<Course>
        {
            new Course {SubjectName = "Математический анализ", CourseType = "Лекции", SemesterHours = 256, GroupId = 6312, TeachersName = "Максимова Людмила Александровна"},
            new Course {SubjectName = "Промышленное программирование", CourseType = "Курсовой проект", SemesterHours = 123, GroupId = 6311, TeachersName = "Шашкова Татьяна Якубовна"},
            new Course {SubjectName = "Физкультура", CourseType = "Курсовой проект", SemesterHours = 14, GroupId = 6295, TeachersName = "Максимова Людмила Александровна" },
            new Course {SubjectName = "Математический анализ", CourseType = "Лекции", SemesterHours = 500, GroupId = 6311, TeachersName = "Шашкова Татьяна Якубовна"}
        };
    }

    public List<Subject> Subjects => _subjects;

    public List<Group> Groups => _groups;

    public List<Teacher> Teachers => _teachers;

    public List<Course> Courses => _courses;
}
