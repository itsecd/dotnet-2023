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

        CreateMap<Employee, EmployeeGetDto>();
        CreateMap<Employee, EmployeePostDto>();
        CreateMap<EmployeePostDto, Employee>();

        CreateMap<JobApplication, JobApplicationGetDto>();
        CreateMap<JobApplication, JobApplicationPostDto>();
        CreateMap<JobApplicationPostDto, JobApplication>();

        CreateMap<CompanyApplication, CompanyApplicationGetDto>();
        CreateMap<CompanyApplicationPostDto, CompanyApplication>();
        CreateMap<CompanyApplicationGetDto, CompanyApplication>();

        CreateMap<Title, TitleGetDto>();
        CreateMap<TitleGetDto, Title>();
        CreateMap<TitlePostDto, Title>();
    }
}
