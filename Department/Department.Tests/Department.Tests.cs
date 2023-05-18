using Department.Domain;
using System.Security.Cryptography;

namespace Department.Tests;

public class DepartmentTests : IClassFixture<DepartmentFixture>
{
    private readonly DepartmentFixture _departmentFixture;

    /// <summary>
    /// Constructor 
    /// </summary>
    public DepartmentTests(DepartmentFixture departmentFixture)
    {
        _departmentFixture = departmentFixture;
    }

    /// <summary>
    /// 1st request: give info about all sport bikes
    /// </summary>
    [Fact]
    public void TestTeachers()
    {
        var request =
            from teacher in _departmentFixture.Teachers
            join course in _departmentFixture.Courses on teacher.FullName equals course.TeachersName
            where course.SubjectName == "Математический анализ"
            orderby teacher.FullName
            select teacher;

        Assert.Equal(2, request.Count());
    }

    /// <summary>
    /// 1st request: give info about all sport bikes
    /// </summary>
    [Fact]
    public void TestCourseProject()
    {
        var request =
            from teacher in _departmentFixture.Teachers
            join course in _departmentFixture.Courses on teacher.FullName equals course.TeachersName
            where course.CourseType == "Курсовой проект"
            select teacher;

        Assert.Equal(2, request.Count());
    }

    /// <summary>
    /// 1st request: give info about all sport bikes
    /// </summary>
    [Fact]
    public void TestSubjects()
    {
        var request =
            from subject in _departmentFixture.Subjects
            join course in _departmentFixture.Courses on subject.Name equals course.SubjectName
            where course.GroupNumber == 6311
            select subject;

        Assert.Equal(2, request.Count());
    }


    [Fact]
    public void TestDepartmentInfo()
    {
        var teacherInfo =
            (from teacher in _departmentFixture.Teachers
            group teacher by teacher.Degree into teacherGroup
            select new
            {
                type = teacherGroup.Key,
                counter = teacherGroup.Count()
            }).ToList();

        var courseInfo =
            (from course in _departmentFixture.Courses
             group course by course.CourseType into courseGroup
             select new
             {
                 type = courseGroup.Key,
                 counter = courseGroup.Count()
             }).ToList();

        var totalGroups =
            from studentGroup in _departmentFixture.Groups
            select studentGroup;

        var totalStudents = 
            (from studentGroup in _departmentFixture.Groups
            select studentGroup.StudentAmount).ToList();

        Assert.Equal("Профессор", teacherInfo[0].type);
        Assert.Equal(2, teacherInfo[0].counter);

        Assert.Equal("Доцент", teacherInfo[1].type);
        Assert.Equal(1, teacherInfo[1].counter);

        Assert.Equal("Лекции", courseInfo[0].type);
        Assert.Equal(2, courseInfo[0].counter);

        Assert.Equal("Курсовой проект", courseInfo[1].type);
        Assert.Equal(2, courseInfo[1].counter);

        Assert.Equal(3, totalGroups.Count());
        Assert.Equal(66, totalStudents.Sum());
    }

    [Fact]
    public void TestMostBusy()
    {
        var totalHours =
            (from courses in _departmentFixture.Courses
             orderby courses.TeachersName
             group courses by courses.TeachersName into teachersGroup
             select new
             {
                 name = teachersGroup.Key,
                 totalTime = teachersGroup.Sum(x => x.SemesterHours)
             }).ToList();

        var result = (from hoursCounter in totalHours orderby hoursCounter.totalTime descending select hoursCounter).Take(3).ToList();

        Assert.Equal("Шашкова Татьяна Якубовна", result[0].name);
        Assert.Equal(623, result[0].totalTime);
    }

    [Fact]
    public void TestDifferentTeachers()
    {
        var request =
            (from courses in _departmentFixture.Courses
             group courses by courses.SubjectName into courseGroup
             select new
             {
                 subjectName = courseGroup.Key,
                 teachers = courseGroup.DistinctBy(x => x.TeachersName).Count()
             }).ToList();

        Assert.Equal(2, request[0].teachers);
        Assert.Equal(1, request[1].teachers);
    }
}