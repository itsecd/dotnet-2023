using Microsoft.EntityFrameworkCore;

namespace Company.Domain;

/// <summary>
/// CompanyDbContext - represents a DbContext
/// </summary>
public class CompanyDbContext : DbContext
{
    /// <summary>
    /// DepartmentDb - represents a collection of Departments in database
    /// </summary>
    public DbSet<Department> DepartmentDb { get; set; }

    /// <summary>
    /// JobDb - represents a collection of Jobs in database
    /// </summary>
    public DbSet<Job> JobDb { get; set; }

    /// <summary>
    /// VacationDb - represents a collection of Vacations in database
    /// </summary>
    public DbSet<Vacation> VacationDb { get; set; }

    /// <summary>
    /// VacationSpotDb - represents a collection of VacationSpots in database
    /// </summary>
    public DbSet<VacationSpot> VacationSpotDb { get; set; }

    /// <summary>
    /// WorkerDb - represents a collection of Workers in database
    /// </summary>
    public DbSet<Worker> WorkerDb { get; set; }

    /// <summary>
    /// WorkersAndDepartmentsDb - represents a collection of WorkersAndDepartments in database
    /// </summary>
    public DbSet<WorkersAndDepartments> WorkersAndDepartmentsDb { get; set; }

    /// <summary>
    /// WorkersAndJobsDb - represents a collection of WorkersAndJobs in database
    /// </summary>
    public DbSet<WorkersAndJobs> WorkersAndJobsDb { get; set; }

    /// <summary>
    /// WorkersAndVacationsDb - represents a collection of WorkersAndVacations in database
    /// </summary>
    public DbSet<WorkersAndVacations> WorkersAndVacationsDb { get; set; }

    /// <summary>
    /// WorkshopDb - represents a collection of Workshops in database
    /// </summary>
    public DbSet<Workshop> WorkshopDb { get; set; }

    /// <summary>
    /// WorkshopsRepository - stores data about Workshops
    /// </summary>
    public static List<Workshop> WorkshopsRepository
    {
        get
        {
            return new()
            {
                new Workshop { Id = 1, Name = "WS #1" },
                new Workshop { Id = 2, Name = "WS #2" },
                new Workshop { Id = 3, Name = "WS #3" },
                new Workshop { Id = 4, Name = "WS #4" }
            };
        }
    }

    /// <summary>
    /// VacationSpotsRepository - stores data about VacationSpots
    /// </summary>
    public static List<VacationSpot> VacationSpotsRepository
    {
        get
        {
            return new()
            {
                new VacationSpot { Id = 1, Name = "Sanatorium" },
                new VacationSpot { Id = 2, Name = "Holiday home" },
                new VacationSpot { Id = 3, Name = "Pioneer camp" }
            };
        }
    }

    /// <summary>
    /// DepartmentsRepository - stores data about Departments
    /// </summary>
    public static List<Department> DepartmentsRepository
    {
        get
        {
            return new()
            {
                new Department { Id = 1, Name = "DP #1" },
                new Department { Id = 2, Name = "DP #2" },
                new Department { Id = 3, Name = "DP #3" },
                new Department { Id = 4, Name = "DP #4" }
            };
        }
    }

    /// <summary>
    /// JobsRepository - stores data about Jobs
    /// </summary>
    public static List<Job> JobsRepository
    {
        get
        {
            return new()
            {
                new Job { Id = 1, Name = "Job #1" },
                new Job { Id = 2, Name = "Job #2" },
                new Job { Id = 3, Name = "Job #3" }
            };
        }
    }

    /// <summary>
    /// VacationsRepository - stores data about Vacations
    /// </summary>
    public static List<Vacation> VacationsRepository
    {
        get
        {
            return new()
            {
                new Vacation { Id = 1, IssueDate = new DateTime(2011,01,01), VacationSpotId = 1 },
                new Vacation { Id = 2, IssueDate = new DateTime(2012,02,02), VacationSpotId = 2 },
                new Vacation { Id = 3, IssueDate = new DateTime(2023,03,03), VacationSpotId = 2 },
                new Vacation { Id = 4, IssueDate = new DateTime(2014,04,04), VacationSpotId = 3 },
                new Vacation { Id = 5, IssueDate = new DateTime(2023,05,05), VacationSpotId = 3 }
            };
        }
    }

    /// <summary>
    /// WorkersRepository - stores data about Workers
    /// </summary>
    public static List<Worker> WorkersRepository
    {
        get
        {
            return new()
            {
                new Worker
                {
                    Id = 1, RegistrationNumber = 1111, LastName = "LN1", FirstName = "FN1", Patronymic = "P1",
                    BirthDate = new DateTime(1971,01,01), Sex = "male", WorkshopId = 1, HomeAddress = "HA1",
                    HomeTelephone = "01111", WorkTelephone = "01111", MaritalStatus = "single",
                    PeopleInFamily = 1, ChildrenInFamily = 0
                },
                new Worker
                {
                    Id = 2, RegistrationNumber = 2222, LastName = "LN2", FirstName = "FN2", Patronymic = "P2",
                    BirthDate = new DateTime(1972,02,02), Sex = "female", WorkshopId = 2, HomeAddress = "HA2",
                    HomeTelephone = "02222", WorkTelephone = "02222", MaritalStatus = "single",
                    PeopleInFamily = 1, ChildrenInFamily = 0
                },
                new Worker
                {
                    Id = 3, RegistrationNumber = 3333, LastName = "LN3", FirstName = "FN3", Patronymic = "P3",
                    BirthDate = new DateTime(1973,03,03), Sex = "male", WorkshopId = 3, HomeAddress = "HA3",
                    HomeTelephone = "03333", WorkTelephone = "03333", MaritalStatus = "married",
                    PeopleInFamily = 2, ChildrenInFamily = 0
                },
                new Worker
                {
                    Id = 4, RegistrationNumber = 4444, LastName = "LN4", FirstName = "FN4", Patronymic = "P4",
                    BirthDate = new DateTime(1974,04,04), Sex = "female", WorkshopId = 4, HomeAddress = "HA4",
                    HomeTelephone = "04444", WorkTelephone = "04444", MaritalStatus = "married",
                    PeopleInFamily = 4, ChildrenInFamily = 2
                },
                new Worker
                {
                    Id = 5, RegistrationNumber = 5555, LastName = "LN5", FirstName = "FN5", Patronymic = "P5",
                    BirthDate = new DateTime(1975,05,05), Sex = "male", WorkshopId = 1, HomeAddress = "HA5",
                    HomeTelephone = "05555", WorkTelephone = "05555", MaritalStatus = "single",
                    PeopleInFamily = 1, ChildrenInFamily = 0
                },
                new Worker
                {
                    Id = 6, RegistrationNumber = 6666, LastName = "LN6", FirstName = "FN6", Patronymic = "P6",
                    BirthDate = new DateTime(1976,06,06), Sex = "female", WorkshopId = 2, HomeAddress = "HA6",
                    HomeTelephone = "06666", WorkTelephone = "06666", MaritalStatus = "single",
                    PeopleInFamily = 1, ChildrenInFamily = 0
                },
                new Worker
                {
                    Id = 7, RegistrationNumber = 7777, LastName = "LN7", FirstName = "FN7", Patronymic = "P7",
                    BirthDate = new DateTime(1977,07,07), Sex = "male", WorkshopId = 3, HomeAddress = "HA7",
                    HomeTelephone = "07777", WorkTelephone = "07777", MaritalStatus = "married",
                    PeopleInFamily = 3, ChildrenInFamily = 1
                },
                new Worker
                {
                    Id = 8, RegistrationNumber = 8888, LastName = "LN8", FirstName = "FN8", Patronymic = "P8",
                    BirthDate = new DateTime(1978,08,08), Sex = "female", WorkshopId = 4, HomeAddress = "HA8",
                    HomeTelephone = "08888", WorkTelephone = "08888", MaritalStatus = "married",
                    PeopleInFamily = 2, ChildrenInFamily = 0
                }
            };
        }
    }

    /// <summary>
    /// WorkersAndDepartmentsRepository - stores data about WorkersAndDepartments
    /// </summary>
    public static List<WorkersAndDepartments> WorkersAndDepartmentsRepository
    {
        get
        {
            return new()
            {
                new WorkersAndDepartments { Id = 1,  WorkerId = 1, DepartmentId = 1 },
                new WorkersAndDepartments { Id = 2,  WorkerId = 1, DepartmentId = 2 },
                new WorkersAndDepartments { Id = 3,  WorkerId = 2, DepartmentId = 3 },
                new WorkersAndDepartments { Id = 4,  WorkerId = 2, DepartmentId = 4 },
                new WorkersAndDepartments { Id = 5,  WorkerId = 3, DepartmentId = 1 },
                new WorkersAndDepartments { Id = 6,  WorkerId = 3, DepartmentId = 2 },
                new WorkersAndDepartments { Id = 7,  WorkerId = 4, DepartmentId = 3 },
                new WorkersAndDepartments { Id = 8,  WorkerId = 4, DepartmentId = 4 },
                new WorkersAndDepartments { Id = 9,  WorkerId = 5, DepartmentId = 1 },
                new WorkersAndDepartments { Id = 10, WorkerId = 5, DepartmentId = 2 },
                new WorkersAndDepartments { Id = 11, WorkerId = 5, DepartmentId = 3 },
                new WorkersAndDepartments { Id = 12, WorkerId = 6, DepartmentId = 4 },
                new WorkersAndDepartments { Id = 13, WorkerId = 7, DepartmentId = 4 },
                new WorkersAndDepartments { Id = 14, WorkerId = 8, DepartmentId = 4 }
            };
        }
    }

    /// <summary>
    /// WorkersAndJobsRepository - stores data about WorkersAndJobs
    /// </summary>
    public static List<WorkersAndJobs> WorkersAndJobsRepository
    {
        get
        {
            return new()
            {
                new WorkersAndJobs { Id = 1, HireDate = new DateTime(2001,01,01), WorkerId = 1, JobId = 1 },
                new WorkersAndJobs { Id = 2, HireDate = new DateTime(2002,02,02), WorkerId = 2, JobId = 1 },
                new WorkersAndJobs { Id = 3, HireDate = new DateTime(2003,03,03), WorkerId = 3, JobId = 1 },
                new WorkersAndJobs { Id = 4, HireDate = new DateTime(2004,04,04), DismissalDate = new DateTime(2009,09,09), WorkerId = 4, JobId = 1 },
                new WorkersAndJobs { Id = 5, HireDate = new DateTime(2005,05,05), WorkerId = 5, JobId = 2 },
                new WorkersAndJobs { Id = 6, HireDate = new DateTime(2006,06,06), WorkerId = 6, JobId = 2 },
                new WorkersAndJobs { Id = 7, HireDate = new DateTime(2007,07,07), WorkerId = 7, JobId = 3 },
                new WorkersAndJobs { Id = 8, HireDate = new DateTime(2008,08,08), WorkerId = 8, JobId = 3 }
            };
        }
    }

    /// <summary>
    /// WorkersAndVacationsRepository - stores data about WorkersAndVacations
    /// </summary>
    public static List<WorkersAndVacations> WorkersAndVacationsRepository
    {
        get
        {
            return new()
            {
                new WorkersAndVacations { Id = 1, WorkerId = 1, VacationId = 1 },
                new WorkersAndVacations { Id = 2, WorkerId = 2, VacationId = 2 },
                new WorkersAndVacations { Id = 3, WorkerId = 3, VacationId = 3 },
                new WorkersAndVacations { Id = 4, WorkerId = 7, VacationId = 4 },
                new WorkersAndVacations { Id = 5, WorkerId = 8, VacationId = 5 },
            };
        }
    }

    /// <summary>
    /// The constructor of EmployeeDbContext
    /// </summary>
    public CompanyDbContext(DbContextOptions options) : base(options)
    {
        Database.EnsureCreated();
    }

    /// <summary>
    /// Inserts data into the database
    /// </summary>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        var workshops = WorkshopsRepository;
        foreach (var workshop in workshops)
            modelBuilder.Entity<Workshop>().HasData(workshop);

        var vacationSpots = VacationSpotsRepository;
        foreach (var vacationSpot in vacationSpots)
            modelBuilder.Entity<VacationSpot>().HasData(vacationSpot);

        var departments = DepartmentsRepository;
        foreach (var department in departments)
            modelBuilder.Entity<Department>().HasData(department);

        var jobs = JobsRepository;
        foreach (var job in jobs)
            modelBuilder.Entity<Job>().HasData(job);

        var vacations = VacationsRepository;
        foreach (var vacation in vacations)
            modelBuilder.Entity<Vacation>().HasData(vacation);

        var workers = WorkersRepository;
        foreach (var worker in workers)
            modelBuilder.Entity<Worker>().HasData(worker);

        var workersAndDepartments = WorkersAndDepartmentsRepository;
        foreach (var workerAndDepartment in workersAndDepartments)
            modelBuilder.Entity<WorkersAndDepartments>().HasData(workerAndDepartment);

        var workersAndJobs = WorkersAndJobsRepository;
        foreach (var workerAndJob in workersAndJobs)
            modelBuilder.Entity<WorkersAndJobs>().HasData(workerAndJob);

        var workersAndVacations = WorkersAndVacationsRepository;
        foreach (var workerAndVacation in workersAndVacations)
            modelBuilder.Entity<WorkersAndVacations>().HasData(workerAndVacation);
    }
}
