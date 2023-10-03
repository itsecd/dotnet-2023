using Company.Domain;

namespace Company.Server.Repository;


static class ListExtensions
{
    static public void Add<T>(this List<T> list, params T[] additions)
    {
        foreach (T addition in additions)
            list.Add(addition);
    }
}

public class CompanyRepository : ICompanyRepository
{
    private readonly List<Workshop> _workshops;
    private readonly List<VacationSpot> _vacationSpots;
    private readonly List<Department> _departments;
    private readonly List<Job> _jobs;
    private readonly List<Vacation> _vacations;
    private readonly List<Worker> _workers;
    private readonly List<WorkersAndDepartments> _workersAndDepartments;
    private readonly List<WorkersAndJobs> _workersAndJobs;
    private readonly List<WorkersAndVacations> _workersAndVacations;

    public CompanyRepository()
    {
        _workshops = new List<Workshop>
        {
            new Workshop { Id = 1, Name = "WS #1", Workers = new List<Worker>() },
            new Workshop { Id = 2, Name = "WS #2", Workers = new List<Worker>() },
            new Workshop { Id = 3, Name = "WS #3", Workers = new List<Worker>() },
            new Workshop { Id = 4, Name = "WS #4", Workers = new List<Worker>() }
        };
        _vacationSpots = new List<VacationSpot>
        {
            new VacationSpot { Id = 1, Name = "Sanatorium" },
            new VacationSpot { Id = 2, Name = "Holiday home" },
            new VacationSpot { Id = 3, Name = "Pioneer camp" }
        };
        _departments = new List<Department>
        {
            new Department { Id = 1, Name = "DP #1", DepartmentWorkers = new List<WorkersAndDepartments>() },
            new Department { Id = 2, Name = "DP #2", DepartmentWorkers = new List<WorkersAndDepartments>() },
            new Department { Id = 3, Name = "DP #3", DepartmentWorkers = new List<WorkersAndDepartments>() },
            new Department { Id = 4, Name = "DP #4", DepartmentWorkers = new List<WorkersAndDepartments>() }
        };
        _jobs = new List<Job>
        {
            new Job { Id = 1, Name = "Job #1", JobWorkers = new List<WorkersAndJobs>() },
            new Job { Id = 2, Name = "Job #2", JobWorkers = new List<WorkersAndJobs>() },
            new Job { Id = 3, Name = "Job #3", JobWorkers = new List<WorkersAndJobs>() }
        };
        _vacations = new List<Vacation>
        {
            new Vacation { Id = 1, IssueDate = new DateTime(2011,01,01), VacationSpotId = 1, VacationWorkers = new List<WorkersAndVacations>() },
            new Vacation { Id = 2, IssueDate = new DateTime(2012,02,02), VacationSpotId = 2, VacationWorkers = new List<WorkersAndVacations>() },
            new Vacation { Id = 3, IssueDate = new DateTime(2023,03,03), VacationSpotId = 2, VacationWorkers = new List<WorkersAndVacations>() },
            new Vacation { Id = 4, IssueDate = new DateTime(2014,04,04), VacationSpotId = 3, VacationWorkers = new List<WorkersAndVacations>() },
            new Vacation { Id = 5, IssueDate = new DateTime(2023,05,05), VacationSpotId = 3, VacationWorkers = new List<WorkersAndVacations>() }
        };
        _workers = new List<Worker>
        {
            new Worker
            {
                Id = 1, RegistrationNumber = 1111, LastName = "LN1", FirstName = "FN1", Patronymic = "P1",
                BirthDate = new DateTime(1971,01,01), Sex = "male", WorkshopId = 1, HomeAddress = "HA1",
                HomeTelephone = "01111", WorkTelephone = "01111", MaritalStatus = "single",
                PeopleInFamily = 1, ChildrenInFamily = 0, WorkerDepartments = new List<WorkersAndDepartments>(),
                WorkerJobs = new List<WorkersAndJobs>(), WorkerVacations = new List<WorkersAndVacations>()
            },
            new Worker
            {
                Id = 2, RegistrationNumber = 2222, LastName = "LN2", FirstName = "FN2", Patronymic = "P2",
                BirthDate = new DateTime(1972,02,02), Sex = "female", WorkshopId = 2, HomeAddress = "HA2",
                HomeTelephone = "02222", WorkTelephone = "02222", MaritalStatus = "single",
                PeopleInFamily = 1, ChildrenInFamily = 0, WorkerDepartments = new List<WorkersAndDepartments>(),
                WorkerJobs = new List<WorkersAndJobs>(), WorkerVacations = new List<WorkersAndVacations>()
            },
            new Worker
            {
                Id = 3, RegistrationNumber = 3333, LastName = "LN3", FirstName = "FN3", Patronymic = "P3",
                BirthDate = new DateTime(1973,03,03), Sex = "male", WorkshopId = 3, HomeAddress = "HA3",
                HomeTelephone = "03333", WorkTelephone = "03333", MaritalStatus = "married",
                PeopleInFamily = 2, ChildrenInFamily = 0, WorkerDepartments = new List<WorkersAndDepartments>(),
                WorkerJobs = new List<WorkersAndJobs>(), WorkerVacations = new List<WorkersAndVacations>()
            },
            new Worker
            {
                Id = 4, RegistrationNumber = 4444, LastName = "LN4", FirstName = "FN4", Patronymic = "P4",
                BirthDate = new DateTime(1974,04,04), Sex = "female", WorkshopId = 4, HomeAddress = "HA4",
                HomeTelephone = "04444", WorkTelephone = "04444", MaritalStatus = "married",
                PeopleInFamily = 4, ChildrenInFamily = 2, WorkerDepartments = new List<WorkersAndDepartments>(),
                WorkerJobs = new List<WorkersAndJobs>(), WorkerVacations = new List<WorkersAndVacations>()
            },
            new Worker
            {
                Id = 5, RegistrationNumber = 5555, LastName = "LN5", FirstName = "FN5", Patronymic = "P5",
                BirthDate = new DateTime(1975,05,05), Sex = "male", WorkshopId = 1, HomeAddress = "HA5",
                HomeTelephone = "05555", WorkTelephone = "05555", MaritalStatus = "single",
                PeopleInFamily = 1, ChildrenInFamily = 0, WorkerDepartments = new List<WorkersAndDepartments>(),
                WorkerJobs = new List<WorkersAndJobs>(), WorkerVacations = new List<WorkersAndVacations>()
            },
            new Worker
            {
                Id = 6, RegistrationNumber = 6666, LastName = "LN6", FirstName = "FN6", Patronymic = "P6",
                BirthDate = new DateTime(1976,06,06), Sex = "female", WorkshopId = 2, HomeAddress = "HA6",
                HomeTelephone = "06666", WorkTelephone = "06666", MaritalStatus = "single",
                PeopleInFamily = 1, ChildrenInFamily = 0, WorkerDepartments = new List<WorkersAndDepartments>(),
                WorkerJobs = new List<WorkersAndJobs>(), WorkerVacations = new List<WorkersAndVacations>()
            },
            new Worker
            {
                Id = 7, RegistrationNumber = 7777, LastName = "LN7", FirstName = "FN7", Patronymic = "P7",
                BirthDate = new DateTime(1977,07,07), Sex = "male", WorkshopId = 3, HomeAddress = "HA7",
                HomeTelephone = "07777", WorkTelephone = "07777", MaritalStatus = "married",
                PeopleInFamily = 3, ChildrenInFamily = 1, WorkerDepartments = new List<WorkersAndDepartments>(),
                WorkerJobs = new List<WorkersAndJobs>(), WorkerVacations = new List<WorkersAndVacations>()
            },
            new Worker
            {
                Id = 8, RegistrationNumber = 8888, LastName = "LN8", FirstName = "FN8", Patronymic = "P8",
                BirthDate = new DateTime(1978,08,08), Sex = "female", WorkshopId = 4, HomeAddress = "HA8",
                HomeTelephone = "08888", WorkTelephone = "08888", MaritalStatus = "married",
                PeopleInFamily = 2, ChildrenInFamily = 0, WorkerDepartments = new List<WorkersAndDepartments>(),
                WorkerJobs = new List<WorkersAndJobs>(), WorkerVacations = new List<WorkersAndVacations>()
            }
        };
        _workersAndDepartments = new List<WorkersAndDepartments>
        {
            new WorkersAndDepartments { Id = 1,  WorkerId = 1, Worker = _workers[0], DepartmentId = 1, Department = _departments[0] },
            new WorkersAndDepartments { Id = 2,  WorkerId = 1, Worker = _workers[0], DepartmentId = 2, Department = _departments[1] },
            new WorkersAndDepartments { Id = 3,  WorkerId = 2, Worker = _workers[1], DepartmentId = 3, Department = _departments[2] },
            new WorkersAndDepartments { Id = 4,  WorkerId = 2, Worker = _workers[1], DepartmentId = 4, Department = _departments[3] },
            new WorkersAndDepartments { Id = 5,  WorkerId = 3, Worker = _workers[2], DepartmentId = 1, Department = _departments[0] },
            new WorkersAndDepartments { Id = 6,  WorkerId = 3, Worker = _workers[2], DepartmentId = 2, Department = _departments[1] },
            new WorkersAndDepartments { Id = 7,  WorkerId = 4, Worker = _workers[3], DepartmentId = 3, Department = _departments[2] },
            new WorkersAndDepartments { Id = 8,  WorkerId = 4, Worker = _workers[3], DepartmentId = 4, Department = _departments[3] },
            new WorkersAndDepartments { Id = 9,  WorkerId = 5, Worker = _workers[4], DepartmentId = 1, Department = _departments[0] },
            new WorkersAndDepartments { Id = 10, WorkerId = 5, Worker = _workers[4], DepartmentId = 2, Department = _departments[1] },
            new WorkersAndDepartments { Id = 11, WorkerId = 5, Worker = _workers[4], DepartmentId = 3, Department = _departments[2] },
            new WorkersAndDepartments { Id = 12, WorkerId = 6, Worker = _workers[5], DepartmentId = 4, Department = _departments[3] },
            new WorkersAndDepartments { Id = 13, WorkerId = 7, Worker = _workers[6], DepartmentId = 4, Department = _departments[3] },
            new WorkersAndDepartments { Id = 14, WorkerId = 8, Worker = _workers[7], DepartmentId = 4, Department = _departments[3] }
        };
        _workersAndJobs = new List<WorkersAndJobs>
        {
            new WorkersAndJobs { Id = 1, HireDate = new DateTime(2001,01,01), WorkerId = 1, Worker = _workers[0], JobId = 1, Job = _jobs[0] },
            new WorkersAndJobs { Id = 2, HireDate = new DateTime(2002,02,02), WorkerId = 2, Worker = _workers[1], JobId = 1, Job = _jobs[0] },
            new WorkersAndJobs { Id = 3, HireDate = new DateTime(2003,03,03), WorkerId = 3, Worker = _workers[2], JobId = 1, Job = _jobs[0] },
            new WorkersAndJobs { Id = 4, HireDate = new DateTime(2004,04,04), DismissalDate = new DateTime(2009,09,09), WorkerId = 4, Worker = _workers[3], JobId = 1, Job = _jobs[0] },
            new WorkersAndJobs { Id = 5, HireDate = new DateTime(2005,05,05), WorkerId = 5, Worker = _workers[4], JobId = 2, Job = _jobs[1] },
            new WorkersAndJobs { Id = 6, HireDate = new DateTime(2006,06,06), WorkerId = 6, Worker = _workers[5], JobId = 2, Job = _jobs[1] },
            new WorkersAndJobs { Id = 7, HireDate = new DateTime(2007,07,07), WorkerId = 7, Worker = _workers[6], JobId = 3, Job = _jobs[2] },
            new WorkersAndJobs { Id = 8, HireDate = new DateTime(2008,08,08), WorkerId = 8, Worker = _workers[7], JobId = 3, Job = _jobs[2] }
        };
        _workersAndVacations = new List<WorkersAndVacations>
        {
            new WorkersAndVacations { Id = 1, WorkerId = 1, Worker = _workers[0], VacationId = 1, Vacation = _vacations[0] },
            new WorkersAndVacations { Id = 2, WorkerId = 2, Worker = _workers[1], VacationId = 2, Vacation = _vacations[1] },
            new WorkersAndVacations { Id = 3, WorkerId = 3, Worker = _workers[2], VacationId = 3, Vacation = _vacations[2] },
            new WorkersAndVacations { Id = 4, WorkerId = 7, Worker = _workers[6], VacationId = 4, Vacation = _vacations[3] },
            new WorkersAndVacations { Id = 5, WorkerId = 8, Worker = _workers[7], VacationId = 5, Vacation = _vacations[4] },
        };



        _workshops[0].Workers.Add(_workers[0], _workers[1]);
        _workshops[1].Workers.Add(_workers[2], _workers[3]);
        _workshops[2].Workers.Add(_workers[4], _workers[5]);
        _workshops[3].Workers.Add(_workers[6], _workers[7]);

        _departments[0].DepartmentWorkers.Add(_workersAndDepartments[0], _workersAndDepartments[4], _workersAndDepartments[8]);
        _departments[1].DepartmentWorkers.Add(_workersAndDepartments[1], _workersAndDepartments[5], _workersAndDepartments[9]);
        _departments[2].DepartmentWorkers.Add(_workersAndDepartments[2], _workersAndDepartments[6], _workersAndDepartments[10]);
        _departments[3].DepartmentWorkers.Add(_workersAndDepartments[3], _workersAndDepartments[7], _workersAndDepartments[11], _workersAndDepartments[12], _workersAndDepartments[13]);

        _jobs[0].JobWorkers.Add(_workersAndJobs[0], _workersAndJobs[1], _workersAndJobs[2], _workersAndJobs[3]);
        _jobs[1].JobWorkers.Add(_workersAndJobs[4], _workersAndJobs[5]);
        _jobs[2].JobWorkers.Add(_workersAndJobs[6], _workersAndJobs[7]);

        _vacations[0].VacationWorkers.Add(_workersAndVacations[0]);
        _vacations[1].VacationWorkers.Add(_workersAndVacations[1]);
        _vacations[2].VacationWorkers.Add(_workersAndVacations[2]);
        _vacations[3].VacationWorkers.Add(_workersAndVacations[3]);
        _vacations[4].VacationWorkers.Add(_workersAndVacations[4]);



        _workers[0].WorkerDepartments.Add(_workersAndDepartments[0], _workersAndDepartments[1]);
        _workers[1].WorkerDepartments.Add(_workersAndDepartments[2], _workersAndDepartments[3]);
        _workers[2].WorkerDepartments.Add(_workersAndDepartments[0], _workersAndDepartments[1]);
        _workers[3].WorkerDepartments.Add(_workersAndDepartments[2], _workersAndDepartments[3]);
        _workers[4].WorkerDepartments.Add(_workersAndDepartments[0], _workersAndDepartments[1], _workersAndDepartments[2]);
        _workers[5].WorkerDepartments.Add(_workersAndDepartments[3]);
        _workers[6].WorkerDepartments.Add(_workersAndDepartments[3]);
        _workers[7].WorkerDepartments.Add(_workersAndDepartments[3]);

        _workers[0].WorkerJobs.Add(_workersAndJobs[0]);
        _workers[1].WorkerJobs.Add(_workersAndJobs[1]);
        _workers[2].WorkerJobs.Add(_workersAndJobs[2]);
        _workers[3].WorkerJobs.Add(_workersAndJobs[3]);
        _workers[4].WorkerJobs.Add(_workersAndJobs[4]);
        _workers[5].WorkerJobs.Add(_workersAndJobs[5]);
        _workers[6].WorkerJobs.Add(_workersAndJobs[6]);
        _workers[7].WorkerJobs.Add(_workersAndJobs[7]);

        _workers[0].WorkerVacations.Add(_workersAndVacations[0]);
        _workers[1].WorkerVacations.Add(_workersAndVacations[1]);
        _workers[2].WorkerVacations.Add(_workersAndVacations[2]);
        _workers[6].WorkerVacations.Add(_workersAndVacations[3]);
        _workers[7].WorkerVacations.Add(_workersAndVacations[4]);
    }


    public List<Workshop> Workshops => _workshops;
    public List<VacationSpot> VacationSpots => _vacationSpots;
    public List<Department> Departments => _departments;
    public List<Job> Jobs => _jobs;
    public List<Vacation> Vacations => _vacations;
    public List<Worker> Workers => _workers;
    public List<WorkersAndDepartments> WorkersAndDepartments => _workersAndDepartments;
    public List<WorkersAndJobs> WorkersAndJobs => _workersAndJobs;
    public List<WorkersAndVacations> WorkersAndVacations => _workersAndVacations;
}
