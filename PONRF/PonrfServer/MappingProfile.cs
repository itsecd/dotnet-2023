using AutoMapper;
using PonrfDomain;
using PonrfServer.Dto;

namespace PonrfServer;

public class MappingProfile: Profile
{
    public MappingProfile()
    {
        CreateMap<Building, BuildingDto>().ReverseMap();
        CreateMap<Auction, AuctionDto>().ReverseMap();
        CreateMap<PrivatizedBuilding, PrivatizedBuildingDto>().ReverseMap();
    }
}
