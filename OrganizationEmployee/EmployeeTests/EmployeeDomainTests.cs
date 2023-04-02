namespace EmployeeDomainTests;
using System.Linq;

public class EmployeeDomainTestClass : IClassFixture<EmployeeDomainFixture>
{
    private readonly EmployeeDomainFixture _fixture;
    public EmployeeDomainTestClass(EmployeeDomainFixture fixture)
    {
        _fixture = fixture;
    }
    /// <summary>
    /// First query - output all employees of the given department
    /// </summary>
    [Theory]
    [InlineData(1, 3)]
    [InlineData(2, 4)]
    public void TestFirstQuery(uint departmentId, int countObjects)
    {
        var firstQuery = (from employee in _fixture.EmployeeWithDepartmentEmployeeFilledFixture
                          from departmentEmployeeItem in employee.DepartmentEmployees
                          where departmentEmployeeItem.Department?.Id == departmentId
                          select employee).ToList();
        Assert.Equal(countObjects, firstQuery.Count);
    }
    /// <summary>
    /// Second query - output all employees working in more than 1 department. Sort the result by last name, first name, patronymic name.
    /// </summary>
    [Fact]
    public void TestSecondQuery()
    {
        var secondQuery = (from employee in _fixture.EmployeeWithDepartmentEmployeeFilledFixture
                           orderby employee.LastName, employee.FirstName, employee.PatronymicName
                           from departmentEmployeeItem in employee.DepartmentEmployees
                           group employee by new
                           {
                               employee.RegNumber,
                               employee.LastName,
                               employee.FirstName,
                               employee.PatronymicName
                           } into grp
                           where grp.Count() > 1
                           orderby grp.Key.LastName, grp.Key.FirstName, grp.Key.PatronymicName
                           select new
                           {
                               grp.Key.RegNumber,
                               grp.Key.FirstName,
                               grp.Key.LastName,
                               grp.Key.PatronymicName,
                               CountDepart = grp.Count()
                           }).ToList();
        Assert.Equal(3, secondQuery.Count);
        Assert.DoesNotContain(secondQuery, requestElem => requestElem.RegNumber == 5);
        Assert.Contains(secondQuery, requestElem => requestElem.RegNumber == 1337);
        Assert.Contains(secondQuery, requestElem => requestElem.RegNumber == 443);
        Assert.Contains(secondQuery, requestElem => requestElem.RegNumber == 3);
    }
    /// <summary>
    /// Third query - output the archive of dismissals, including registration number, first name, last name, patronymic name,
    /// date of birth, workshop, department, occupation of the employee.
    /// </summary>
    [Fact]
    public void TestThirdQuery()
    {
        var thirdQuery = (from employeeOccupationItem in _fixture.EmployeeOccupationFixture
                          where employeeOccupationItem?.DismissalDate != null
                          from department in employeeOccupationItem?.Employee?.DepartmentEmployees
                          select
                          new
                          {
                              employeeOccupationItem.Employee?.RegNumber,
                              employeeOccupationItem.Employee?.FirstName,
                              employeeOccupationItem.Employee?.LastName,
                              employeeOccupationItem.Employee?.PatronymicName,
                              employeeOccupationItem.Employee?.BirthDate,
                              employeeOccupationItem.Employee?.Workshop,
                              department,
                              employeeOccupationItem.Occupation
                          }
              ).ToList();
        Assert.Equal(4, thirdQuery.Count);
        Assert.DoesNotContain(thirdQuery, requestElem => requestElem.RegNumber == 1337);
        Assert.DoesNotContain(thirdQuery, requestElem => requestElem.RegNumber == 443);
        Assert.Contains(thirdQuery, requestElem => requestElem.RegNumber == 5);
        Assert.Contains(thirdQuery, requestElem => requestElem.RegNumber == 3);
    }
    /// <summary>
    /// Fourth Query - output an average age of employees for each department
    /// </summary>
    [Fact]
    public void TestFourthQuery()
    {
        var employees = _fixture.EmployeeWithDepartmentEmployeeFilledFixture;
        var fourthQuery =
            (from tuple in
                 (from employee in employees
                  from departmentEmployeeItem in employee.DepartmentEmployees
                  where departmentEmployeeItem.Department != null
                  select new
                  {
                      EmployeeAge = ((DateTime.Now -
                                      employee.BirthDate).TotalDays / 365.2422),
                      DepartmentId = departmentEmployeeItem.Department?.Id
                  }
                  )
             group tuple by tuple.DepartmentId into grp
             select new
             {
                 AverageAge = grp.Average(employee => employee.EmployeeAge),
                 grp.Key
             }
             ).ToList();
        Assert.True(fourthQuery[0].AverageAge >= 37);
        Assert.True(fourthQuery[1].AverageAge >= 38);
        Assert.NotEqual(fourthQuery[0].AverageAge, fourthQuery[1].AverageAge);
        Assert.Equal(2, fourthQuery.Count);
    }
    /// <summary>
    /// Fifth query - output the info about employees, who received a vacation voucher in past year.
    /// </summary>
    [Fact]
    public void TestFifthQuery()
    {
        var fifthQuery = (from employeeVoucherItem in _fixture.EmployeeVacationVoucher
                          where (new DateTime(2023, 3, 10) -
                                 employeeVoucherItem.VacationVoucher?.IssueDate)?.TotalDays < 365
                          select new
                          {
                              employeeVoucherItem.Employee?.RegNumber,
                              employeeVoucherItem.Employee?.FirstName,
                              employeeVoucherItem.Employee?.LastName,
                              employeeVoucherItem.VacationVoucher?.VoucherType
                          }
                          ).ToList();
        Assert.Contains(fifthQuery, queryElem => queryElem.RegNumber == 1337);
        Assert.Contains(fifthQuery, queryElem => queryElem.RegNumber == 443);
        Assert.Equal(2, fifthQuery.Count);
    }
    /// <summary>
    /// Output the top-5 employees who have the longest working experience at the company
    /// </summary>
    [Fact]
    public void TestSixthQuery()
    {
        var subqueryReplaceNull = (from employeeOccupationItem in _fixture.EmployeeOccupationFixture
                                   select new
                                   {
                                       employeeOccupationItem.Employee?.RegNumber,
                                       employeeOccupationItem.HireDate,
                                       DismissalDate = employeeOccupationItem.DismissalDate ?? DateTime.Now,
                                       employeeOccupationItem.Employee?.FirstName,
                                       employeeOccupationItem.Employee?.LastName
                                   }
                                   ).ToList();
        var sixthQuery = (from subqueryElem in subqueryReplaceNull
                          group subqueryElem by new
                          {
                              subqueryElem.RegNumber,
                              subqueryElem.FirstName,
                              subqueryElem.LastName
                          } into grp
                          orderby grp.Sum(subqueryElem =>
                                          (subqueryElem.DismissalDate -
                                           subqueryElem.HireDate).TotalDays / 365.2422) descending
                          select new
                          {
                              grp.Key.RegNumber,
                              grp.Key.FirstName,
                              grp.Key.LastName,
                              WorkExperience = grp.Sum(subqueryElem =>
                              (subqueryElem.DismissalDate -
                               subqueryElem.HireDate).TotalDays / 365.2422)
                          }
                          ).Take(5).ToList();
        Assert.Equal(4, sixthQuery.Count);
        Assert.True(sixthQuery[0].WorkExperience > 24);
        Assert.True(sixthQuery[1].WorkExperience > 23);
        Assert.True(sixthQuery[2].WorkExperience > 22);
        Assert.True(sixthQuery[2].WorkExperience > 4);
        Assert.Equal((uint)3, sixthQuery[0].RegNumber);
        Assert.Equal((uint)1337, sixthQuery[1].RegNumber);
        Assert.Equal((uint)5, sixthQuery[2].RegNumber);
        Assert.Equal((uint)443, sixthQuery[3].RegNumber);
    }
}