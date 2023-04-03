namespace RecruitmentAgency;

public class RecruitmentAgencyTests
{
    public static List<Vacancy> VacancyList()
    {
        return new List<Vacancy>()
        {
            new Vacancy("Art", "Guitarist"),
            new Vacancy("Art", "Drummer"),
            new Vacancy("Art", "Bass guitarist"),
            new Vacancy("Art", "Record producer"),
            new Vacancy("Art", "Light director"),
            new Vacancy("IT", "Front-end developer"),
            new Vacancy("IT", "Rust developer"),
            new Vacancy("Education", "Math teacher"),
            new Vacancy("Education", "History teacher"),
            new Vacancy("Education", "PE teacher")
        };
    }

    public static List<Employee> EmployeeList()
    {
        return new List<Employee>()
        {
            new Employee("Osokin Daniil Dmitrievich", "+79871112233", 0, "Secondary education", 50000),
            new Employee("Jason Curtis Newsted", "+12568974152", 30, "Higher education", 200000),
            new Employee("Lelouch Lamperouge", "+811503651451", 3, "Secondary education", 160000),
            new Employee("Handsome Jack", "+0009123457810", 16, "Higher education", 999999999),
            new Employee("Il Palazzo", "+819998887766", 10, "Higher education", null),
            new Employee("Rick Rubin", "+18881234568", 40, "None", 20000000)
        };
    }

    public static List<EmployeeApplication> EmployeeApplicationList(List<Employee> employees, List<Vacancy> vacancies)
    {
        return new List<EmployeeApplication>()
        {
            new EmployeeApplication(employees[0], vacancies[0], new DateTime(2023, 03, 25)),
            new EmployeeApplication(employees[0], vacancies[5], new DateTime(2026, 07, 30)),
            new EmployeeApplication(employees[0], vacancies[6], new DateTime(2023, 02, 28)),
            new EmployeeApplication(employees[1], vacancies[3], new DateTime(1986, 05, 15)),
            new EmployeeApplication(employees[2], vacancies[4], new DateTime(2019, 10, 1)),
            new EmployeeApplication(employees[2], vacancies[8], new DateTime(2020, 02, 29)),
            new EmployeeApplication(employees[3], vacancies[5], new DateTime(2012, 12, 21)),
            new EmployeeApplication(employees[4], vacancies[0], new DateTime(1997, 08, 13)),
            new EmployeeApplication(employees[4], vacancies[2], new DateTime(1997, 08, 15)),
            new EmployeeApplication(employees[5], vacancies[3], new DateTime(2016, 05, 8)),
        };
    }

    public static List<Employer> EmployerList()
    {
        return new List<Employer>()
        {
            new Employer("Horns and hooves", "Ivanov Ivan Ivanovich", "+79271567898"),
            new Employer("Fredguitarist", "Yuri Shilnikov", "+79875551337"),
            new Employer("Vector", "Pupkin Vasiliy Semyonovich", "+78005553535"),
            new Employer("Metallica", "Lars Ulrich", "+15559876543"),
            new Employer("Middle school ¹228", "Shaikhlislamova Guzel Rinatovna", "+998126547895"),
            new Employer("Boobs band", "Shebalkov Pavel Anatolyevich", "+78415758425")
        };
    }

    public static List<EmployerApplication> EmployerApplicationList(List<Employer> employers, List<Vacancy> vacancies)
    {
        return new List<EmployerApplication>()
        {
            new EmployerApplication(employers[0], vacancies[5], 10, "Higher education", 350000, new DateTime(2020, 12, 31)),
            new EmployerApplication(employers[0], vacancies[7], 3, "None", 120000, new DateTime(2018, 06, 19)),
            new EmployerApplication(employers[1], vacancies[0], 0, "None", 30000, new DateTime(2019, 05, 6)),
            new EmployerApplication(employers[2], vacancies[5], 7, "None", 200000, new DateTime(2015, 10, 9)),
            new EmployerApplication(employers[2], vacancies[6], 0, "Secondary education", 100000, new DateTime(2022, 12, 24)),
            new EmployerApplication(employers[3], vacancies[2], 10, "Secondary education", 100000, new DateTime(1986, 09, 15)),
            new EmployerApplication(employers[4], vacancies[7], 0, "Higher education", 25125, new DateTime(2017, 09, 12)),
            new EmployerApplication(employers[4], vacancies[8], 2, "Higher education", 28694, new DateTime(2017, 10, 4)),
            new EmployerApplication(employers[4], vacancies[9], 0, "Higher education", 21420, new DateTime(2017, 10, 17)),
            new EmployerApplication(employers[5], vacancies[1], 0, "None", 0, new DateTime(2020, 01, 1)),
            new EmployerApplication(employers[5], vacancies[3], 2, "None", 80000, new DateTime(2023, 03, 25)),
            new EmployerApplication(employers[5], vacancies[4], 2, "None", 45000, new DateTime(2020, 03, 25)),
        };
    }

    public static List<Vacancy> VacancyListWithApplications()
    {
        var vacancies = VacancyList();
        EmployeeApplicationList(EmployeeList(), vacancies);
        EmployerApplicationList(EmployerList(), vacancies);

        return vacancies;
    }

    /// <summary>
    /// Task 1 - Filter employee by vacancy's name; sort by employee's name
    /// </summary>
    [Fact]
    public void EmployeeFilterByVacancy()
    {
        var result = (from applications in EmployeeApplicationList(EmployeeList(), VacancyList())
                      where applications.Vacancy.Name == "Guitarist"
                      orderby applications.Employee.Name
                      select applications.Employee).ToList();

        Assert.Equal(2, result.Count);
    }

    /// <summary>
    /// Task 2 - Filter employee for a specified period
    /// </summary>
    [Fact]
    public void EmployeeFilterByDate()
    {
        var result = (from applications in EmployeeApplicationList(EmployeeList(), VacancyList())
                      where applications.Date >= new DateTime(1986, 06, 01) && applications.Date <= new DateTime(2013, 01, 1)
                      select applications.Employee).ToList();

        Assert.Equal(3, result.Count);
    }

    /// <summary>
    /// Task 3 - Filter employee by employer requirments
    /// </summary>
    [Fact]
    public void EmployeeFilterByEmployerApplication()
    {
        var vacancyList = VacancyListWithApplications();

        var result = from vacancies in vacancyList
                     from employerApplication in vacancies.EmployerApplicationList.Where(employerApplication => employerApplication.Id == 4)
                     from employeeApplication in vacancies.EmployeeApplicationList.Where(employeeApplication => employeeApplication?.Employee?.Salary <= employerApplication.Salary &&
                        employeeApplication.Employee?.Education == employerApplication.Education && employeeApplication.Vacancy.Name == employerApplication?.Vacancy?.Name &&
                        employeeApplication.Employee?.WorkExperience >= employerApplication.WorkExperience)
                     select new
                     {
                         employee = employeeApplication.Employee,
                     };


        Assert.Single(result);
    }

    /// <summary>
    /// Task 4 - Show info about applications for each sector and for each name
    /// </summary>
    [Fact]
    public void ApplicationCount()
    {
        var vacancyList = VacancyListWithApplications();

        var result = from vacancies in vacancyList
                     select new
                     {
                         vacancySector = vacancies.Sector,
                         vacancyName = vacancies.Name,
                         employeeApplicationsCount = vacancies.EmployeeApplicationList.Count(employeeApplication => employeeApplication.Vacancy.Name == vacancies.Name),
                         employerApplicationsCount = vacancies.EmployerApplicationList.Count(employerApplication => employerApplication?.Vacancy?.Name == vacancies.Name)
                     };

        Assert.Equal(2, result.First().employeeApplicationsCount);
        Assert.Equal("Guitarist", result.First().vacancyName);
    }

    /// <summary>
    /// Task 5 - Show top 5 employer by application count
    /// </summary>
    [Fact]
    public void EmployerTop5List()
    {
        var employerList = EmployerList();
        var result = (from employerApplication in EmployerApplicationList(employerList, VacancyList())
                      group employerApplication by employerApplication?.Employer?.Name into tableGroup
                      orderby tableGroup.Count() descending
                      select new
                      {
                          Company = tableGroup.Key,
                          NumRequests = tableGroup.Count()
                      }).Take(5).ToList();

        Assert.Equal(employerList[0].Name, result[2].Company);
        Assert.Equal(employerList[1].Name, result[4].Company);
        Assert.Equal(employerList[2].Name, result[3].Company);
        Assert.Equal(employerList[4].Name, result[0].Company);
        Assert.Equal(employerList[5].Name, result[1].Company);
    }

    /// <summary>
    /// Task 6 - Filter employers by offered salary
    /// </summary>
    [Fact]
    public void FilterEmployerBiggestSalary()
    {
        var employerApplicationList = EmployerApplicationList(EmployerList(), VacancyList());
        var result = from employerApplication in employerApplicationList
                     where employerApplication.Salary == (from employerApplicationSalaries in employerApplicationList
                                                          select employerApplicationSalaries.Salary).Max()
                     select new
                     {
                         CompanyRequest = employerApplication,
                     };
        Assert.Equal((uint)350000, result.First().CompanyRequest.Salary);
    }
}