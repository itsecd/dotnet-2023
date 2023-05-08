using Microsoft.EntityFrameworkCore;

namespace UniversityData.Domain;
public class UniversityDataDbContext : DbContext
{
    /// <summary>
    /// Коллекция объектов класса ConstructionProperty
    /// </summary>
    public DbSet<ConstructionProperty> ConstructionProperties { get; set; }
    /// <summary>
    /// Коллекция объектов класса Departments
    /// </summary>
    public DbSet<Department> Departments { get; set; }
    /// <summary>
    /// Коллекция объектов класса Faculty
    /// </summary>
    public DbSet<Faculty> Faculties { get; set; }
    /// <summary>
    /// Коллекция объектов класса Rector
    /// </summary>
    public DbSet<Rector> Rectors { get; set; }
    /// <summary>
    /// Коллекция объектов класса Specialty
    /// </summary>
    public DbSet<Specialty> Specialties { get; set; }
    /// <summary>
    /// Коллекция объектов класса SpecialtyTableNode
    /// </summary>
    public DbSet<SpecialtyTableNode> SpecialtyTableNodes { get; set; }
    /// <summary>
    /// Коллекция объектов класса University
    /// </summary>
    public DbSet<University> Universities { get; set; }
    /// <summary>
    /// Коллекция объектов класса UniversityProperty
    /// </summary>
    public DbSet<UniversityProperty> UniversityProperties { get; set; }

    public UniversityDataDbContext(DbContextOptions options) : base(options)
    {
        Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UniversityProperty>().HasData(
            new UniversityProperty
            {
                Id = 1,
                NameUniversityProperty = "муниципальная",
                Universities = new List<University>()
            },
            new UniversityProperty
            {
                Id = 2,
                NameUniversityProperty = "частная",
                Universities = new List<University>()
            });

        modelBuilder.Entity<ConstructionProperty>().HasData(
            new ConstructionProperty
            {
                Id = 1,
                NameConstructionProperty = "муниципальная",
                Universities = new List<University>()
            },
            new ConstructionProperty
            {
                Id = 2,
                NameConstructionProperty = "частная",
                Universities = new List<University>()
            },
            new ConstructionProperty
            {
                Id = 3,
                NameConstructionProperty = "федеральная",
                Universities = new List<University>()
            });

        modelBuilder.Entity<Specialty>().HasData(
            new Specialty
            {
                Id = 1,
                Name = "Прикладная информатика",
                Code = "09.03.03",
                SpecialtyTableNodes = new List<SpecialtyTableNode>()
            },
            new Specialty
            {
                Id = 2,
                Name = "Информационные системы и технологии",
                Code = "09.03.02",
                SpecialtyTableNodes = new List<SpecialtyTableNode>()
            },
            new Specialty
            {
                Id = 3,
                Name = "Информатика и вычислительная техника",
                Code = "09.03.01",
                SpecialtyTableNodes = new List<SpecialtyTableNode>()
            },
            new Specialty
            {
                Id = 4,
                Name = "Прикладная математика и информатика",
                Code = "01.03.02",
                SpecialtyTableNodes = new List<SpecialtyTableNode>()
            },
            new Specialty
            {
                Id = 5,
                Name = "Информационная безопасность автоматизированных систем",
                Code = "10.05.03",
                SpecialtyTableNodes = new List<SpecialtyTableNode>()
            });

        modelBuilder.Entity<Department>().HasData(
            new Department
            {
                Id = 1,
                Name = "ГИиБ",
                SupervisorNumber = "890918734",
                UniversityId = 1
            },
            new Department
            {
                Id = 2,
                Name = "Кафедры алгебры и геометрии",
                SupervisorNumber = "890918735",
                UniversityId = 2
            },
            new Department
            {
                Id = 3,
                Name = "Кафедра высшей математики",
                SupervisorNumber = "890918736",
                UniversityId = 2
            },
            new Department
            {
                Id = 4,
                Name = "Кафедра информационных технологий",
                SupervisorNumber = "890918737",
                UniversityId = 3
            });

        modelBuilder.Entity<Rector>().HasData(
            new Rector
            {
                Id = 1,
                Name = "Владимир",
                Surname = "Богатырев",
                Patronymic = "Дмитриевич",
                Degree = "Доктор экономических наук",
                Title = "Профессор",
                Position = "Ректор",
                UniversityiId = 1
            },
            new Rector
            {
                Id = 2,
                Name = "Дмитрий",
                Surname = "Быков",
                Patronymic = "Евгеньевич",
                Degree = "Доктор технических наук",
                Title = "Профессор",
                Position = "Ректор",
                UniversityiId = 2
            },
            new Rector
            {
                Id = 3,
                Name = "Вадим",
                Surname = "Ружников",
                Patronymic = "Александрович",
                Degree = "Кандидат технических наук",
                Title = "Доцент",
                Position = "Ректор",
                UniversityiId = 3
            });

        modelBuilder.Entity<Faculty>().HasData(
            new Faculty
            {
                Id = 1,
                Name = "Институт информатики и кибернетики",
                WorkersCount = 16,
                StudentsCount = 110,
                UniversityId = 1
            },
            new Faculty
            {
                Id = 2,
                Name = "Институт экономики и управления",
                WorkersCount = 22,
                StudentsCount = 81,
                UniversityId = 1
            },
            new Faculty
            {
                Id = 3,
                Name = "Юридический институт",
                WorkersCount = 11,
                StudentsCount = 65,
                UniversityId = 1
            },
            new Faculty
            {
                Id = 4,
                Name = "Социально-гумманитарный институт",
                WorkersCount = 30,
                UniversityId = 2,
                StudentsCount = 200
            },
            new Faculty
            {
                Id = 5,
                Name = "Институт доп. образования",
                WorkersCount = 22,
                StudentsCount = 62,
                UniversityId = 2
            },
            new Faculty
            {
                Id = 6,
                Name = "Институт двигателей и энергетических установок",
                WorkersCount = 16,
                StudentsCount = 70,
                UniversityId = 3
            });

        modelBuilder.Entity<SpecialtyTableNode>().HasData(
            new SpecialtyTableNode
            {
                Id = 1,
                CountGroups = 8,
                UniversityId = 1,
                SpecialtyId = 1
            },
            new SpecialtyTableNode
            {
                Id = 2,
                CountGroups = 17,
                UniversityId = 2,
                SpecialtyId = 1
            },
            new SpecialtyTableNode
            {
                Id = 3,
                CountGroups = 6,
                UniversityId = 1,
                SpecialtyId = 2
            },
            new SpecialtyTableNode
            {
                Id = 4,
                CountGroups = 6,
                UniversityId = 2,
                SpecialtyId = 2
            },
            new SpecialtyTableNode
            {
                Id = 5,
                CountGroups = 9,
                UniversityId = 2,
                SpecialtyId = 3,
            },
            new SpecialtyTableNode
            {
                Id = 6,
                CountGroups = 4,
                UniversityId = 1,
                SpecialtyId = 3
            },
            new SpecialtyTableNode
            {
                Id = 7,
                CountGroups = 8,
                UniversityId = 2,
                SpecialtyId = 4,
            },
            new SpecialtyTableNode
            {
                Id = 8,
                CountGroups = 8,
                UniversityId = 3,
                SpecialtyId = 4
            },
            new SpecialtyTableNode
            {
                Id = 9,
                CountGroups = 10,
                UniversityId = 3,
                SpecialtyId = 5
            },
            new SpecialtyTableNode
            {
                Id = 10,
                CountGroups = 8,
                UniversityId = 2,
                SpecialtyId = 5
            },
            new SpecialtyTableNode
            {
                Id = 11,
                CountGroups = 8,
                UniversityId = 3,
                SpecialtyId = 1
            });

        modelBuilder.Entity<University>().HasData(
           new University
           {
               Id = 1,
               Number = "12345",
               Name = "Самарский университет",
               Address = "Самара",
               RectorId = 1,
               UniversityPropertyId = 1,
               ConstructionPropertyId = 1,
               DepartmentsData = new List<Department>(),
               FacultiesData = new List<Faculty>(),
               SpecialtyTable = new List<SpecialtyTableNode>()
           },
           new University
           {
               Id = 2,
               Number = "56789",
               Name = "СамГТУ",
               Address = "Самара",
               RectorId = 2,
               UniversityPropertyId = 1,
               ConstructionPropertyId = 1,
               DepartmentsData = new List<Department>(),
               FacultiesData = new List<Faculty>(),
               SpecialtyTable = new List<SpecialtyTableNode>()
           },
           new University
           {
               Id = 3,
               Number = "45678",
               Name = "ПГУТИ",
               Address = "Самара",
               RectorId = 3,
               UniversityPropertyId = 1,
               ConstructionPropertyId = 3,
               DepartmentsData = new List<Department>(),
               FacultiesData = new List<Faculty>(),
               SpecialtyTable = new List<SpecialtyTableNode>()
           });
    }
}
