namespace RealtorServer;
using AutoMapper;
using Realtor;
using RealtorServer.Dto;

public class MappingProfile:Profile
{
    public MappingProfile()
    {
        CreateMap<House,HouseGetDto>();
        CreateMap<House, HousePostDto>();
        CreateMap<Client, ClientGetDto>();
        CreateMap<Client, ClientPostDto>();
        CreateMap<Application, ApplicationGetDto>();
        CreateMap<Application, ApplicationPostDto>();
        CreateMap<ApplicationHasHouse, ApplicationHasHouseDto>();

        CreateMap<HouseGetDto, House>();
        CreateMap<HousePostDto, House>();
        CreateMap<ClientPostDto, Client>();
        CreateMap<ClientGetDto, Client>();
        CreateMap<ApplicationPostDto, Application>();
        CreateMap<ApplicationGetDto, Application>();
        CreateMap<ApplicationHasHouseDto, ApplicationHasHouse>();
    }
}
