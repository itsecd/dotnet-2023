namespace ApplicationsServer;

using ApplicationsServer.DTO;
using AutoMapper;
using RecruitmentAgency;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Company, CompanyGetDTO>();
        CreateMap<Company, CompanyPostDTO>();
        CreateMap<CompanyPostDTO, Company>();
    }
}
