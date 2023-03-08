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

    public List<Employee> EmployeeOnlyWorkshopFilledFixture
    {
        get
        {
            var workshopList = WorkshopFixture;
            var employeeList = new List<Employee>()
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

    public List<EmployeeOccupation> EmployeeOccupationFixture
    {
        get
        {
            var employeeList = EmployeeOnlyWorkshopFilledFixture;
            var occupationList = OccupationFixture;
            var departmentEmployeeList = DepartmentEmployeeFixture;
            var employeeOccupationList = new List<EmployeeOccupation>
            {
                new EmployeeOccupation
                {
                    Id = 1,
                    HireDate = new DateOnly(2000, 1, 27),
                    DismissalDate = null,
                    Employee = employeeList[0],
                    Occupation = occupationList[1],
                },
                new EmployeeOccupation
                {
                    Id = 2,
                    HireDate = new DateOnly(1998, 3, 20),
                    DismissalDate = new DateOnly(2010, 5, 23),
                    Employee = employeeList[2],
                    Occupation = occupationList[4]
                },
                new EmployeeOccupation
                {
                    Id = 3,
                    HireDate = new DateOnly(2010, 5, 24),
                    DismissalDate = null,
                    Employee = employeeList[2],
                    Occupation = occupationList[1]
                },
                new EmployeeOccupation
                {
                    Id = 4,
                    HireDate = new DateOnly(2018, 8, 7),
                    DismissalDate = null,
                    Employee = employeeList[1],
                    Occupation = occupationList[2]
                },
                new EmployeeOccupation
                {
                    Id = 5,
                    HireDate = new DateOnly(2000, 9, 10),
                    DismissalDate = new DateOnly(2011, 11, 11),
                    Employee = employeeList[3],
                    Occupation = occupationList[1]
                },
                new EmployeeOccupation
                {
                    Id = 6,
                    HireDate = new DateOnly(2011, 11, 12),
                    DismissalDate = new DateOnly(2016, 3, 24),
                    Employee = employeeList[3],
                    Occupation = occupationList[3]
                },
                new EmployeeOccupation
                {
                    Id = 7,
                    HireDate = new DateOnly(2016, 3, 25),
                    DismissalDate = null,
                    Employee = employeeList[3],
                    Occupation = occupationList[4]
                }
            };
            employeeList[0].EmployeeOccupation.Add(employeeOccupationList[0]);
            employeeList[2].EmployeeOccupation.Add(employeeOccupationList[1]);
            employeeList[2].EmployeeOccupation.Add(employeeOccupationList[2]);
            employeeList[1].EmployeeOccupation.Add(employeeOccupationList[3]);
            employeeList[3].EmployeeOccupation.Add(employeeOccupationList[4]);
            employeeList[3].EmployeeOccupation.Add(employeeOccupationList[5]);
            employeeList[3].EmployeeOccupation.Add(employeeOccupationList[6]);
            occupationList[1].EmployeeOccupation.Add(employeeOccupationList[0]);
            occupationList[1].EmployeeOccupation.Add(employeeOccupationList[2]);
            occupationList[1].EmployeeOccupation.Add(employeeOccupationList[4]);
            occupationList[4].EmployeeOccupation.Add(employeeOccupationList[1]);
            occupationList[4].EmployeeOccupation.Add(employeeOccupationList[6]);
            occupationList[2].EmployeeOccupation.Add(employeeOccupationList[3]);
            occupationList[3].EmployeeOccupation.Add(employeeOccupationList[5]);

            employeeList[0].DepartmentEmployee.Add(departmentEmployeeList[0]);
            employeeList[0].DepartmentEmployee.Add(departmentEmployeeList[1]);
            employeeList[1].DepartmentEmployee.Add(departmentEmployeeList[2]);
            employeeList[1].DepartmentEmployee.Add(departmentEmployeeList[3]);
            employeeList[2].DepartmentEmployee.Add(departmentEmployeeList[4]);
            employeeList[2].DepartmentEmployee.Add(departmentEmployeeList[5]);
            employeeList[3].DepartmentEmployee.Add(departmentEmployeeList[6]);
            departmentEmployeeList[0].Employee = employeeList[0];
            departmentEmployeeList[1].Employee = employeeList[0];
            departmentEmployeeList[2].Employee = employeeList[1];
            departmentEmployeeList[3].Employee = employeeList[2];
            departmentEmployeeList[4].Employee = employeeList[1];
            departmentEmployeeList[5].Employee = employeeList[2];
            departmentEmployeeList[6].Employee = employeeList[3];
            return employeeOccupationList;
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


    public List<Employee> EmployeeWithDepartmentEmployeeFilledFixture
    {
        get
        {
            var departmentList = DepartmentFixture;
            var employees = EmployeeOnlyWorkshopFilledFixture;
            var departmentEmployeeList = DepartmentEmployeeFixture;
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
            return employees;
        }
    }

    public List<VacationVoucher> VacationVoucherFixture
    {
        get
        {
            var voucherTypes = VoucherTypeFixture;
            var vacationVouchers = new List<VacationVoucher>
            {
                new VacationVoucher
                {
                    Id = 1,
                    VoucherType = null,
                    IssueDate = new DateOnly(2022, 3, 22),
                    EmployeeVacationVoucher = new List<EmployeeVacationVoucher>()
                },
                new VacationVoucher
                {
                    Id = 2,
                    VoucherType = null,
                    IssueDate = new DateOnly(2022, 5, 12),
                    EmployeeVacationVoucher = new List<EmployeeVacationVoucher>()
                },
                new VacationVoucher
                {
                    Id = 3,
                    VoucherType = null,
                    IssueDate = new DateOnly(2020, 1, 5),
                    EmployeeVacationVoucher = new List<EmployeeVacationVoucher>()
                }
            };
            voucherTypes[0].VacationVoucher.Add(vacationVouchers[0]);
            voucherTypes[1].VacationVoucher.Add(vacationVouchers[1]);
            voucherTypes[2].VacationVoucher.Add(vacationVouchers[2]);
            vacationVouchers[0].VoucherType = voucherTypes[0];
            vacationVouchers[1].VoucherType = voucherTypes[1];
            vacationVouchers[2].VoucherType = voucherTypes[2];
            return vacationVouchers;
        }
    }

    public List<EmployeeVacationVoucher> EmployeeVacationVoucher
    {
        get
        {
            var employees = EmployeeOnlyWorkshopFilledFixture;
            var vacationVouchers = VacationVoucherFixture;
            var employeeVacationVoucherList = new List<EmployeeVacationVoucher>()
            {
                new EmployeeVacationVoucher
                {
                    Id = 1,
                    Employee = null,
                    VacationVoucher = null
                },
                new EmployeeVacationVoucher
                {
                    Id = 2,
                    Employee = null,
                    VacationVoucher = null
                },
                new EmployeeVacationVoucher
                {
                    Id = 3,
                    Employee = null,
                    VacationVoucher = null
                }
            };
            employees[0].EmployeeVacationVoucher.Add(employeeVacationVoucherList[0]);
            employees[1].EmployeeVacationVoucher.Add(employeeVacationVoucherList[1]);
            employees[2].EmployeeVacationVoucher.Add(employeeVacationVoucherList[2]);
            vacationVouchers[0].EmployeeVacationVoucher.Add(employeeVacationVoucherList[0]);
            vacationVouchers[1].EmployeeVacationVoucher.Add(employeeVacationVoucherList[1]);
            vacationVouchers[2].EmployeeVacationVoucher.Add(employeeVacationVoucherList[2]);
            employeeVacationVoucherList[0].Employee = employees[0];
            employeeVacationVoucherList[1].Employee = employees[1];
            employeeVacationVoucherList[2].Employee = employees[2];
            employeeVacationVoucherList[0].VacationVoucher = vacationVouchers[0];
            employeeVacationVoucherList[1].VacationVoucher = vacationVouchers[1];
            employeeVacationVoucherList[2].VacationVoucher = vacationVouchers[2];
            return employeeVacationVoucherList;
        }
    }
}