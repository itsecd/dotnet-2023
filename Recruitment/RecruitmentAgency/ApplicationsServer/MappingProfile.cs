namespace ApplicationsServer;

using ApplicationsServer.DTO;
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
        CreateMap<Company, CompanyGetDTO>();
        CreateMap<Company, CompanyPostDTO>();
        CreateMap<CompanyPostDTO, Company>();

        CreateMap<Employee, EmployeeGetDTO>();
        CreateMap<Employee, EmployeePostDTO>();
        CreateMap<EmployeePostDTO, Employee>();

        CreateMap<JobApplication, JobApplicationGetDTO>();
        CreateMap<JobApplicationGetDTO, JobApplication>();

        CreateMap<CompanyApplication, CompanyApplicationGetDTO>();
        CreateMap<CompanyApplicationGetDTO, CompanyApplication>();

        CreateMap<Title, TitleGetDTO>();
        CreateMap<TitleGetDTO, Title>();
    }
}
