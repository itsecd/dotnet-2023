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


        CreateMap<Building, BuildingGetDto>();
        CreateMap<Building, BuildingPostDto>().ReverseMap();

        CreateMap<BuildingAuctionConnection, BuildingAuctionConnectionForAuctionDto>().ReverseMap();
        CreateMap<BuildingAuctionConnection, BuildingAuctionConnectionForBuildingDto>().ReverseMap();

        CreateMap<Buyer, BuyerAddressDto>();
        CreateMap<Buyer, BuyerGetDto>();
        CreateMap<Buyer, BuyerPostDto>().ReverseMap();



        CreateMap<BuyerAuctionConnection, BuyerAuctionConnectionForAuctionDto>().ReverseMap();
        CreateMap<BuyerAuctionConnection, BuyerAuctionConnectionForBuyerDto>().ReverseMap();


        CreateMap<District, DistrictGetDto>();
        CreateMap<District, DistrictPostDto>().ReverseMap();

        CreateMap<Organization, OrganizationGetDto>();
        CreateMap<Organization, OrganizationPostDto>().ReverseMap();

        CreateMap<Privatized, PrivatizedGetDto>();
        CreateMap<Privatized, PrivatizedPostDto>().ReverseMap();
    }
}
