using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace Company.Client;

public class ApiWrapper
{
    private readonly ApiClient _client;

    public ApiWrapper()
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();
        var serverUrl = configuration.GetSection("ServerUrl").Value;

        _client = new ApiClient(serverUrl, new HttpClient());
    }

    public Task<ICollection<DepartmentGetDto>> GetDepartmentsAsync()
    {
        return _client.DepartmentAllAsync();
    }
    public Task<DepartmentGetDto> AddDepartmentAsync(DepartmentPostDto department)
    {
        return _client.DepartmentPOSTAsync(department);
    }
    public Task UpdateDepartmentAsync(int id, DepartmentPostDto department)
    {
        return _client.DepartmentPUTAsync(id, department);
    }
    public Task DeleteDepartmentAsync(int id)
    {
        return _client.DepartmentDELETEAsync(id);
    }

    public Task<ICollection<JobGetDto>> GetJobsAsync()
    {
        return _client.JobAllAsync();
    }
    public Task<JobGetDto> AddJobAsync(JobPostDto job)
    {
        return _client.JobPOSTAsync(job);
    }
    public Task UpdateJobAsync(int id, JobPostDto job)
    {
        return _client.JobPUTAsync(id, job);
    }
    public Task DeleteJobAsync(int id)
    {
        return _client.JobDELETEAsync(id);
    }

    public Task<ICollection<VacationGetDto>> GetVacationsAsync()
    {
        return _client.VacationAllAsync();
    }
    public Task<VacationGetDto> AddVacationAsync(VacationPostDto vacation)
    {
        return _client.VacationPOSTAsync(vacation);
    }
    public Task UpdateVacationAsync(int id, VacationPostDto vacation)
    {
        return _client.VacationPUTAsync(id, vacation);
    }
    public Task DeleteVacationAsync(int id)
    {
        return _client.VacationDELETEAsync(id);
    }

    public Task<ICollection<VacationSpotGetDto>> GetVacationSpotsAsync()
    {
        return _client.VacationSpotAllAsync();
    }
    public Task<VacationSpotGetDto> AddVacationSpotAsync(VacationSpotPostDto vacationSpot)
    {
        return _client.VacationSpotPOSTAsync(vacationSpot);
    }
    public Task UpdateVacationSpotAsync(int id, VacationSpotPostDto vacationSpot)
    {
        return _client.VacationSpotPUTAsync(id, vacationSpot);
    }
    public Task DeleteVacationSpotAsync(int id)
    {
        return _client.VacationSpotDELETEAsync(id);
    }

    public Task<ICollection<WorkerGetDto>> GetWorkersAsync()
    {
        return _client.WorkerAllAsync();
    }
    public Task<WorkerGetDto> AddWorkerAsync(WorkerPostDto worker)
    {
        return _client.WorkerPOSTAsync(worker);
    }
    public Task UpdateWorkerAsync(int id, WorkerPostDto worker)
    {
        return _client.WorkerPUTAsync(id, worker);
    }
    public Task DeleteWorkerAsync(int id)
    {
        return _client.WorkerDELETEAsync(id);
    }

    public Task<ICollection<WorkersAndDepartmentsGetDto>> GetWorkersAndDepartmentsAsync()
    {
        return _client.WorkersAndDepartmentsAllAsync();
    }
    public Task<WorkersAndDepartmentsGetDto> AddWorkersAndDepartmentsAsync(WorkersAndDepartmentsPostDto workersAndDepartments)
    {
        return _client.WorkersAndDepartmentsPOSTAsync(workersAndDepartments);
    }
    public Task UpdateWorkersAndDepartmentsAsync(int id, WorkersAndDepartmentsPostDto workersAndDepartments)
    {
        return _client.WorkersAndDepartmentsPUTAsync(id, workersAndDepartments);
    }
    public Task DeleteWorkersAndDepartmentsAsync(int id)
    {
        return _client.WorkersAndDepartmentsDELETEAsync(id);
    }

    public Task<ICollection<WorkersAndJobsGetDto>> GetWorkersAndJobsAsync()
    {
        return _client.WorkersAndJobsAllAsync();
    }
    public Task<WorkersAndJobsGetDto> AddWorkersAndJobsAsync(WorkersAndJobsPostDto workersAndJobs)
    {
        return _client.WorkersAndJobsPOSTAsync(workersAndJobs);
    }
    public Task UpdateWorkersAndJobsAsync(int id, WorkersAndJobsPostDto workersAndJobs)
    {
        return _client.WorkersAndJobsPUTAsync(id, workersAndJobs);
    }
    public Task DeleteWorkersAndJobsAsync(int id)
    {
        return _client.WorkersAndJobsDELETEAsync(id);
    }

    public Task<ICollection<WorkersAndVacationsGetDto>> GetWorkersAndVacationsAsync()
    {
        return _client.WorkersAndVacationsAllAsync();
    }
    public Task<WorkersAndVacationsGetDto> AddWorkersAndVacationsAsync(WorkersAndVacationsPostDto workersAndVacations)
    {
        return _client.WorkersAndVacationsPOSTAsync(workersAndVacations);
    }
    public Task UpdateWorkersAndVacationsAsync(int id, WorkersAndVacationsPostDto workersAndVacations)
    {
        return _client.WorkersAndVacationsPUTAsync(id, workersAndVacations);
    }
    public Task DeleteWorkersAndVacationsAsync(int id)
    {
        return _client.WorkersAndVacationsDELETEAsync(id);
    }

    public Task<ICollection<WorkshopGetDto>> GetWorkshopsAsync()
    {
        return _client.WorkshopAllAsync();
    }
    public Task<WorkshopGetDto> AddWorkshopAsync(WorkshopPostDto workshop)
    {
        return _client.WorkshopPOSTAsync(workshop);
    }
    public Task UpdateWorkshopAsync(int id, WorkshopPostDto workshop)
    {
        return _client.WorkshopPUTAsync(id, workshop);
    }
    public Task DeleteWorkshopAsync(int id)
    {
        return _client.WorkshopDELETEAsync(id);
    }
}