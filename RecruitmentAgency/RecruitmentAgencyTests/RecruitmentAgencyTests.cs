namespace RecruitmentAgency;

public class RecruitmentAgencyTests
{
    public List<Vacancy> VacancyList()
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

    public List<Employee> EmployeeList()
    {
        return new List<Employee>()
        {
            new Employee("Osokin Daniil Dmitrievich", "+79871112233", null, "Secondary Education", 50000),
            new Employee("Jason Curtis Newsted", "+12568974152", 30, "Baccalaureate", 200000),
            new Employee("Lelouch Lamperouge", "+811503651451", 3, "Secondary Education", 160000),
            new Employee("Handsome Jack", "+0009123457810", 16, "Doctor of engineering", 999999999),
            new Employee("Il Palazzo", "+819998887766", 10, "Baccalaureate", null),
            new Employee("Rick Rubin", "+18881234568", 40, null, 20000000)
        };
    }

    public List<EmployeeApplication> EmployeeApplicationList(List<Employee> employees, List<Vacancy> vacancies)
    {
        return new List<EmployeeApplication>()
        {
            new EmployeeApplication(employees[0], vacancies[0], new DateTime(2023, 03, 25)),
            new EmployeeApplication(employees[0], vacancies[5], new DateTime(2026, 07, 30)),
            new EmployeeApplication(employees[0], vacancies[6], new DateTime(2023, 07, 30)),
            new EmployeeApplication(employees[1], vacancies[3], new DateTime(1986, 05, 15)),
            new EmployeeApplication(employees[2], vacancies[4], new DateTime(2019, 10, 1)),
            new EmployeeApplication(employees[2], vacancies[8], new DateTime(2020, 02, 29)),
            new EmployeeApplication(employees[3], vacancies[5], new DateTime(2012, 12, 21)),
            new EmployeeApplication(employees[4], vacancies[0], new DateTime(1997, 08, 13)),
            new EmployeeApplication(employees[4], vacancies[2], new DateTime(1997, 08, 15)),
            new EmployeeApplication(employees[5], vacancies[3], new DateTime(2016, 05, 8)),
        };


    }

    public List<Employer> EmployerList()
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

    public List<EmployerApplication> EmployerApplicationList(List<Employer> employers, List<Vacancy> vacancies)
    {
        return new List<EmployerApplication>()
        {
            new EmployerApplication(employers[0], vacancies[5], 10, "IT Higher education", 350000, new DateTime(2020, 12, 31)),
            new EmployerApplication(employers[0], vacancies[7], 3, null, 200000, new DateTime(2018, 06, 19)),
            new EmployerApplication(employers[1], vacancies[0], null, null, 30000, new DateTime(2019, 05, 6)),
            new EmployerApplication(employers[2], vacancies[5], 7, null, 200000, new DateTime(2015, 10, 9)),
            new EmployerApplication(employers[2], vacancies[6], 3, null, 140000, new DateTime(2023, 04, 1)),
            new EmployerApplication(employers[3], vacancies[2], 10, "Secondary education", 100000, new DateTime(1986, 09, 15)),
            new EmployerApplication(employers[4], vacancies[7], null, "Higher education", 25125, new DateTime(2017, 09, 12)),
            new EmployerApplication(employers[4], vacancies[8], 2, "Higher education", 28694, new DateTime(2017, 10, 4)),
            new EmployerApplication(employers[4], vacancies[9], null, "Higher education", 21420, new DateTime(2017, 10, 17)),
            new EmployerApplication(employers[5], vacancies[1], null, null, null, new DateTime(2020, 01, 1)),
            new EmployerApplication(employers[5], vacancies[3], null, null, 80000, new DateTime(2023, 03, 25)),
            new EmployerApplication(employers[5], vacancies[4], null, null, 45000, new DateTime(2020, 03, 25)),
        };
    }

    /// <summary>
    /// Task 1 - Filter employee by vacancy name; sort by employee name
    /// </summary>
    [Fact]
    public void EmployeeFilterVacancy()
    {
        var employeeApplicationList = EmployeeApplicationList(EmployeeList(), VacancyList());

        var result = (from applications in employeeApplicationList
                      where applications.Vacancy.Name == "Name"
                      orderby applications.Employee.Name
                      select applications.Employee).ToList();

        Assert.Equal(5, result.Count);
    }

    /// <summary>
    /// Task 2 - Filter employee for a specified period
    /// </summary>
    [Fact]
    public void EmployeeFilterDate()
    {
        var employeeApplicationList = EmployeeApplicationList(EmployeeList(), VacancyList());

        var result = (from applications in employeeApplicationList
                      where applications.Date >= new DateTime(2022, 2, 9) && applications.Date <= new DateTime(2022, 8, 8)
                      select applications.Employee).ToList();

        Assert.Equal(5, result.Count);
    }

}