using AutoMapper;
using NonResidentialFund.Domain;
using NonResidentialFund.Server.Dto;

namespace NonResidentialFund.Server;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Building, BuildingPostDto>();
        CreateMap<BuildingPostDto, Building>();

        CreateMap<Buyer, BuyerPostDto>();
        CreateMap<BuyerPostDto, Buyer>();

        CreateMap<District, DistrictPostDto>();
        CreateMap<DistrictPostDto, District>();

        CreateMap<Organization, OrganizationPostDto>();
        CreateMap<OrganizationPostDto, Organization>();
    }
}
