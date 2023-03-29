using EmployeeDomain;

namespace OrganizationServer;

public class OrganizationRepository
{
    public List<Workshop> Workshops = new()
    {
        new Workshop
        {
            Name = "Ленинский цех",
            Id = 1,
            Employees = new List<Employee>()
        },
        new Workshop
        {
            Name = "Производственный цех",
            Id = 2,
            Employees = new List<Employee>()
        },
        new Workshop {
            Name = "Восточный цех",
            Id = 3,
            Employees = new List<Employee>()
        },
        new Workshop
        {
            Name = "Волжский цех",
            Id = 4,
            Employees = new List<Employee>()
        },
        new Workshop
        {
            Name = "Новоспасский цех",
            Id = 5,
            Employees = new List<Employee>()
        },
        new Workshop
        {
            Name = "Ульяновский цех",
            Id = 6,
            Employees = new List<Employee>()
        }
    };

    public List<Department> Departments = new()
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
            Id = 4
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

    public List<VoucherType> VoucherTypes = new()
    {
        new VoucherType
        {
            Name = "Санаторий",
            Id = 0,
            VacationVouchers = new List<VacationVoucher>()
        },
        new VoucherType
        {
            Name = "Дом отдыха",
            Id = 1,
            VacationVouchers = new List<VacationVoucher>()
        },
        new VoucherType
        {
            Name = "Пионерский лагерь предприятия",
            Id = 2,
            VacationVouchers = new List<VacationVoucher>()
        }
    };

    public List<VacationVoucher> VacationVouchers = new()
    {
        new VacationVoucher
        {
            Id = 1,
            VoucherType = null,
            IssueDate = new DateTime(2022, 3, 22),
            EmployeeVacationVouchers = new List<EmployeeVacationVoucher>()
        },
        new VacationVoucher
        {
            Id = 2,
            VoucherType = null,
            IssueDate = new DateTime(2022, 5, 12),
            EmployeeVacationVouchers = new List<EmployeeVacationVoucher>()
        },
        new VacationVoucher
        {
            Id = 3,
            VoucherType = null,
            IssueDate = new DateTime(2020, 1, 5),
            EmployeeVacationVouchers = new List<EmployeeVacationVoucher>()
        }
    };

    public List<Occupation> Occupations = new()
    {
        new Occupation
        {
            Name = "Аналитик данных",
            Id = 0,
            EmployeeOccupations = new List<EmployeeOccupation>()
        },
        new Occupation
        {
            Name = "Программист",
            Id = 1,
            EmployeeOccupations = new List<EmployeeOccupation>()
        },
        new Occupation
        {
            Name = "Тестировщик",
            Id = 2,
            EmployeeOccupations = new List<EmployeeOccupation>()
        },
        new Occupation
        {
            Name = "Технический персонал",
            Id = 3,
            EmployeeOccupations = new List<EmployeeOccupation>()
        },
        new Occupation
        {
            Name = "Менеджер",
            Id = 4,
            EmployeeOccupations = new List<EmployeeOccupation>()
        }
    };

    public List<Employee> Employees
    {
        get
        {
            var workshopList = Workshops;
            var employeeList = new List<Employee>()
                {
                        new Employee
                        {
                            Id = Guid.NewGuid(),
                            RegNumber = 1337,
                            FirstName = "Владислав",
                            LastName = "Мещеряков",
                            PatronymicName = "Даниилович",
                            BirthDate = new DateTime(1978, 3, 22),
                            Workshop = null,
                            HomeAddress = "пгт. Безенчук, ул.Нефтянников д.35",
                            HomeTelephone = "89633154365",
                            WorkTelephone = "88462322442",
                            FamilyStatus = "женат",
                            FamilyMembersCount = 4,
                            ChildrenCount = 2,
                            EmployeeOccupations = new List<EmployeeOccupation>(),
                            DepartmentEmployees = new List<DepartmentEmployee>(),
                            EmployeeVacationVouchers = new List<EmployeeVacationVoucher>()
                        },
                        new Employee
                        {
                            Id = Guid.NewGuid(),
                            RegNumber = 443,
                            FirstName = "Сергей",
                            LastName = "Ляхов",
                            PatronymicName = "Сергеевич",
                            BirthDate = new DateTime(2000, 1, 23),
                            Workshop = null,
                            HomeAddress = "г.Самара, ул.Ленина, д.57",
                            HomeTelephone = "89633154365",
                            WorkTelephone = "88462322442",
                            FamilyStatus = "холост",
                            FamilyMembersCount = 3,
                            ChildrenCount = 0,
                            EmployeeOccupations = new List<EmployeeOccupation>(),
                            DepartmentEmployees = new List<DepartmentEmployee>(),
                            EmployeeVacationVouchers = new List<EmployeeVacationVoucher>()
                        },
                        new Employee
                        {
                            Id = Guid.NewGuid(),
                            RegNumber = 3,
                            FirstName = "Михаил",
                            LastName = "Зайцев",
                            PatronymicName = "Иванович",
                            BirthDate = new DateTime(1978, 8, 6),
                            Workshop = null,
                            HomeAddress = "г.Самара Московское шоссе, д.108",
                            HomeTelephone = "89633154365",
                            WorkTelephone = "88462322442",
                            FamilyStatus = "женат",
                            FamilyMembersCount = 5,
                            ChildrenCount = 3,
                            EmployeeOccupations = new List<EmployeeOccupation>(),
                            DepartmentEmployees = new List<DepartmentEmployee>(),
                            EmployeeVacationVouchers = new List<EmployeeVacationVoucher>()
                        },
                        new Employee
                        {
                            Id = Guid.NewGuid(),
                            RegNumber = 5,
                            FirstName = "Дарья",
                            LastName = "Заварзина",
                            PatronymicName = "Анатольевна",
                            BirthDate = new DateTime(1980, 10, 10),
                            Workshop = null,
                            HomeAddress =  "пгт.Безенчук ул.Чапева д.43",
                            HomeTelephone = "89633154365",
                            WorkTelephone = "88462322442",
                            FamilyStatus = "замужем",
                            FamilyMembersCount = 3,
                            ChildrenCount = 1,
                            EmployeeOccupations = new List<EmployeeOccupation>(),
                            DepartmentEmployees = new List<DepartmentEmployee>(),
                            EmployeeVacationVouchers = new List<EmployeeVacationVoucher>()
                        }
                };
            workshopList[0].Employees.Add(employeeList[3]);
            workshopList[1].Employees.Add(employeeList[2]);
            workshopList[2].Employees.Add(employeeList[1]);
            workshopList[3].Employees.Add(employeeList[0]);
            employeeList[3].Workshop = workshopList[0];
            employeeList[2].Workshop = workshopList[1];
            employeeList[1].Workshop = workshopList[2];
            employeeList[0].Workshop = workshopList[3];
            return employeeList;
        }

    }

    public List<DepartmentEmployee> DepartmentEmployees
    {
        get
        {
            var departmentList = Departments;
            return new List<DepartmentEmployee>
            {
                new DepartmentEmployee
                {
                    Department = departmentList[0],
                    Employee = null,
                    Id = 1
                },
                new DepartmentEmployee
                {
                    Department = departmentList[1],
                    Employee = null,
                    Id = 2
                },
                new DepartmentEmployee
                {
                    Department = departmentList[1],
                    Employee = null,
                    Id = 3
                },
                new DepartmentEmployee
                {
                    Department = departmentList[0],
                    Employee = null,
                    Id = 4
                },
                new DepartmentEmployee
                {
                    Department = departmentList[0],
                    Employee = null,
                    Id = 5
                },
                new DepartmentEmployee
                {
                    Department = departmentList[1],
                    Employee = null,
                    Id = 6
                },
                new DepartmentEmployee
                {
                    Department = departmentList[1],
                    Employee = null,
                    Id = 7
                }
            };
        }
    }
}
