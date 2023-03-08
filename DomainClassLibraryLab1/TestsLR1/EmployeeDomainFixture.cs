using EmployeeDomain;

namespace EmployeeDomainTests;
public class EmployeeDomainFixture
{

    public List<Workshop> WorkshopFixture
    {
        get
        {
            return new List<Workshop>
            {
                new Workshop {
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
        }

    }

    public List<Department> DepartmentFixture
    {
        get 
        {
            return new List<Department>
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
        }
    }

    public List<Occupation> OccupationFixture
    {
        get
        {
            return new List<Occupation>
            {
                new Occupation
                {
                    Name = "Аналитик данных",
                    Id = 0,
                    EmployeeOccupation = new List<EmployeeOccupation>()
                },
                new Occupation
                {
                    Name = "Программист",
                    Id = 1,
                    EmployeeOccupation = new List<EmployeeOccupation>()
                },
                new Occupation
                {
                    Name = "Тестировщик",
                    Id = 2,
                    EmployeeOccupation = new List<EmployeeOccupation>()
                },
                new Occupation
                {
                    Name = "Технический персонал",
                    Id = 3,
                    EmployeeOccupation = new List<EmployeeOccupation>()
                },
                new Occupation
                {
                    Name = "Менеджер",
                    Id = 4,
                    EmployeeOccupation = new List<EmployeeOccupation>()
                }
            };
        }
    }

    public List<VoucherType> VoucherTypeFixture
    {
        get
        {
            return new List<VoucherType>
            {
                new VoucherType
                {
                    Name = "Санаторий",
                    Id = 0,
                    VacationVoucher = new List<VacationVoucher>()
                },
                new VoucherType
                {
                    Name = "Дом отдыха",
                    Id = 1,
                    VacationVoucher = new List<VacationVoucher>()
                },
                new VoucherType
                {
                    Name = "Пионерский лагерь предприятия",
                    Id = 2,
                    VacationVoucher = new List<VacationVoucher>()
                }
            };
        }
    }

    public List<Employee> EmployeeFixture
    {
        get
        {
            return new List<Employee>()
                {
                        new Employee
                        { 
                            Id = Guid.NewGuid(),
                            regNumber = 1337,
                            FirstName = "Владислав",
                            LastName = "Мещеряков",
                            PatronymicName = "Даниилович",
                            BirthDate = new DateOnly(1978, 3, 22),
                            Workshop = null,
                            HomeAddress = "пгт. Безенчук, ул.Нефтянников д.35",
                            HomeTelephone = "89633154365",
                            WorkTelephone = "88462322442",
                            FamilyStatus = "женат",
                            FamilyMembersCount = 4,
                            ChildrenCount = 2,
                            EmployeeOccupation = new List<EmployeeOccupation>(),
                            DepartmentEmployee = new List<DepartmentEmployee>(),
                            EmployeeVacationVoucher = new List<EmployeeVacationVoucher>()
                        },
                        new Employee
                        {
                            Id = Guid.NewGuid(),
                            regNumber = 443,
                            FirstName = "Сергей",
                            LastName = "Ляхов",
                            PatronymicName = "Сергеевич",
                            BirthDate = new DateOnly(2000, 1, 23),
                            Workshop = null,
                            HomeAddress = "г.Самара, ул.Ленина, д.57",
                            HomeTelephone = "89633154365",
                            WorkTelephone = "88462322442",
                            FamilyStatus = "холост",
                            FamilyMembersCount = 3,
                            ChildrenCount = 0,
                            EmployeeOccupation = new List<EmployeeOccupation>(),
                            DepartmentEmployee = new List<DepartmentEmployee>(),
                            EmployeeVacationVoucher = new List<EmployeeVacationVoucher>()
                        },
                        new Employee
                        {
                            Id = Guid.NewGuid(),
                            regNumber = 3,
                            FirstName = "Михаил",
                            LastName = "Зайцев",
                            PatronymicName = "Иванович",
                            BirthDate = new DateOnly(1978, 8, 6),
                            Workshop = null,
                            HomeAddress = "г.Самара Московское шоссе, д.108",
                            HomeTelephone = "89633154365",
                            WorkTelephone = "88462322442",
                            FamilyStatus = "женат",
                            FamilyMembersCount = 5,
                            ChildrenCount = 3,
                            EmployeeOccupation = new List<EmployeeOccupation>(),
                            DepartmentEmployee = new List<DepartmentEmployee>(),
                            EmployeeVacationVoucher = new List<EmployeeVacationVoucher>()
                        },
                        new Employee
                        {
                            Id = Guid.NewGuid(),
                            regNumber = 5,
                            FirstName = "Дарья",
                            LastName = "Заварзина",
                            PatronymicName = "Анатольевна",
                            BirthDate = new DateOnly(1980, 10, 10),
                            Workshop = null,
                            HomeAddress =  "пгт.Безенчук ул.Чапева д.43",
                            HomeTelephone = "89633154365",
                            WorkTelephone = "88462322442",
                            FamilyStatus = "замужем",
                            FamilyMembersCount = 3,
                            ChildrenCount = 1,
                            EmployeeOccupation = new List<EmployeeOccupation>(),
                            DepartmentEmployee = new List<DepartmentEmployee>(),
                            EmployeeVacationVoucher = new List<EmployeeVacationVoucher>()
                        }
                };
        }
    }

    public List<EmployeeOccupation> EmployeeOccupationFixture
    {
        get
        {
            return new List<EmployeeOccupation>
            {
                new EmployeeOccupation
                {
                    Id = 1,
                    HireDate = new DateOnly(2000, 1, 27),
                    DismissalDate = null,
                    Employee = null,
                    Occupation = null
                },
                new EmployeeOccupation
                {
                    Id = 2,
                    HireDate = new DateOnly(1998, 3, 20),
                    DismissalDate = new DateOnly(2010, 5, 23),
                    Employee = null,
                    Occupation = null
                },
                new EmployeeOccupation
                {
                    Id = 3,
                    HireDate = new DateOnly(2010, 5, 24),
                    DismissalDate = null,
                    Employee = null,
                    Occupation = null
                },
                new EmployeeOccupation
                {
                    Id = 4,
                    HireDate = new DateOnly(2018, 8, 7),
                    DismissalDate = null,
                    Employee = null,
                    Occupation = null
                },
                new EmployeeOccupation
                {
                    Id = 5,
                    HireDate = new DateOnly(2000, 9, 10),
                    DismissalDate = new DateOnly(2011, 11, 11),
                    Employee = null,
                    Occupation = null
                },
                new EmployeeOccupation
                {
                    Id = 6,
                    HireDate = new DateOnly(2011, 11, 12),
                    DismissalDate = new DateOnly(2016, 3, 24),
                    Employee = null,
                    Occupation = null
                },
                new EmployeeOccupation
                {
                    Id = 7,
                    HireDate = new DateOnly(2016, 3, 25),
                    DismissalDate = null,
                    Employee = null,
                    Occupation = null
                },

            };
        }
    }

    public List<DepartmentEmployee> DepartmentEmployeeFixture
    {
        get
        {
            var departmentList = DepartmentFixture;
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