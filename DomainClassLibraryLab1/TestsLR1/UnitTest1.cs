namespace EmployeeDomainTests;
using System.Linq;

public class EmployeeDomainTestClass : IClassFixture<EmployeeDomainFixture>
{
    private readonly EmployeeDomainFixture _fixture;
    public EmployeeDomainTestClass(EmployeeDomainFixture fixture)
    {
        _fixture = fixture;
    }
    [Fact]
    public void TestFirstQuery()
    {
        var firstQuery = (from employee in _fixture.EmployeeWithDepartmentEmployeeFilledFixture
                            from departmentEmployeeItem in employee.DepartmentEmployee
                      where departmentEmployeeItem.Department != null && departmentEmployeeItem.Department.Id == 1
                      select employee).ToList();
        Assert.Equal(3, firstQuery.Count);
    }
    [Fact]
    public void TestSecondQuery()
    {
        var secondQuery = (from employee in _fixture.EmployeeWithDepartmentEmployeeFilledFixture
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
        Assert.Equal(3, secondQuery.Count);
    }
    [Fact]
    public void TestThirdQuery()
    {
        var thirdQuery = (from employeeOccupationItem in _fixture.EmployeeOccupationFixture
                            where employeeOccupationItem != null && employeeOccupationItem.DismissalDate != null
                            from department in employeeOccupationItem?.Employee?.DepartmentEmployee
                            select
                            new
                            {
                                regNumber = employeeOccupationItem.Employee?.regNumber,
                                firstName = employeeOccupationItem.Employee?.FirstName,
                                lastName = employeeOccupationItem.Employee?.LastName,
                                patronymicName = employeeOccupationItem.Employee?.PatronymicName,
                                birthDate = employeeOccupationItem.Employee?.BirthDate,
                                workshop = employeeOccupationItem.Employee?.Workshop,
                                department = department,
                                occupation = employeeOccupationItem.Occupation,
                            }).ToList();
        Assert.Equal(4, thirdQuery.Count());
        Assert.DoesNotContain(thirdQuery, requestElem => requestElem.regNumber == 1337);
        Assert.DoesNotContain(thirdQuery, requestElem => requestElem.regNumber == 443);
        Assert.Contains(thirdQuery, requestElem => requestElem.regNumber == 5);
        Assert.Contains(thirdQuery, requestElem => requestElem.regNumber == 3);
    }
    [Fact]
    public void TestFourthQuery()
    {
        var employees = _fixture.EmployeeWithDepartmentEmployeeFilledFixture;
        var fourthQuery =
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
        Assert.NotEqual(fourthQuery[0].averageAge, fourthQuery[1].averageAge);
        Assert.Equal(2, fourthQuery.Count());
    }
    [Fact]
    public void TestFifthQuery()
    {
        var fifthQuery = (from employeeVoucherItem in _fixture.EmployeeVacationVoucher
                          where (DateOnly.FromDateTime(DateTime.Now).DayNumber - employeeVoucherItem.VacationVoucher?.IssueDate.DayNumber) < 365.2425
                          select new
                          {
                              regNumber = employeeVoucherItem.Employee?.regNumber,
                              firstName = employeeVoucherItem.Employee?.FirstName,
                              lastName = employeeVoucherItem.Employee?.LastName,
                              voucherType = employeeVoucherItem.VacationVoucher?.VoucherType
                          }
                          ).ToList();
        Assert.Contains(fifthQuery, queryElem => queryElem.regNumber == 1337);
        Assert.Contains(fifthQuery, queryElem => queryElem.regNumber == 443);
        Assert.Equal(2, fifthQuery.Count());
    }
    [Fact]
    public void TestSixthQuery()
    {
        var subqueryReplaceNull = (from employeeOccupationItem in _fixture.EmployeeOccupationFixture
                                   select new
                                   {
                                       regNumber = employeeOccupationItem.Employee?.regNumber,
                                       hireDate = employeeOccupationItem.HireDate,
                                       dismissalDate = (employeeOccupationItem.DismissalDate == null ? DateOnly.FromDateTime(DateTime.Now) : employeeOccupationItem.DismissalDate),
                                       firstName = employeeOccupationItem.Employee?.FirstName,
                                       lastName = employeeOccupationItem.Employee?.LastName
                                   }
                            ).ToList();
        var sixthQuery = (from subqueryElem in subqueryReplaceNull
                            group subqueryElem by new { subqueryElem.regNumber, subqueryElem.firstName, subqueryElem.lastName } into grp
                            orderby grp.Sum(subqueryElem => (subqueryElem.dismissalDate?.DayNumber - subqueryElem.hireDate.DayNumber) / 365.2425) descending
                            select new
                            {
                                regNumber = grp.Key.regNumber,
                                firstName = grp.Key.firstName,
                                lastName = grp.Key.lastName,
                                workExperience = grp.Sum(subqueryElem => (subqueryElem.dismissalDate?.DayNumber - subqueryElem.hireDate.DayNumber) / 365.2425)
                            }
                            ).ToList();
        Assert.Equal(4, sixthQuery.Count());
        Assert.True(sixthQuery[0].workExperience > 24);
        Assert.True(sixthQuery[1].workExperience > 23);
        Assert.True(sixthQuery[2].workExperience > 22);
        Assert.True(sixthQuery[2].workExperience > 4);
        Assert.Equal((uint)3, sixthQuery[0].regNumber);
        Assert.Equal((uint)1337, sixthQuery[1].regNumber);
        Assert.Equal((uint)5, sixthQuery[2].regNumber);
        Assert.Equal((uint)443, sixthQuery[3].regNumber);
    }
}