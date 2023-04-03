namespace ApplicationsServer;

using ApplicationsServer.Dto;
using AutoMapper;
using RecruitmentAgency;


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

        CreateMap<JobApplication, JobApplicationGetDto>()
             .ForMember(dest => dest.Employee, opt => opt.MapFrom(src => src.Employee.Id));

        CreateMap<JobApplicationGetDto, JobApplication>();
        CreateMap<JobApplication, JobApplicationGetDto>();

        CreateMap<CompanyApplication, CompanyApplicationGetDto>();

        CreateMap<CompanyApplicationGetDto, CompanyApplication>();

        CreateMap<Title, TitleGetDto>();
        CreateMap<TitleGetDto, Title>();
    }
}
