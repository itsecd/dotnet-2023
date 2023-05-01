using EmployeeDomain;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace EmployeeDomain;
public class EmployeeDbContext : DbContext
{
    public DbSet<Department> Departments { get; set; }
    public DbSet<DepartmentEmployee> DepartmentEmployees { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<EmployeeOccupation> EmployeeOccupations { get; set; }
    public DbSet<EmployeeVacationVoucher> EmployeeVacationVouchers { get; set; }
    public DbSet<Occupation> Occupations { get; set; }
    public DbSet<VacationVoucher> VacationVouchers { get; set; }
    public DbSet<VoucherType> VacationVouchersTypes { get; set; }
    public DbSet<Workshop> Workshops { get; set; }

    public EmployeeDbContext(DbContextOptions options) : base(options)
    {
        Database.EnsureCreated();
    }
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
                    Name = "Новоспасский цех",
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
                    // VacationVouchers = new List<VacationVoucher>()
                },
                new VoucherType
                {
                    Name = "Дом отдыха",
                    Id = 2,
                    // VacationVouchers = new List<VacationVoucher>()
                },
                new VoucherType
                {
                    Name = "Пионерский лагерь предприятия",
                    Id = 3,
                    // VacationVouchers = new List<VacationVoucher>()
                },
                new VoucherType
                {
                    Name = "Путевка на горнолыжный курорт",
                    Id = 4,
                   // VacationVouchers = new List<VacationVoucher>()
                }
            };
        }
    }

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
                }
            };
        }
    }

    public List<VacationVoucher> VacationVoucherRepository
    {
        get
        {
            var vouchersTypes = VoucherTypeRepository;
            return new()
            {
                new VacationVoucher
                {
                    Id = 1,
                    //VoucherType = vouchersTypes[0],
                    VoucherTypeId = vouchersTypes[0].Id,
                    IssueDate = DateTime.Now.AddDays(-330),
                    // EmployeeVacationVouchers = new List<EmployeeVacationVoucher>()
                },
                new VacationVoucher
                {
                    Id = 2,
                    //VoucherType = vouchersTypes[1],
                    VoucherTypeId = vouchersTypes[1].Id,
                    IssueDate = DateTime.Now.AddDays(-300),
                    // EmployeeVacationVouchers = new List<EmployeeVacationVoucher>()
                },
                new VacationVoucher
                {
                    Id = 3,
                    //VoucherType = vouchersTypes[2],
                    VoucherTypeId = vouchersTypes[2].Id,
                    IssueDate = DateTime.Now.AddYears(-2),
                    // EmployeeVacationVouchers = new List<EmployeeVacationVoucher>()
                },
                new VacationVoucher
                {
                    Id = 4,
                    //VoucherType = vouchersTypes[2],
                    VoucherTypeId = vouchersTypes[2].Id,
                    IssueDate = DateTime.Now.AddYears(-5),
                    // EmployeeVacationVouchers = new List<EmployeeVacationVoucher>()
                },
                new VacationVoucher
                {
                    Id = 5,
                    //VoucherType = vouchersTypes[2],
                    VoucherTypeId = vouchersTypes[2].Id,
                    IssueDate = DateTime.Now.AddYears(-8),
                    // EmployeeVacationVouchers = new List<EmployeeVacationVoucher>()
                }
            };
        }
    }

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

    public List<Employee> EmployeeRepository
    {
        get
        {
            var workshopList = WorkshopRepository;
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
                    WorkshopId = workshopList[4].Id,
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
                    WorkshopId = workshopList[5].Id,
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
                    WorkshopId = workshopList[6].Id,
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
                    WorkshopId = workshopList[3].Id,
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
        }
    }

    public List<DepartmentEmployee> DepartmentEmployeeRepository
    {
        get
        {
            var departments = DepartmentRepository;
            var employees = EmployeeRepository;
            return new()
            {
                new DepartmentEmployee
                {
                    Id = 1,
                    DepartmentId = departments[0].Id,
                    EmployeeId = employees[0].Id
                },
                new DepartmentEmployee
                {
                    Id = 2,
                    DepartmentId = departments[1].Id,
                    EmployeeId = employees[0].Id
                },
                new DepartmentEmployee
                {
                    Id = 3,
                    DepartmentId = departments[1].Id,
                    EmployeeId = employees[1].Id
                },
                new DepartmentEmployee
                {
                    Id = 4,
                    DepartmentId = departments[0].Id,
                    EmployeeId = employees[2].Id
                },
                new DepartmentEmployee
                {
                    Id = 5,
                    DepartmentId = departments[0].Id,
                    EmployeeId = employees[1].Id
                },
                new DepartmentEmployee
                {
                    Id = 6,
                    DepartmentId = departments[1].Id,
                    EmployeeId = employees[2].Id
                },
                new DepartmentEmployee
                {
                    Id = 7,
                    DepartmentId = departments[1].Id,
                    EmployeeId = employees[3].Id
                }
            };
        }
    }

    public List<EmployeeOccupation> EmployeeOccupationRepository
    {
        get
        {
            return new()
            {

            };
        }
    }

protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        //modelBuilder.Entity<DepartmentEmployee>()
        //.HasOne<Department>()
        //.WithMany()
        //.HasForeignKey(deparmentEmployee => deparmentEmployee.DepartmentId)
        //.IsRequired();

        //modelBuilder.Entity<DepartmentEmployee>()
        //.HasOne<Employee>()
        //.WithMany()
        //.HasForeignKey(deparmentEmployee => deparmentEmployee.EmployeeId)
        //.IsRequired();
        //modelBuilder.Entity<VoucherType>().HasMany(type => type.VacationVouchers);
        //modelBuilder.Entity<VacationVoucher>().HasOne(voucher => voucher.VoucherType);

        /*modelBuilder.Entity<VoucherType>()
            .HasMany(type => type.VacationVouchers)
            .WithOne(voucher => voucher.VoucherType)
            .HasForeignKey(voucher => voucher.VoucherTypeId)
            .HasPrincipalKey(type => type.Id); */

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
    }
}
