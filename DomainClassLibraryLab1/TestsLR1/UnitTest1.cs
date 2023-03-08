namespace UnitTestLR1;

using EmployeeDomain;
using EmployeeDomainTests;
using System.Linq;  // для запросов

public class EmployeeDomainTestClass : IClassFixture<EmployeeFixture>   //этот класс на самом деле наследуется от Object
{
    // Существуют факты и теории
    // факты - методы, применяют один метод
    // теория - проверяют несколько значений (?)
    private readonly EmployeeFixture _fixture;
    public EmployeeDomainTestClass(EmployeeFixture fixture)
    {
        _fixture = fixture;
    }
    [Fact]
    public void TestInts()
    {
        var a = 0;
        var b = 2;
        var c = a + b;
        Assert.Equal(2, c);
    }
    [Fact]
    public void TestFirstQuery()
    {
        var workshopList = _fixture.WorkshopFixture;
        /*
        var workshopFirst = new Workshop
        {
            Name = "Ленинский цех",
            Id = 1,
            Employees = new List<Employee>()
        };
        var workshopSecond = new Workshop
        {
            Name = "Производственный цех",
            Id = 2,
            Employees = new List<Employee>()
        };
        var workshopThird = new Workshop
        {
            Name = "Восточный цех",
            Id = 3,
            Employees = new List<Employee>()
        };
        var workshopFourth = new Workshop
        {
            Name = "Волжский цех",
            Id = 4,
            Employees = new List<Employee>()
        };
        var workshopFifth = new Workshop
        {
            Name = "Новоспасский цех",
            Id = 5,
            Employees = new List<Employee>()
        };
        var workshopSixth = new Workshop
        {
            Name = "Ульяновский цех",
            Id = 6,
            Employees = new List<Employee>()
        };*/
        var occupationFirst = new Occupation
        {
            Name = "Аналитик данных",
            Id = 0,
            EmployeeOccupation = new List<EmployeeOccupation>()
        };
        var occupationSecond = new Occupation
        {
            Name = "Программист",
            Id = 1,
            EmployeeOccupation = new List<EmployeeOccupation>()
        };
        var occupationThird = new Occupation
        {
            Name = "Тестировщик",
            Id = 2,
            EmployeeOccupation = new List<EmployeeOccupation>()
        };
        var departmentFirst = new Department
        {
            Name = "Отдел ИБ",
            Id = 1
        };
        var departmentSecond = new Department
        {
            Name = "Отдел программирования",
            Id = 2
        };
        var departmentThird = new Department
        {
            Name = "Отдел кадров",
            Id = 3
        };
        var departmentList = new List<Department>
        {
            new Department
            {
                Name = "Отдел ИБ",
                Id = 1
            },
            new Department
            {
                Name = "Отдел программирования",
                Id = 2
            },
            new Department
            {
                Name = "Отдел кадров",
                Id = 3
            },
            new Department
            {
                Name = "Отдел менеджмента",
                Id=4
            },
            new Department
            {
                Name = "Отдел бухгалтерии",
                Id = 5
            },
            new Department
            {
                Name = "Отдел аналитики данных",
                Id = 6
            },
            new Department
            {
                Name = "Отдел тестирования",
                Id = 7
            },
            new Department
            {
                Name = "Технический отдел",
                Id = 8
            },
            new Department
            {
                Name = "Отдел логистики",
                Id = 9
            },
            new Department
            {
                Name = "Отдел снабжения и закупок",
                Id = 10
            }
        };
        var voucherTypeFirst = new VoucherType
        {
            Name = "Санаторий",
            Id = 0,
            VacationVoucher = new List<VacationVoucher>()
        };
        var voucherTypeSecond = new VoucherType
        {
            Name = "Дом отдыха",
            Id = 1,
            VacationVoucher = new List<VacationVoucher>()
        };
        var voucherTypeThird = new VoucherType
        {
            Name = "Пионерский лагерь предприятия",
            Id = 2,
            VacationVoucher = new List<VacationVoucher>()
        };
        var employees = new List<Employee>()
        {
            new Employee(Guid.NewGuid(), 1337, "Владислав", "Мещеряков", "Даниилович", new DateOnly(1978, 3, 22), workshopList[4],
            "пгт. Безенчук, ул.Нефтянников д.35", "89633154365", "88462322442", "женат", 4, 2, new List<EmployeeOccupation>(),
            new List<DepartmentEmployee>(), new List<EmployeeVacationVoucher>()
            ),
            new Employee(Guid.NewGuid(), 443, "Сергей", "Ляхов", "Сергеевич", new DateOnly(2000, 1, 23), workshopList[5],
            "г.Самара, ул.Ленина, д.57", "89633154365", "88462322442", "холост", 3, 0, new List<EmployeeOccupation>(),
            new List<DepartmentEmployee>(), new List<EmployeeVacationVoucher>()
            ),
            new Employee(Guid.NewGuid(), 3, "Михаил", "Зайцев", "Иванович", new DateOnly(1978, 8, 6), workshopList[5],
            "г.Самара Московское шоссе, д.108", "89633154365", "88462322442", "женат", 5, 3, new List<EmployeeOccupation>(),
            new List<DepartmentEmployee>(), new List<EmployeeVacationVoucher>()
            ),
            new Employee(Guid.NewGuid(), 7, "Дарья", "Заварзина", "Анатольевна", new DateOnly(1980, 10, 10), workshopList[0],
            "пгт.Безенчук ул.Чапева д.43", "89633154365", "88462322442", "замужем", 3, 1, new List<EmployeeOccupation>(),
            new List<DepartmentEmployee>(), new List<EmployeeVacationVoucher>()
            )
        };
        workshopList[4].Employees.Add(employees[0]);
        workshopList[5].Employees.Add(employees[1]);
        workshopList[5].Employees.Add(employees[2]);
        workshopList[0].Employees.Add(employees[3]);
        var departmentEmployeeFirst = new DepartmentEmployee
        {
            Department = departmentList[0],
            Employee = employees[0],
            Id = 1
        };
        var departmentEmployeeSecond = new DepartmentEmployee
        {
            Department = departmentList[1],
            Employee = employees[0],
            Id = 2
        };
        var departmentEmployeeThird = new DepartmentEmployee
        {
            Department = departmentList[1],
            Employee = employees[1],
            Id = 3
        };
        var departmentEmployeeFourth = new DepartmentEmployee
        {
            Department = departmentList[0],
            Employee = employees[2],
            Id = 4
        };
        var departmentEmployeeFifth = new DepartmentEmployee
        {
            Department = departmentList[0],
            Employee = employees[1],
            Id = 5
        };
        var departmentEmployeeSixth = new DepartmentEmployee
        {
            Department = departmentList[1],
            Employee = employees[2],
            Id = 6
        };
        var departmentEmployeeSeventh = new DepartmentEmployee
        {
            Department = departmentList[1],
            Employee = employees[3],
            Id = 7
        };
        employees[0].DepartmentEmployee.Add(departmentEmployeeFirst);
        employees[0].DepartmentEmployee.Add(departmentEmployeeSecond);
        employees[1].DepartmentEmployee.Add(departmentEmployeeThird);
        employees[1].DepartmentEmployee.Add(departmentEmployeeFifth);
        employees[2].DepartmentEmployee.Add(departmentEmployeeFourth);
        employees[2].DepartmentEmployee.Add(departmentEmployeeSixth);
        employees[3].DepartmentEmployee.Add(departmentEmployeeSeventh);
        var departmentEmployeeList = new List<DepartmentEmployee>
        {
            departmentEmployeeFirst,
            departmentEmployeeSecond,
            departmentEmployeeThird,
            departmentEmployeeFourth,
            departmentEmployeeFifth,
            departmentEmployeeSixth,
            departmentEmployeeSeventh
        };
        var requestFirst = (from employee in employees
                            join departmentEmployeeItem in departmentEmployeeList on employee equals departmentEmployeeItem.Employee
                            join department in departmentList on departmentEmployeeItem.Department equals department
                            where department.Id == 1
                            select employee).ToList();
        Assert.Equal(3, requestFirst.Count);

        var requestSecond = (from employee in employees
                             orderby employee.LastName, employee.FirstName, employee.PatronymicName
                             join departmentEmployeeItem in departmentEmployeeList on employee equals departmentEmployeeItem.Employee
                             join department in departmentList on departmentEmployeeItem.Department equals department
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

        //TODO: requestThird

        var requestFourth = 
            (from tuple in (
                                from employee in employees
                                 join departmentEmployeeItem in departmentEmployeeList on employee equals departmentEmployeeItem.Employee
                                 join department in departmentList on departmentEmployeeItem.Department equals department
                                 select new
                                 {
                                     employeeAge = (DateOnly.FromDateTime(DateTime.Now).DayNumber - employee.BirthDate.DayNumber) / 365.2425,
                                     departmentId = department.Id
                                 }   //подзапрос готов, нужен теперь полный..
                            )
               group tuple by tuple.departmentId into grp
               select new
               {
                   averageAge = grp.Average(empl => empl.employeeAge),
                   departmentId = grp.Key
               }).ToList();
        Assert.NotEqual(requestFourth[0].averageAge, requestFourth[1].averageAge);
        var ky2 = 5;
    }
}