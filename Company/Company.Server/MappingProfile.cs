using AutoMapper;
using Company.Domain;
using Company.Server.Dto;

namespace Company.Server;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Department, DepartmentGetDto>();
        CreateMap<DepartmentPostDto, Department>();

        CreateMap<Job, JobGetDto>();
        CreateMap<JobPostDto, Job>();

        CreateMap<Vacation, VacationGetDto>();
        CreateMap<VacationPostDto, Vacation>();

        CreateMap<VacationSpot, VacationSpotGetDto>();
        CreateMap<VacationSpotPostDto, VacationSpot>();

        CreateMap<Worker, WorkerGetDto>();
        CreateMap<WorkerPostDto, Worker>();

        CreateMap<WorkersAndDepartments, WorkersAndDepartmentsGetDto>();
        CreateMap<WorkersAndDepartmentsPostDto, WorkersAndDepartments>();

        CreateMap<WorkersAndJobs, WorkersAndJobsGetDto>();
        CreateMap<WorkersAndJobsPostDto, WorkersAndJobs>();

        CreateMap<WorkersAndVacations, WorkersAndVacationsGetDto>();
        CreateMap<WorkersAndVacationsPostDto, WorkersAndVacations>();

        CreateMap<Workshop, WorkshopGetDto>();
        CreateMap<WorkshopPostDto, Workshop>();
    }
}