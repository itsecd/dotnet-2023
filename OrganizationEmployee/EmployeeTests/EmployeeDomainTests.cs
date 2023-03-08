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
                          from departmentEmployeeItem in employee.DepartmentEmployee
                          where departmentEmployeeItem.Department != null && departmentEmployeeItem.Department.Id == departmentId
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
                           from departmentEmployeeItem in employee.DepartmentEmployee
                           group employee by new { employee.regNumber, employee.LastName, employee.FirstName, employee.PatronymicName } into grp
                           where grp.Count() > 1
                           orderby grp.Key.LastName, grp.Key.FirstName, grp.Key.PatronymicName
                           select new
                           {
                               regNumber = grp.Key.regNumber,
                               FirstName = grp.Key.FirstName,
                               LastName = grp.Key.LastName,
                               PatronymicName = grp.Key.PatronymicName,
                               CountDepart = grp.Count()
                           }).ToList();
        Assert.Equal(3, secondQuery.Count);
        Assert.DoesNotContain(secondQuery, requestElem => requestElem.regNumber == 5);
        Assert.Contains(secondQuery, requestElem => requestElem.regNumber == 1337);
        Assert.Contains(secondQuery, requestElem => requestElem.regNumber == 443);
        Assert.Contains(secondQuery, requestElem => requestElem.regNumber == 3);
    }
    /// <summary>
    /// Third query - output the archive of dismissals, including registration number, first name, last name, patronymic name,
    /// date of birth, workshop, department, occupation of the employee.
    /// </summary>
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
    /// <summary>
    /// Fourth Query - output an average age of employees for each department
    /// </summary>
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
        Assert.True(fourthQuery[0].averageAge > 37);
        Assert.True(fourthQuery[1].averageAge > 38);
        Assert.NotEqual(fourthQuery[0].averageAge, fourthQuery[1].averageAge);
        Assert.Equal(2, fourthQuery.Count());
    }
    /// <summary>
    /// Fifth query - output the info about employees, who received a vacation voucher in past year.
    /// </summary>
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
    /// <summary>
    /// Output the top-5 employees who have the longest working experience at the company
    /// </summary>
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
                            ).Take(5).ToList();
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