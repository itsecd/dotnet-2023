using Company.Domain;

namespace Company.Server.Repository;


public interface ICompanyRepository
{
    List<Department> Departments { get; }
    List<Job> Jobs { get; }
    List<Vacation> Vacations { get; }
    List<VacationSpot> VacationSpots { get; }
    List<Worker> Workers { get; }
    List<WorkersAndDepartments> WorkersAndDepartments { get; }
    List<WorkersAndJobs> WorkersAndJobs { get; }
    List<WorkersAndVacations> WorkersAndVacations { get; }
    List<Workshop> Workshops { get; }
}