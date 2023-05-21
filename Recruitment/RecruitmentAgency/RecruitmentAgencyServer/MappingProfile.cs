namespace RecruitmentAgencyServer;

using AutoMapper;
using RecruitmentAgency;
using RecruitmentAgencyServer.Dto;


/// <summary>
/// A class that allows you to quickly convert some types to other types
/// </summary>
public class MappingProfile : Profile
{
    /// <summary>
    /// Constructor
    /// </summary>
    public MappingProfile()
    {
        CreateMap<Company, CompanyGetDto>();
        CreateMap<Company, CompanyPostDto>();
        CreateMap<CompanyPostDto, Company>();
        CreateMap<CompanyPostDto, CompanyGetDto>();
        CreateMap<CompanyGetDto, CompanyPostDto>();

        CreateMap<Employee, EmployeeGetDto>();
        CreateMap<Employee, EmployeePostDto>();
        CreateMap<EmployeePostDto, Employee>();
        CreateMap<EmployeePostDto, EmployeeGetDto>();
        CreateMap<EmployeeGetDto, EmployeePostDto>();

        CreateMap<JobApplication, JobApplicationGetDto>();
        CreateMap<JobApplication, JobApplicationPostDto>();
        CreateMap<JobApplicationPostDto, JobApplication>();
        CreateMap<JobApplicationPostDto, JobApplicationGetDto>();
        CreateMap<JobApplicationGetDto, JobApplicationPostDto>();

        CreateMap<CompanyApplication, CompanyApplicationGetDto>();
        CreateMap<CompanyApplicationPostDto, CompanyApplication>();
        CreateMap<CompanyApplicationGetDto, CompanyApplication>();
        CreateMap<CompanyApplicationPostDto, CompanyApplicationGetDto>();
        CreateMap<CompanyApplicationGetDto, CompanyApplicationPostDto>();


        CreateMap<Title, TitleGetDto>();
        CreateMap<TitleGetDto, Title>();
        CreateMap<TitlePostDto, Title>();
        CreateMap<TitlePostDto, TitleGetDto>();
        CreateMap<TitleGetDto, TitlePostDto>();
    }
}
