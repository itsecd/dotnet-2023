namespace Company.UnitTests;

public class CompanyDomainTests : IClassFixture<CompanyDomainFixture>
{
    private readonly CompanyDomainFixture _companyDomainFixture;

    public CompanyDomainTests(CompanyDomainFixture companyDomainFixture)
    {
        _companyDomainFixture = companyDomainFixture;
    }

    /// <summary>
    /// Test1 - output all Workers of the given Department
    /// </summary>
    [Theory]
    [InlineData(1, 3)]
    [InlineData(2, 3)]
    [InlineData(3, 3)]
    [InlineData(4, 5)]
    public void Test1(int departmentId, int countObjects)
    {
        var query = (from worker in _companyDomainFixture.Workers
                     from obj in worker.WorkerDepartments
                     where obj.DepartmentId == departmentId
                     select worker).ToList();

        Assert.Equal(countObjects, query.Count);
    }

    /// <summary>
    /// Test2 - output all Workers working in more than 1 Department;
    /// Sort the result by last name, first name, patronymic.
    /// </summary>
    [Fact]
    public void Test2()
    {
        var query = (from worker in _companyDomainFixture.Workers
                     orderby worker.LastName, worker.FirstName, worker.Patronymic
                     from obj in worker.WorkerDepartments
                     group worker by new
                     {
                         worker.RegistrationNumber,
                         worker.LastName,
                         worker.FirstName,
                         worker.Patronymic
                     } into grp
                     where grp.Count() > 1
                     orderby grp.Key.LastName, grp.Key.FirstName, grp.Key.Patronymic
                     select new
                     {
                         grp.Key.RegistrationNumber,
                         grp.Key.LastName,
                         grp.Key.FirstName,
                         grp.Key.Patronymic,
                         NumberOfDepartments = grp.Count()
                     }).ToList();

        Assert.Equal(5, query.Count);
        Assert.DoesNotContain(query, queryElem => queryElem.RegistrationNumber == 6666);
        Assert.DoesNotContain(query, queryElem => queryElem.RegistrationNumber == 7777);
        Assert.DoesNotContain(query, queryElem => queryElem.RegistrationNumber == 8888);
    }

    /// <summary>
    /// Test3 - output the archive of dismissals, including registration number, first name, last name, patronymic,
    /// birth date, workshop, department and job of the worker.
    /// </summary>
    [Fact]
    public void Test3()
    {
        DateTime MaxValue = new DateTime(9999, 12, 31);
        var query = (from obj in _companyDomainFixture.WorkersAndJobs
                     where obj?.DismissalDate != MaxValue
                     select new
                     {
                         obj.Worker?.RegistrationNumber,
                         obj.Worker?.LastName,
                         obj.Worker?.FirstName,
                         obj.Worker?.Patronymic,
                         obj.Worker?.BirthDate,
                         ws = from workshop in _companyDomainFixture.Workshops
                              where obj.Worker?.WorkshopId == workshop.Id
                              select workshop.Name,
                         dp = from another_obj in obj.Worker?.WorkerDepartments
                              select another_obj.Department?.Name,
                         obj.Job?.Name
                     }).ToList();

        Assert.Single(query);
        Assert.Contains(query, queryElem => queryElem.RegistrationNumber == 4444);
    }

    /// <summary>
    /// Test4 - output an average age of Workers for each department
    /// </summary>
    [Fact]
    public void Test4()
    {
        var query = (from tuple in from worker in _companyDomainFixture.Workers
                                   from obj in worker.WorkerDepartments
                                   select new
                                   {
                                       workerAge = (DateTime.Now - worker.BirthDate).TotalDays / 365,
                                       departmentId = obj.Department?.Id
                                   }
                     group tuple by tuple.departmentId into grp
                     select new
                     {
                         averageAge = grp.Average(worker => worker.workerAge),
                         grp.Key
                     }).ToList();

        Assert.Equal(4, query.Count);

        Assert.True(query[0].averageAge > 50);
        Assert.True(query[0].averageAge < 51);

        Assert.True(query[1].averageAge > 50);
        Assert.True(query[1].averageAge < 51);

        Assert.True(query[2].averageAge > 49);
        Assert.True(query[2].averageAge < 50);

        Assert.True(query[3].averageAge > 48);
        Assert.True(query[3].averageAge < 49);
    }

    /// <summary>
    /// Test5 - output the info about Workers, who received a vacation in past year.
    /// </summary>
    [Fact]
    public void Test5()
    {
        var query = (from obj in _companyDomainFixture.WorkersAndVacations
                     where (DateTime.Now - obj.Vacation?.IssueDate)?.TotalDays < 365
                     select new
                     {
                         obj.Worker?.RegistrationNumber,
                         obj.Worker?.LastName,
                         obj.Worker?.FirstName,
                         vacationSpot = from vacationSpot in _companyDomainFixture.VacationSpots
                                        where vacationSpot.Id == obj.Vacation?.VacationSpotId
                                        select vacationSpot.Name
                     }).ToList();

        Assert.Equal(2, query.Count);
        Assert.Contains(query, queryElem => queryElem.RegistrationNumber == 3333);
        Assert.Contains(query, queryElem => queryElem.RegistrationNumber == 8888);
    }

    /// <summary>
    /// Test6 - output the top-5 Workers, who have the longest working experience it the company
    /// </summary>
    [Fact]
    public void Test6()
    {
        var additionalQuery = (from obj in _companyDomainFixture.WorkersAndJobs
                               select new
                               {
                                   obj.Worker?.RegistrationNumber,
                                   obj.HireDate,
                                   dismissalDate = (obj.DismissalDate == DateTime.MaxValue) ? DateTime.Now : obj.DismissalDate,
                                   obj.Worker?.LastName,
                                   obj.Worker?.FirstName
                               }).ToList();
        var query = (from obj in additionalQuery
                     group obj by new
                     {
                         obj.RegistrationNumber,
                         obj.LastName,
                         obj.FirstName
                     } into grp
                     let wE = grp.Sum(grpElem => (grpElem.dismissalDate - grpElem.HireDate).TotalDays / 365)
                     orderby wE descending
                     select new
                     {
                         grp.Key.RegistrationNumber,
                         grp.Key.LastName,
                         grp.Key.FirstName,
                         workExperience = wE
                     }).Take(5).ToList();

        Assert.Equal(5, query.Count);

        Assert.True(query[0].RegistrationNumber == 1111);
        Assert.True(query[1].RegistrationNumber == 2222);
        Assert.True(query[2].RegistrationNumber == 3333);
        Assert.True(query[3].RegistrationNumber == 5555);
        Assert.True(query[4].RegistrationNumber == 6666);
    }
}