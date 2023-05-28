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
    /// 1st request: give info about all teachers on given course
    /// </summary>
    [Fact]
    public void TestTeachers()
    {
        var request =
            from teacher in _departmentFixture.Teachers
            join course in _departmentFixture.Courses on teacher.FullName equals course.TeachersName
            where course.SubjectName == "Math"
            orderby teacher.FullName
            select teacher;

        Assert.Equal(2, request.Count());
    }

    /// <summary>
    /// 2nd request: give info about all teachers whose curriculum includes a course project
    /// </summary>
    [Fact]
    public void TestCourseProject()
    {
        var request =
            from teacher in _departmentFixture.Teachers
            join course in _departmentFixture.Courses on teacher.FullName equals course.TeachersName
            where course.CourseType == "Course project"
            select teacher;

        Assert.Equal(2, request.Count());
    }

    /// <summary>
    /// 3rd request: give info about all subjects for given group
    /// </summary>
    [Fact]
    public void TestSubjects()
    {
        var request =
            from subject in _departmentFixture.Subjects
            join course in _departmentFixture.Courses on subject.Name equals course.SubjectName
            where course.GroupId == 6311
            select subject;

        Assert.Equal(2, request.Count());
    }

    /// <summary>
    /// 4th request: summary information about the department (amount of teachers, amount of groups, amount of students, etc.)
    /// </summary>
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

        Assert.Equal("Professor", teacherInfo[0].type);
        Assert.Equal(2, teacherInfo[0].counter);

        Assert.Equal("Assistant professor", teacherInfo[1].type);
        Assert.Equal(1, teacherInfo[1].counter);

        Assert.Equal("Lectures", courseInfo[0].type);
        Assert.Equal(2, courseInfo[0].counter);

        Assert.Equal("Course project", courseInfo[1].type);
        Assert.Equal(2, courseInfo[1].counter);

        Assert.Equal(3, totalGroups.Count());
        Assert.Equal(66, totalStudents.Sum());
    }

    /// <summary>
    /// 5th request: give info about most busy teacher
    /// </summary>
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

        Assert.Equal("Shashkova Tatiana", result[0].name);
        Assert.Equal(623, result[0].totalTime);
    }

    /// <summary>
    /// 6th request: give info about subjects taught by different teachers
    /// </summary>
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