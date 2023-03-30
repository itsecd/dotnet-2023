using AutoMapper;
using NonResidentialFund.Domain;
using NonResidentialFund.Server.Dto;

namespace NonResidentialFund.Server;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Auction, AuctionGetDto>();
        CreateMap<Auction, AuctionPostDto>().ReverseMap();

        CreateMap<Building, BuildingPostDto>().ReverseMap();

        CreateMap<Buyer, BuyerPostDto>().ReverseMap();

        CreateMap<District, DistrictPostDto>().ReverseMap();

        CreateMap<Organization, OrganizationPostDto>().ReverseMap();

        CreateMap<Privatized, PrivatizedPostDto>().ReverseMap();
    }
}
