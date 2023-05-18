namespace Department.Tests;

public class DepartmentTests : IClassFixture<DepartmentFixture>
{
    private readonly DepartmentFixture _departmentFixture;
    public DepartmentTests(DepartmentFixture departmentFixture)
    {
        _departmentFixture = departmentFixture;
    }

    [Fact]
    public void TestTeachers()
    {
        var request =
            from course in _departmentFixture.Courses
            where course.Id == 2
            select 
    }
}