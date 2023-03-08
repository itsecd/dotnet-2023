namespace UnitTestLR1;

using EmployeeDomain;
using EmployeeDomainTests;
using System.Linq;  // для запросов

public class EmployeeDomainTestClass : IClassFixture<EmployeeDomainFixture>   //этот класс на самом деле наследуется от Object
{
    // Существуют факты и теории
    // факты - методы, применяют один метод
    // теория - проверяют несколько значений (?)
    private readonly EmployeeDomainFixture _fixture;
    public EmployeeDomainTestClass(EmployeeDomainFixture fixture)
    {
        _fixture = fixture;
    }
    [Fact]
    public void TestFirstQuery()
    {
        var departmentList = _fixture.DepartmentFixture;
        var employees = _fixture.EmployeeFixture;
        var departmentEmployeeList = _fixture.DepartmentEmployeeFixture;
        employees[0].DepartmentEmployee.Add(departmentEmployeeList[0]);
        employees[0].DepartmentEmployee.Add(departmentEmployeeList[1]);
        employees[1].DepartmentEmployee.Add(departmentEmployeeList[2]);
        employees[1].DepartmentEmployee.Add(departmentEmployeeList[3]);
        employees[2].DepartmentEmployee.Add(departmentEmployeeList[4]);
        employees[2].DepartmentEmployee.Add(departmentEmployeeList[5]);
        employees[3].DepartmentEmployee.Add(departmentEmployeeList[6]);
        departmentEmployeeList[0].Employee = employees[0];
        departmentEmployeeList[1].Employee = employees[0];
        departmentEmployeeList[2].Employee = employees[1];
        departmentEmployeeList[3].Employee = employees[2];
        departmentEmployeeList[4].Employee = employees[1];
        departmentEmployeeList[5].Employee = employees[2];
        departmentEmployeeList[6].Employee = employees[3];
        var requestFirst = (from employee in employees
                            from departmentEmployeeItem in employee.DepartmentEmployee
                            where departmentEmployeeItem.Department != null && departmentEmployeeItem.Department.Id == 1
                            select employee).ToList();
        Assert.Equal(3, requestFirst.Count);
    }
    [Fact]
    public void TestSecondQuery()
    {
        var departmentList = _fixture.DepartmentFixture;
        var employees = _fixture.EmployeeFixture;
        var departmentEmployeeList = _fixture.DepartmentEmployeeFixture;
        employees[0].DepartmentEmployee.Add(departmentEmployeeList[0]);
        employees[0].DepartmentEmployee.Add(departmentEmployeeList[1]);
        employees[1].DepartmentEmployee.Add(departmentEmployeeList[2]);
        employees[1].DepartmentEmployee.Add(departmentEmployeeList[3]);
        employees[2].DepartmentEmployee.Add(departmentEmployeeList[4]);
        employees[2].DepartmentEmployee.Add(departmentEmployeeList[5]);
        employees[3].DepartmentEmployee.Add(departmentEmployeeList[6]);
        departmentEmployeeList[0].Employee = employees[0];
        departmentEmployeeList[1].Employee = employees[0];
        departmentEmployeeList[2].Employee = employees[1];
        departmentEmployeeList[3].Employee = employees[2];
        departmentEmployeeList[4].Employee = employees[1];
        departmentEmployeeList[5].Employee = employees[2];
        departmentEmployeeList[6].Employee = employees[3];



        var requestSecond = (from employee in employees
                             orderby employee.LastName, employee.FirstName, employee.PatronymicName
                             from departmentEmployeeItem in employee.DepartmentEmployee
                             group employee by new { employee.Id, employee.LastName, employee.FirstName, employee.PatronymicName } into grp
                             where grp.Count() > 1
                             orderby grp.Key.LastName, grp.Key.FirstName, grp.Key.PatronymicName
                             select new
                             {
                                 Id = grp.Key.Id,
                                 FirstName = grp.Key.FirstName,
                                 LastName = grp.Key.LastName,
                                 PatronymicName = grp.Key.PatronymicName,
                                 CountDepart = grp.Count()
                             }).ToList();
        Assert.Equal(3, requestSecond.Count);
        /*
        var requestSecond = (from employee in employees
                             orderby employee.LastName, employee.FirstName, employee.PatronymicName
                             join departmentEmployeeItem in departmentEmployeeList on employee equals departmentEmployeeItem.Employee

                             group employee by new { employee.Id, employee.LastName, employee.FirstName, employee.PatronymicName } into grp
                             where grp.Count() > 1
                             orderby grp.Key.LastName, grp.Key.FirstName, grp.Key.PatronymicName
                             select new
                             {
                                 Id = grp.Key.Id,
                                 FirstName = grp.Key.FirstName,
                                 LastName = grp.Key.LastName,
                                 PatronymicName = grp.Key.PatronymicName,
                                 CountDepart = grp.Count()
                             }).ToList();
        Assert.Equal(3, requestSecond.Count);
        Assert.Equal(requestSecond, requestSecond22); */
    }
    [Fact]
    public void TestFourthQuery()
    {
        var departmentList = _fixture.DepartmentFixture;
        var employees = _fixture.EmployeeFixture;
        var departmentEmployeeList = _fixture.DepartmentEmployeeFixture;
        employees[0].DepartmentEmployee.Add(departmentEmployeeList[0]);
        employees[0].DepartmentEmployee.Add(departmentEmployeeList[1]);
        employees[1].DepartmentEmployee.Add(departmentEmployeeList[2]);
        employees[1].DepartmentEmployee.Add(departmentEmployeeList[3]);
        employees[2].DepartmentEmployee.Add(departmentEmployeeList[4]);
        employees[2].DepartmentEmployee.Add(departmentEmployeeList[5]);
        employees[3].DepartmentEmployee.Add(departmentEmployeeList[6]);
        departmentEmployeeList[0].Employee = employees[0];
        departmentEmployeeList[1].Employee = employees[0];
        departmentEmployeeList[2].Employee = employees[1];
        departmentEmployeeList[3].Employee = employees[2];
        departmentEmployeeList[4].Employee = employees[1];
        departmentEmployeeList[5].Employee = employees[2];
        departmentEmployeeList[6].Employee = employees[3];

        var requestFourth =
            (from tuple in (
                                from employee in employees
                                from departmentEmployeeItem in employee.DepartmentEmployee
                                where departmentEmployeeItem.Department != null
                                select new
                                {
                                    employeeAge = (DateOnly.FromDateTime(DateTime.Now).DayNumber - employee.BirthDate.DayNumber) / 365.2425,
                                    departmentId = departmentEmployeeItem.Department?.Id
                                }
                            )
             group tuple by tuple.departmentId into grp
             select new
             {
                 averageAge = grp.Average(employee => employee.employeeAge),
                 departmentId = grp.Key
             }).ToList();
        Assert.NotEqual(requestFourth[0].averageAge, requestFourth[1].averageAge);
    }
}