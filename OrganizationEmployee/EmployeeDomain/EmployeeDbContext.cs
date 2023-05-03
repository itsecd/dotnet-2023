using Microsoft.EntityFrameworkCore;

namespace EmployeeDomain;
/// <summary>
/// EmployeeDbContext - represents a DbContext used to make queries to database
/// </summary>
public class EmployeeDbContext : DbContext
{
    /// <summary>
    /// Departments - represents a collection of departments in database
    /// </summary>
    public DbSet<Department> Departments { get; set; }
    /// <summary>
    /// Departments - represents a collection of DepartmentEmployee in database
    /// </summary>
    public DbSet<DepartmentEmployee> DepartmentEmployees { get; set; }
    /// <summary>
    /// Employees - represents a collection of employees in database
    /// </summary>
    public DbSet<Employee> Employees { get; set; }
    /// <summary>
    /// EmployeeOccupations - represents a collection of EmployeeOccupation in database
    /// </summary>
    public DbSet<EmployeeOccupation> EmployeeOccupations { get; set; }
    /// <summary>
    /// EmployeeVacationVouchers - represents a collection of EmployeeVacationVoucher in database
    /// </summary>
    public DbSet<EmployeeVacationVoucher> EmployeeVacationVouchers { get; set; }
    /// <summary>
    /// Occupations - represents a collection of occupations in database
    /// </summary>
    public DbSet<Occupation> Occupations { get; set; }
    /// <summary>
    /// VacationVouchers - represents a collection of vacation vouchers in database
    /// </summary>
    public DbSet<VacationVoucher> VacationVouchers { get; set; }
    /// <summary>
    /// VacationVouchersTypes - represents a collection of vacation voucher types in database
    /// </summary>
    public DbSet<VoucherType> VacationVouchersTypes { get; set; }
    /// <summary>
    /// Workshops - represents a collection of workshops in database
    /// </summary>
    public DbSet<Workshop> Workshops { get; set; }
    /// <summary>
    /// The constructor of EmployeeDbContext
    /// </summary>
    /// <param name="options">Parameters for EmployeeDbContext</param>
    public EmployeeDbContext(DbContextOptions options) : base(options)
    {
        Database.EnsureDeleted();
        Database.EnsureCreated();
    }
    /// <summary>
    /// WorkshopRepository - the data of workshops, which is needed to be added into database
    /// </summary>
    public List<Workshop> WorkshopRepository
    {
        get
        {
            return new List<Workshop>
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
                    Name = "Закрытый цех",
                    Id = 5,
                    Employees = new List<Employee>()
                },
                new Workshop
                {
                    Name = "Ульяновский цех",
                    Id = 6,
                    Employees = new List<Employee>()
                },
                new Workshop
                {
                    Name = "Новосибирский цех",
                    Id = 7,
                    Employees = new List<Employee>()
                }
            };
        }

    }
    /// <summary>
    /// VoucherTypeRepository - the data of vacation voucher types,
    /// which is needed to be added into database
    /// </summary>
    public List<VoucherType> VoucherTypeRepository
    {
        get
        {
            return new()
            {
                new VoucherType
                {
                    Name = "Санаторий",
                    Id = 1,
                },
                new VoucherType
                {
                    Name = "Дом отдыха",
                    Id = 2,
                },
                new VoucherType
                {
                    Name = "Пионерский лагерь предприятия",
                    Id = 3,
                },
                new VoucherType
                {
                    Name = "Путевка на горнолыжный курорт",
                    Id = 4,
                }
            };
        }
    }
    /// <summary>
    /// OccupationRepository - the data of occupations, which is needed to be added into database
    /// </summary>
    public List<Occupation> OccupationRepository
    {
        get
        {
            return new()
            {
                new Occupation
                {
                    Name = "Аналитик данных",
                    Id = 1,
                    EmployeeOccupations = new List<EmployeeOccupation>()
                },
                new Occupation
                {
                    Name = "Программист",
                    Id = 2,
                    EmployeeOccupations = new List<EmployeeOccupation>()
                },
                new Occupation
                {
                    Name = "Тестировщик",
                    Id = 3,
                    EmployeeOccupations = new List<EmployeeOccupation>()
                },
                new Occupation
                {
                    Name = "Технический персонал",
                    Id = 4,
                    EmployeeOccupations = new List<EmployeeOccupation>()
                },
                new Occupation
                {
                    Name = "Менеджер",
                    Id = 5,
                    EmployeeOccupations = new List<EmployeeOccupation>()
                },
                new Occupation
                {
                    Name = "Удаленная должность",
                    Id = 6,
                    EmployeeOccupations = new List<EmployeeOccupation>()
                }
            };
        }
    }
    /// <summary>
    /// VacationVoucherRepository - the data of vacation vouchers, which is needed to be added into database
    /// </summary>
    public List<VacationVoucher> VacationVoucherRepository
    {
        get
        {
            return new()
            {
                new VacationVoucher
                {
                    Id = 1,
                    VoucherTypeId = VoucherTypeRepository[0].Id,
                    IssueDate = DateTime.Now.AddDays(-330),
                },
                new VacationVoucher
                {
                    Id = 2,
                    VoucherTypeId = VoucherTypeRepository[1].Id,
                    IssueDate = DateTime.Now.AddDays(-300),
                },
                new VacationVoucher
                {
                    Id = 3,
                    VoucherTypeId = VoucherTypeRepository[2].Id,
                    IssueDate = DateTime.Now.AddYears(-2),
                },
                new VacationVoucher
                {
                    Id = 4,
                    VoucherTypeId = VoucherTypeRepository[2].Id,
                    IssueDate = DateTime.Now.AddYears(-5),
                },
                new VacationVoucher
                {
                    Id = 5,
                    VoucherTypeId = VoucherTypeRepository[2].Id,
                    IssueDate = DateTime.Now.AddYears(-8),
                }
            };
        }
    }
    /// <summary>
    /// DepartmentRepository - the data of departments, which is needed to be added into database
    /// </summary>
    public List<Department> DepartmentRepository
    {
        get
        {
            return new()
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
    /// <summary>
    /// EmployeeRepository - the data of employees, which is needed to be added into database
    /// </summary>
    public List<Employee> EmployeeRepository
    {
        get
        {
            return new()
            {
            new Employee
                {
                    Id = 1,
                    RegNumber = 1337,
                    FirstName = "Владислав",
                    LastName = "Мещеряков",
                    PatronymicName = "Даниилович",
                    BirthDate = new DateTime(1978, 3, 22),
                    WorkshopId = WorkshopRepository[5].Id,
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
                    Id = 2,
                    RegNumber = 443,
                    FirstName = "Сергей",
                    LastName = "Ляхов",
                    PatronymicName = "Сергеевич",
                    BirthDate = new DateTime(2000, 1, 23),
                    WorkshopId = WorkshopRepository[5].Id,
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
                    Id = 3,
                    RegNumber = 3,
                    FirstName = "Михаил",
                    LastName = "Зайцев",
                    PatronymicName = "Иванович",
                    BirthDate = new DateTime(1978, 8, 6),
                    WorkshopId = WorkshopRepository[6].Id,
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
                    Id = 4,
                    RegNumber = 5,
                    FirstName = "Дарья",
                    LastName = "Заварзина",
                    PatronymicName = "Анатольевна",
                    BirthDate = new DateTime(1980, 10, 10),
                    WorkshopId = WorkshopRepository[3].Id,
                    HomeAddress =  "пгт.Безенчук ул.Чапева д.43",
                    HomeTelephone = "89633154365",
                    WorkTelephone = "88462322442",
                    FamilyStatus = "замужем",
                    FamilyMembersCount = 3,
                    ChildrenCount = 1,
                    EmployeeOccupations = new List<EmployeeOccupation>(),
                    DepartmentEmployees = new List<DepartmentEmployee>(),
                    EmployeeVacationVouchers = new List<EmployeeVacationVoucher>()
                },
                new Employee
                {
                    Id = 77,
                    RegNumber = 33,
                    FirstName = "Удаленный",
                    LastName = "Пользователь",
                    PatronymicName = "Сотрудник",
                    BirthDate = new DateTime(),
                    WorkshopId = null,
                    HomeAddress =  "неизвестно",
                    HomeTelephone = "89633154365",
                    WorkTelephone = "88462322442",
                    FamilyStatus = "замужем",
                    FamilyMembersCount = 1,
                    ChildrenCount = 1,
                    EmployeeOccupations = new List<EmployeeOccupation>(),
                    DepartmentEmployees = new List<DepartmentEmployee>(),
                    EmployeeVacationVouchers = new List<EmployeeVacationVoucher>()
                }
            };
        }
    }
    /// <summary>
    /// DepartmentEmployeeRepository - the data of DepartmentEmployee entities, 
    /// which is needed to be added into database
    /// </summary>
    public List<DepartmentEmployee> DepartmentEmployeeRepository
    {
        get
        {
            return new()
            {
                new DepartmentEmployee
                {
                    Id = 1,
                    DepartmentId = DepartmentRepository[0].Id,
                    EmployeeId = EmployeeRepository[0].Id
                },
                new DepartmentEmployee
                {
                    Id = 2,
                    DepartmentId = DepartmentRepository[1].Id,
                    EmployeeId = EmployeeRepository[0].Id
                },
                new DepartmentEmployee
                {
                    Id = 3,
                    DepartmentId = DepartmentRepository[1].Id,
                    EmployeeId = EmployeeRepository[1].Id
                },
                new DepartmentEmployee
                {
                    Id = 4,
                    DepartmentId = DepartmentRepository[0].Id,
                    EmployeeId = EmployeeRepository[2].Id
                },
                new DepartmentEmployee
                {
                    Id = 5,
                    DepartmentId = DepartmentRepository[0].Id,
                    EmployeeId = EmployeeRepository[1].Id
                },
                new DepartmentEmployee
                {
                    Id = 6,
                    DepartmentId = DepartmentRepository[1].Id,
                    EmployeeId = EmployeeRepository[2].Id
                },
                new DepartmentEmployee
                {
                    Id = 7,
                    DepartmentId = DepartmentRepository[1].Id,
                    EmployeeId = EmployeeRepository[3].Id
                }
            };
        }
    }
    /// <summary>
    /// EmployeeOccupationRepository - the data of EmployeeOccupation entities, 
    /// which is needed to be added into database
    /// </summary>
    public List<EmployeeOccupation> EmployeeOccupationRepository
    {
        get
        {
            return new()
            {
                new EmployeeOccupation
                {
                    Id = 1,
                    HireDate = new DateTime(2000, 1, 27),
                    DismissalDate = null,
                    EmployeeId = EmployeeRepository[0].Id,
                    OccupationId = OccupationRepository[1].Id,
                },
                new EmployeeOccupation
                {
                    Id = 2,
                    HireDate = new DateTime(1998, 3, 20),
                    DismissalDate = new DateTime(2010, 5, 23),
                    EmployeeId = EmployeeRepository[2].Id,
                    OccupationId = OccupationRepository[4].Id
                },
                new EmployeeOccupation
                {
                    Id = 3,
                    HireDate = new DateTime(2010, 5, 24),
                    DismissalDate = null,
                    EmployeeId = EmployeeRepository[2].Id,
                    OccupationId = OccupationRepository[1].Id
                },
                new EmployeeOccupation
                {
                    Id = 4,
                    HireDate = new DateTime(2018, 8, 7),
                    DismissalDate = null,
                    EmployeeId = EmployeeRepository[1].Id,
                    OccupationId = OccupationRepository[2].Id
                },
                new EmployeeOccupation
                {
                    Id = 5,
                    HireDate = new DateTime(2000, 9, 10),
                    DismissalDate = new DateTime(2011, 11, 11),
                    EmployeeId = EmployeeRepository[3].Id,
                    OccupationId = OccupationRepository[1].Id
                },
                new EmployeeOccupation
                {
                    Id = 6,
                    HireDate = new DateTime(2011, 11, 12),
                    DismissalDate = new DateTime(2016, 3, 24),
                    EmployeeId = EmployeeRepository[3].Id,
                    OccupationId = OccupationRepository[3].Id
                },
                new EmployeeOccupation
                {
                    Id = 7,
                    HireDate = new DateTime(2016, 3, 25),
                    DismissalDate = null,
                    EmployeeId = EmployeeRepository[3].Id,
                    OccupationId = OccupationRepository[4].Id
                }
            };
        }
    }
    /// <summary>
    /// EmployeeVacationVoucherRepository - the data of EmployeeVacationVoucher entities, 
    /// which is needed to be added into database
    /// </summary>
    public List<EmployeeVacationVoucher> EmployeeVacationVoucherRepository
    {
        get
        {
            return new()
            {
                new EmployeeVacationVoucher
                {
                    Id = 1,
                    EmployeeId = EmployeeRepository[0].Id,
                    VacationVoucherId = VacationVoucherRepository[0].Id
                },
                new EmployeeVacationVoucher
                {
                    Id = 2,
                    EmployeeId = EmployeeRepository[1].Id,
                    VacationVoucherId = VacationVoucherRepository[1].Id
                },
                new EmployeeVacationVoucher
                {
                    Id = 3,
                    EmployeeId = EmployeeRepository[2].Id,
                    VacationVoucherId = VacationVoucherRepository[2].Id
                }
            };
        }
    }
    /// <summary>
    /// Inserts the data into the database
    /// </summary>
    /// <param name="modelBuilder">Entity for configuring the state of database</param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var workshops = WorkshopRepository;
        foreach (var workshop in workshops)
        {
            modelBuilder.Entity<Workshop>().HasData(workshop);
        }

        var voucherTypes = VoucherTypeRepository;
        foreach (var voucherType in voucherTypes)
        {
            modelBuilder.Entity<VoucherType>().HasData(voucherType);
        }

        var occupations = OccupationRepository;
        foreach (var occupation in occupations)
        {
            modelBuilder.Entity<Occupation>().HasData(occupation);
        }

        var vacationVouchers = VacationVoucherRepository;
        foreach (var vacationVoucher in vacationVouchers)
        {
            modelBuilder.Entity<VacationVoucher>().HasData(vacationVoucher);
        }

        var departments = DepartmentRepository;
        foreach (var department in departments)
        {
            modelBuilder.Entity<Department>().HasData(department);
        }

        var employees = EmployeeRepository;
        foreach (var employee in employees)
        {
            modelBuilder.Entity<Employee>().HasData(employee);
        }

        var departmentEmployees = DepartmentEmployeeRepository;
        foreach (var departmentEmployee in departmentEmployees)
        {
            modelBuilder.Entity<DepartmentEmployee>().HasData(departmentEmployee);
        }

        var employeeOccupations = EmployeeOccupationRepository;
        foreach (var employeeOccupation in employeeOccupations)
        {
            modelBuilder.Entity<EmployeeOccupation>().HasData(employeeOccupation);
        }

        var employeeVacationVouchers = EmployeeVacationVoucherRepository;
        foreach (var employeeVacationVoucher in employeeVacationVouchers)
        {
            modelBuilder.Entity<EmployeeVacationVoucher>().HasData(employeeVacationVoucher);
        }
    }
}
