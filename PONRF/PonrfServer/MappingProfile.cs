using AutoMapper;
using PonrfDomain;
using PonrfServer.Dto;

namespace PonrfServer;

/// <summary>
/// MappingProfile used for mapping Dto objects in Domain objects
/// </summary>
public class MappingProfile : Profile
{
    /// <summary>
    /// Constructor for MappingProfile 
    /// </summary>
    public MappingProfile()
    {
        CreateMap<Auction, AuctionGetDto>().ReverseMap();
        CreateMap<Auction, AuctionPostDto>().ReverseMap();

        CreateMap<Building, BuildingGetDto>().ReverseMap();
        CreateMap<Building, BuildingPostDto>().ReverseMap();

        CreateMap<Customer, CustomerGetDto>().ReverseMap();
        CreateMap<Customer, CustomerPostDto>().ReverseMap();

        CreateMap<PrivatizedBuilding, PrivatizedBuildingGetDto>().ReverseMap();
        CreateMap<PrivatizedBuilding, PrivatizedBuildingPostDto>().ReverseMap();
    }
}
