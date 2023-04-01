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

        CreateMap<BuildingAuctionConnection, BuildingAuctionConnectionForAuctionDto>().ReverseMap();
        CreateMap<BuildingAuctionConnection, BuildingAuctionConnectionForBuildingDto>().ReverseMap();

        CreateMap<Buyer, BuyerPostDto>().ReverseMap();
        CreateMap<BuyerAuctionConnection, BuyerAuctionConnectionForAuctionDto>().ReverseMap();
        CreateMap<BuyerAuctionConnection, BuyerAuctionConnectionForBuyerDto>().ReverseMap();
        
        CreateMap<District, DistrictPostDto>().ReverseMap();

        CreateMap<Organization, OrganizationPostDto>().ReverseMap();

        CreateMap<Privatized, PrivatizedPostDto>().ReverseMap();
    }
}
